namespace SGU_C__User.GUI
{
    partial class SuaThietBi
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
            panel1 = new Panel();
            button2 = new Button();
            label1 = new Label();
            comboBox1 = new ComboBox();
            label5 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            button4 = new Button();
            button3 = new Button();
            textBox1 = new TextBox();
            label2 = new Label();
            label6 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Blue;
            panel1.Controls.Add(button2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-3, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1022, 62);
            panel1.TabIndex = 15;
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.Cursor = Cursors.Hand;
            button2.Location = new Point(851, 17);
            button2.Name = "button2";
            button2.Size = new Size(149, 34);
            button2.TabIndex = 2;
            button2.Text = "Logout";
            button2.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(129, 24);
            label1.Name = "label1";
            label1.Size = new Size(191, 20);
            label1.TabIndex = 0;
            label1.Text = "Smart Library Hub-Admin";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(123, 510);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(192, 28);
            comboBox1.TabIndex = 25;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(126, 474);
            label5.Name = "label5";
            label5.Size = new Size(75, 20);
            label5.TabIndex = 24;
            label5.Text = "Trạng thái";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(126, 419);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(245, 27);
            textBox3.TabIndex = 23;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(126, 386);
            label4.Name = "label4";
            label4.Size = new Size(74, 20);
            label4.TabIndex = 22;
            label4.Text = "Giá mượn";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(126, 332);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(245, 27);
            textBox2.TabIndex = 21;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(126, 299);
            label3.Name = "label3";
            label3.Size = new Size(88, 20);
            label3.TabIndex = 20;
            label3.Text = "Loại thiết bị";
            // 
            // button4
            // 
            button4.Location = new Point(271, 591);
            button4.Name = "button4";
            button4.Size = new Size(100, 29);
            button4.TabIndex = 19;
            button4.Text = "Hủy";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(126, 591);
            button3.Name = "button3";
            button3.Size = new Size(100, 29);
            button3.TabIndex = 18;
            button3.Text = "Xác nhận";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(126, 250);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(245, 27);
            textBox1.TabIndex = 17;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(126, 217);
            label2.Name = "label2";
            label2.Size = new Size(83, 20);
            label2.TabIndex = 16;
            label2.Text = "Tên thiết bị";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(123, 93);
            label6.Name = "label6";
            label6.Size = new Size(276, 54);
            label6.TabIndex = 26;
            label6.Text = "SỬA THIẾT BỊ";
            // 
            // SuaThietBi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1020, 646);
            Controls.Add(label6);
            Controls.Add(panel1);
            Controls.Add(comboBox1);
            Controls.Add(label5);
            Controls.Add(textBox3);
            Controls.Add(label4);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Name = "SuaThietBi";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SuaThietBi";
            Load += SuaThietBi_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button button2;
        private Label label1;
        private ComboBox comboBox1;
        private Label label5;
        private TextBox textBox3;
        private Label label4;
        private TextBox textBox2;
        private Label label3;
        private Button button4;
        private Button button3;
        private TextBox textBox1;
        private Label label2;
        private Label label6;
    }
}