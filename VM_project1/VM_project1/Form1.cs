using System;
using System.Drawing;
using System.Windows.Forms;
using VM.Core;
using VM.PlatformSDKCS;
using System.Diagnostics;
using System.Threading;
using VMControls.WPF.Release;
using VMControls.Winform.Release;
using System.Threading.Tasks;
using System.IO;
using ImageSourceModuleCs;
using System.Collections.Generic;
using IMVSMarkInspModuVACs;
// 确保引入了绘制需要的命名空间，如果不适用请根据你的SDK版本调整
using VMControls.Winform.Release;
using VMControls.RenderInterface;
using VMControls.Interface;

namespace VM_project1
{
    public partial class Form1 : Form
    {
        // 运行时间统计
        private System.Windows.Forms.Timer uptimeTimer;
        private DateTime startTime;
        private bool isContinuousRunning = false;
        private CancellationTokenSource cancellationTokenSource;

        // 数据统计
        private int totalOK = 0;
        private int totalNG = 0;

        // 图像管理
        private List<string> imageQueue = new List<string>();
        private int currentImageIndex = 0;
        private Bitmap currentOriginalBitmap; // 当前正在检测的原始大图

        // 用于存放手动导入的标准样本图
        private Bitmap sampleOriginalBitmap = null;

        // 右键菜单管理
        private ContextMenuStrip thumbnailContextMenu;
        private PictureBox rightClickedPictureBox;

        // --- 新增：建模配置 ROI绘制状态管理 ---
        private enum DrawMode { None, Detection, Locate }
        private DrawMode currentDrawMode = DrawMode.None;
        private string baseImagePath = "";

        // 🌟 核心变量：专门保存画完蓝框后裁剪出来的局部图路径 🌟
        private string croppedImagePath = "";

        // 用于存储当前绘制的图形对象
        private object detectionRoiShape = null;
        private ImageSourceModuleTool baseImageModu = null; // 大图的饭碗
        private ImageSourceModuleTool cropImageModu = null; // 🌟新增：小图的饭碗🌟
        private List<object> locateRoiShapes = new List<object>();

        // 声明新增的按钮
        private Button btnImportBaseImg;
        private Button btnDrawDetectionRoi;
        private Button btnDrawLocateRoi;

        public Form1()
        {
            // 启动前清理残留进程
            KillProcess("VisionMasterServerApp");
            KillProcess("VisionMaster");
            KillProcess("VmModuleProxy.exe");

            InitializeComponent();

            // 强制绑定 TabControl 的切换事件
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);

            InitThumbnailContextMenu(); // 初始化右键菜单
            InitializeCustomUI();
            InitModelConfigUI();        // 初始化建模配置页面的UI和事件
            InitUptimeTimer();
        }

        private void InitializeCustomUI()
        {
            SwitchPage(pnlDashboard);
            UpdateStatsUI();
        }

        // --- 初始化建模配置UI ---
        private void InitModelConfigUI()
        {
            // 1. 导入基准图像按钮 (添加到 groupBox3)
            btnImportBaseImg = new Button();
            btnImportBaseImg.Text = "导入图像";
            btnImportBaseImg.Size = new Size(100, 30);
            btnImportBaseImg.Location = new Point(20, 110);
            btnImportBaseImg.BackColor = Color.SteelBlue;
            btnImportBaseImg.ForeColor = Color.White;
            btnImportBaseImg.FlatStyle = FlatStyle.Flat;
            btnImportBaseImg.Click += BtnImportBaseImg_Click;
            groupBox3.Controls.Add(btnImportBaseImg);

            // 2. 绘制检测区域ROI按钮 (添加到 groupBox4)
            btnDrawDetectionRoi = new Button();
            btnDrawDetectionRoi.Text = "绘制ROI";
            btnDrawDetectionRoi.Size = new Size(100, 30);
            btnDrawDetectionRoi.Location = new Point(20, 100);
            btnDrawDetectionRoi.BackColor = Color.FromArgb(64, 64, 64);
            btnDrawDetectionRoi.ForeColor = Color.White;
            btnDrawDetectionRoi.FlatStyle = FlatStyle.Flat;
            btnDrawDetectionRoi.Click += BtnDrawDetectionRoi_Click;
            groupBox4.Controls.Add(btnDrawDetectionRoi);

            // 3. 绘制定位点框按钮 (添加到 groupBox5)
            btnDrawLocateRoi = new Button();
            btnDrawLocateRoi.Text = "绘制定位框";
            btnDrawLocateRoi.Size = new Size(100, 30);
            btnDrawLocateRoi.Location = new Point(20, 100);
            btnDrawLocateRoi.BackColor = Color.FromArgb(64, 64, 64);
            btnDrawLocateRoi.ForeColor = Color.White;
            btnDrawLocateRoi.FlatStyle = FlatStyle.Flat;
            btnDrawLocateRoi.Click += BtnDrawLocateRoi_Click;
            groupBox5.Controls.Add(btnDrawLocateRoi);

            // 绑定 VM 控件的自定义 ROI 绘制完成与删除事件
            vmRenderControl2.OnCustomRoiAddEvent += VmRenderControl2_OnCustomRoiAddEvent;
            vmRenderControl2.OnCustomRoiDeleteEvent += VmRenderControl2_OnCustomRoiDeleteEvent;
        }

