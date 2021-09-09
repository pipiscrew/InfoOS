namespace InfoOS
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabStartup = new System.Windows.Forms.TabPage();
            this.tabProcesses = new System.Windows.Forms.TabPage();
            this.tabFolderSizes = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabStartup);
            this.tabControl1.Controls.Add(this.tabProcesses);
            this.tabControl1.Controls.Add(this.tabFolderSizes);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(896, 494);
            this.tabControl1.TabIndex = 0;
            // 
            // tabStartup
            // 
            this.tabStartup.Location = new System.Drawing.Point(4, 24);
            this.tabStartup.Name = "tabStartup";
            this.tabStartup.Padding = new System.Windows.Forms.Padding(3);
            this.tabStartup.Size = new System.Drawing.Size(888, 466);
            this.tabStartup.TabIndex = 0;
            this.tabStartup.Text = "Startup";
            this.tabStartup.UseVisualStyleBackColor = true;
            // 
            // tabProcesses
            // 
            this.tabProcesses.Location = new System.Drawing.Point(4, 24);
            this.tabProcesses.Name = "tabProcesses";
            this.tabProcesses.Padding = new System.Windows.Forms.Padding(3);
            this.tabProcesses.Size = new System.Drawing.Size(886, 428);
            this.tabProcesses.TabIndex = 1;
            this.tabProcesses.Text = "Processes";
            this.tabProcesses.UseVisualStyleBackColor = true;
            // 
            // tabFolderSizes
            // 
            this.tabFolderSizes.Location = new System.Drawing.Point(4, 24);
            this.tabFolderSizes.Name = "tabFolderSizes";
            this.tabFolderSizes.Size = new System.Drawing.Size(886, 428);
            this.tabFolderSizes.TabIndex = 2;
            this.tabFolderSizes.Text = "Folder Sizes";
            this.tabFolderSizes.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 494);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabStartup;
        private System.Windows.Forms.TabPage tabProcesses;
        private System.Windows.Forms.TabPage tabFolderSizes;
    }
}