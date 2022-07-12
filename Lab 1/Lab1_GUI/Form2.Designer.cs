
namespace Lab1_GUI
{
    partial class Form2
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
            textBox1 = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.textBox1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox1.Enabled = false;
            this.textBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBox1.Location = new System.Drawing.Point(544, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(234, 111);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "You can use arrows(◄ ►▲▼) for move\r\nRestart - press R\r\nTo show hint press.. \r\nAdd" +
    "itional life - $\r\nBack - press B\r\nIf you want to finish game press Esc";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            label1.Location = new System.Drawing.Point(593, 136);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(64, 17);
            label1.TabIndex = 1;
            label1.Text = "00:00:00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(544, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Time:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(547, 157);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(47, 17);
            label3.TabIndex = 3;
            label3.Text = "Life: 0";
            // 
            // Form2
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ControlText;
            ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(label1);
            this.Controls.Add(this.textBox1);
            ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            Name = "Form2";
            Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        public static System.Windows.Forms.Label label3;
        public static System.Windows.Forms.Label label1;
    }
}