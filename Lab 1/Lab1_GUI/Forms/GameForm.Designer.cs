
namespace Lab1_GUI
{
    partial class GameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.timeNumbers_label = new System.Windows.Forms.Label();
            this.time_label = new System.Windows.Forms.Label();
            this.life_label = new System.Windows.Forms.Label();
            this.rules_lbl = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameOptions_stripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.backToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelPlayer1 = new System.Windows.Forms.Label();
            this.labelPlayer2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timeNumbers_label
            // 
            this.timeNumbers_label.AutoSize = true;
            this.timeNumbers_label.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.timeNumbers_label.Location = new System.Drawing.Point(593, 117);
            this.timeNumbers_label.Name = "timeNumbers_label";
            this.timeNumbers_label.Size = new System.Drawing.Size(64, 17);
            this.timeNumbers_label.TabIndex = 1;
            this.timeNumbers_label.Text = "00:00:00";
            // 
            // time_label
            // 
            this.time_label.AutoSize = true;
            this.time_label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.time_label.Location = new System.Drawing.Point(542, 117);
            this.time_label.Name = "time_label";
            this.time_label.Size = new System.Drawing.Size(43, 17);
            this.time_label.TabIndex = 2;
            this.time_label.Text = "Time:";
            // 
            // life_label
            // 
            this.life_label.AutoSize = true;
            this.life_label.Location = new System.Drawing.Point(542, 147);
            this.life_label.Name = "life_label";
            this.life_label.Size = new System.Drawing.Size(47, 17);
            this.life_label.TabIndex = 3;
            this.life_label.Text = "Life: 0";
            // 
            // rules_lbl
            // 
            this.rules_lbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.rules_lbl.Location = new System.Drawing.Point(545, 9);
            this.rules_lbl.Name = "rules_lbl";
            this.rules_lbl.Size = new System.Drawing.Size(243, 97);
            this.rules_lbl.TabIndex = 4;
            this.rules_lbl.Text = "Your goal is to reach the finish line\r\nwithout getting blown up by mines,\r\nwhich " +
    "amount indicates as player\r\nUse arrows for move\r\nGood luck!:)";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameOptions_stripMenu});
            this.menuStrip1.Location = new System.Drawing.Point(606, 173);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(124, 28);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameOptions_stripMenu
            // 
            this.gameOptions_stripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.backToolStripMenuItem});
            this.gameOptions_stripMenu.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gameOptions_stripMenu.Name = "gameOptions_stripMenu";
            this.gameOptions_stripMenu.Size = new System.Drawing.Size(116, 24);
            this.gameOptions_stripMenu.Text = "Game options";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(166, 26);
            this.toolStripMenuItem2.Text = "Main Menu";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(166, 26);
            this.toolStripMenuItem3.Text = "Restart";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // backToolStripMenuItem
            // 
            this.backToolStripMenuItem.Name = "backToolStripMenuItem";
            this.backToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.backToolStripMenuItem.Text = "Pause";
            this.backToolStripMenuItem.Click += new System.EventHandler(this.backToolStripMenuItem_Click);
            // 
            // labelPlayer1
            // 
            this.labelPlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPlayer1.Location = new System.Drawing.Point(168, 147);
            this.labelPlayer1.Name = "labelPlayer1";
            this.labelPlayer1.Size = new System.Drawing.Size(15, 15);
            this.labelPlayer1.TabIndex = 8;
            this.labelPlayer1.Text = "0";
            this.labelPlayer1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPlayer2
            // 
            this.labelPlayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPlayer2.Location = new System.Drawing.Point(251, 147);
            this.labelPlayer2.Name = "labelPlayer2";
            this.labelPlayer2.Size = new System.Drawing.Size(15, 15);
            this.labelPlayer2.TabIndex = 9;
            this.labelPlayer2.Text = "0";
            this.labelPlayer2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(800, 474);
            this.Controls.Add(this.labelPlayer2);
            this.Controls.Add(this.labelPlayer1);
            this.Controls.Add(this.rules_lbl);
            this.Controls.Add(this.life_label);
            this.Controls.Add(this.time_label);
            this.Controls.Add(this.timeNumbers_label);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GameForm";
            this.Text = "Form2";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label time_label;
        private System.Windows.Forms.Label rules_lbl;
        public System.Windows.Forms.Label life_label;
        public System.Windows.Forms.Label timeNumbers_label;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameOptions_stripMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.Label labelPlayer1;
        private System.Windows.Forms.Label labelPlayer2;
    }
}