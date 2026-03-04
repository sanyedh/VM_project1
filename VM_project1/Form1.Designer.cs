namespace VM_project1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnNavLogs = new System.Windows.Forms.Button();
            this.btnNavConfig = new System.Windows.Forms.Button();
            this.btnNavDashboard = new System.Windows.Forms.Button();
            this.lblLogo = new System.Windows.Forms.Label();
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.lblUptime = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlDashboard = new System.Windows.Forms.Panel();
            this.groupBoxRender = new System.Windows.Forms.GroupBox();
            this.vmRenderControl1 = new VMControls.Winform.Release.VmRenderControl();
            this.pnlDashRight = new System.Windows.Forms.Panel();
            this.groupBoxStats = new System.Windows.Forms.GroupBox();
            this.btnClearStats = new System.Windows.Forms.Button();
            this.lblYield = new System.Windows.Forms.Label();
            this.lblNG = new System.Windows.Forms.Label();
            this.lblOK = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.chartResults = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBoxControls = new System.Windows.Forms.GroupBox();
            this.btnStopRun = new System.Windows.Forms.Button();
            this.btnContinuousRun = new System.Windows.Forms.Button();
            this.Scheme_run = new System.Windows.Forms.Button();
            this.pnlConfig = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBoxFlow = new System.Windows.Forms.GroupBox();
            this.vmProcedureConfigControl1 = new VMControls.Winform.Release.VmProcedureConfigControl();
            this.groupBoxParams = new System.Windows.Forms.GroupBox();
            this.vmParamsConfigWithRenderControl1 = new VMControls.Winform.Release.VmParamsConfigWithRenderControl();
            this.vmParamsConfigControl1 = new VMControls.Winform.Release.VmParamsConfigControl();
            this.groupBoxConfigTop = new System.Windows.Forms.GroupBox();
            this.Select_path = new System.Windows.Forms.Button();
            this.Scheme_load = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Scheme_save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlLogs = new System.Windows.Forms.Panel();
            this.groupBoxLogs = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.pnlMenu.SuspendLayout();
            this.pnlTopBar.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlDashboard.SuspendLayout();
            this.groupBoxRender.SuspendLayout();
            this.pnlDashRight.SuspendLayout();
            this.groupBoxStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartResults)).BeginInit();
            this.groupBoxControls.SuspendLayout();
            this.pnlConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBoxFlow.SuspendLayout();
            this.groupBoxParams.SuspendLayout();
            this.groupBoxConfigTop.SuspendLayout();
            this.pnlLogs.SuspendLayout();
            this.groupBoxLogs.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.pnlMenu.Controls.Add(this.btnNavLogs);
            this.pnlMenu.Controls.Add(this.btnNavConfig);
            this.pnlMenu.Controls.Add(this.btnNavDashboard);
            this.pnlMenu.Controls.Add(this.lblLogo);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(200, 753);
            this.pnlMenu.TabIndex = 0;
            // 
            // btnNavLogs
            // 
            this.btnNavLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnNavLogs.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavLogs.FlatAppearance.BorderSize = 0;
            this.btnNavLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavLogs.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNavLogs.ForeColor = System.Drawing.Color.White;
            this.btnNavLogs.Location = new System.Drawing.Point(0, 190);
            this.btnNavLogs.Name = "btnNavLogs";
            this.btnNavLogs.Size = new System.Drawing.Size(200, 60);
            this.btnNavLogs.TabIndex = 3;
            this.btnNavLogs.Text = "运行日志";
            this.btnNavLogs.UseVisualStyleBackColor = false;
            this.btnNavLogs.Click += new System.EventHandler(this.btnNavLogs_Click);
            // 
            // btnNavConfig
            // 
            this.btnNavConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnNavConfig.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavConfig.FlatAppearance.BorderSize = 0;
            this.btnNavConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavConfig.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNavConfig.ForeColor = System.Drawing.Color.White;
            this.btnNavConfig.Location = new System.Drawing.Point(0, 130);
            this.btnNavConfig.Name = "btnNavConfig";
            this.btnNavConfig.Size = new System.Drawing.Size(200, 60);
            this.btnNavConfig.TabIndex = 2;
            this.btnNavConfig.Text = "方案配置";
            this.btnNavConfig.UseVisualStyleBackColor = false;
            this.btnNavConfig.Click += new System.EventHandler(this.btnNavConfig_Click);
            // 
            // btnNavDashboard
            // 
            this.btnNavDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnNavDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavDashboard.FlatAppearance.BorderSize = 0;
            this.btnNavDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavDashboard.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNavDashboard.ForeColor = System.Drawing.Color.White;
            this.btnNavDashboard.Location = new System.Drawing.Point(0, 70);
            this.btnNavDashboard.Name = "btnNavDashboard";
            this.btnNavDashboard.Size = new System.Drawing.Size(200, 60);
            this.btnNavDashboard.TabIndex = 1;
            this.btnNavDashboard.Text = "监控看板";
            this.btnNavDashboard.UseVisualStyleBackColor = false;
            this.btnNavDashboard.Click += new System.EventHandler(this.btnNavDashboard_Click);
            // 
            // lblLogo
            // 
            this.lblLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(126)))), ((int)(((byte)(49)))));
            this.lblLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLogo.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(0, 0);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(200, 70);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "视觉检测系统";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.White;
            this.pnlTopBar.Controls.Add(this.lblUptime);
            this.pnlTopBar.Controls.Add(this.labelTitle);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(200, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(1182, 70);
            this.pnlTopBar.TabIndex = 1;
            // 
            // lblUptime
            // 
            this.lblUptime.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblUptime.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUptime.ForeColor = System.Drawing.Color.Gray;
            this.lblUptime.Location = new System.Drawing.Point(882, 0);
            this.lblUptime.Name = "lblUptime";
            this.lblUptime.Size = new System.Drawing.Size(300, 70);
            this.lblUptime.TabIndex = 1;
            this.lblUptime.Text = "已持续运行: 0天 00:00:00";
            this.lblUptime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelTitle.Location = new System.Drawing.Point(25, 18);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(231, 36);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "标签印刷质量检测";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlDashboard);
            this.pnlMain.Controls.Add(this.pnlConfig);
            this.pnlMain.Controls.Add(this.pnlLogs);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(200, 70);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(10);
            this.pnlMain.Size = new System.Drawing.Size(1182, 683);
            this.pnlMain.TabIndex = 2;
            // 
            // pnlDashboard
            // 
            this.pnlDashboard.Controls.Add(this.groupBoxRender);
            this.pnlDashboard.Controls.Add(this.pnlDashRight);
            this.pnlDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDashboard.Location = new System.Drawing.Point(10, 10);
            this.pnlDashboard.Name = "pnlDashboard";
            this.pnlDashboard.Size = new System.Drawing.Size(1162, 663);
            this.pnlDashboard.TabIndex = 0;
            // 
            // groupBoxRender
            // 
            this.groupBoxRender.Controls.Add(this.vmRenderControl1);
            this.groupBoxRender.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxRender.Font = new System.Drawing.Font("微软雅黑", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxRender.Location = new System.Drawing.Point(0, 0);
            this.groupBoxRender.Name = "groupBoxRender";
            this.groupBoxRender.Size = new System.Drawing.Size(762, 663);
            this.groupBoxRender.TabIndex = 0;
            this.groupBoxRender.TabStop = false;
            this.groupBoxRender.Text = "实时检测图像";
            // 
            // vmRenderControl1
            // 
            this.vmRenderControl1.BackColor = System.Drawing.Color.Black;
            this.vmRenderControl1.CoordinateInfoVisible = true;
            this.vmRenderControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vmRenderControl1.ImageSource = null;
            this.vmRenderControl1.IsShowCustomROIMenu = false;
            this.vmRenderControl1.Location = new System.Drawing.Point(3, 26);
            this.vmRenderControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.vmRenderControl1.ModuleSource = null;
            this.vmRenderControl1.Name = "vmRenderControl1";
            this.vmRenderControl1.Size = new System.Drawing.Size(756, 634);
            this.vmRenderControl1.TabIndex = 0;
            this.vmRenderControl1.Load += new System.EventHandler(this.vmRenderControl1_Load_1);
            // 
            // pnlDashRight
            // 
            this.pnlDashRight.Controls.Add(this.groupBoxStats);
            this.pnlDashRight.Controls.Add(this.groupBoxControls);
            this.pnlDashRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDashRight.Location = new System.Drawing.Point(762, 0);
            this.pnlDashRight.Name = "pnlDashRight";
            this.pnlDashRight.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.pnlDashRight.Size = new System.Drawing.Size(400, 663);
            this.pnlDashRight.TabIndex = 1;
            // 
            // groupBoxStats
            // 
            this.groupBoxStats.Controls.Add(this.btnClearStats);
            this.groupBoxStats.Controls.Add(this.lblYield);
            this.groupBoxStats.Controls.Add(this.lblNG);
            this.groupBoxStats.Controls.Add(this.lblOK);
            this.groupBoxStats.Controls.Add(this.lblTotal);
            this.groupBoxStats.Controls.Add(this.chartResults);
            this.groupBoxStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxStats.Font = new System.Drawing.Font("微软雅黑", 10.2F);
            this.groupBoxStats.Location = new System.Drawing.Point(10, 0);
            this.groupBoxStats.Name = "groupBoxStats";
            this.groupBoxStats.Size = new System.Drawing.Size(390, 503);
            this.groupBoxStats.TabIndex = 0;
            this.groupBoxStats.TabStop = false;
            this.groupBoxStats.Text = "质量统计";
            // 
            // btnClearStats
            // 
            this.btnClearStats.Location = new System.Drawing.Point(260, 440);
            this.btnClearStats.Name = "btnClearStats";
            this.btnClearStats.Size = new System.Drawing.Size(110, 35);
            this.btnClearStats.TabIndex = 5;
            this.btnClearStats.Text = "重置数据";
            this.btnClearStats.UseVisualStyleBackColor = true;
            this.btnClearStats.Click += new System.EventHandler(this.btnClearStats_Click);
            // 
            // lblYield
            // 
            this.lblYield.AutoSize = true;
            this.lblYield.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.lblYield.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblYield.Location = new System.Drawing.Point(25, 455);
            this.lblYield.Name = "lblYield";
            this.lblYield.Size = new System.Drawing.Size(150, 31);
            this.lblYield.TabIndex = 4;
            this.lblYield.Text = "良率: 0.00%";
            // 
            // lblNG
            // 
            this.lblNG.AutoSize = true;
            this.lblNG.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.lblNG.ForeColor = System.Drawing.Color.Crimson;
            this.lblNG.Location = new System.Drawing.Point(25, 415);
            this.lblNG.Name = "lblNG";
            this.lblNG.Size = new System.Drawing.Size(68, 27);
            this.lblNG.TabIndex = 3;
            this.lblNG.Text = "NG: 0";
            // 
            // lblOK
            // 
            this.lblOK.AutoSize = true;
            this.lblOK.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.lblOK.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblOK.Location = new System.Drawing.Point(25, 375);
            this.lblOK.Name = "lblOK";
            this.lblOK.Size = new System.Drawing.Size(66, 27);
            this.lblOK.TabIndex = 2;
            this.lblOK.Text = "OK: 0";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotal.Location = new System.Drawing.Point(25, 335);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(75, 27);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "总计: 0";
            // 
            // chartResults
            // 
            chartArea1.Name = "ChartArea1";
            this.chartResults.ChartAreas.Add(chartArea1);
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            this.chartResults.Legends.Add(legend1);
            this.chartResults.Location = new System.Drawing.Point(10, 30);
            this.chartResults.Name = "chartResults";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartResults.Series.Add(series1);
            this.chartResults.Size = new System.Drawing.Size(370, 290);
            this.chartResults.TabIndex = 0;
            this.chartResults.Text = "chart1";
            // 
            // groupBoxControls
            // 
            this.groupBoxControls.Controls.Add(this.btnStopRun);
            this.groupBoxControls.Controls.Add(this.btnContinuousRun);
            this.groupBoxControls.Controls.Add(this.Scheme_run);
            this.groupBoxControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBoxControls.Font = new System.Drawing.Font("微软雅黑", 10.2F);
            this.groupBoxControls.Location = new System.Drawing.Point(10, 503);
            this.groupBoxControls.Name = "groupBoxControls";
            this.groupBoxControls.Size = new System.Drawing.Size(390, 160);
            this.groupBoxControls.TabIndex = 1;
            this.groupBoxControls.TabStop = false;
            this.groupBoxControls.Text = "运行控制";
            // 
            // btnStopRun
            // 
            this.btnStopRun.BackColor = System.Drawing.Color.Tomato;
            this.btnStopRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopRun.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold);
            this.btnStopRun.ForeColor = System.Drawing.Color.White;
            this.btnStopRun.Location = new System.Drawing.Point(200, 90);
            this.btnStopRun.Name = "btnStopRun";
            this.btnStopRun.Size = new System.Drawing.Size(170, 50);
            this.btnStopRun.TabIndex = 2;
            this.btnStopRun.Text = "■ 停止检测";
            this.btnStopRun.UseVisualStyleBackColor = false;
            this.btnStopRun.Click += new System.EventHandler(this.btnStopRun_Click);
            // 
            // btnContinuousRun
            // 
            this.btnContinuousRun.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnContinuousRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinuousRun.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold);
            this.btnContinuousRun.ForeColor = System.Drawing.Color.White;
            this.btnContinuousRun.Location = new System.Drawing.Point(20, 90);
            this.btnContinuousRun.Name = "btnContinuousRun";
            this.btnContinuousRun.Size = new System.Drawing.Size(170, 50);
            this.btnContinuousRun.TabIndex = 1;
            this.btnContinuousRun.Text = "▶ 连续测试";
            this.btnContinuousRun.UseVisualStyleBackColor = false;
            this.btnContinuousRun.Click += new System.EventHandler(this.btnContinuousRun_Click);
            // 
            // Scheme_run
            // 
            this.Scheme_run.Location = new System.Drawing.Point(20, 35);
            this.Scheme_run.Name = "Scheme_run";
            this.Scheme_run.Size = new System.Drawing.Size(350, 40);
            this.Scheme_run.TabIndex = 0;
            this.Scheme_run.Text = "单次测试";
            this.Scheme_run.UseVisualStyleBackColor = true;
            this.Scheme_run.Click += new System.EventHandler(this.Scheme_run_Click);
            // 
            // pnlConfig
            // 
            this.pnlConfig.Controls.Add(this.splitContainer1);
            this.pnlConfig.Controls.Add(this.groupBoxConfigTop);
            this.pnlConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConfig.Location = new System.Drawing.Point(10, 10);
            this.pnlConfig.Name = "pnlConfig";
            this.pnlConfig.Size = new System.Drawing.Size(1162, 663);
            this.pnlConfig.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 80);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxFlow);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBoxParams);
            this.splitContainer1.Size = new System.Drawing.Size(1162, 583);
            this.splitContainer1.SplitterDistance = 600;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBoxFlow
            // 
            this.groupBoxFlow.Controls.Add(this.vmProcedureConfigControl1);
            this.groupBoxFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxFlow.Font = new System.Drawing.Font("微软雅黑", 10.2F);
            this.groupBoxFlow.Location = new System.Drawing.Point(0, 0);
            this.groupBoxFlow.Name = "groupBoxFlow";
            this.groupBoxFlow.Size = new System.Drawing.Size(600, 583);
            this.groupBoxFlow.TabIndex = 0;
            this.groupBoxFlow.TabStop = false;
            this.groupBoxFlow.Text = "流程配置";
            // 
            // vmProcedureConfigControl1
            // 
            this.vmProcedureConfigControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vmProcedureConfigControl1.Location = new System.Drawing.Point(3, 26);
            this.vmProcedureConfigControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.vmProcedureConfigControl1.Name = "vmProcedureConfigControl1";
            this.vmProcedureConfigControl1.Size = new System.Drawing.Size(594, 554);
            this.vmProcedureConfigControl1.TabIndex = 0;
