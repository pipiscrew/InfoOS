namespace InfoOS
{
    partial class frmStartupItem
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
            this.components = new System.ComponentModel.Container();
            this.lstv = new System.Windows.Forms.ListView();
            this.colTarget = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFilepath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextM = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripCopyTarget = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripFilepath = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripCopyAll = new System.Windows.Forms.ToolStripMenuItem();
            this.imgL = new System.Windows.Forms.ImageList(this.components);
            this.contextM.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstv
            // 
            this.lstv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTarget,
            this.colFilepath,
            this.colLocation});
            this.lstv.ContextMenuStrip = this.contextM;
            this.lstv.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lstv.FullRowSelect = true;
            this.lstv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstv.Location = new System.Drawing.Point(15, 17);
            this.lstv.Name = "lstv";
            this.lstv.Size = new System.Drawing.Size(856, 435);
            this.lstv.SmallImageList = this.imgL;
            this.lstv.TabIndex = 0;
            this.lstv.UseCompatibleStateImageBehavior = false;
            this.lstv.View = System.Windows.Forms.View.Details;
            // 
            // colTarget
            // 
            this.colTarget.Text = "Target";
            this.colTarget.Width = 150;
            // 
            // colFilepath
            // 
            this.colFilepath.Text = "Filepath";
            this.colFilepath.Width = 500;
            // 
            // colLocation
            // 
            this.colLocation.Text = "Location";
            this.colLocation.Width = 150;
            // 
            // contextM
            // 
            this.contextM.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripCopyTarget,
            this.toolStripFilepath,
            this.toolStripLocation,
            this.toolStripSeparator1,
            this.toolStripCopyAll});
            this.contextM.Name = "contextM";
            this.contextM.Size = new System.Drawing.Size(152, 98);
            // 
            // toolStripCopyTarget
            // 
            this.toolStripCopyTarget.Name = "toolStripCopyTarget";
            this.toolStripCopyTarget.Size = new System.Drawing.Size(151, 22);
            this.toolStripCopyTarget.Text = "Copy Target";
            this.toolStripCopyTarget.Click += new System.EventHandler(this.toolStripCopyTarget_Click);
            // 
            // toolStripFilepath
            // 
            this.toolStripFilepath.Name = "toolStripFilepath";
            this.toolStripFilepath.Size = new System.Drawing.Size(151, 22);
            this.toolStripFilepath.Text = "Copy Filepath";
            this.toolStripFilepath.Click += new System.EventHandler(this.toolStripFilepath_Click);
            // 
            // toolStripLocation
            // 
            this.toolStripLocation.Name = "toolStripLocation";
            this.toolStripLocation.Size = new System.Drawing.Size(151, 22);
            this.toolStripLocation.Text = "Copy Location";
            this.toolStripLocation.Click += new System.EventHandler(this.toolStripLocation_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(148, 6);
            // 
            // toolStripCopyAll
            // 
            this.toolStripCopyAll.Name = "toolStripCopyAll";
            this.toolStripCopyAll.Size = new System.Drawing.Size(151, 22);
            this.toolStripCopyAll.Text = "Copy All";
            this.toolStripCopyAll.Click += new System.EventHandler(this.toolStripCopyAll_Click);
            // 
            // imgL
            // 
            this.imgL.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imgL.ImageSize = new System.Drawing.Size(16, 16);
            this.imgL.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // frmStartupItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 464);
            this.Controls.Add(this.lstv);
            this.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.Name = "frmStartupItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.contextM.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstv;
        private System.Windows.Forms.ColumnHeader colTarget;
        private System.Windows.Forms.ColumnHeader colFilepath;
        private System.Windows.Forms.ColumnHeader colLocation;
        private System.Windows.Forms.ImageList imgL;
        private System.Windows.Forms.ContextMenuStrip contextM;
        private System.Windows.Forms.ToolStripMenuItem toolStripCopyTarget;
        private System.Windows.Forms.ToolStripMenuItem toolStripFilepath;
        private System.Windows.Forms.ToolStripMenuItem toolStripLocation;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripCopyAll;
    }
}

