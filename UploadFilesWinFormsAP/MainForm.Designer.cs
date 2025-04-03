namespace UploadFilesWinFormsAP
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            openImgFileDialog = new OpenFileDialog();
            btnSelectImgs = new Button();
            btnUpload = new Button();
            txtMessage = new RichTextBox();
            tabMain = new TabControl();
            tabUpload = new TabPage();
            tabAlbum = new TabPage();
            tabPage3 = new TabPage();
            tabMain.SuspendLayout();
            tabUpload.SuspendLayout();
            SuspendLayout();
            // 
            // openImgFileDialog
            // 
            openImgFileDialog.FileName = "openFileDialog1";
            openImgFileDialog.Multiselect = true;
            // 
            // btnSelectImgs
            // 
            btnSelectImgs.Location = new Point(50, 50);
            btnSelectImgs.Name = "btnSelectImgs";
            btnSelectImgs.Size = new Size(188, 58);
            btnSelectImgs.TabIndex = 0;
            btnSelectImgs.Text = "選擇檔案";
            btnSelectImgs.UseVisualStyleBackColor = true;
            btnSelectImgs.Click += btnSelectImgs_Click;
            // 
            // btnUpload
            // 
            btnUpload.Location = new Point(285, 50);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(188, 58);
            btnUpload.TabIndex = 1;
            btnUpload.Text = "上傳";
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += btnUpload_Click;
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(50, 196);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(2061, 1152);
            txtMessage.TabIndex = 2;
            txtMessage.Text = "";
            // 
            // tabMain
            // 
            tabMain.Controls.Add(tabUpload);
            tabMain.Controls.Add(tabAlbum);
            tabMain.Controls.Add(tabPage3);
            tabMain.Location = new Point(26, 12);
            tabMain.Name = "tabMain";
            tabMain.SelectedIndex = 0;
            tabMain.Size = new Size(2174, 1466);
            tabMain.TabIndex = 3;
            // 
            // tabUpload
            // 
            tabUpload.Controls.Add(txtMessage);
            tabUpload.Controls.Add(btnUpload);
            tabUpload.Controls.Add(btnSelectImgs);
            tabUpload.Location = new Point(10, 55);
            tabUpload.Name = "tabUpload";
            tabUpload.Padding = new Padding(3);
            tabUpload.Size = new Size(2154, 1401);
            tabUpload.TabIndex = 0;
            tabUpload.Text = "上傳檔案";
            tabUpload.UseVisualStyleBackColor = true;
            // 
            // tabAlbum
            // 
            tabAlbum.Location = new Point(10, 55);
            tabAlbum.Name = "tabAlbum";
            tabAlbum.Padding = new Padding(3);
            tabAlbum.Size = new Size(2154, 1401);
            tabAlbum.TabIndex = 1;
            tabAlbum.Text = "相簿功能";
            tabAlbum.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(10, 55);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(2154, 1401);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "tabPage3";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(18F, 38F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2223, 1490);
            Controls.Add(tabMain);
            Name = "MainForm";
            Text = "主視窗";
            Load += Form1_Load;
            tabMain.ResumeLayout(false);
            tabUpload.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private OpenFileDialog openImgFileDialog;
        private Button btnSelectImgs;
        private Button btnUpload;
        private RichTextBox txtMessage;
        private TabControl tabMain;
        private TabPage tabUpload;
        private TabPage tabAlbum;
        private TabPage tabPage3;
    }
}
