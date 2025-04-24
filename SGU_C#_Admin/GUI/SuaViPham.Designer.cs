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
            Btn_Logout = new Button();
            label1 = new Label();
            label6 = new Label();
            comboBox_Type = new ComboBox();
            label5 = new Label();
            Btn_Cancel = new Button();
            Btn_Accept = new Button();
            textBox_Content = new TextBox();
            label2 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Blue;
            panel1.Controls.Add(Btn_Logout);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(1, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1022, 62);
            panel1.TabIndex = 27;
            // 
            // Btn_Logout
            // 
            Btn_Logout.BackColor = Color.White;
            Btn_Logout.Cursor = Cursors.Hand;
            Btn_Logout.Location = new Point(851, 17);
            Btn_Logout.Name = "Btn_Logout";
            Btn_Logout.Size = new Size(149, 34);
            Btn_Logout.TabIndex = 2;
            Btn_Logout.Text = "Logout";
            Btn_Logout.UseVisualStyleBackColor = false;
            Btn_Logout.Click += Btn_Logout_Click;
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
            label6.Size = new Size(522, 54);
            label6.TabIndex = 38;
            label6.Text = "SỬA THÔNG TIN VI PHẠM";
            // 
            // comboBox_Type
            // 
            comboBox_Type.FormattingEnabled = true;
            comboBox_Type.Location = new Point(137, 210);
            comboBox_Type.Name = "comboBox_Type";
            comboBox_Type.Size = new Size(192, 28);
            comboBox_Type.TabIndex = 37;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(140, 174);
            label5.Name = "label5";
            label5.Size = new Size(94, 20);
            label5.TabIndex = 36;
            label5.Text = "Loại vi phạm";
            // 
            // Btn_Cancel
            // 
            Btn_Cancel.Cursor = Cursors.Hand;
            Btn_Cancel.Location = new Point(282, 401);
            Btn_Cancel.Name = "Btn_Cancel";
            Btn_Cancel.Size = new Size(100, 29);
            Btn_Cancel.TabIndex = 31;
            Btn_Cancel.Text = "Hủy";
            Btn_Cancel.UseVisualStyleBackColor = true;
            Btn_Cancel.Click += Btn_Cancel_Click;
            // 
            // Btn_Accept
            // 
            Btn_Accept.Cursor = Cursors.Hand;
            Btn_Accept.Location = new Point(137, 401);
            Btn_Accept.Name = "Btn_Accept";
            Btn_Accept.Size = new Size(100, 29);
            Btn_Accept.TabIndex = 30;
            Btn_Accept.Text = "Xác nhận";
            Btn_Accept.UseVisualStyleBackColor = true;
            Btn_Accept.Click += Btn_Accept_Click;
            // 
            // textBox_Content
            // 
            textBox_Content.Location = new Point(137, 319);
            textBox_Content.Name = "textBox_Content";
            textBox_Content.Size = new Size(482, 27);
            textBox_Content.TabIndex = 29;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(137, 286);
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
            Controls.Add(comboBox_Type);
            Controls.Add(label5);
            Controls.Add(Btn_Cancel);
            Controls.Add(Btn_Accept);
            Controls.Add(textBox_Content);
            Controls.Add(label2);
            Name = "SuaViPham";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sửa thông tin vi phạm";
            Load += SuaViPham_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button Btn_Logout;
        private Label label1;
        private Label label6;
        private ComboBox comboBox_Type;
        private Label label5;
        private Button Btn_Cancel;
        private Button Btn_Accept;
        private TextBox textBox_Content;
        private Label label2;
    }
}