namespace SGU_C__User.GUI
{
    partial class ThemPhong
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
            comboBox_Status = new ComboBox();
            label5 = new Label();
            textBox_Capacity = new TextBox();
            label4 = new Label();
            textBox_Type = new TextBox();
            label3 = new Label();
            Btn_Cancel = new Button();
            Btn_Accept = new Button();
            textBox_Name = new TextBox();
            label2 = new Label();
            textBox_Price = new TextBox();
            label7 = new Label();
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
            panel1.TabIndex = 39;
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
            label6.Size = new Size(293, 54);
            label6.TabIndex = 50;
            label6.Text = "THÊM PHÒNG";
            // 
            // comboBox_Status
            // 
            comboBox_Status.FormattingEnabled = true;
            comboBox_Status.Location = new Point(130, 545);
            comboBox_Status.Name = "comboBox_Status";
            comboBox_Status.Size = new Size(192, 28);
            comboBox_Status.TabIndex = 49;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(127, 509);
            label5.Name = "label5";
            label5.Size = new Size(75, 20);
            label5.TabIndex = 48;
            label5.Text = "Trạng thái";
            // 
            // textBox_Capacity
            // 
            textBox_Capacity.Location = new Point(127, 366);
            textBox_Capacity.Name = "textBox_Capacity";
            textBox_Capacity.Size = new Size(245, 27);
            textBox_Capacity.TabIndex = 47;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(127, 333);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 46;
            label4.Text = "Sức chứa";
            // 
            // textBox_Type
            // 
            textBox_Type.Location = new Point(127, 279);
            textBox_Type.Name = "textBox_Type";
            textBox_Type.Size = new Size(245, 27);
            textBox_Type.TabIndex = 45;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(127, 246);
            label3.Name = "label3";
            label3.Size = new Size(84, 20);
            label3.TabIndex = 44;
            label3.Text = "Loại phòng";
            // 
            // Btn_Cancel
            // 
            Btn_Cancel.Cursor = Cursors.Hand;
            Btn_Cancel.Location = new Point(275, 591);
            Btn_Cancel.Name = "Btn_Cancel";
            Btn_Cancel.Size = new Size(100, 29);
            Btn_Cancel.TabIndex = 43;
            Btn_Cancel.Text = "Hủy";
            Btn_Cancel.UseVisualStyleBackColor = true;
            Btn_Cancel.Click += Btn_Cancel_Click;
            // 
            // Btn_Accept
            // 
            Btn_Accept.Cursor = Cursors.Hand;
            Btn_Accept.Location = new Point(130, 591);
            Btn_Accept.Name = "Btn_Accept";
            Btn_Accept.Size = new Size(100, 29);
            Btn_Accept.TabIndex = 42;
            Btn_Accept.Text = "Xác nhận";
            Btn_Accept.UseVisualStyleBackColor = true;
            Btn_Accept.Click += Btn_Accept_Click;
            // 
            // textBox_Name
            // 
            textBox_Name.Location = new Point(127, 197);
            textBox_Name.Name = "textBox_Name";
            textBox_Name.Size = new Size(245, 27);
            textBox_Name.TabIndex = 41;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(127, 164);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 40;
            label2.Text = "Tên phòng";
            // 
            // textBox_Price
            // 
            textBox_Price.Location = new Point(127, 458);
            textBox_Price.Name = "textBox_Price";
            textBox_Price.Size = new Size(245, 27);
            textBox_Price.TabIndex = 52;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(127, 425);
            label7.Name = "label7";
            label7.Size = new Size(74, 20);
            label7.TabIndex = 51;
            label7.Text = "Giá mượn";
            // 
            // ThemPhong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1022, 648);
            Controls.Add(textBox_Price);
            Controls.Add(label7);
            Controls.Add(panel1);
            Controls.Add(label6);
            Controls.Add(comboBox_Status);
            Controls.Add(label5);
            Controls.Add(textBox_Capacity);
            Controls.Add(label4);
            Controls.Add(textBox_Type);
            Controls.Add(label3);
            Controls.Add(Btn_Cancel);
            Controls.Add(Btn_Accept);
            Controls.Add(textBox_Name);
            Controls.Add(label2);
            Name = "ThemPhong";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thêm phòng";
            Load += ThemPhong_Load;
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
        private ComboBox comboBox_Status;
        private Label label5;
        private TextBox textBox_Capacity;
        private Label label4;
        private TextBox textBox_Type;
        private Label label3;
        private Button Btn_Cancel;
        private Button Btn_Accept;
        private TextBox textBox_Name;
        private Label label2;
        private TextBox textBox_Price;
        private Label label7;
    }
}