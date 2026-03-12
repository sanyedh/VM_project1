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
            if (currentOriginalBitmap != null)
            {
                currentOriginalBitmap.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnNavModelConfig = new System.Windows.Forms.Button();
            this.btnNavLogs = new System.Windows.Forms.Button();
            this.btnNavConfig = new System.Windows.Forms.Button();
            this.btnNavDashboard = new System.Windows.Forms.Button();
            this.lblLogo = new System.Windows.Forms.Label();
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.btnImportSample = new System.Windows.Forms.Button();
            this.btnStopRun = new System.Windows.Forms.Button();
            this.btnContinuousRun = new System.Windows.Forms.Button();
            this.Scheme_run = new System.Windows.Forms.Button();
            this.lblYield = new System.Windows.Forms.Label();
            this.lblNG = new System.Windows.Forms.Label();
            this.lblOK = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblUptime = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlModelConfig = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.vmRenderControl2 = new VMControls.Winform.Release.VmRenderControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pnlDashboard = new System.Windows.Forms.Panel();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpLeft = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxRender = new System.Windows.Forms.GroupBox();
            this.vmRenderControl1 = new VMControls.Winform.Release.VmRenderControl();
            this.groupBoxThumbnails = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelThumbnails = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSelectImages = new System.Windows.Forms.Button();
            this.tlpRight = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxDefectList = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelDefects = new System.Windows.Forms.FlowLayoutPanel();
            this.tlpCompare = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxDefectDetail = new System.Windows.Forms.GroupBox();
            this.pbDefectDetail = new System.Windows.Forms.PictureBox();
            this.groupBoxStandardDetail = new System.Windows.Forms.GroupBox();
            this.pbStandardDetail = new System.Windows.Forms.PictureBox();
            this.pnlConfig = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBoxFlow = new System.Windows.Forms.GroupBox();
            this.vmProcedureConfigControl1 = new VMControls.Winform.Release.VmProcedureConfigControl();
            this.groupBoxConfigTop = new System.Windows.Forms.GroupBox();
            this.Select_path = new System.Windows.Forms.Button();
            this.Scheme_load = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Scheme_save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlLogs = new System.Windows.Forms.Panel();
            this.groupBoxLogs = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.pnlMenu.SuspendLayout();
            this.pnlTopBar.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlModelConfig.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.pnlDashboard.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.tlpLeft.SuspendLayout();
            this.groupBoxRender.SuspendLayout();
            this.groupBoxThumbnails.SuspendLayout();
            this.tlpRight.SuspendLayout();
            this.groupBoxDefectList.SuspendLayout();
            this.tlpCompare.SuspendLayout();
            this.groupBoxDefectDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDefectDetail)).BeginInit();
            this.groupBoxStandardDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStandardDetail)).BeginInit();
            this.pnlConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBoxFlow.SuspendLayout();
            this.groupBoxConfigTop.SuspendLayout();
            this.pnlLogs.SuspendLayout();
            this.groupBoxLogs.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.pnlMenu.Controls.Add(this.btnNavModelConfig);
            this.pnlMenu.Controls.Add(this.btnNavLogs);
            this.pnlMenu.Controls.Add(this.btnNavConfig);
            this.pnlMenu.Controls.Add(this.btnNavDashboard);
            this.pnlMenu.Controls.Add(this.lblLogo);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 70);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(200, 780);
            this.pnlMenu.TabIndex = 0;
            // 
            // btnNavModelConfig
            // 
            this.btnNavModelConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnNavModelConfig.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavModelConfig.FlatAppearance.BorderSize = 0;
            this.btnNavModelConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavModelConfig.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNavModelConfig.ForeColor = System.Drawing.Color.White;
            this.btnNavModelConfig.Location = new System.Drawing.Point(0, 250);
            this.btnNavModelConfig.Name = "btnNavModelConfig";
            this.btnNavModelConfig.Size = new System.Drawing.Size(200, 60);
            this.btnNavModelConfig.TabIndex = 4;
            this.btnNavModelConfig.Text = "建模配置";
            this.btnNavModelConfig.UseVisualStyleBackColor = false;
            this.btnNavModelConfig.Click += new System.EventHandler(this.btnNavModelConfig_Click);
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
            this.pnlTopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.pnlTopBar.Controls.Add(this.btnImportSample);
            this.pnlTopBar.Controls.Add(this.btnStopRun);
            this.pnlTopBar.Controls.Add(this.btnContinuousRun);
            this.pnlTopBar.Controls.Add(this.Scheme_run);
            this.pnlTopBar.Controls.Add(this.lblYield);
            this.pnlTopBar.Controls.Add(this.lblNG);
            this.pnlTopBar.Controls.Add(this.lblOK);
            this.pnlTopBar.Controls.Add(this.lblTotal);
            this.pnlTopBar.Controls.Add(this.lblUptime);
            this.pnlTopBar.Controls.Add(this.labelTitle);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(1482, 70);
            this.pnlTopBar.TabIndex = 1;
            // 
            // btnImportSample
            // 
            this.btnImportSample.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportSample.BackColor = System.Drawing.Color.SteelBlue;
            this.btnImportSample.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportSample.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.btnImportSample.ForeColor = System.Drawing.Color.White;
            this.btnImportSample.Location = new System.Drawing.Point(996, 15);
            this.btnImportSample.Name = "btnImportSample";
            this.btnImportSample.Size = new System.Drawing.Size(110, 40);
            this.btnImportSample.TabIndex = 9;
            this.btnImportSample.Text = "导入样本图";
            this.btnImportSample.UseVisualStyleBackColor = false;
            this.btnImportSample.Click += new System.EventHandler(this.btnImportSample_Click);
            // 
            // btnStopRun
            // 
            this.btnStopRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStopRun.BackColor = System.Drawing.Color.Tomato;
            this.btnStopRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopRun.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.btnStopRun.ForeColor = System.Drawing.Color.White;
            this.btnStopRun.Location = new System.Drawing.Point(1370, 15);
            this.btnStopRun.Name = "btnStopRun";
            this.btnStopRun.Size = new System.Drawing.Size(100, 40);
            this.btnStopRun.TabIndex = 8;
            this.btnStopRun.Text = "■ 停止";
            this.btnStopRun.UseVisualStyleBackColor = false;
            this.btnStopRun.Click += new System.EventHandler(this.btnStopRun_Click);
            // 
            // btnContinuousRun
            // 
            this.btnContinuousRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnContinuousRun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnContinuousRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinuousRun.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.btnContinuousRun.ForeColor = System.Drawing.Color.White;
            this.btnContinuousRun.Location = new System.Drawing.Point(1237, 15);
            this.btnContinuousRun.Name = "btnContinuousRun";
            this.btnContinuousRun.Size = new System.Drawing.Size(118, 40);
            this.btnContinuousRun.TabIndex = 7;
            this.btnContinuousRun.Text = "▶ 开始检测";
            this.btnContinuousRun.UseVisualStyleBackColor = false;
            this.btnContinuousRun.Click += new System.EventHandler(this.btnContinuousRun_Click);
            // 
            // Scheme_run
            // 
            this.Scheme_run.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Scheme_run.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.Scheme_run.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Scheme_run.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.Scheme_run.ForeColor = System.Drawing.Color.White;
            this.Scheme_run.Location = new System.Drawing.Point(1116, 15);
            this.Scheme_run.Name = "Scheme_run";
            this.Scheme_run.Size = new System.Drawing.Size(100, 40);
            this.Scheme_run.TabIndex = 6;
            this.Scheme_run.Text = "单次测试";
            this.Scheme_run.UseVisualStyleBackColor = false;
            this.Scheme_run.Click += new System.EventHandler(this.Scheme_run_Click);
            // 
            // lblYield
            // 
            this.lblYield.AutoSize = true;
            this.lblYield.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.lblYield.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblYield.Location = new System.Drawing.Point(580, 25);
            this.lblYield.Name = "lblYield";
            this.lblYield.Size = new System.Drawing.Size(125, 27);
            this.lblYield.TabIndex = 5;
            this.lblYield.Text = "良率: 0.00%";
            // 
            // lblNG
            // 
            this.lblNG.AutoSize = true;
            this.lblNG.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.lblNG.ForeColor = System.Drawing.Color.Crimson;
            this.lblNG.Location = new System.Drawing.Point(490, 25);
            this.lblNG.Name = "lblNG";
            this.lblNG.Size = new System.Drawing.Size(68, 27);
            this.lblNG.TabIndex = 4;
            this.lblNG.Text = "NG: 0";
            // 
            // lblOK
            // 
            this.lblOK.AutoSize = true;
            this.lblOK.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.lblOK.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblOK.Location = new System.Drawing.Point(400, 25);
            this.lblOK.Name = "lblOK";
            this.lblOK.Size = new System.Drawing.Size(66, 27);
            this.lblOK.TabIndex = 3;
            this.lblOK.Text = "OK: 0";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotal.ForeColor = System.Drawing.Color.White;
            this.lblTotal.Location = new System.Drawing.Point(300, 25);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(75, 27);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "总计: 0";
            // 
            // lblUptime
            // 
            this.lblUptime.AutoSize = true;
            this.lblUptime.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUptime.ForeColor = System.Drawing.Color.LightGray;
            this.lblUptime.Location = new System.Drawing.Point(715, 26);
            this.lblUptime.Name = "lblUptime";
            this.lblUptime.Size = new System.Drawing.Size(118, 24);
            this.lblUptime.TabIndex = 1;
            this.lblUptime.Text = "0天 00:00:00";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(25, 18);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(231, 36);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "印刷质量检测软件";
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlMain.Controls.Add(this.pnlModelConfig);
            this.pnlMain.Controls.Add(this.pnlDashboard);
            this.pnlMain.Controls.Add(this.pnlConfig);
            this.pnlMain.Controls.Add(this.pnlLogs);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(200, 70);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(10);
            this.pnlMain.Size = new System.Drawing.Size(1282, 780);
            this.pnlMain.TabIndex = 2;
            // 
            // pnlModelConfig
            // 
            this.pnlModelConfig.Controls.Add(this.groupBox2);
            this.pnlModelConfig.Controls.Add(this.groupBox1);
            this.pnlModelConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlModelConfig.Location = new System.Drawing.Point(10, 10);
            this.pnlModelConfig.Name = "pnlModelConfig";
            this.pnlModelConfig.Size = new System.Drawing.Size(1262, 760);
            this.pnlModelConfig.TabIndex = 2;
            this.pnlModelConfig.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.vmRenderControl2);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox2.Location = new System.Drawing.Point(433, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(826, 761);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "图像显示";
            // 
            // vmRenderControl2
            // 
            this.vmRenderControl2.BackColor = System.Drawing.Color.Black;
            this.vmRenderControl2.CoordinateInfoVisible = true;
            this.vmRenderControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vmRenderControl2.ImageSource = null;
            this.vmRenderControl2.IsShowCustomROIMenu = false;
            this.vmRenderControl2.Location = new System.Drawing.Point(3, 21);
            this.vmRenderControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.vmRenderControl2.ModuleSource = null;
            this.vmRenderControl2.Name = "vmRenderControl2";
            this.vmRenderControl2.Size = new System.Drawing.Size(820, 737);
            this.vmRenderControl2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(0, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(427, 764);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "配置";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(418, 745);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(410, 716);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "1、裁切定位";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBox2);
            this.groupBox5.Location = new System.Drawing.Point(3, 319);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(396, 145);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "3、绘制定位点框";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(3, 21);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(387, 37);
            this.textBox2.TabIndex = 0;
            this.textBox2.Text = "在检测区域内，绘制点框进行建模，从而实现剪切小图\r\n与样张小图对齐，且支持绘制多个定位框";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox5);
            this.groupBox4.Location = new System.Drawing.Point(3, 168);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(396, 145);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "2、裁剪检测区域";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(7, 28);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(296, 25);
            this.textBox5.TabIndex = 0;
            this.textBox5.Text = "在放大图中绘制裁切区域，以明确检测区域";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox4);
            this.groupBox3.Controls.Add(this.textBox3);
            this.groupBox3.Location = new System.Drawing.Point(3, 17);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(396, 145);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "1、导入基准图像";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(6, 81);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(76, 25);
            this.textBox4.TabIndex = 1;
            this.textBox4.Text = "导入图像";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(6, 25);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(217, 25);
            this.textBox3.TabIndex = 0;
            this.textBox3.Text = "导入一张OK图像进行建模配置";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox7);
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(410, 716);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "2、检测配置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pnlDashboard
            // 
            this.pnlDashboard.Controls.Add(this.tlpMain);
            this.pnlDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDashboard.Location = new System.Drawing.Point(10, 10);
            this.pnlDashboard.Name = "pnlDashboard";
            this.pnlDashboard.Size = new System.Drawing.Size(1262, 760);
            this.pnlDashboard.TabIndex = 0;
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpMain.Controls.Add(this.tlpLeft, 0, 0);
            this.tlpMain.Controls.Add(this.tlpRight, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(1262, 760);
            this.tlpMain.TabIndex = 0;
            // 
            // tlpLeft
            // 
            this.tlpLeft.ColumnCount = 1;
            this.tlpLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLeft.Controls.Add(this.groupBoxRender, 0, 0);
            this.tlpLeft.Controls.Add(this.groupBoxThumbnails, 0, 1);
            this.tlpLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLeft.Location = new System.Drawing.Point(3, 3);
            this.tlpLeft.Name = "tlpLeft";
            this.tlpLeft.RowCount = 2;
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.33334F));
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpLeft.Size = new System.Drawing.Size(751, 754);
            this.tlpLeft.TabIndex = 0;
            // 
            // groupBoxRender
            // 
            this.groupBoxRender.Controls.Add(this.vmRenderControl1);
            this.groupBoxRender.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxRender.Font = new System.Drawing.Font("微软雅黑", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxRender.ForeColor = System.Drawing.Color.White;
            this.groupBoxRender.Location = new System.Drawing.Point(3, 3);
            this.groupBoxRender.Name = "groupBoxRender";
            this.groupBoxRender.Size = new System.Drawing.Size(745, 622);
            this.groupBoxRender.TabIndex = 0;
            this.groupBoxRender.TabStop = false;
            this.groupBoxRender.Text = "运行图像";
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
            this.vmRenderControl1.Size = new System.Drawing.Size(739, 593);
            this.vmRenderControl1.TabIndex = 0;
            // 
            // groupBoxThumbnails
            // 
            this.groupBoxThumbnails.Controls.Add(this.flowLayoutPanelThumbnails);
            this.groupBoxThumbnails.Controls.Add(this.btnSelectImages);
            this.groupBoxThumbnails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxThumbnails.Font = new System.Drawing.Font("微软雅黑", 10.2F);
            this.groupBoxThumbnails.ForeColor = System.Drawing.Color.White;
            this.groupBoxThumbnails.Location = new System.Drawing.Point(3, 631);
            this.groupBoxThumbnails.Name = "groupBoxThumbnails";
            this.groupBoxThumbnails.Size = new System.Drawing.Size(745, 120);
            this.groupBoxThumbnails.TabIndex = 1;
            this.groupBoxThumbnails.TabStop = false;
            this.groupBoxThumbnails.Text = "本地图像队列";
            // 
            // flowLayoutPanelThumbnails
            // 
            this.flowLayoutPanelThumbnails.AutoScroll = true;
            this.flowLayoutPanelThumbnails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelThumbnails.Location = new System.Drawing.Point(3, 26);
            this.flowLayoutPanelThumbnails.Name = "flowLayoutPanelThumbnails";
            this.flowLayoutPanelThumbnails.Size = new System.Drawing.Size(619, 91);
            this.flowLayoutPanelThumbnails.TabIndex = 1;
            this.flowLayoutPanelThumbnails.WrapContents = false;
            // 
            // btnSelectImages
            // 
            this.btnSelectImages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSelectImages.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSelectImages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectImages.Location = new System.Drawing.Point(622, 26);
            this.btnSelectImages.Name = "btnSelectImages";
            this.btnSelectImages.Size = new System.Drawing.Size(120, 91);
            this.btnSelectImages.TabIndex = 0;
            this.btnSelectImages.Text = "+ 添加图像";
            this.btnSelectImages.UseVisualStyleBackColor = false;
            this.btnSelectImages.Click += new System.EventHandler(this.BtnSelectImages_Click);
            // 
            // tlpRight
            // 
            this.tlpRight.ColumnCount = 2;
            this.tlpRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tlpRight.Controls.Add(this.groupBoxDefectList, 0, 0);
            this.tlpRight.Controls.Add(this.tlpCompare, 1, 0);
            this.tlpRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRight.Location = new System.Drawing.Point(760, 3);
            this.tlpRight.Name = "tlpRight";
            this.tlpRight.RowCount = 1;
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRight.Size = new System.Drawing.Size(499, 754);
            this.tlpRight.TabIndex = 1;
            // 
            // groupBoxDefectList
            // 
            this.groupBoxDefectList.Controls.Add(this.flowLayoutPanelDefects);
            this.groupBoxDefectList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDefectList.Font = new System.Drawing.Font("微软雅黑", 10.2F);
            this.groupBoxDefectList.ForeColor = System.Drawing.Color.White;
            this.groupBoxDefectList.Location = new System.Drawing.Point(3, 3);
            this.groupBoxDefectList.Name = "groupBoxDefectList";
            this.groupBoxDefectList.Size = new System.Drawing.Size(118, 748);
            this.groupBoxDefectList.TabIndex = 0;
            this.groupBoxDefectList.TabStop = false;
            this.groupBoxDefectList.Text = "缺陷列表";
            // 
            // flowLayoutPanelDefects
            // 
            this.flowLayoutPanelDefects.AutoScroll = true;
            this.flowLayoutPanelDefects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelDefects.Location = new System.Drawing.Point(3, 26);
            this.flowLayoutPanelDefects.Name = "flowLayoutPanelDefects";
            this.flowLayoutPanelDefects.Size = new System.Drawing.Size(112, 719);
            this.flowLayoutPanelDefects.TabIndex = 0;
            // 
            // tlpCompare
            // 
            this.tlpCompare.ColumnCount = 1;
            this.tlpCompare.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCompare.Controls.Add(this.groupBoxDefectDetail, 0, 0);
            this.tlpCompare.Controls.Add(this.groupBoxStandardDetail, 0, 1);
            this.tlpCompare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCompare.Location = new System.Drawing.Point(127, 3);
            this.tlpCompare.Name = "tlpCompare";
            this.tlpCompare.RowCount = 2;
            this.tlpCompare.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCompare.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCompare.Size = new System.Drawing.Size(369, 748);
            this.tlpCompare.TabIndex = 1;
            // 
            // groupBoxDefectDetail
            // 
            this.groupBoxDefectDetail.Controls.Add(this.pbDefectDetail);
            this.groupBoxDefectDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDefectDetail.Font = new System.Drawing.Font("微软雅黑", 10.2F);
            this.groupBoxDefectDetail.ForeColor = System.Drawing.Color.White;
            this.groupBoxDefectDetail.Location = new System.Drawing.Point(3, 3);
            this.groupBoxDefectDetail.Name = "groupBoxDefectDetail";
            this.groupBoxDefectDetail.Size = new System.Drawing.Size(363, 368);
            this.groupBoxDefectDetail.TabIndex = 0;
            this.groupBoxDefectDetail.TabStop = false;
            this.groupBoxDefectDetail.Text = "缺陷图";
            // 
            // pbDefectDetail
            // 
            this.pbDefectDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pbDefectDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbDefectDetail.Location = new System.Drawing.Point(3, 26);
            this.pbDefectDetail.Name = "pbDefectDetail";
            this.pbDefectDetail.Size = new System.Drawing.Size(357, 339);
            this.pbDefectDetail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbDefectDetail.TabIndex = 0;
            this.pbDefectDetail.TabStop = false;
            // 
            // groupBoxStandardDetail
            // 
            this.groupBoxStandardDetail.Controls.Add(this.pbStandardDetail);
            this.groupBoxStandardDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxStandardDetail.Font = new System.Drawing.Font("微软雅黑", 10.2F);
            this.groupBoxStandardDetail.ForeColor = System.Drawing.Color.White;
            this.groupBoxStandardDetail.Location = new System.Drawing.Point(3, 377);
            this.groupBoxStandardDetail.Name = "groupBoxStandardDetail";
            this.groupBoxStandardDetail.Size = new System.Drawing.Size(363, 368);
            this.groupBoxStandardDetail.TabIndex = 1;
            this.groupBoxStandardDetail.TabStop = false;
            this.groupBoxStandardDetail.Text = "标准图";
            // 
            // pbStandardDetail
            // 
            this.pbStandardDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pbStandardDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbStandardDetail.Location = new System.Drawing.Point(3, 26);
            this.pbStandardDetail.Name = "pbStandardDetail";
            this.pbStandardDetail.Size = new System.Drawing.Size(357, 339);
            this.pbStandardDetail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbStandardDetail.TabIndex = 0;
            this.pbStandardDetail.TabStop = false;
            // 
            // pnlConfig
            // 
            this.pnlConfig.Controls.Add(this.splitContainer1);
            this.pnlConfig.Controls.Add(this.groupBoxConfigTop);
            this.pnlConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConfig.Location = new System.Drawing.Point(10, 10);
            this.pnlConfig.Name = "pnlConfig";
            this.pnlConfig.Size = new System.Drawing.Size(1262, 760);
            this.pnlConfig.TabIndex = 1;
            this.pnlConfig.Visible = false;
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
            this.splitContainer1.Size = new System.Drawing.Size(1262, 680);
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
            this.groupBoxFlow.Size = new System.Drawing.Size(600, 680);
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
            this.vmProcedureConfigControl1.Size = new System.Drawing.Size(594, 651);
            this.vmProcedureConfigControl1.TabIndex = 0;
// TODO: “”的代码生成失败，原因是出现异常“无效的基元类型: System.IntPtr。请考虑使用 CodeObjectCreateExpression。”。
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
            this.groupBoxConfigTop.Size = new System.Drawing.Size(1262, 80);
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
            this.pnlLogs.Size = new System.Drawing.Size(1262, 760);
            this.pnlLogs.TabIndex = 3;
            this.pnlLogs.Visible = false;
            // 
            // groupBoxLogs
            // 
            this.groupBoxLogs.Controls.Add(this.listBox1);
            this.groupBoxLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxLogs.Font = new System.Drawing.Font("微软雅黑", 10.2F);
            this.groupBoxLogs.Location = new System.Drawing.Point(0, 0);
            this.groupBoxLogs.Name = "groupBoxLogs";
            this.groupBoxLogs.Size = new System.Drawing.Size(1262, 760);
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
            this.listBox1.Size = new System.Drawing.Size(1256, 731);
            this.listBox1.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.radioButton3);
            this.groupBox6.Controls.Add(this.radioButton2);
            this.groupBox6.Controls.Add(this.radioButton1);
            this.groupBox6.Controls.Add(this.textBox7);
            this.groupBox6.Controls.Add(this.textBox6);
            this.groupBox6.Location = new System.Drawing.Point(17, 17);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(378, 144);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "检测区域";
            // 
            // groupBox7
            // 
            this.groupBox7.Location = new System.Drawing.Point(17, 167);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(378, 537);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "参数设置";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(7, 25);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(365, 41);
            this.textBox6.TabIndex = 0;
            this.textBox6.Text = "检测内容包括一维码、二维码（个数可变，尽量考虑多个码的场景）、文字图案";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(7, 93);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(67, 25);
            this.textBox7.TabIndex = 1;
            this.textBox7.Text = "ROI绘制";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.radioButton1.Location = new System.Drawing.Point(92, 94);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(73, 19);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.Text = "一维码";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.radioButton2.Location = new System.Drawing.Point(186, 93);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(73, 19);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.Text = "二维码";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.radioButton3.Location = new System.Drawing.Point(279, 94);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(88, 19);
            this.radioButton3.TabIndex = 4;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "文字图案";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1482, 850);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlTopBar);
            this.Name = "Form1";
            this.Text = "印刷质量检测软件";
            this.pnlMenu.ResumeLayout(false);
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlModelConfig.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.pnlDashboard.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.tlpLeft.ResumeLayout(false);
            this.groupBoxRender.ResumeLayout(false);
            this.groupBoxThumbnails.ResumeLayout(false);
            this.tlpRight.ResumeLayout(false);
            this.groupBoxDefectList.ResumeLayout(false);
            this.tlpCompare.ResumeLayout(false);
            this.groupBoxDefectDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbDefectDetail)).EndInit();
            this.groupBoxStandardDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbStandardDetail)).EndInit();
            this.pnlConfig.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBoxFlow.ResumeLayout(false);
            this.groupBoxConfigTop.ResumeLayout(false);
            this.groupBoxConfigTop.PerformLayout();
            this.pnlLogs.ResumeLayout(false);
            this.groupBoxLogs.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        // 自定义页面导航与容器
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Button btnNavLogs;
        private System.Windows.Forms.Button btnNavConfig;
        private System.Windows.Forms.Button btnNavDashboard;
        private System.Windows.Forms.Button btnNavModelConfig;

        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label lblUptime;
        private System.Windows.Forms.Label lblYield;
        private System.Windows.Forms.Label lblNG;
        private System.Windows.Forms.Label lblOK;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button Scheme_run;
        private System.Windows.Forms.Button btnContinuousRun;
        private System.Windows.Forms.Button btnStopRun;
        private System.Windows.Forms.Button btnImportSample;

        private System.Windows.Forms.Panel pnlMain;

        // 子页面1：监控看板
        private System.Windows.Forms.Panel pnlDashboard;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpLeft;
        private System.Windows.Forms.TableLayoutPanel tlpRight;
        private System.Windows.Forms.TableLayoutPanel tlpCompare;

        private System.Windows.Forms.GroupBox groupBoxRender;
        private VMControls.Winform.Release.VmRenderControl vmRenderControl1;

        private System.Windows.Forms.GroupBox groupBoxThumbnails;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelThumbnails;
        private System.Windows.Forms.Button btnSelectImages;

        private System.Windows.Forms.GroupBox groupBoxDefectList;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelDefects;

        private System.Windows.Forms.GroupBox groupBoxDefectDetail;
        private System.Windows.Forms.PictureBox pbDefectDetail;
        private System.Windows.Forms.GroupBox groupBoxStandardDetail;
        private System.Windows.Forms.PictureBox pbStandardDetail;

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

        // 子页面3：建模配置
        private System.Windows.Forms.Panel pnlModelConfig;

        // 子页面4：系统日志
        private System.Windows.Forms.Panel pnlLogs;
        private System.Windows.Forms.GroupBox groupBoxLogs;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private VMControls.Winform.Release.VmRenderControl vmRenderControl2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
    }
}