namespace SGU_C__User.GUI
{
    partial class ThemTaiKhoan
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
            textBox_Name = new TextBox();
            label4 = new Label();
            textBox_Password = new TextBox();
            label3 = new Label();
            Btn_Cancel = new Button();
            Btn_Accept = new Button();
            textBox_Email = new TextBox();
            label2 = new Label();
            textBox_Birthday = new TextBox();
            label7 = new Label();
            textBox_Address = new TextBox();
            label8 = new Label();
            comboBox_Gender = new ComboBox();
            label9 = new Label();
            textBox_PhoneNumber = new TextBox();
            label10 = new Label();
            label11 = new Label();
            comboBox_Role = new ComboBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Blue;
            panel1.Controls.Add(Btn_Logout);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1022, 62);
            panel1.TabIndex = 16;
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
            label6.Location = new Point(126, 76);
            label6.Name = "label6";
            label6.Size = new Size(367, 54);
            label6.TabIndex = 27;
            label6.Text = "THÊM TÀI KHOẢN";
            // 
            // comboBox_Status
            // 
            comboBox_Status.FormattingEnabled = true;
            comboBox_Status.Location = new Point(126, 866);
            comboBox_Status.Name = "comboBox_Status";
            comboBox_Status.Size = new Size(192, 28);
            comboBox_Status.TabIndex = 26;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(129, 830);
            label5.Name = "label5";
            label5.Size = new Size(75, 20);
            label5.TabIndex = 25;
            label5.Text = "Trạng thái";
            // 
            // textBox_Name
            // 
            textBox_Name.Location = new Point(129, 423);
            textBox_Name.Name = "textBox_Name";
            textBox_Name.Size = new Size(245, 27);
            textBox_Name.TabIndex = 24;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(129, 390);
            label4.Name = "label4";
            label4.Size = new Size(73, 20);
            label4.TabIndex = 23;
            label4.Text = "Họ và tên";
            // 
            // textBox_Password
            // 
            textBox_Password.Location = new Point(129, 336);
            textBox_Password.Name = "textBox_Password";
            textBox_Password.Size = new Size(245, 27);
            textBox_Password.TabIndex = 22;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(129, 303);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 21;
            label3.Text = "Mật khẩu";
            // 
            // Btn_Cancel
            // 
            Btn_Cancel.Cursor = Cursors.Hand;
            Btn_Cancel.Location = new Point(271, 924);
            Btn_Cancel.Name = "Btn_Cancel";
            Btn_Cancel.Size = new Size(100, 29);
            Btn_Cancel.TabIndex = 20;
            Btn_Cancel.Text = "Hủy";
            Btn_Cancel.UseVisualStyleBackColor = true;
            Btn_Cancel.Click += Btn_Cancel_Click;
            // 
            // Btn_Accept
            // 
            Btn_Accept.Cursor = Cursors.Hand;
            Btn_Accept.Location = new Point(126, 924);
            Btn_Accept.Name = "Btn_Accept";
            Btn_Accept.Size = new Size(100, 29);
            Btn_Accept.TabIndex = 19;
            Btn_Accept.Text = "Xác nhận";
            Btn_Accept.UseVisualStyleBackColor = true;
            Btn_Accept.Click += Btn_Accept_Click;
            // 
            // textBox_Email
            // 
            textBox_Email.Location = new Point(129, 254);
            textBox_Email.Name = "textBox_Email";
            textBox_Email.Size = new Size(245, 27);
            textBox_Email.TabIndex = 18;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(129, 221);
            label2.Name = "label2";
            label2.Size = new Size(46, 20);
            label2.TabIndex = 17;
            label2.Text = "Email";
            // 
            // textBox_Birthday
            // 
            textBox_Birthday.Location = new Point(126, 508);
            textBox_Birthday.Name = "textBox_Birthday";
            textBox_Birthday.Size = new Size(245, 27);
            textBox_Birthday.TabIndex = 29;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(126, 475);
            label7.Name = "label7";
            label7.Size = new Size(74, 20);
            label7.TabIndex = 28;
            label7.Text = "Ngày sinh";
            // 
            // textBox_Address
            // 
            textBox_Address.Location = new Point(129, 593);
            textBox_Address.Name = "textBox_Address";
            textBox_Address.Size = new Size(245, 27);
            textBox_Address.TabIndex = 31;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(129, 560);
            label8.Name = "label8";
            label8.Size = new Size(55, 20);
            label8.TabIndex = 30;
            label8.Text = "Địa chỉ";
            // 
            // comboBox_Gender
            // 
            comboBox_Gender.FormattingEnabled = true;
            comboBox_Gender.Location = new Point(126, 781);
            comboBox_Gender.Name = "comboBox_Gender";
            comboBox_Gender.Size = new Size(192, 28);
            comboBox_Gender.TabIndex = 33;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(129, 745);
            label9.Name = "label9";
            label9.Size = new Size(65, 20);
            label9.TabIndex = 32;
            label9.Text = "Giới tính";
            // 
            // textBox_PhoneNumber
            // 
            textBox_PhoneNumber.Location = new Point(129, 688);
            textBox_PhoneNumber.Name = "textBox_PhoneNumber";
            textBox_PhoneNumber.Size = new Size(245, 27);
            textBox_PhoneNumber.TabIndex = 35;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(129, 655);
            label10.Name = "label10";
            label10.Size = new Size(97, 20);
            label10.TabIndex = 34;
            label10.Text = "Số điện thoại";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(128, 142);
            label11.Name = "label11";
            label11.Size = new Size(74, 20);
            label11.TabIndex = 36;
            label11.Text = "Mã quyền";
            // 
            // comboBox_Role
            // 
            comboBox_Role.FormattingEnabled = true;
            comboBox_Role.Location = new Point(129, 176);
            comboBox_Role.Name = "comboBox_Role";
            comboBox_Role.Size = new Size(192, 28);
            comboBox_Role.TabIndex = 37;
            // 
            // ThemTaiKhoan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1023, 977);
            Controls.Add(comboBox_Role);
            Controls.Add(label11);
            Controls.Add(textBox_PhoneNumber);
            Controls.Add(label10);
            Controls.Add(comboBox_Gender);
            Controls.Add(label9);
            Controls.Add(textBox_Address);
            Controls.Add(label8);
            Controls.Add(textBox_Birthday);
            Controls.Add(label7);
            Controls.Add(panel1);
            Controls.Add(label6);
            Controls.Add(comboBox_Status);
            Controls.Add(label5);
            Controls.Add(textBox_Name);
            Controls.Add(label4);
            Controls.Add(textBox_Password);
            Controls.Add(label3);
            Controls.Add(Btn_Cancel);
            Controls.Add(Btn_Accept);
            Controls.Add(textBox_Email);
            Controls.Add(label2);
            Name = "ThemTaiKhoan";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thêm tài khoản";
            Load += ThemTaiKhoan_Load;
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
        private TextBox textBox_Name;
        private Label label4;
        private TextBox textBox_Password;
        private Label label3;
        private Button Btn_Cancel;
        private Button Btn_Accept;
        private TextBox textBox_Email;
        private Label label2;
        private TextBox textBox_Birthday;
        private Label label7;
        private TextBox textBox_Address;
        private Label label8;
        private ComboBox comboBox_Gender;
        private Label label9;
        private TextBox textBox_PhoneNumber;
        private Label label10;
        private Label label11;
        private ComboBox comboBox_Role;
    }
}