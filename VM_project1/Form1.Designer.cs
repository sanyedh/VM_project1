namespace VM_project1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.vmProcedureConfigControl1 = new VMControls.Winform.Release.VmProcedureConfigControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.vmRenderControl1 = new VMControls.Winform.Release.VmRenderControl();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Scheme_save = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Scheme_run = new System.Windows.Forms.Button();
            this.Scheme_load = new System.Windows.Forms.Button();
            this.Select_path = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.vmParamsConfigWithRenderControl1 = new VMControls.Winform.Release.VmParamsConfigWithRenderControl();
            this.vmParamsConfigControl1 = new VMControls.Winform.Release.VmParamsConfigControl();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.vmProcedureConfigControl1);
            this.groupBox1.Location = new System.Drawing.Point(12, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(596, 506);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "流程显示区";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // vmProcedureConfigControl1
            // 
            this.vmProcedureConfigControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vmProcedureConfigControl1.Location = new System.Drawing.Point(3, 21);
            this.vmProcedureConfigControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.vmProcedureConfigControl1.Name = "vmProcedureConfigControl1";
            this.vmProcedureConfigControl1.Size = new System.Drawing.Size(590, 482);
            this.vmProcedureConfigControl1.TabIndex = 0;
// TODO: “”的代码生成失败，原因是出现异常“无效的基元类型: System.IntPtr。请考虑使用 CodeObjectCreateExpression。”。
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.vmRenderControl1);
            this.groupBox2.Location = new System.Drawing.Point(614, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(582, 503);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "图像显示区";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // vmRenderControl1
            // 
            this.vmRenderControl1.BackColor = System.Drawing.Color.Black;
            this.vmRenderControl1.CoordinateInfoVisible = true;
            this.vmRenderControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vmRenderControl1.ImageSource = null;
            this.vmRenderControl1.IsShowCustomROIMenu = false;
            this.vmRenderControl1.Location = new System.Drawing.Point(3, 21);
            this.vmRenderControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.vmRenderControl1.ModuleSource = null;
            this.vmRenderControl1.Name = "vmRenderControl1";
            this.vmRenderControl1.Size = new System.Drawing.Size(576, 479);
            this.vmRenderControl1.TabIndex = 0;
            this.vmRenderControl1.Load += new System.EventHandler(this.vmRenderControl1_Load);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Scheme_save);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.Scheme_run);
            this.groupBox3.Controls.Add(this.Scheme_load);
            this.groupBox3.Controls.Add(this.Select_path);
            this.groupBox3.Location = new System.Drawing.Point(12, 514);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(593, 228);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "方案操作区";
            // 
            // Scheme_save
            // 
            this.Scheme_save.Location = new System.Drawing.Point(367, 141);
            this.Scheme_save.Name = "Scheme_save";
            this.Scheme_save.Size = new System.Drawing.Size(140, 32);
            this.Scheme_save.TabIndex = 6;
            this.Scheme_save.Text = "方案保存";
            this.Scheme_save.UseVisualStyleBackColor = true;
            this.Scheme_save.Click += new System.EventHandler(this.Scheme_save_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(94, 47);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(331, 25);
            this.textBox1.TabIndex = 5;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "方案路径：";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Scheme_run
            // 
            this.Scheme_run.Location = new System.Drawing.Point(190, 141);
            this.Scheme_run.Name = "Scheme_run";
            this.Scheme_run.Size = new System.Drawing.Size(140, 32);
            this.Scheme_run.TabIndex = 2;
            this.Scheme_run.Text = "执行方案";
            this.Scheme_run.UseVisualStyleBackColor = true;
            this.Scheme_run.Click += new System.EventHandler(this.Scheme_run_Click);
            // 
            // Scheme_load
            // 
            this.Scheme_load.Location = new System.Drawing.Point(9, 141);
            this.Scheme_load.Name = "Scheme_load";
            this.Scheme_load.Size = new System.Drawing.Size(140, 32);
            this.Scheme_load.TabIndex = 1;
            this.Scheme_load.Text = "加载方案";
            this.Scheme_load.UseVisualStyleBackColor = true;
            this.Scheme_load.Click += new System.EventHandler(this.Scheme_load_Click);
            // 
            // Select_path
            // 
            this.Select_path.Location = new System.Drawing.Point(447, 47);
            this.Select_path.Name = "Select_path";
            this.Select_path.Size = new System.Drawing.Size(140, 25);
            this.Select_path.TabIndex = 0;
            this.Select_path.Text = "选择路径";
            this.Select_path.UseVisualStyleBackColor = true;
            this.Select_path.Click += new System.EventHandler(this.Select_path_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(6, 25);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(581, 199);
            this.listBox1.TabIndex = 3;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listBox1);
            this.groupBox4.Location = new System.Drawing.Point(617, 514);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(579, 228);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "消息显示区";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.vmParamsConfigControl1);
            this.groupBox5.Controls.Add(this.vmParamsConfigWithRenderControl1);
            this.groupBox5.Location = new System.Drawing.Point(1227, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(548, 499);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "参数配置";
            // 
            // vmParamsConfigWithRenderControl1
            // 
            this.vmParamsConfigWithRenderControl1.BackColor = System.Drawing.Color.White;
            this.vmParamsConfigWithRenderControl1.CoordinateInfoVisible = true;
            this.vmParamsConfigWithRenderControl1.ImageSource = null;
            this.vmParamsConfigWithRenderControl1.Location = new System.Drawing.Point(0, 240);
            this.vmParamsConfigWithRenderControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.vmParamsConfigWithRenderControl1.ModuleSource = null;
            this.vmParamsConfigWithRenderControl1.MultiImageButtonVisible = false;
            this.vmParamsConfigWithRenderControl1.Name = "vmParamsConfigWithRenderControl1";
            this.vmParamsConfigWithRenderControl1.ParamsConfig = null;
            this.vmParamsConfigWithRenderControl1.ROIVisible = true;
            this.vmParamsConfigWithRenderControl1.Size = new System.Drawing.Size(541, 250);
            this.vmParamsConfigWithRenderControl1.TabIndex = 0;
            // 
            // vmParamsConfigControl1
            // 
            this.vmParamsConfigControl1.BackColor = System.Drawing.Color.White;
            this.vmParamsConfigControl1.Location = new System.Drawing.Point(0, 21);
            this.vmParamsConfigControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.vmParamsConfigControl1.ModuleSource = null;
            this.vmParamsConfigControl1.Name = "vmParamsConfigControl1";
            this.vmParamsConfigControl1.ParamsConfig = null;
            this.vmParamsConfigControl1.Size = new System.Drawing.Size(538, 211);
            this.vmParamsConfigControl1.TabIndex = 1;
            this.vmParamsConfigControl1.Load += new System.EventHandler(this.vmParamsConfigControl1_Load);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1778, 754);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button Scheme_run;
        private System.Windows.Forms.Button Scheme_load;
        private System.Windows.Forms.Button Select_path;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private VMControls.Winform.Release.VmProcedureConfigControl vmProcedureConfigControl1;
        private VMControls.Winform.Release.VmRenderControl vmRenderControl1;
        private System.Windows.Forms.Button Scheme_save;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private VMControls.Winform.Release.VmParamsConfigWithRenderControl vmParamsConfigWithRenderControl1;
        private VMControls.Winform.Release.VmParamsConfigControl vmParamsConfigControl1;
    }
}