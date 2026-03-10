using System;
using System.Drawing;
using System.Windows.Forms;
using VM.Core;
using VM.PlatformSDKCS;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using ImageSourceModuleCs;
using System.Collections.Generic;
using IMVSMarkInspModuVACs;

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

        // --- 新增：用于存放手动导入的标准样本图 ---
        private Bitmap sampleOriginalBitmap = null;

        // 右键菜单管理
        private ContextMenuStrip thumbnailContextMenu;
        private PictureBox rightClickedPictureBox;

        public Form1()
        {
            // 启动前清理残留进程
            KillProcess("VisionMasterServerApp");
            KillProcess("VisionMaster");
            KillProcess("VmModuleProxy.exe");

            InitializeComponent();
            InitThumbnailContextMenu(); // 初始化右键菜单
            InitializeCustomUI();
            InitUptimeTimer();
        }

        private void InitializeCustomUI()
        {
            SwitchPage(pnlDashboard);
            UpdateStatsUI();
        }

        // --- 初始化缩略图右键菜单 ---
        private void InitThumbnailContextMenu()
        {
            thumbnailContextMenu = new ContextMenuStrip();
            var deleteItem = new ToolStripMenuItem("删除该图像");
            var clearItem = new ToolStripMenuItem("清空全部图像");

            deleteItem.Click += (s, e) => {
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

            clearItem.Click += (s, e) => {
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
        private void btnNavLogs_Click(object sender, EventArgs e) => SwitchPage(pnlLogs);

        private void SwitchPage(Panel targetPage)
        {
            pnlDashboard.Visible = false;
            pnlConfig.Visible = false;
            pnlLogs.Visible = false;

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

                    try
                    {
                        var defaultModule = (VMControls.Interface.IVmModule)VmSolution.Instance["流程1.字符缺陷检测1"];
                        if (defaultModule != null)
                        {
                            vmParamsConfigControl1.ModuleSource = defaultModule;
                            vmParamsConfigWithRenderControl1.ModuleSource = defaultModule;
                        }
                    }
                    catch { }
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
                    // 兼容带有 Label 的情况（判断控件类型）
                    foreach (Control innerCtrl in pnl.Controls)
                    {
                        if (innerCtrl is PictureBox currentPb)
                        {
                            if (currentPb == selectedPb)
                            {
                                pnl.BackColor = Color.DodgerBlue; // 蓝色高亮框
                            }
                            else
                            {
                                pnl.BackColor = Color.FromArgb(40, 40, 40); // 恢复默认暗色背景
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

            Task.Run(() => {
                try
                {
                    Image img = Image.FromFile(path);
                    this.Invoke((Action)(() => pb.Image = img));
                }
                catch { }
            });

            pb.MouseUp += (s, e) => {
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

                    Invoke((Action)(() => {
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
                        ExtractDefectImagesAndShow(process, defectCount); // 将流程及缺陷数传给提取函数
                    }
                    else
                    {
                        Invoke((Action)(() => {
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

        // --- 核心修改：基于导入的样本图进行同坐标对比切图 ---
        private void ExtractDefectImagesAndShow(VmProcedure process, int defectCount)
        {
            if (currentOriginalBitmap == null) return;

            Invoke((Action)(() => {
                flowLayoutPanelDefects.Controls.Clear();
                pbDefectDetail.Image = null;
                pbStandardDetail.Image = null; // 清空标准对比图

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

                        // 1. 获取缺陷在当前图上的绝对坐标和宽高
                        float cx = box.CenterPoint.X;
                        float cy = box.CenterPoint.Y;
                        float w = box.BoxWidth;
                        float h = box.BoxHeight;

                        // 2. 计算统一的截图框大小（放大4倍，保底 150 像素）
                        int cropWidth = Math.Max((int)(w * 4), 150);
                        int cropHeight = Math.Max((int)(h * 4), 150);

                        int cropX = (int)(cx - cropWidth / 2.0f);
                        int cropY = (int)(cy - cropHeight / 2.0f);

                        // 核心：这个 rect 是贯穿缺陷图和样本图的“通用切割刀”
                        Rectangle rect = new Rectangle(cropX, cropY, cropWidth, cropHeight);

                        int actualCropX = Math.Max(0, rect.X);
                        int actualCropY = Math.Max(0, rect.Y);

                        // 3. 在当前测试图上切下缺陷区域
                        Bitmap defectSnippet = CropImage(currentOriginalBitmap, rect);

                        // 4. 在我们手动导入的“样本图”上，用完全相同的坐标切下对应区域
                        Bitmap stdSnippet = null;
                        if (sampleOriginalBitmap != null)
                        {
                            stdSnippet = CropImage(sampleOriginalBitmap, rect);
                        }

                        // 5. 渲染 UI 并绑定点击事件
                        if (defectSnippet != null)
                        {
                            // 在缺陷局部图上画红框
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

                            // 点击缩略图时，同时更新 缺陷大图 和 样本大图
                            pbFlaw.Click += (s, e) => {
                                HighlightSelectedImage(flowLayoutPanelDefects, pbFlaw);
                                pbDefectDetail.Image = ((PictureBox)s).Image;

                                // 如果用户导入了样本图，这里就会展示出纯净的对比图
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

        // --- 图像安全裁剪通用方法 ---
        private Bitmap CropImage(Bitmap source, Rectangle rect)
        {
            if (source == null) return null;

            // 防止截取框越界到原图外面去，导致 GDI+ 报错
            rect.X = Math.Max(0, rect.X);
            rect.Y = Math.Max(0, rect.Y);
            rect.Width = Math.Min(rect.Width, source.Width - rect.X);
            rect.Height = Math.Min(rect.Height, source.Height - rect.Y);

            if (rect.Width <= 0 || rect.Height <= 0) return null;

            Bitmap target = new Bitmap(rect.Width, rect.Height);
            using (Graphics g = Graphics.FromImage(target))
            {
                // 以源图对应区域绘制到新 bitmap 上
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

        private void vmRenderControl1_Load_1(object sender, EventArgs e)
        {

        }
    }
}