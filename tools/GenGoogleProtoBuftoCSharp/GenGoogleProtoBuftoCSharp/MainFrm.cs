using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using GenGoogleProtoBuftoAS3.Helpers;
using System.Threading;

namespace GenGoogleProtoBuftoAS3
{
    public partial class MainFrm : Form
    {

        private int mCount = 0;
        private int mFilesCount = 0;
        public MainFrm()
        {
            InitializeComponent();
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            doSelectFolder();
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            this.lblStatus.ForeColor = Color.Red;
            this.lblStatus.Text = "转换中.......";
            Thread convertThread = new Thread(doConvert);
            convertThread.Start();
            this.btnGen.Enabled = false;
        }

        private void doConvert()
        {

            if (this.txtOutputPath.Text.Trim() == string.Empty || this.txtFolderPath.Text.Trim() == string.Empty)
            {
                MessageBox.Show("输入或输出路径不能为空！");
                setGenBtnEnabled(true);
                return;
            }

            if (this.txtFolderPath.Text.Trim() != string.Empty)
            {
                if (!Directory.Exists(txtFolderPath.Text.Trim()))
                {
                    MessageBox.Show("请选择或输入正确的协议文件路径");
                    setGenBtnEnabled(true);
                    return;
                }
                List<string> vProtoFiles = getProtoFiles(this.txtFolderPath.Text.Trim());
                mFilesCount = vProtoFiles.Count;
                if (mFilesCount > 0)
                {
                    IOHelper.UpdateConfiguration("InputPath", this.txtFolderPath.Text.Trim());
                    IOHelper.UpdateConfiguration("OutputPath", this.txtOutputPath.Text.Trim());
                }
                else
                {
                    MessageBox.Show("所选的文件夹中没有proto文件！");
                    return;
                }
                if (Directory.Exists(txtOutputPath.Text.Trim()))
                {
                    doStartConvertTask(vProtoFiles, this.txtFolderPath.Text.Trim(), this.txtOutputPath.Text.Trim());
                }
                else
                {
                    try
                    {
                        Directory.CreateDirectory(txtOutputPath.Text.Trim());
                        doStartConvertTask(vProtoFiles, this.txtFolderPath.Text.Trim(), this.txtOutputPath.Text.Trim());
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("请选择或输入正确的输出目录！");
                        setGenBtnEnabled(true);
                    }
                }
            }
            else
            {
                if (MessageBox.Show("没有选择文件夹！") == DialogResult.OK)
                {
                    doSelectFolder();
                }

            }
        }

        private void setGenBtnEnabled(bool pValue)
        {
            this.Invoke(new Action(() =>
                {
                    this.btnGen.Enabled = pValue;
                }));
        }

        private void doStartConvertTask(List<string> pFiles, string pInputPath, string pOutputPath)
        {
            foreach (var o in pFiles)
            {
                //string vFileName = "person.proto";
                Process vProcess = new Process();
                vProcess.Exited += vProcess_Exited;
                ProcessStartInfo vProcessInfo = new ProcessStartInfo();
                vProcessInfo.FileName = "ProtoGen.exe";
                vProcessInfo.Arguments = " " + o + " --proto_path=" + pInputPath + " --include_imports -output_directory=" + pOutputPath;
                vProcessInfo.UseShellExecute = false;
                vProcessInfo.CreateNoWindow = true;
                Debug.WriteLine(vProcessInfo.FileName + " " + vProcessInfo.Arguments);
                vProcess.StartInfo = vProcessInfo;
                vProcess.EnableRaisingEvents = true;
                vProcess.OutputDataReceived += vProcess_OutputDataReceived;
                vProcess.Start();
                vProcess.WaitForExit();
            }
        }

        void vProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {

        }

        private void vProcess_Exited(object sender, EventArgs e)
        {
            ++mCount;
            Debug.Print("start order:{0}", mCount);
            if (mCount == mFilesCount)
            {
                mCount = 0;
                this.Invoke(new Action(() =>
                    {
                        this.lblStatus.ForeColor = Color.Green;
                        this.lblStatus.Text = "转换完成";
                        this.btnGen.Enabled = true;
                    }
                ));
            }
        }

        /// <summary>
        /// 选择文件夹
        /// </summary>
        private void doSelectFolder()
        {
            if (fbdProtoFilesSelecter.ShowDialog() == DialogResult.OK)
            {
                txtFolderPath.Text = fbdProtoFilesSelecter.SelectedPath;
                IOHelper.UpdateConfiguration("InputPath", fbdProtoFilesSelecter.SelectedPath);
            }
        }

        private List<string> getProtoFiles(string filePath)
        {
            List<string> vResultList = new List<string>();
            DirectoryInfo vDirInfo = new DirectoryInfo(filePath);
            FileInfo[] vFileInfos = vDirInfo.GetFiles("*", SearchOption.AllDirectories);
            foreach (var o in vFileInfos)
            {
                if (o.FullName.Contains(".proto"))
                {
                    vResultList.Add(o.FullName);
                }
            }
            return vResultList;
        }

        private void btnOutputSelecter_Click(object sender, EventArgs e)
        {
            if (fbdOutputFolder.ShowDialog() == DialogResult.OK)
            {
                txtOutputPath.Text = fbdOutputFolder.SelectedPath;
                IOHelper.UpdateConfiguration("OutputPath", fbdOutputFolder.SelectedPath);
            }
        }

        private void txtFolderPath_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["InputPath"] != null)
            {
                this.txtFolderPath.Text = IOHelper.GetConfiguration("InputPath");
            }
            if (ConfigurationManager.AppSettings["OutputPath"] != null)
            {
                this.txtOutputPath.Text = IOHelper.GetConfiguration("OutputPath");
            }
        }
    }
}
