using System;
using System.Windows.Forms;
using VM.Core;
using VM.PlatformSDKCS;
using System.Diagnostics;
using System.Linq;

namespace VM_project1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            KillProcess("VisionMasterServerApp"); 
            KillProcess("VisionMaster");
            KillProcess("VmModuleProxy.exe");

            InitializeComponent();
        }

        private void KillProcess(string processName)
        {
            if (string.IsNullOrEmpty(processName)) return;

            // 移除可能的.exe后缀
            processName = processName.Replace(".exe", "");

            Process[] processes = Process.GetProcessesByName(processName);
            foreach (Process process in processes)
            {
                try
                {
                    if (!process.HasExited)
                    {
                        process.Kill();
                        process.WaitForExit(3000); // 等待3秒确保进程退出
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"终止进程 {processName} 失败：{ex.Message}");
                }
            }
        }

        // 移除无意义的空事件方法（减少冗余）
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void vmRenderControl1_Load(object sender, EventArgs e) { }
        private void groupBox2_Enter(object sender, EventArgs e) { }

        /*
         * 选择路径（修改方法名避免与控件名冲突）
         */
        private void Select_path_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
                {
                    openFileDialog1.Filter = "VM SOL File|*.sol";
                    openFileDialog1.Title = "选择VM方案文件";
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        textBox1.Text = openFileDialog1.FileName;
                        AddLog("选择路径成功：" + openFileDialog1.FileName);
                    }
                    else
                    {
                        AddLog("取消选择路径");
                    }
                }
            }
            catch (Exception ex)
            {
                AddLog("选择路径失败：" + ex.Message);
                MessageBox.Show("选择路径出错：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*
         * 加载方案（修改方法名+增加空路径校验+异常处理）
         */
        private void Scheme_load_Click(object sender, EventArgs e)
        {
            try
            {
                // 校验路径是否为空
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    AddLog("加载方案失败：未选择方案路径");
                    MessageBox.Show("请先选择方案文件路径！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 加载方案
                VmSolution.Load(textBox1.Text);
                AddLog("加载方案成功：" + textBox1.Text);
            }
            catch (Exception ex)
            {
                AddLog("加载方案失败：" + ex.Message);
                MessageBox.Show("加载方案出错：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*
         * 方案执行一次（修改方法名+增加实例校验）
         */
        private void Scheme_run_Click(object sender, EventArgs e)
        {
            try
            {
                // 校验方案是否已加载
                if (VmSolution.Instance == null)
                {
                    AddLog("执行方案失败：未加载任何方案");
                    MessageBox.Show("请先加载方案！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // 模块参数配置
                // 1. 先获取对象，不急于转换
                object ocrObject = VmSolution.Instance["流程1.字符识别1"];

                // 2. 验证对象类型（调试/排查用，可保留也可删除）
                if (ocrObject == null)
                {
                    AddLog("错误：未找到名为'流程1.字符识别1'的模块");
                    return;
                }
                AddLog($"实际对象类型：{ocrObject.GetType().FullName}"); // 改为用AddLog打印到日志框，更直观

                // 3. 安全转换：改为实际的IMVSOcrModuTool类型
                IMVSOcrModuCs.IMVSOcrModuTool ocrTool = ocrObject as IMVSOcrModuCs.IMVSOcrModuTool;

                // 4. 检查转换结果
                if (ocrTool == null)
                {
                    AddLog($"错误：无法将 {ocrObject.GetType().FullName} 转换为 IMVSOcrModuCs.IMVSOcrModuTool");
                    return;
                }

                // 5. 正常赋值
                vmParamsConfigWithRenderControl1.ModuleSource = ocrTool; /// 带渲染的参数配置控件

                vmParamsConfigControl1.ModuleSource = ocrTool; // 不带渲染的参数配置控件 

                VmSolution.Instance.SyncRun();
                AddLog("方案执行一次成功");

                // 获取结果 分为渲染结果和数据结果
                VmProcedure vmProcess1 = null;
                try
                {
                    // 尝试获取流程1，用try-catch替代ContainsKey判断流程是否存在
                    vmProcess1 = (VmProcedure)VmSolution.Instance["流程1"];
                }
                catch
                {
                    AddLog("获取结果失败：未找到名为「流程1」的流程");
                    MessageBox.Show("未找到「流程1」流程，请检查流程名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 绑定渲染控件（增加控件非空校验）
                if (vmRenderControl1 != null)
                {
                    vmRenderControl1.ModuleSource = vmProcess1; // 显示源绑定流程1对象
                    AddLog("渲染控件绑定流程1成功");
                }

                // 安全获取OCR字符串结果（解决结构体不能判null问题）
                string ocrResult = "无数据";
                if (vmProcess1?.ModuResult != null)
                {
                    // StringDataArray是结构体，不判null，直接获取后检查数组
                    var strOutput = vmProcess1.ModuResult.GetOutputString("out");
                    if (strOutput.astStringVal != null && strOutput.astStringVal.Length > 0)
                    {
                        ocrResult = strOutput.astStringVal[0].strValue ?? "空";
                    }
                    else
                    {
                        AddLog("字符识别结果：输出参数「out」无数据");
                    }
                }

                // 安全获取OCR整数结果（解决结构体不能判null问题）
                string ocrNum = "无数据";
                if (vmProcess1.ModuResult != null)
                {
                    // IntDataArray是结构体，不判null，直接获取后检查数组
                    var intOutput = vmProcess1.ModuResult.GetOutputInt("out0");
                    if (intOutput.pIntVal != null && intOutput.pIntVal.Length > 0)
                    {
                        ocrNum = intOutput.pIntVal[0].ToString();
                    }
                    else
                    {
                        AddLog("字符识别数量：输出参数「out0」无数据");
                    }
                }

                // 输出结果到列表（复用AddLog方法，简化代码）
                AddLog("字符识别结果：" + ocrResult);
                AddLog("字符识别数量：" + ocrNum);

            }
            catch (Exception ex)
            {
                AddLog("执行方案失败：" + ex.Message);
                MessageBox.Show("执行方案出错：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*
         * 保存方案（修改方法名+增加校验）
         */
        private void Scheme_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (VmSolution.Instance == null)
                {
                    AddLog("保存方案失败：未加载任何方案");
                    MessageBox.Show("请先加载方案！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                VmSolution.Save();
                AddLog("保存方案成功：" + textBox1.Text);
            }
            catch (Exception ex)
            {
                AddLog("保存方案失败：" + ex.Message);
                MessageBox.Show("保存方案出错：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 封装日志添加方法（简化代码）
        /// </summary>
        /// <param name="message">日志信息</param>
        private void AddLog(string message)
        {
            listBox1.Items.Add($"[{DateTime.Now:HH:mm:ss}] {message}");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }

        private void vmParamsConfigControl1_Load(object sender, EventArgs e)
        {
             
        }
    }
}