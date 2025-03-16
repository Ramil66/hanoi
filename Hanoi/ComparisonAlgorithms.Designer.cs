namespace Курсовая
{
    partial class ComparisonAlgorithms
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
            this.Recursive = new System.Windows.Forms.GroupBox();
            this.Triangle = new System.Windows.Forms.GroupBox();
            this.Cycle = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Start = new Курсовая.Design.RoundButton();
            this.Back = new Курсовая.Design.RoundButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // Recursive
            // 
            this.Recursive.Font = new System.Drawing.Font("Montserrat ExtraBold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Recursive.Location = new System.Drawing.Point(3, 12);
            this.Recursive.Name = "Recursive";
            this.Recursive.Size = new System.Drawing.Size(490, 290);
            this.Recursive.TabIndex = 0;
            this.Recursive.TabStop = false;
            this.Recursive.Text = "Рекурсивный алгоритм";
            // 
            // Triangle
            // 
            this.Triangle.Font = new System.Drawing.Font("Montserrat ExtraBold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Triangle.Location = new System.Drawing.Point(498, 12);
            this.Triangle.Name = "Triangle";
            this.Triangle.Size = new System.Drawing.Size(490, 290);
            this.Triangle.TabIndex = 1;
            this.Triangle.TabStop = false;
            this.Triangle.Text = "\"Треугольное\" решение";
            // 
            // Cycle
            // 
            this.Cycle.Font = new System.Drawing.Font("Montserrat ExtraBold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Cycle.Location = new System.Drawing.Point(3, 308);
            this.Cycle.Name = "Cycle";
            this.Cycle.Size = new System.Drawing.Size(490, 290);
            this.Cycle.TabIndex = 2;
            this.Cycle.TabStop = false;
            this.Cycle.Text = "Циклический алгоритм";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.richTextBox1);
            this.groupBox5.Controls.Add(this.textBox1);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.Start);
            this.groupBox5.Controls.Add(this.Back);
            this.groupBox5.Font = new System.Drawing.Font("Montserrat ExtraBold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox5.Location = new System.Drawing.Point(498, 308);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(490, 290);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Итоги";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.richTextBox1.Font = new System.Drawing.Font("Montserrat ExtraBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox1.Location = new System.Drawing.Point(10, 23);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(474, 218);
            this.richTextBox1.TabIndex = 13;
            this.richTextBox1.Text = "";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Montserrat ExtraBold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(243, 252);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(70, 24);
            this.textBox1.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat ExtraBold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 255);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Введите количество дисков:";
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(138)))), ((int)(((byte)(247)))));
            this.Start.ColorPen = System.Drawing.Color.Empty;
            this.Start.Font = new System.Drawing.Font("Montserrat ExtraBold", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Start.Location = new System.Drawing.Point(319, 250);
            this.Start.Name = "Start";
            this.Start.RoundingEnable = true;
            this.Start.Size = new System.Drawing.Size(30, 30);
            this.Start.TabIndex = 10;
            this.Start.UseVisualStyleBackColor = false;
            this.Start.Click += new System.EventHandler(this.roundButton2_Click);
            // 
            // Back
            // 
            this.Back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(138)))), ((int)(((byte)(247)))));
            this.Back.ColorPen = System.Drawing.Color.Empty;
            this.Back.Font = new System.Drawing.Font("Montserrat ExtraBold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Back.ForeColor = System.Drawing.Color.White;
            this.Back.Location = new System.Drawing.Point(364, 247);
            this.Back.Name = "Back";
            this.Back.Rounding = 80;
            this.Back.RoundingEnable = true;
            this.Back.Size = new System.Drawing.Size(120, 35);
            this.Back.TabIndex = 9;
            this.Back.Text = "Назад";
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Click += new System.EventHandler(this.roundButton1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ComparisonAlgorithms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.Cycle);
            this.Controls.Add(this.Triangle);
            this.Controls.Add(this.Recursive);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ComparisonAlgorithms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ComparisonAlgorithms";
            this.Load += new System.EventHandler(this.ComparisonAlgorithms_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Recursive;
        private System.Windows.Forms.GroupBox Triangle;
        private System.Windows.Forms.GroupBox Cycle;
        private System.Windows.Forms.GroupBox groupBox5;
        private Курсовая.Design.RoundButton Back;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private Курсовая.Design.RoundButton Start;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}