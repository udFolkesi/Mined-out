
namespace Lab1_GUI
{
    partial class MenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.startGame_bttn = new System.Windows.Forms.Button();
            this.rate_bttn = new System.Windows.Forms.Button();
            this.settings_bttn = new System.Windows.Forms.Button();
            this.exit_bttn = new System.Windows.Forms.Button();
            this.player1_bttn = new System.Windows.Forms.Button();
            this.player2_bttn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.MenuLabel = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // startGame_bttn
            // 
            this.startGame_bttn.Location = new System.Drawing.Point(359, 271);
            this.startGame_bttn.Name = "startGame_bttn";
            this.startGame_bttn.Size = new System.Drawing.Size(123, 38);
            this.startGame_bttn.TabIndex = 0;
            this.startGame_bttn.Text = "Start Game";
            this.startGame_bttn.UseVisualStyleBackColor = true;
            this.startGame_bttn.Click += new System.EventHandler(this.StartGame_bttn_Click);
            // 
            // rate_bttn
            // 
            this.rate_bttn.Location = new System.Drawing.Point(359, 315);
            this.rate_bttn.Name = "rate_bttn";
            this.rate_bttn.Size = new System.Drawing.Size(123, 38);
            this.rate_bttn.TabIndex = 1;
            this.rate_bttn.Text = "Rate";
            this.rate_bttn.UseVisualStyleBackColor = true;
            this.rate_bttn.Click += new System.EventHandler(this.Rate_bttn_Click);
            // 
            // settings_bttn
            // 
            this.settings_bttn.Location = new System.Drawing.Point(359, 359);
            this.settings_bttn.Name = "settings_bttn";
            this.settings_bttn.Size = new System.Drawing.Size(123, 38);
            this.settings_bttn.TabIndex = 2;
            this.settings_bttn.Text = "Settings";
            this.settings_bttn.UseVisualStyleBackColor = true;
            this.settings_bttn.Click += new System.EventHandler(this.Settings_bttn_Click);
            // 
            // exit_bttn
            // 
            this.exit_bttn.Location = new System.Drawing.Point(359, 403);
            this.exit_bttn.Name = "exit_bttn";
            this.exit_bttn.Size = new System.Drawing.Size(123, 38);
            this.exit_bttn.TabIndex = 3;
            this.exit_bttn.Text = "Exit";
            this.exit_bttn.UseVisualStyleBackColor = true;
            this.exit_bttn.Click += new System.EventHandler(this.Exit_bttn_Click);
            // 
            // player1_bttn
            // 
            this.player1_bttn.Location = new System.Drawing.Point(325, 271);
            this.player1_bttn.Name = "player1_bttn";
            this.player1_bttn.Size = new System.Drawing.Size(86, 38);
            this.player1_bttn.TabIndex = 4;
            this.player1_bttn.Text = "1 player";
            this.player1_bttn.UseVisualStyleBackColor = true;
            this.player1_bttn.Click += new System.EventHandler(this.Player1_bttn_Click);
            // 
            // player2_bttn
            // 
            this.player2_bttn.Location = new System.Drawing.Point(426, 271);
            this.player2_bttn.Name = "player2_bttn";
            this.player2_bttn.Size = new System.Drawing.Size(86, 38);
            this.player2_bttn.TabIndex = 5;
            this.player2_bttn.Text = "2 players";
            this.player2_bttn.UseVisualStyleBackColor = true;
            this.player2_bttn.Click += new System.EventHandler(this.Player2_bttn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Lab1_GUI.Properties.Resources.mined_out_cover2;
            this.pictureBox1.Location = new System.Drawing.Point(279, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(287, 225);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // MenuLabel
            // 
            this.MenuLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.MenuLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MenuLabel.Location = new System.Drawing.Point(400, 243);
            this.MenuLabel.Name = "MenuLabel";
            this.MenuLabel.Size = new System.Drawing.Size(45, 22);
            this.MenuLabel.TabIndex = 7;
            this.MenuLabel.Text = "Menu";
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MenuLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.player2_bttn);
            this.Controls.Add(this.player1_bttn);
            this.Controls.Add(this.exit_bttn);
            this.Controls.Add(this.settings_bttn);
            this.Controls.Add(this.rate_bttn);
            this.Controls.Add(this.startGame_bttn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MenuForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startGame_bttn;
        private System.Windows.Forms.Button rate_bttn;
        private System.Windows.Forms.Button settings_bttn;
        private System.Windows.Forms.Button exit_bttn;
        private System.Windows.Forms.Button player1_bttn;
        private System.Windows.Forms.Button player2_bttn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox MenuLabel;
    }
}