// TODO: “”的代码生成失败，原因是出现异常“无效的基元类型: System.IntPtr。请考虑使用 CodeObjectCreateExpression。”。
            // 
            // groupBoxParams
            // 
            this.groupBoxParams.Controls.Add(this.vmParamsConfigWithRenderControl1);
            this.groupBoxParams.Controls.Add(this.vmParamsConfigControl1);
            this.groupBoxParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxParams.Font = new System.Drawing.Font("微软雅黑", 10.2F);
            this.groupBoxParams.Location = new System.Drawing.Point(0, 0);
            this.groupBoxParams.Name = "groupBoxParams";
            this.groupBoxParams.Size = new System.Drawing.Size(558, 583);
            this.groupBoxParams.TabIndex = 0;
            this.groupBoxParams.TabStop = false;
            this.groupBoxParams.Text = "算子参数配置";
            // 
            // vmParamsConfigWithRenderControl1
            // 
            this.vmParamsConfigWithRenderControl1.BackColor = System.Drawing.Color.White;
            this.vmParamsConfigWithRenderControl1.CoordinateInfoVisible = true;
            this.vmParamsConfigWithRenderControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vmParamsConfigWithRenderControl1.ImageSource = null;
            this.vmParamsConfigWithRenderControl1.Location = new System.Drawing.Point(3, 300);
            this.vmParamsConfigWithRenderControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.vmParamsConfigWithRenderControl1.ModuleSource = null;
            this.vmParamsConfigWithRenderControl1.MultiImageButtonVisible = false;
            this.vmParamsConfigWithRenderControl1.Name = "vmParamsConfigWithRenderControl1";
            this.vmParamsConfigWithRenderControl1.ParamsConfig = null;
            this.vmParamsConfigWithRenderControl1.ROIVisible = true;
            this.vmParamsConfigWithRenderControl1.Size = new System.Drawing.Size(552, 280);
            this.vmParamsConfigWithRenderControl1.TabIndex = 1;
            // 
            // vmParamsConfigControl1
            // 
            this.vmParamsConfigControl1.BackColor = System.Drawing.Color.White;
            this.vmParamsConfigControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.vmParamsConfigControl1.Location = new System.Drawing.Point(3, 26);
            this.vmParamsConfigControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.vmParamsConfigControl1.ModuleSource = null;
            this.vmParamsConfigControl1.Name = "vmParamsConfigControl1";
            this.vmParamsConfigControl1.ParamsConfig = null;
            this.vmParamsConfigControl1.Size = new System.Drawing.Size(552, 274);
            this.vmParamsConfigControl1.TabIndex = 0;
            // 
            // groupBoxConfigTop
            // 
            this.groupBoxConfigTop.Controls.Add(this.Select_path);
            this.groupBoxConfigTop.Controls.Add(this.Scheme_load);
            this.groupBoxConfigTop.Controls.Add(this.textBox1);
            this.groupBoxConfigTop.Controls.Add(this.Scheme_save);
            this.groupBoxConfigTop.Controls.Add(this.label1);
            this.groupBoxConfigTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxConfigTop.Font = new System.Drawing.Font("微软雅黑", 10.2F);
            this.groupBoxConfigTop.Location = new System.Drawing.Point(0, 0);
            this.groupBoxConfigTop.Name = "groupBoxConfigTop";
            this.groupBoxConfigTop.Size = new System.Drawing.Size(1162, 80);
            this.groupBoxConfigTop.TabIndex = 0;
            this.groupBoxConfigTop.TabStop = false;
            this.groupBoxConfigTop.Text = "方案文件";
            // 
            // Select_path
            // 
            this.Select_path.Location = new System.Drawing.Point(540, 30);
            this.Select_path.Name = "Select_path";
            this.Select_path.Size = new System.Drawing.Size(100, 30);
            this.Select_path.TabIndex = 1;
            this.Select_path.Text = "选择...";
            this.Select_path.UseVisualStyleBackColor = true;
            this.Select_path.Click += new System.EventHandler(this.Select_path_Click);
            // 
            // Scheme_load
            // 
            this.Scheme_load.Location = new System.Drawing.Point(660, 30);
            this.Scheme_load.Name = "Scheme_load";
            this.Scheme_load.Size = new System.Drawing.Size(120, 30);
            this.Scheme_load.TabIndex = 2;
            this.Scheme_load.Text = "加载方案";
            this.Scheme_load.UseVisualStyleBackColor = true;
            this.Scheme_load.Click += new System.EventHandler(this.Scheme_load_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(100, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(430, 30);
            this.textBox1.TabIndex = 0;
            // 
            // Scheme_save
            // 
            this.Scheme_save.Location = new System.Drawing.Point(790, 30);
            this.Scheme_save.Name = "Scheme_save";
            this.Scheme_save.Size = new System.Drawing.Size(120, 30);
            this.Scheme_save.TabIndex = 3;
            this.Scheme_save.Text = "保存方案";
            this.Scheme_save.UseVisualStyleBackColor = true;
            this.Scheme_save.Click += new System.EventHandler(this.Scheme_save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "方案路径";
            // 
            // pnlLogs
            // 
            this.pnlLogs.Controls.Add(this.groupBoxLogs);
            this.pnlLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLogs.Location = new System.Drawing.Point(10, 10);
            this.pnlLogs.Name = "pnlLogs";
            this.pnlLogs.Size = new System.Drawing.Size(1162, 663);
            this.pnlLogs.TabIndex = 2;
            // 
            // groupBoxLogs
            // 
            this.groupBoxLogs.Controls.Add(this.listBox1);
            this.groupBoxLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxLogs.Font = new System.Drawing.Font("微软雅黑", 10.2F);
            this.groupBoxLogs.Location = new System.Drawing.Point(0, 0);
            this.groupBoxLogs.Name = "groupBoxLogs";
            this.groupBoxLogs.Size = new System.Drawing.Size(1162, 663);
            this.groupBoxLogs.TabIndex = 0;
            this.groupBoxLogs.TabStop = false;
            this.groupBoxLogs.Text = "系统运行日志";
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 23;
            this.listBox1.Location = new System.Drawing.Point(3, 26);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(1156, 634);
            this.listBox1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 753);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlTopBar);
            this.Controls.Add(this.pnlMenu);
            this.Name = "Form1";
            this.Text = "印刷质量检测软件 - 竞赛版";
            this.pnlMenu.ResumeLayout(false);
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlDashboard.ResumeLayout(false);
            this.groupBoxRender.ResumeLayout(false);
            this.pnlDashRight.ResumeLayout(false);
            this.groupBoxStats.ResumeLayout(false);
            this.groupBoxStats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartResults)).EndInit();
            this.groupBoxControls.ResumeLayout(false);
            this.pnlConfig.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBoxFlow.ResumeLayout(false);
            this.groupBoxParams.ResumeLayout(false);
            this.groupBoxConfigTop.ResumeLayout(false);
            this.groupBoxConfigTop.PerformLayout();
            this.pnlLogs.ResumeLayout(false);
            this.groupBoxLogs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        // 自定义页面导航与容器
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Button btnNavLogs;
        private System.Windows.Forms.Button btnNavConfig;
        private System.Windows.Forms.Button btnNavDashboard;

        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label lblUptime;

        private System.Windows.Forms.Panel pnlMain;

        // 子页面1：监控看板
        private System.Windows.Forms.Panel pnlDashboard;
        private System.Windows.Forms.GroupBox groupBoxRender;
        private VMControls.Winform.Release.VmRenderControl vmRenderControl1;
        private System.Windows.Forms.Panel pnlDashRight;
        private System.Windows.Forms.GroupBox groupBoxStats;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartResults;
        private System.Windows.Forms.Label lblYield;
        private System.Windows.Forms.Label lblNG;
        private System.Windows.Forms.Label lblOK;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnClearStats;
        private System.Windows.Forms.GroupBox groupBoxControls;
        private System.Windows.Forms.Button Scheme_run;
        private System.Windows.Forms.Button btnContinuousRun;
        private System.Windows.Forms.Button btnStopRun;

        // 子页面2：方案配置
        private System.Windows.Forms.Panel pnlConfig;
        private System.Windows.Forms.GroupBox groupBoxConfigTop;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Select_path;
        private System.Windows.Forms.Button Scheme_load;
        private System.Windows.Forms.Button Scheme_save;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBoxFlow;
        private VMControls.Winform.Release.VmProcedureConfigControl vmProcedureConfigControl1;
        private System.Windows.Forms.GroupBox groupBoxParams;
        private VMControls.Winform.Release.VmParamsConfigControl vmParamsConfigControl1;
        private VMControls.Winform.Release.VmParamsConfigWithRenderControl vmParamsConfigWithRenderControl1;

        // 子页面3：系统日志
        private System.Windows.Forms.Panel pnlLogs;
        private System.Windows.Forms.GroupBox groupBoxLogs;
        private System.Windows.Forms.ListBox listBox1;
    }
}