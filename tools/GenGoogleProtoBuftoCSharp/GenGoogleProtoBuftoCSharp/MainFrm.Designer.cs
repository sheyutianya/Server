namespace GenGoogleProtoBuftoAS3
{
    partial class MainFrm
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.fbdProtoFilesSelecter = new System.Windows.Forms.FolderBrowserDialog();
            this.btnGen = new System.Windows.Forms.Button();
            this.txtFolderPath = new System.Windows.Forms.TextBox();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.fbdOutputFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.lblProtoFolder = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOutputSelecter = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fbdProtoFilesSelecter
            // 
            this.fbdProtoFilesSelecter.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // btnGen
            // 
            this.btnGen.Location = new System.Drawing.Point(378, 128);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(75, 23);
            this.btnGen.TabIndex = 0;
            this.btnGen.Text = "生成";
            this.btnGen.UseVisualStyleBackColor = true;
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            // 
            // txtFolderPath
            // 
            this.txtFolderPath.AllowDrop = true;
            this.txtFolderPath.Location = new System.Drawing.Point(12, 35);
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.Size = new System.Drawing.Size(360, 21);
            this.txtFolderPath.TabIndex = 1;
            this.txtFolderPath.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtFolderPath_DragDrop);
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Location = new System.Drawing.Point(378, 33);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(75, 23);
            this.btnSelectFolder.TabIndex = 2;
            this.btnSelectFolder.Text = "选择";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // fbdOutputFolder
            // 
            this.fbdOutputFolder.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Location = new System.Drawing.Point(12, 79);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.Size = new System.Drawing.Size(360, 21);
            this.txtOutputPath.TabIndex = 3;
            // 
            // lblProtoFolder
            // 
            this.lblProtoFolder.AutoSize = true;
            this.lblProtoFolder.Location = new System.Drawing.Point(10, 20);
            this.lblProtoFolder.Name = "lblProtoFolder";
            this.lblProtoFolder.Size = new System.Drawing.Size(101, 12);
            this.lblProtoFolder.TabIndex = 4;
            this.lblProtoFolder.Text = "协议文件夹路径：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "CS文件输出文件夹路径：";
            // 
            // btnOutputSelecter
            // 
            this.btnOutputSelecter.Location = new System.Drawing.Point(378, 77);
            this.btnOutputSelecter.Name = "btnOutputSelecter";
            this.btnOutputSelecter.Size = new System.Drawing.Size(75, 23);
            this.btnOutputSelecter.TabIndex = 6;
            this.btnOutputSelecter.Text = "选择";
            this.btnOutputSelecter.UseVisualStyleBackColor = true;
            this.btnOutputSelecter.Click += new System.EventHandler(this.btnOutputSelecter_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStatus.Location = new System.Drawing.Point(18, 122);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(42, 16);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "待命";
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 163);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnOutputSelecter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblProtoFolder);
            this.Controls.Add(this.txtOutputPath);
            this.Controls.Add(this.btnSelectFolder);
            this.Controls.Add(this.txtFolderPath);
            this.Controls.Add(this.btnGen);
            this.MaximizeBox = false;
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "协议生成CSharp";
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog fbdProtoFilesSelecter;
        private System.Windows.Forms.Button btnGen;
        private System.Windows.Forms.TextBox txtFolderPath;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.FolderBrowserDialog fbdOutputFolder;
        private System.Windows.Forms.TextBox txtOutputPath;
        private System.Windows.Forms.Label lblProtoFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOutputSelecter;
        private System.Windows.Forms.Label lblStatus;
    }
}

