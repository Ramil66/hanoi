namespace Курсовая
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.roundButton1 = new Курсовая.Design.RoundButton();
            this.roundButton2 = new Курсовая.Design.RoundButton();
            this.roundButton3 = new Курсовая.Design.RoundButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat ExtraBold", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(288, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(425, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ханойские башни";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // roundButton1
            // 
            this.roundButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(138)))), ((int)(((byte)(247)))));
            this.roundButton1.ColorPen = System.Drawing.Color.Empty;
            this.roundButton1.Font = new System.Drawing.Font("Montserrat ExtraBold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.roundButton1.ForeColor = System.Drawing.Color.White;
            this.roundButton1.Location = new System.Drawing.Point(440, 292);
            this.roundButton1.Name = "roundButton1";
            this.roundButton1.Rounding = 80;
            this.roundButton1.RoundingEnable = true;
            this.roundButton1.Size = new System.Drawing.Size(120, 40);
            this.roundButton1.TabIndex = 1;
            this.roundButton1.Text = "Играть";
            this.roundButton1.UseVisualStyleBackColor = false;
            this.roundButton1.Click += new System.EventHandler(this.roundButton1_Click);
            // 
            // roundButton2
            // 
            this.roundButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(138)))), ((int)(((byte)(247)))));
            this.roundButton2.ColorPen = System.Drawing.Color.Empty;
            this.roundButton2.Font = new System.Drawing.Font("Montserrat ExtraBold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.roundButton2.ForeColor = System.Drawing.Color.White;
            this.roundButton2.Location = new System.Drawing.Point(407, 349);
            this.roundButton2.Name = "roundButton2";
            this.roundButton2.Rounding = 80;
            this.roundButton2.RoundingEnable = true;
            this.roundButton2.Size = new System.Drawing.Size(186, 40);
            this.roundButton2.TabIndex = 2;
            this.roundButton2.Text = "Сравнение алгоритмов";
            this.roundButton2.UseVisualStyleBackColor = false;
            this.roundButton2.Click += new System.EventHandler(this.roundButton2_Click);
            // 
            // roundButton3
            // 
            this.roundButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(138)))), ((int)(((byte)(247)))));
            this.roundButton3.ColorPen = System.Drawing.Color.Empty;
            this.roundButton3.Font = new System.Drawing.Font("Montserrat ExtraBold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.roundButton3.ForeColor = System.Drawing.Color.White;
            this.roundButton3.Location = new System.Drawing.Point(440, 410);
            this.roundButton3.Name = "roundButton3";
            this.roundButton3.Rounding = 80;
            this.roundButton3.RoundingEnable = true;
            this.roundButton3.Size = new System.Drawing.Size(120, 40);
            this.roundButton3.TabIndex = 3;
            this.roundButton3.Text = "Выйти";
            this.roundButton3.UseVisualStyleBackColor = false;
            this.roundButton3.Click += new System.EventHandler(this.roundButton3_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.roundButton3);
            this.Controls.Add(this.roundButton2);
            this.Controls.Add(this.roundButton1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Design.RoundButton roundButton1;
        private Design.RoundButton roundButton2;
        private Design.RoundButton roundButton3;
    }
}