        // --- 需求 1：通过动态模块导入基准图像 ---
        private void BtnImportBaseImg_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog { Filter = "图像文件|*.bmp;*.jpg;*.png;*.tif|所有文件|*.*", Title = "选择基准图像" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        baseImagePath = ofd.FileName;
                        if (VmSolution.Instance == null)
                        {
                            MessageBox.Show("请先在方案配置页加载全局方案 (VM SOL File)！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // 1. 如果之前有旧的模块，先销毁释放内存
                        if (baseImageModu != null)
                        {
                            vmRenderControl2.ModuleSource = null;
                            vmRenderControl2.ImageSource = null;
                            baseImageModu.Destroy();
                            baseImageModu = null;
                        }

                        // 2. 创建动态图像源模块
                        baseImageModu = VmSolution.Instance.CreateDynamicModule<ImageSourceModuleTool>();

                        // 3. 设置为本地图像模式，清理旧图并传入新路径
                        baseImageModu.ModuParams.ImageSourceType = ImageSourceParam.ImageSourceTypeEnum.LocalImage;
                        baseImageModu.ClearAllInputImage();
                        baseImageModu.AddInputImageByPath(ofd.FileName);

                        // 4. 执行模块，使图片加载到内存
                        baseImageModu.Run();

                        // 5. 核心修复：直接绑定 ModuleSource，让控件自动接管渲染
                        vmRenderControl2.ModuleSource = baseImageModu;

                        // 6. 还原视图比例（防止图片飞出可视区域）并强制刷新
                        vmRenderControl2.InitView();
                        vmRenderControl2.UpdateVMResultShow();

                        // 还原绘制状态
                        detectionRoiShape = null;
                        locateRoiShapes.Clear();
                        croppedImagePath = ""; // 清空旧的裁剪图缓存
                        currentDrawMode = DrawMode.None;

                        AddLog($"建模配置: 成功导入基准图像 - {Path.GetFileName(ofd.FileName)}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("图像导入失败：" + ex.Message + "\n请确认图片路径不包含特殊字符且文件未损坏。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void RedrawAllShapes()
        {
            // 1. 暴力清空画布
            vmRenderControl2.ClearDisplayView();

            // 2. 重新垫上纯净的底图
            if (baseImageModu != null)
            {
                vmRenderControl2.ModuleSource = baseImageModu;
            }

            // 3. 把保存的蓝色检测框加回渲染层
            if (detectionRoiShape != null)
            {
                vmRenderControl2.AddShape(detectionRoiShape);
            }

            // 4. 把保存的所有黄色定位框加回渲染层
            foreach (var shape in locateRoiShapes)
            {
                vmRenderControl2.AddShape(shape);
            }

            // 5. 强制立刻刷新显示
            vmRenderControl2.UpdateVMResultShow();
        }

        // --- 需求 2：绘制检测区域（蓝色） ---
        private void BtnDrawDetectionRoi_Click(object sender, EventArgs e)
        {
            if (vmRenderControl2.ImageSource == null && vmRenderControl2.ModuleSource == null)
            {
                MessageBox.Show("请先导入基准图像！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            currentDrawMode = DrawMode.Detection;
            btnDrawDetectionRoi.BackColor = Color.DodgerBlue;
            btnDrawLocateRoi.BackColor = Color.FromArgb(64, 64, 64);

            detectionRoiShape = null; // 因为是重新画检测区，所以清空旧的蓝框
            croppedImagePath = "";    // 同时清空旧图缓存

            RedrawAllShapes(); // 统一重绘（显示底图和剩下的黄框）

            vmRenderControl2.IsShowCustomROIMenu = true;
            vmRenderControl2.PrepareDrawRoi(CustomRoiType.Box);
            AddLog("请在图像上拖拽绘制【检测区域】(蓝色)。");
        }

        // --- 需求 3：绘制定位点框（黄色） ---
        private void BtnDrawLocateRoi_Click(object sender, EventArgs e)
        {
            if (vmRenderControl2.ImageSource == null && vmRenderControl2.ModuleSource == null)
            {
                MessageBox.Show("请先导入基准图像！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            currentDrawMode = DrawMode.Locate;
            btnDrawLocateRoi.BackColor = Color.DarkOrange;
            btnDrawDetectionRoi.BackColor = Color.FromArgb(64, 64, 64);

            RedrawAllShapes(); // 统一重绘（确保之前的蓝框和黄框都在图上）

            vmRenderControl2.IsShowCustomROIMenu = true;
            vmRenderControl2.PrepareDrawRoi(CustomRoiType.Box);
            AddLog("请在图像上拖拽绘制【定位框】(黄色)。可绘制多个。");
        }

        // --- 全局拦截按键，实现 Delete 键删除所有框 ---
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Delete)
            {
                if (pnlModelConfig.Visible && (detectionRoiShape != null || locateRoiShapes.Count > 0))
                {
                    detectionRoiShape = null;
                    locateRoiShapes.Clear();
                    croppedImagePath = ""; // 删除框时，同步销毁已有的裁剪缓存

                    vmRenderControl2.ClearDisplayView();

                    if (baseImageModu != null)
                    {
                        vmRenderControl2.ModuleSource = baseImageModu;
                    }

                    vmRenderControl2.UpdateVMResultShow();
                    AddLog("已按下 Delete 键，清空图像上的所有检测区域和定位框。");
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        // --- 自定义 ROI 绘制完成回调 ---
        private void VmRenderControl2_OnCustomRoiAddEvent(object sender, VMControls.RenderInterface.CustomRoiEventArgs e)
        {
            dynamic dynamicRoi = e.Roi;
            int imgW = e.ImageWidth;
            int imgH = e.ImageHeight;

            try
            {
                // 1. 换算真实坐标
                double cx = dynamicRoi.CenterPoint.X * imgW;
                double cy = dynamicRoi.CenterPoint.Y * imgH;
                double w = 0, h = 0;
                try { w = dynamicRoi.Width * imgW; h = dynamicRoi.Height * imgH; }
                catch { w = dynamicRoi.BoxWidth * imgW; h = dynamicRoi.BoxHeight * imgH; }

                System.Windows.Point centerPoint = new System.Windows.Point(cx, cy);

                // 2. 构造彩色持久化框
                string colorHex = (currentDrawMode == DrawMode.Detection) ? "#0000FF" : "#FFFF00";
                VMControls.WPF.RectangleEx staticRect = new VMControls.WPF.RectangleEx(centerPoint, w, h, stroke: colorHex, strokeThickness: 2);

                // 3. 存入我们的变量列表
                if (currentDrawMode == DrawMode.Detection)
                {
                    detectionRoiShape = staticRect;
                    AddLog("检测区域绘制完成。");

                    // 🌟 核心：画完蓝框的瞬间，立马在后台触发切图 🌟
                    CropAndSaveDetectionRegion(staticRect);
                }
                else if (currentDrawMode == DrawMode.Locate)
                {
                    locateRoiShapes.Add(staticRect);
                    AddLog($"定位点框绘制完成，当前总数: {locateRoiShapes.Count}。");
                }
            }
            catch (Exception ex)
            {
                AddLog($"生成彩色框失败: {ex.Message}");
            }

            // 4. 恢复 UI 状态
            vmRenderControl2.IsShowCustomROIMenu = false;
            currentDrawMode = DrawMode.None;
            if (btnDrawDetectionRoi.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    btnDrawDetectionRoi.BackColor = Color.FromArgb(64, 64, 64);
                    btnDrawLocateRoi.BackColor = Color.FromArgb(64, 64, 64);
                }));
            }
            else
            {
                btnDrawDetectionRoi.BackColor = Color.FromArgb(64, 64, 64);
                btnDrawLocateRoi.BackColor = Color.FromArgb(64, 64, 64);
            }

            // 5. 统一重绘
            RedrawAllShapes();
        }

        private void VmRenderControl2_OnCustomRoiDeleteEvent(object sender, VMControls.RenderInterface.CustomRoiEventArgs e)
        {
            IROI deletedRoi = e.Roi;

            if (detectionRoiShape != null && detectionRoiShape.Equals(deletedRoi))
            {
                detectionRoiShape = null;
                croppedImagePath = ""; // 同步清理缓存
                AddLog("检测区域 ROI 已被删除。");
            }
            else if (locateRoiShapes.Contains(deletedRoi))
            {
                locateRoiShapes.Remove(deletedRoi);
                AddLog($"定位点框已删除，当前剩余数量: {locateRoiShapes.Count}。");
            }
        }

        // --- 修改：在后台静默裁剪，并直接加载到专门的动态模块中 ---
        private void CropAndSaveDetectionRegion(VMControls.WPF.RectangleEx rectEx)
        {
            if (string.IsNullOrEmpty(baseImagePath) || !File.Exists(baseImagePath)) return;

            try
            {
                using (Bitmap baseBmp = new Bitmap(baseImagePath))
                {
                    int cropX = Math.Max(0, (int)(rectEx.CenterPoint.X - rectEx.Width / 2));
                    int cropY = Math.Max(0, (int)(rectEx.CenterPoint.Y - rectEx.Height / 2));
                    int cropW = Math.Min(baseBmp.Width - cropX, (int)rectEx.Width);
                    int cropH = Math.Min(baseBmp.Height - cropY, (int)rectEx.Height);

                    if (cropW <= 0 || cropH <= 0) return;

                    Rectangle cropRect = new Rectangle(cropX, cropY, cropW, cropH);
                    Bitmap croppedBmp = CropImage(baseBmp, cropRect);

                    if (croppedBmp != null)
                    {
                        croppedImagePath = Path.Combine(Path.GetTempPath(), "vm_cropped_base.bmp");
                        croppedBmp.Save(croppedImagePath, System.Drawing.Imaging.ImageFormat.Bmp);
                        croppedBmp.Dispose();

                        // 🌟 核心修改：切完图立刻装进“小图饭碗” (cropImageModu) 🌟
                        if (cropImageModu != null)
                        {
                            cropImageModu.Destroy(); // 清理旧的
                            cropImageModu = null;
                        }

                        cropImageModu = VmSolution.Instance.CreateDynamicModule<ImageSourceModuleTool>();
                        cropImageModu.ModuParams.ImageSourceType = ImageSourceParam.ImageSourceTypeEnum.LocalImage;
                        cropImageModu.ClearAllInputImage();
                        cropImageModu.AddInputImageByPath(croppedImagePath);
                        cropImageModu.Run(); // 运行，让小图进入 VM 内存

                        AddLog("后台处理：蓝框区域已裁剪，并已装载到缓存模块。");
                    }
                }
            }
            catch (Exception ex)
            {
                AddLog($"后台切图失败: {ex.Message}");
            }
        }

        // 🌟 极简切页逻辑 🌟
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddLog($"检测到页面切换，当前切到了第 {tabControl1.SelectedIndex + 1} 页");

            if (tabControl1.SelectedIndex == 1) // 切到第 2 页：检测配置
            {
                AddLog("切换到第 2 页：尝试加载裁剪图...");
                LoadCroppedImageOnly();
            }
            else if (tabControl1.SelectedIndex == 0) // 切回第 1 页：裁切定位
            {
                AddLog("切换到第 1 页：恢复全局底图和框...");
                RedrawAllShapes();
            }
        }

        // --- 核心修改：用最直接的方法换图 ---
        private void LoadCroppedImageOnly()
        {
            // 只要小图模块存在，直接把控件的数据源切给它
            if (cropImageModu != null)
            {
                vmRenderControl2.ClearDisplayView();     // 擦除原图的框
                vmRenderControl2.ModuleSource = cropImageModu; // 🌟 核心：输入改为剪切后的图像模块
                vmRenderControl2.InitView();             // 还原比例
                vmRenderControl2.UpdateVMResultShow();   // 强制显示
                AddLog("成功切换并显示裁剪小图！");
            }
            else
            {
                AddLog("拦截：没有裁剪数据，请先画蓝框！");
            }
        }

        // --- 其他原有的业务功能代码保持不变 ---

        private void InitThumbnailContextMenu()
        {
            thumbnailContextMenu = new ContextMenuStrip();
            var deleteItem = new ToolStripMenuItem("删除该图像");
            var clearItem = new ToolStripMenuItem("清空全部图像");

            deleteItem.Click += (s, e) =>
            {
                if (rightClickedPictureBox != null)
                {
                    string path = (string)rightClickedPictureBox.Tag;
                    imageQueue.Remove(path);

                    Control parentPanel = rightClickedPictureBox.Parent;
                    if (parentPanel != null && parentPanel is Panel)
                    {
                        flowLayoutPanelThumbnails.Controls.Remove(parentPanel);
                        parentPanel.Dispose();
                    }

                    AddLog($"已移除图像: {Path.GetFileName(path)}");
                    if (currentImageIndex >= imageQueue.Count) currentImageIndex = 0;
                }
            };

            clearItem.Click += (s, e) =>
            {
                imageQueue.Clear();
                foreach (Control ctrl in flowLayoutPanelThumbnails.Controls)
                {
                    ctrl.Dispose();
                }
                flowLayoutPanelThumbnails.Controls.Clear();
                currentImageIndex = 0;
                AddLog("已清空图像队列");
            };

            thumbnailContextMenu.Items.Add(deleteItem);
            thumbnailContextMenu.Items.Add(new ToolStripSeparator());
            thumbnailContextMenu.Items.Add(clearItem);
        }

        private void InitUptimeTimer()
        {
            uptimeTimer = new System.Windows.Forms.Timer();
            uptimeTimer.Interval = 1000;
            uptimeTimer.Tick += UptimeTimer_Tick;
            startTime = DateTime.Now;
            uptimeTimer.Start();
        }

        private void UptimeTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = DateTime.Now - startTime;
            lblUptime.Text = $"运行: {ts.Days}天 {ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}";
        }

        // --- 导航按钮功能 ---
        private void btnNavDashboard_Click(object sender, EventArgs e) => SwitchPage(pnlDashboard);
        private void btnNavConfig_Click(object sender, EventArgs e) => SwitchPage(pnlConfig);
        private void btnNavModelConfig_Click(object sender, EventArgs e) => SwitchPage(pnlModelConfig);
        private void btnNavLogs_Click(object sender, EventArgs e) => SwitchPage(pnlLogs);

        private void SwitchPage(Panel targetPage)
        {
            pnlDashboard.Visible = false;
            pnlConfig.Visible = false;
            pnlLogs.Visible = false;
            pnlModelConfig.Visible = false;

            targetPage.Visible = true;
            targetPage.BringToFront();
        }

        private void UpdateStatsUI()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(UpdateStatsUI));
                return;
            }

            int total = totalOK + totalNG;
            double yieldRate = total == 0 ? 0 : (double)totalOK / total * 100;

            lblTotal.Text = $"总计: {total}";
            lblOK.Text = $"OK: {totalOK}";
            lblNG.Text = $"NG: {totalNG}";
            lblYield.Text = $"良率: {yieldRate:F2}%";
        }

        private void KillProcess(string processName)
        {
            if (string.IsNullOrEmpty(processName)) return;
            processName = processName.Replace(".exe", "");
            Process[] processes = Process.GetProcessesByName(processName);
            foreach (Process process in processes)
            {
                try { if (!process.HasExited) { process.Kill(); process.WaitForExit(3000); } }
                catch { }
            }
        }

        // --- 方案配置功能 ---
        private void Select_path_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "VM SOL File|*.sol", Title = "选择VM方案文件" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = ofd.FileName;
                    AddLog("选择路径成功：" + ofd.FileName);
                }
            }
        }

        private void Scheme_load_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text)) { MessageBox.Show("请选择路径"); return; }

                VmSolution.Load(textBox1.Text);
                AddLog("加载方案成功：" + textBox1.Text);

                VmProcedure vmProcess1 = (VmProcedure)VmSolution.Instance["流程1"];
                if (vmProcess1 != null)
                {
                    try
                    {
                        var renderModule = (VMControls.Interface.IVmModule)VmSolution.Instance["流程1.字符缺陷检测1"];
                        vmRenderControl1.ModuleSource = renderModule != null ? renderModule : vmProcess1;
                    }
                    catch
                    {
                        vmRenderControl1.ModuleSource = vmProcess1;
                    }
                }
            }
            catch (Exception ex) { AddLog("加载方案失败：" + ex.Message); }
        }

        private void Scheme_save_Click(object sender, EventArgs e)
        {
            if (VmSolution.Instance == null) return;
            VmSolution.Save();
            AddLog("保存方案成功");
        }

        // --- 高亮选中的图片（包裹蓝框） ---
        private void HighlightSelectedImage(FlowLayoutPanel panel, PictureBox selectedPb)
        {
            foreach (Control ctrl in panel.Controls)
            {
                if (ctrl is Panel pnl && pnl.Controls.Count > 0 && pnl.Controls[0] is PictureBox pb)
                {
                    foreach (Control innerCtrl in pnl.Controls)
                    {
                        if (innerCtrl is PictureBox currentPb)
                        {
                            if (currentPb == selectedPb)
                            {
                                pnl.BackColor = Color.DodgerBlue;
                            }
                            else
                            {
                                pnl.BackColor = Color.FromArgb(40, 40, 40);
                            }
                        }
                    }
                }
            }
        }

        // --- 导入标准样本图功能 ---
        private void btnImportSample_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "选择无缺陷的样本图 (标准对照图)";
                ofd.Filter = "图像文件|*.jpg;*.jpeg;*.png;*.bmp;*.tif|所有文件|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (sampleOriginalBitmap != null)
                        {
                            sampleOriginalBitmap.Dispose();
                        }

                        sampleOriginalBitmap = new Bitmap(ofd.FileName);
                        AddLog($"成功导入样本图: {Path.GetFileName(ofd.FileName)}");

                        MessageBox.Show("样本图导入成功！后续检测将使用此图对应的区域作为无缺陷对比图。", "导入成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        AddLog($"导入样本图失败: {ex.Message}");
                        MessageBox.Show("图片加载失败，请检查文件是否损坏。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // --- 左下角图片列表管理功能 ---
        private void BtnSelectImages_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "选择要检测的图片";
                ofd.Filter = "图像文件|*.jpg;*.jpeg;*.png;*.bmp;*.tif|所有文件|*.*";
                ofd.Multiselect = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    int addedCount = 0;
                    bool isFirstAdd = (imageQueue.Count == 0);

                    foreach (string file in ofd.FileNames)
                    {
                        if (!imageQueue.Contains(file))
                        {
                            imageQueue.Add(file);
                            AddThumbnail(file);
                            addedCount++;
                        }
                    }

                    if (addedCount > 0)
                    {
                        AddLog($"已追加 {addedCount} 张图片到测试队列");
                        if (isFirstAdd && flowLayoutPanelThumbnails.Controls.Count > 0)
                        {
                            Panel pnl = flowLayoutPanelThumbnails.Controls[0] as Panel;
                            if (pnl != null && pnl.Controls.Count > 0 && pnl.Controls[0] is PictureBox pb)
                            {
                                HighlightSelectedImage(flowLayoutPanelThumbnails, pb);
                                currentImageIndex = 0;
                                SetVMImagePath(imageQueue[0]);
                            }
                        }
                    }
                }
            }
        }

        private void AddThumbnail(string path)
        {
            Panel pnlWrapper = new Panel();
            pnlWrapper.Size = new Size(124, 84);
            pnlWrapper.Padding = new Padding(2);
            pnlWrapper.BackColor = Color.FromArgb(40, 40, 40);
            pnlWrapper.Margin = new Padding(5);

            PictureBox pb = new PictureBox();
            pb.Dock = DockStyle.Fill;
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.Cursor = Cursors.Hand;
            pb.Tag = path;

            Task.Run(() =>
            {
                try
                {
                    Image img = Image.FromFile(path);
                    this.Invoke((Action)(() => pb.Image = img));
                }
                catch { }
            });

            pb.MouseUp += (s, e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    rightClickedPictureBox = (PictureBox)s;
                    thumbnailContextMenu.Show(pb, e.Location);
                }
                else if (e.Button == MouseButtons.Left)
                {
                    string imgPath = (string)((PictureBox)s).Tag;
                    currentImageIndex = imageQueue.IndexOf(imgPath);
                    HighlightSelectedImage(flowLayoutPanelThumbnails, pb);
                    SetVMImagePath(imgPath);
                }
            };

            pnlWrapper.Controls.Add(pb);
            flowLayoutPanelThumbnails.Controls.Add(pnlWrapper);
        }

        private void SetVMImagePath(string path)
        {
            try
            {
                if (currentOriginalBitmap != null)
                {
                    currentOriginalBitmap.Dispose();
                }
                currentOriginalBitmap = new Bitmap(path);

                ImageSourceModuleTool imgTool = VmSolution.Instance["流程1.图像源1"] as ImageSourceModuleTool;
                if (imgTool != null)
                {
                    imgTool.ModuParams.ImageSourceType = ImageSourceParam.ImageSourceTypeEnum.LocalImage;
                    imgTool.ClearAllInputImage();
                    imgTool.AddInputImageByPath(path);
                }
            }
            catch (Exception ex)
            {
                Invoke((Action)(() => AddLog("设置图像源异常: " + ex.Message)));
            }
        }

        // --- 核心执行及结果提取功能 ---
        private void Scheme_run_Click(object sender, EventArgs e)
        {
            if (imageQueue.Count == 0) { MessageBox.Show("图像队列为空，请先添加图像！"); return; }
            if (currentImageIndex < 0 || currentImageIndex >= imageQueue.Count) currentImageIndex = 0;

            string currentImgPath = imageQueue[currentImageIndex];
            ExecuteDetection(currentImgPath);
        }

        private async void btnContinuousRun_Click(object sender, EventArgs e)
        {
            if (VmSolution.Instance == null) { MessageBox.Show("请先加载方案！"); return; }
            if (imageQueue.Count == 0) { MessageBox.Show("图像队列为空，请先添加图像！"); return; }

            isContinuousRunning = true;
            cancellationTokenSource = new CancellationTokenSource();
            AddLog(">>> 开始连续运行 <<<");

            await Task.Run(async () =>
            {
                while (isContinuousRunning && !cancellationTokenSource.IsCancellationRequested)
                {
                    string currentImgPath = imageQueue[currentImageIndex];

                    Invoke((Action)(() =>
                    {
                        if (flowLayoutPanelThumbnails.Controls.Count > currentImageIndex)
                        {
                            var pnl = flowLayoutPanelThumbnails.Controls[currentImageIndex] as Panel;
                            if (pnl != null && pnl.Controls.Count > 0 && pnl.Controls[0] is PictureBox pb)
                            {
                                HighlightSelectedImage(flowLayoutPanelThumbnails, pb);
                            }
                        }
                    }));

                    ExecuteDetection(currentImgPath);

                    currentImageIndex++;
                    if (currentImageIndex >= imageQueue.Count) currentImageIndex = 0;

                    await Task.Delay(500);
                }
            }, cancellationTokenSource.Token);
        }

        private void btnStopRun_Click(object sender, EventArgs e)
        {
            isContinuousRunning = false;
            cancellationTokenSource?.Cancel();
            AddLog(">>> 已停止连续运行 <<<");
        }

        private void ExecuteDetection(string imgPath)
        {
            try
            {
                if (VmSolution.Instance == null) { Invoke((Action)(() => AddLog("错误：未加载方案"))); return; }

                // 执行检测前，把控件重新绑定回检测模块，这样才能看到检测红框
                try
                {
                    var renderModule = (VMControls.Interface.IVmModule)VmSolution.Instance["流程1.字符缺陷检测1"];
                    vmRenderControl1.ModuleSource = renderModule != null ? renderModule : (VmProcedure)VmSolution.Instance["流程1"];
                }
                catch { }

                SetVMImagePath(imgPath);
                VmSolution.Instance.SyncRun();

                VmProcedure vmProcess1 = null;
                try { vmProcess1 = (VmProcedure)VmSolution.Instance["流程1"]; }
                catch { return; }

                ExtractDefectResult(vmProcess1);
            }
            catch (Exception ex) { Invoke((Action)(() => AddLog("执行异常：" + ex.Message))); }
        }

        private void ExtractDefectResult(VmProcedure process)
        {
            try
            {
                bool isNg = false;
                int defectCount = 0;

                if (process.ModuResult != null)
                {
                    var intOutputDefect = process.ModuResult.GetOutputInt("out");
                    if (intOutputDefect.pIntVal != null && intOutputDefect.pIntVal.Length > 0)
                    {
                        defectCount = intOutputDefect.pIntVal[0];
                    }
                    isNg = defectCount > 0;
                    Invoke((Action)(() => AddLog($"检测结果: {(isNg ? "NG" : "OK")} (缺陷数: {defectCount})")));

                    if (isNg)
                    {
                        ExtractDefectImagesAndShow(process, defectCount);
                    }
                    else
                    {
                        Invoke((Action)(() =>
                        {
                            flowLayoutPanelDefects.Controls.Clear();
                            pbDefectDetail.Image = null;
                            pbStandardDetail.Image = null;
                        }));
                    }
                }

                if (isNg) totalNG++; else totalOK++;
                UpdateStatsUI();
            }
            catch (Exception ex)
            {
                Invoke((Action)(() => AddLog($"获取缺陷异常: {ex.Message}")));
            }
        }

        private void ExtractDefectImagesAndShow(VmProcedure process, int defectCount)
        {
            if (currentOriginalBitmap == null) return;

            Invoke((Action)(() =>
            {
                flowLayoutPanelDefects.Controls.Clear();
                pbDefectDetail.Image = null;
                pbStandardDetail.Image = null;

                try
                {
                    var defectTool = VmSolution.Instance["流程1.字符缺陷检测1"] as IMVSMarkInspModuVATool;
                    if (defectTool == null || defectTool.ModuResult == null) return;

                    var flawBoxes = defectTool.ModuResult.FlawBox;
                    int count = defectTool.ModuResult.FlawNum;

                    if (flawBoxes == null || count == 0) return;
                    count = Math.Min(count, flawBoxes.Count);

                    for (int i = 0; i < count; i++)
                    {
                        var box = flawBoxes[i];

                        float cx = box.CenterPoint.X;
                        float cy = box.CenterPoint.Y;
                        float w = box.BoxWidth;
                        float h = box.BoxHeight;

                        int cropWidth = Math.Max((int)(w * 4), 150);
                        int cropHeight = Math.Max((int)(h * 4), 150);

                        int cropX = (int)(cx - cropWidth / 2.0f);
                        int cropY = (int)(cy - cropHeight / 2.0f);

                        Rectangle rect = new Rectangle(cropX, cropY, cropWidth, cropHeight);

                        int actualCropX = Math.Max(0, rect.X);
                        int actualCropY = Math.Max(0, rect.Y);

                        Bitmap defectSnippet = CropImage(currentOriginalBitmap, rect);

                        Bitmap stdSnippet = null;
                        if (sampleOriginalBitmap != null)
                        {
                            stdSnippet = CropImage(sampleOriginalBitmap, rect);
                        }

                        if (defectSnippet != null)
                        {
                            using (Graphics g = Graphics.FromImage(defectSnippet))
                            {
                                float relativeX = (cx - w / 2.0f) - actualCropX;
                                float relativeY = (cy - h / 2.0f) - actualCropY;
                                using (Pen redPen = new Pen(Color.Red, 2))
                                {
                                    g.DrawRectangle(redPen, relativeX, relativeY, w, h);
                                }
                            }

                            Panel pnlWrapper = new Panel();
                            pnlWrapper.Size = new Size(104, 130);
                            pnlWrapper.Padding = new Padding(2);
                            pnlWrapper.BackColor = Color.FromArgb(40, 40, 40);
                            pnlWrapper.Margin = new Padding(5);

                            Label lblIndex = new Label();
                            lblIndex.Text = $"{i + 1}/{count}";
                            lblIndex.ForeColor = Color.White;
                            lblIndex.Dock = DockStyle.Bottom;
                            lblIndex.Height = 20;
                            lblIndex.TextAlign = ContentAlignment.MiddleCenter;

                            PictureBox pbFlaw = new PictureBox();
                            pbFlaw.Dock = DockStyle.Fill;
                            pbFlaw.SizeMode = PictureBoxSizeMode.Zoom;
                            pbFlaw.Image = defectSnippet;
                            pbFlaw.Cursor = Cursors.Hand;

                            pbFlaw.Click += (s, e) =>
                            {
                                HighlightSelectedImage(flowLayoutPanelDefects, pbFlaw);
                                pbDefectDetail.Image = ((PictureBox)s).Image;

                                if (stdSnippet != null)
                                {
                                    pbStandardDetail.Image = stdSnippet;
                                }
                                else
                                {
                                    pbStandardDetail.Image = null;
                                }
                            };

                            pnlWrapper.Controls.Add(lblIndex);
                            pnlWrapper.Controls.Add(pbFlaw);
                            flowLayoutPanelDefects.Controls.Add(pnlWrapper);
                        }
                    }
                    AddLog($"成功提取了 {count} 个缺陷切图并关联了样本对照图");
                }
                catch (Exception ex)
                {
                    AddLog($"切图提取异常: {ex.Message}");
                }
            }));
        }

        private Bitmap CropImage(Bitmap source, Rectangle rect)
        {
            if (source == null) return null;

            rect.X = Math.Max(0, rect.X);
            rect.Y = Math.Max(0, rect.Y);
            rect.Width = Math.Min(rect.Width, source.Width - rect.X);
            rect.Height = Math.Min(rect.Height, source.Height - rect.Y);

            if (rect.Width <= 0 || rect.Height <= 0) return null;

            Bitmap target = new Bitmap(rect.Width, rect.Height);
            using (Graphics g = Graphics.FromImage(target))
            {
                g.DrawImage(source, new Rectangle(0, 0, target.Width, target.Height), rect, GraphicsUnit.Pixel);
            }
            return target;
        }

        private void AddLog(string message)
        {
            if (listBox1.InvokeRequired)
            {
                listBox1.Invoke(new Action<string>(AddLog), message);
                return;
            }
            listBox1.Items.Add($"[{DateTime.Now:HH:mm:ss}] {message}");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }

        private void btnClearStats_Click(object sender, EventArgs e)
        {
            totalOK = 0;
            totalNG = 0;
            UpdateStatsUI();
            AddLog("统计数据已重置");
        }

        private void vmRenderControl1_Load_1(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}