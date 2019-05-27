namespace DemoCoCaro
{
    partial class frmCoCaro
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerVsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerVsComToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.picCocaro = new System.Windows.Forms.PictureBox();
            this.bnPvP = new System.Windows.Forms.Button();
            this.bnPvC = new System.Windows.Forms.Button();
            this.bnExit = new System.Windows.Forms.Button();
            this.bnCreate = new System.Windows.Forms.Button();
            this.pnBanCo = new System.Windows.Forms.Panel();
            this.tmChuChay = new System.Windows.Forms.Timer(this.components);
            this.pnLaw = new System.Windows.Forms.Panel();
            this.lbChuChay = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCocaro)).BeginInit();
            this.pnLaw.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.eToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(732, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(45, 24);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playerVsToolStripMenuItem,
            this.playerVsComToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.newToolStripMenuItem.Text = "&New";
            // 
            // playerVsToolStripMenuItem
            // 
            this.playerVsToolStripMenuItem.Name = "playerVsToolStripMenuItem";
            this.playerVsToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.playerVsToolStripMenuItem.Text = "Player vs Player";
            this.playerVsToolStripMenuItem.Click += new System.EventHandler(this.PvP);
            // 
            // playerVsComToolStripMenuItem
            // 
            this.playerVsComToolStripMenuItem.Name = "playerVsComToolStripMenuItem";
            this.playerVsComToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.playerVsComToolStripMenuItem.Text = "Player vs Com";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.exitToolStripMenuItem.Text = "&Exit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.undoToolStripMenuItem.Text = "&Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.redoToolStripMenuItem.Text = "&Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // eToolStripMenuItem
            // 
            this.eToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.eToolStripMenuItem.Name = "eToolStripMenuItem";
            this.eToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.eToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.aboutToolStripMenuItem.Text = "&About";
            // 
            // picCocaro
            // 
            this.picCocaro.BackgroundImage = global::DemoCoCaro.Properties.Resources.cocaro;
            this.picCocaro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picCocaro.Location = new System.Drawing.Point(12, 52);
            this.picCocaro.Name = "picCocaro";
            this.picCocaro.Size = new System.Drawing.Size(180, 180);
            this.picCocaro.TabIndex = 1;
            this.picCocaro.TabStop = false;
            // 
            // bnPvP
            // 
            this.bnPvP.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnPvP.Location = new System.Drawing.Point(12, 460);
            this.bnPvP.Name = "bnPvP";
            this.bnPvP.Size = new System.Drawing.Size(180, 28);
            this.bnPvP.TabIndex = 3;
            this.bnPvP.Text = "Player vs Player";
            this.bnPvP.UseVisualStyleBackColor = true;
            // 
            // bnPvC
            // 
            this.bnPvC.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnPvC.Location = new System.Drawing.Point(12, 494);
            this.bnPvC.Name = "bnPvC";
            this.bnPvC.Size = new System.Drawing.Size(180, 28);
            this.bnPvC.TabIndex = 4;
            this.bnPvC.Text = "Player vs COM";
            this.bnPvC.UseVisualStyleBackColor = true;
            // 
            // bnExit
            // 
            this.bnExit.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnExit.Location = new System.Drawing.Point(12, 528);
            this.bnExit.Name = "bnExit";
            this.bnExit.Size = new System.Drawing.Size(90, 28);
            this.bnExit.TabIndex = 5;
            this.bnExit.Text = "Exit";
            this.bnExit.UseVisualStyleBackColor = true;
            // 
            // bnCreate
            // 
            this.bnCreate.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnCreate.Location = new System.Drawing.Point(102, 528);
            this.bnCreate.Name = "bnCreate";
            this.bnCreate.Size = new System.Drawing.Size(90, 28);
            this.bnCreate.TabIndex = 6;
            this.bnCreate.Text = "Create";
            this.bnCreate.UseVisualStyleBackColor = true;
            // 
            // pnBanCo
            // 
            this.pnBanCo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.pnBanCo.Location = new System.Drawing.Point(211, 52);
            this.pnBanCo.Name = "pnBanCo";
            this.pnBanCo.Size = new System.Drawing.Size(501, 495);
            this.pnBanCo.TabIndex = 7;
            this.pnBanCo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnBanCo_Paint);
            this.pnBanCo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnBanCo_MouseClick);
            // 
            // tmChuChay
            // 
            this.tmChuChay.Interval = 25;
            this.tmChuChay.Tick += new System.EventHandler(this.tmChuChay_Tick);
            // 
            // pnLaw
            // 
            this.pnLaw.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnLaw.Controls.Add(this.lbChuChay);
            this.pnLaw.Location = new System.Drawing.Point(12, 238);
            this.pnLaw.Name = "pnLaw";
            this.pnLaw.Size = new System.Drawing.Size(180, 216);
            this.pnLaw.TabIndex = 8;
            // 
            // lbChuChay
            // 
            this.lbChuChay.AutoSize = true;
            this.lbChuChay.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbChuChay.Location = new System.Drawing.Point(3, 195);
            this.lbChuChay.Name = "lbChuChay";
            this.lbChuChay.Size = new System.Drawing.Size(0, 19);
            this.lbChuChay.TabIndex = 0;
            // 
            // frmCoCaro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(732, 567);
            this.Controls.Add(this.pnLaw);
            this.Controls.Add(this.pnBanCo);
            this.Controls.Add(this.bnCreate);
            this.Controls.Add(this.bnExit);
            this.Controls.Add(this.bnPvC);
            this.Controls.Add(this.bnPvP);
            this.Controls.Add(this.picCocaro);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmCoCaro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Caro";
            this.Load += new System.EventHandler(this.frmCoCaro_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCocaro)).EndInit();
            this.pnLaw.ResumeLayout(false);
            this.pnLaw.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playerVsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playerVsComToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.PictureBox picCocaro;
        private System.Windows.Forms.Button bnPvP;
        private System.Windows.Forms.Button bnPvC;
        private System.Windows.Forms.Button bnExit;
        private System.Windows.Forms.Button bnCreate;
        private System.Windows.Forms.Panel pnBanCo;
        private System.Windows.Forms.Timer tmChuChay;
        private System.Windows.Forms.Panel pnLaw;
        private System.Windows.Forms.Label lbChuChay;
    }
}

