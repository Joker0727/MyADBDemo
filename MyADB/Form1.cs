using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyADB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string commandStr = this.textBox1.Text;
            if (string.IsNullOrEmpty(commandStr))
            {
                MessageBox.Show("请输入命令！","adb提示");
                return;
            }

            string adbResult = RunAdbCommand(commandStr);
            this.richTextBox1.Text = adbResult;
        }

        /// <summary>
        /// 执行adb命令
        /// </summary>
        /// <param name="commandStr">执行的命令参数</param>
        /// <returns></returns>
        public string RunAdbCommand(string commandStr)
        {
            string adbResult = string.Empty;
            try
            {
                String cmd = Application.StartupPath + "\\adb\\adb.exe";
                Process p = new Process();
                p.StartInfo.FileName = cmd;           //设定程序名   
                p.StartInfo.Arguments = commandStr;    //设定程式执行參數   
                p.StartInfo.UseShellExecute = false;        //关闭Shell的使用   
                p.StartInfo.RedirectStandardInput = true;   //重定向标准输入   
                p.StartInfo.RedirectStandardOutput = true;  //重定向标准输出   
                p.StartInfo.RedirectStandardError = true;   //重定向错误输出   
                p.StartInfo.CreateNoWindow = true;          //设置不显示窗口   
                p.Start();
                adbResult = p.StandardOutput.ReadToEnd();
                p.Close();
            }
            catch (Exception ex)
            {
                adbResult = ex.ToString();
            }
            return adbResult;
        }
    }
}
