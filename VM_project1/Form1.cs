using System;
using System.Drawing;
using System.Windows.Forms;
using VM.Core;
using VM.PlatformSDKCS;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using ImageSourceModuleCs;


// 修改
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

        // 图像输入管理
        private Panel pnlImageInput;
        private ListBox lbImageList;
        private Button btnSelectImages;
        private int currentImageIndex = 0;

        public Form1()
        {
            KillProcess("VisionMasterServerApp");
            KillProcess("VisionMaster");
            KillProcess("VmModuleProxy.exe");

            InitializeComponent();
            InitializeCustomUI();
            InitUptimeTimer();
        }

        private void InitializeCustomUI()
        {
            AddImageInputUI(); // 动态生成底部图片输入面板

            SwitchPage(pnlDashboard);

            // 初始化饼状图
            chartResults.Series.Clear();
            Series series = new Series("Result");
            series.ChartType = SeriesChartType.Pie;
            series.IsValueShownAsLabel = true;
            series.LabelForeColor = Color.White;
            series.Font = new Font("微软雅黑", 12f, FontStyle.Bold);
            chartResults.Series.Add(series);

            UpdateChart();
        }

        // --- 动态生成底部图片输入面板 ---
        private void AddImageInputUI()
        {
            pnlImageInput = new Panel();
            pnlImageInput.Dock = DockStyle.Bottom;
            pnlImageInput.Height = 130;
            pnlImageInput.Padding = new Padding(0, 5, 0, 0);

            GroupBox gbImageInput = new GroupBox();
            gbImageInput.Text = "本地图像输入队列";
            gbImageInput.Dock = DockStyle.Fill;
            gbImageInput.Font = new Font("微软雅黑", 10.2f);
            pnlImageInput.Controls.Add(gbImageInput);

            btnSelectImages = new Button();
            btnSelectImages.Text = "📁 选择图片\n(支持多选)";
            btnSelectImages.Location = new Point(20, 35);
            btnSelectImages.Size = new Size(130, 60);
            btnSelectImages.BackColor = Color.LightSeaGreen;
            btnSelectImages.ForeColor = Color.White;
            btnSelectImages.FlatStyle = FlatStyle.Flat;
            btnSelectImages.Click += BtnSelectImages_Click;
            gbImageInput.Controls.Add(btnSelectImages);

            lbImageList = new ListBox();
            lbImageList.Location = new Point(170, 35);
            lbImageList.Size = new Size(570, 70);
            lbImageList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbImageInput.Controls.Add(lbImageList);

            // 挂载到面板，调整层级确保排版不乱
            this.pnlDashboard.Controls.Add(pnlImageInput);
            this.pnlDashRight.BringToFront();
            this.pnlImageInput.BringToFront();
        }

        // --- 文件选择逻辑 ---
        private void BtnSelectImages_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "选择要检测的图片";
                ofd.Filter = "图像文件|*.jpg;*.jpeg;*.png;*.bmp;*.tif|所有文件|*.*";
                ofd.Multiselect = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    lbImageList.Items.Clear();
                    foreach (string file in ofd.FileNames)
                    {
                        lbImageList.Items.Add(file);
                    }
                    currentImageIndex = 0;
                    AddLog($"已加载 {ofd.FileNames.Length} 张图片到测试队列");
                }
            }
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
            lblUptime.Text = $"已持续运行: {ts.Days}天 {ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}";
        }

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

        private void UpdateChart()
        {
            if (chartResults.InvokeRequired)
            {
                chartResults.Invoke(new Action(UpdateChart));
                return;
            }

            chartResults.Series[0].Points.Clear();

            if (totalOK == 0 && totalNG == 0)
            {
                int emptyIndex = chartResults.Series[0].Points.AddXY("暂无数据", 1);
                chartResults.Series[0].Points[emptyIndex].Color = Color.LightGray;
            }
            else
            {
                if (totalOK > 0)
                {
                    int okIndex = chartResults.Series[0].Points.AddXY($"OK\n{totalOK}", totalOK);
                    chartResults.Series[0].Points[okIndex].Color = Color.LimeGreen;
                }

                if (totalNG > 0)
                {
                    int ngIndex = chartResults.Series[0].Points.AddXY($"NG\n{totalNG}", totalNG);
                    chartResults.Series[0].Points[ngIndex].Color = Color.Crimson;
                }
            }

            int total = totalOK + totalNG;
            double yieldRate = total == 0 ? 0 : (double)totalOK / total * 100;

            lblTotal.Text = $"总计: {total}";
            lblOK.Text = $"OK: {totalOK}";
            lblNG.Text = $"NG: {totalNG}";
            lblYield.Text = $"良率: {yieldRate:F2}%";

            chartResults.Invalidate();
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
                    // 将主渲染控件绑定到“字符缺陷检测1”，以便直接看到图像和检测框
                    try
                    {
                        var renderModule = (VMControls.Interface.IVmModule)VmSolution.Instance["流程1.字符缺陷检测1"];
                        if (renderModule != null)
                        {
                            vmRenderControl1.ModuleSource = renderModule;
                        }
                        else
                        {
                            vmRenderControl1.ModuleSource = vmProcess1;
                        }
                    }
                    catch
                    {
                        vmRenderControl1.ModuleSource = vmProcess1;
                    }

                    // 给参数配置面板绑定算子
                    try
                    {
                        var defaultModule = (VMControls.Interface.IVmModule)VmSolution.Instance["流程1.字符缺陷检测1"];
                        if (defaultModule != null)
                        {
                            vmParamsConfigControl1.ModuleSource = defaultModule;
                            vmParamsConfigWithRenderControl1.ModuleSource = defaultModule;
                        }
                    }
                    catch { /* 静默忽略 */ }
                }
            }
            catch (Exception ex) { AddLog("加载方案失败：" + ex.Message); }
        }

        // --- 向 VM 图像源推图的方法 ---
        // --- 向 VM 图像源推图的方法 (已修复类型转换报错) ---
        // --- 参照 SDK 开发指南重写的推图方法 ---
        // --- 完全遵循 V5.0 SDK 指南规范的推图方法 ---
        private void SetVMImagePath(string path)
        {
            try
            {
                // 1. 修正类名：严格使用开发指南中的 ImageSourceModuleTool
                ImageSourceModuleTool imgTool = VmSolution.Instance["流程1.图像源1"] as ImageSourceModuleTool;

                if (imgTool != null)
                {
                    // 2. 指定图像源为本地图像 (枚举值 0x1)
                    imgTool.ModuParams.ImageSourceType = ImageSourceParam.ImageSourceTypeEnum.LocalImage;

                    // 3. 按照指南推荐：先清空所有输入图像，再通过路径添加
                    imgTool.ClearAllInputImage();
                    imgTool.AddInputImageByPath(path);

                    // 日志提示（可选，用来确认是否走到这一步）
                    // Invoke((Action)(() => AddLog($"成功注入图片: {path}")));
                }
                else
                {
                    Invoke((Action)(() => AddLog("错误：未能获取图像源算子！请确认项目已引用 ImageSourceModuleCs.dll。")));
                }
            }
            catch (Exception ex)
            {
                Invoke((Action)(() => AddLog("设置图像源路径异常: " + ex.Message)));
            }
        }

        private void Scheme_run_Click(object sender, EventArgs e) => RunVisionSolution();

        private void RunVisionSolution()
        {
            try
            {
                if (VmSolution.Instance == null) { Invoke((Action)(() => AddLog("错误：未加载方案"))); return; }

                // 每次检测前，从列表中取出一张图片灌入 VM 图像源
                if (lbImageList != null && lbImageList.Items.Count > 0)
                {
                    if (currentImageIndex >= lbImageList.Items.Count)
                    {
                        currentImageIndex = 0; // 播完一轮自动循环
                    }

                    string currentImgPath = lbImageList.Items[currentImageIndex].ToString();
                    SetVMImagePath(currentImgPath);

                    // 在 UI 上高亮当前正在检测的图片
                    Invoke((Action)(() => {
                        lbImageList.SelectedIndex = currentImageIndex;
                    }));

                    currentImageIndex++;
                }

                VmSolution.Instance.SyncRun();

                VmProcedure vmProcess1 = null;
                try { vmProcess1 = (VmProcedure)VmSolution.Instance["流程1"]; }
                catch { return; }

                // 提取截图中的全局输出变量 out0, out, out1
                ExtractCurrentInfo(vmProcess1);
                ExtractDefectResult(vmProcess1);

                Invoke((Action)(() => AddLog("--- 检测完成 ---")));
            }
            catch (Exception ex) { Invoke((Action)(() => AddLog("执行异常：" + ex.Message))); }
        }

        // 提取图像名称 (out0)
        private void ExtractCurrentInfo(VmProcedure process)
        {
            try
            {
                if (process.ModuResult != null)
                {
                    var strOutput = process.ModuResult.GetOutputString("out0");
                    if (strOutput.astStringVal != null && strOutput.astStringVal.Length > 0)
                    {
                        Invoke((Action)(() => AddLog($"当前图像: {strOutput.astStringVal[0].strValue}")));
                    }
                }
            }
            catch { }
        }

        // 提取缺陷 (out) 和状态 (out1)
        private void ExtractDefectResult(VmProcedure process)
        {
            try
            {
                bool isNg = false;
                int defectCount = 0;
                int matchStatus = 0;

                if (process.ModuResult != null)
                {
                    // 获取 out: 缺陷个数
                    var intOutputDefect = process.ModuResult.GetOutputInt("out");
                    if (intOutputDefect.pIntVal != null && intOutputDefect.pIntVal.Length > 0)
                    {
                        defectCount = intOutputDefect.pIntVal[0];
                    }

                    // 获取 out1: 匹配状态
                    var intOutputMatch = process.ModuResult.GetOutputInt("out1");
                    if (intOutputMatch.pIntVal != null && intOutputMatch.pIntVal.Length > 0)
                    {
                        matchStatus = intOutputMatch.pIntVal[0];
                    }

                    // 核心判断逻辑：只要缺陷数大于 0 则判定为 NG
                    isNg = defectCount > 0;

                    Invoke((Action)(() => AddLog($"检测结果: {(isNg ? "NG" : "OK")} (缺陷数: {defectCount}, 匹配状态: {matchStatus})")));
                }
                else
                {
                    Invoke((Action)(() => AddLog("警告: 未获取到流程输出结果。")));
                }

                // 更新统计数据与图表
                if (isNg) totalNG++; else totalOK++;
                UpdateChart();
            }
            catch (Exception ex)
            {
                Invoke((Action)(() => AddLog($"获取缺陷异常: {ex.Message}")));
            }
        }

        private async void btnContinuousRun_Click(object sender, EventArgs e)
        {
            if (VmSolution.Instance == null) { MessageBox.Show("请先加载方案！"); return; }
            isContinuousRunning = true;
            cancellationTokenSource = new CancellationTokenSource();
            AddLog(">>> 开始连续运行 <<<");

            await Task.Run(() =>
            {
                while (isContinuousRunning && !cancellationTokenSource.IsCancellationRequested)
                {
                    RunVisionSolution();
                    Thread.Sleep(500);
                }
            }, cancellationTokenSource.Token);
        }

        private void btnStopRun_Click(object sender, EventArgs e)
        {
            isContinuousRunning = false;
            cancellationTokenSource?.Cancel();
            AddLog(">>> 已停止连续运行 <<<");
        }

        private void Scheme_save_Click(object sender, EventArgs e)
        {
            if (VmSolution.Instance == null) return;
            VmSolution.Save();
            AddLog("保存方案成功");
        }

        private void btnClearStats_Click(object sender, EventArgs e)
        {
            totalOK = 0;
            totalNG = 0;
            UpdateChart();
            AddLog("统计数据已重置");
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

        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void vmRenderControl1_Load(object sender, EventArgs e) { }
        private void groupBox2_Enter(object sender, EventArgs e) { }
        private void vmParamsConfigControl1_Load(object sender, EventArgs e) { }

        private void vmRenderControl1_Load_1(object sender, EventArgs e)
        {

        }
    }
}