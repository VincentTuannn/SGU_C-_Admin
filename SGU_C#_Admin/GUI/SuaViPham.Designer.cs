namespace SGU_C__User.GUI
{
    partial class SuaViPham
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
            label6 = new Label();
            comboBox1 = new ComboBox();
            label5 = new Label();
            button4 = new Button();
            button3 = new Button();
            textBox1 = new TextBox();
            label2 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Blue;
            panel1.Controls.Add(button2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(1, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1022, 62);
            panel1.TabIndex = 27;
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
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(127, 93);
            label6.Name = "label6";
            label6.Size = new Size(288, 54);
            label6.TabIndex = 38;
            label6.Text = "SỬA VI PHẠM";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(133, 226);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(192, 28);
            comboBox1.TabIndex = 37;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(136, 190);
            label5.Name = "label5";
            label5.Size = new Size(94, 20);
            label5.TabIndex = 36;
            label5.Text = "Loại vi phạm";
            // 
            // button4
            // 
            button4.Location = new Point(278, 417);
            button4.Name = "button4";
            button4.Size = new Size(100, 29);
            button4.TabIndex = 31;
            button4.Text = "Hủy";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(133, 417);
            button3.Name = "button3";
            button3.Size = new Size(100, 29);
            button3.TabIndex = 30;
            button3.Text = "Xác nhận";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(133, 335);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(482, 27);
            textBox1.TabIndex = 29;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(133, 302);
            label2.Name = "label2";
            label2.Size = new Size(128, 20);
            label2.TabIndex = 28;
            label2.Text = "Nội dung vi phạm";
            // 
            // SuaViPham
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1025, 482);
            Controls.Add(panel1);
            Controls.Add(label6);
            Controls.Add(comboBox1);
            Controls.Add(label5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Name = "SuaViPham";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SuaViPham";
            Load += SuaViPham_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button button2;
        private Label label1;
        private Label label6;
        private ComboBox comboBox1;
        private Label label5;
        private Button button4;
        private Button button3;
        private TextBox textBox1;
        private Label label2;
    }
}