namespace SGU_C__User.GUI
{
    partial class Login
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
            btn_ShowHide = new Button();
            Btn_Login = new Button();
            label3 = new Label();
            textBox_Password = new TextBox();
            label2 = new Label();
            textBox_Email = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(224, 224, 224);
            panel1.Controls.Add(btn_ShowHide);
            panel1.Controls.Add(Btn_Login);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(textBox_Password);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(textBox_Email);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(237, 25);
            panel1.Name = "panel1";
            panel1.Size = new Size(381, 394);
            panel1.TabIndex = 0;
            // 
            // btn_ShowHide
            // 
            btn_ShowHide.Location = new Point(341, 198);
            btn_ShowHide.Name = "btn_ShowHide";
            btn_ShowHide.Size = new Size(24, 29);
            btn_ShowHide.TabIndex = 6;
            btn_ShowHide.UseVisualStyleBackColor = true;
            btn_ShowHide.Click += btn_ShowHide_Click;
            // 
            // Btn_Login
            // 
            Btn_Login.Cursor = Cursors.Hand;
            Btn_Login.Location = new Point(46, 292);
            Btn_Login.Name = "Btn_Login";
            Btn_Login.Size = new Size(289, 44);
            Btn_Login.TabIndex = 5;
            Btn_Login.Text = "Đăng nhập";
            Btn_Login.UseVisualStyleBackColor = true;
            Btn_Login.Click += Btn_Login_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(46, 168);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 4;
            label3.Text = "Mật khẩu";
            // 
            // textBox_Password
            // 
            textBox_Password.Location = new Point(46, 200);
            textBox_Password.Name = "textBox_Password";
            textBox_Password.Size = new Size(289, 27);
            textBox_Password.TabIndex = 3;
            textBox_Password.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(48, 89);
            label2.Name = "label2";
            label2.Size = new Size(46, 20);
            label2.TabIndex = 2;
            label2.Text = "Email";
            // 
            // textBox_Email
            // 
            textBox_Email.Location = new Point(48, 121);
            textBox_Email.Name = "textBox_Email";
            textBox_Email.Size = new Size(289, 27);
            textBox_Email.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(67, 20);
            label1.Name = "label1";
            label1.Size = new Size(246, 50);
            label1.TabIndex = 0;
            label1.Text = "ĐĂNG NHẬP";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label3;
        private TextBox textBox_Password;
        private Label label2;
        private TextBox textBox_Email;
        private Button Btn_Login;
        private Button btn_ShowHide;
    }
}