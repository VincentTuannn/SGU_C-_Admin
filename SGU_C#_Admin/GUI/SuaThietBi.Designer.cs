﻿namespace SGU_C__User.GUI
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
            Btn_Logout = new Button();
            label1 = new Label();
            comboBox_Status = new ComboBox();
            label5 = new Label();
            textBox_Price = new TextBox();
            label4 = new Label();
            textBox_Type = new TextBox();
            label3 = new Label();
            Btn_Cancel = new Button();
            Btn_Accept = new Button();
            textBox_Name = new TextBox();
            label2 = new Label();
            label6 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Blue;
            panel1.Controls.Add(Btn_Logout);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-3, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1022, 62);
            panel1.TabIndex = 15;
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
            // comboBox_Status
            // 
            comboBox_Status.FormattingEnabled = true;
            comboBox_Status.Location = new Point(126, 460);
            comboBox_Status.Name = "comboBox_Status";
            comboBox_Status.Size = new Size(192, 28);
            comboBox_Status.TabIndex = 25;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(126, 423);
            label5.Name = "label5";
            label5.Size = new Size(75, 20);
            label5.TabIndex = 24;
            label5.Text = "Trạng thái";
            // 
            // textBox_Price
            // 
            textBox_Price.Location = new Point(126, 368);
            textBox_Price.Name = "textBox_Price";
            textBox_Price.Size = new Size(245, 27);
            textBox_Price.TabIndex = 23;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(126, 335);
            label4.Name = "label4";
            label4.Size = new Size(74, 20);
            label4.TabIndex = 22;
            label4.Text = "Giá mượn";
            // 
            // textBox_Type
            // 
            textBox_Type.Location = new Point(126, 281);
            textBox_Type.Name = "textBox_Type";
            textBox_Type.Size = new Size(245, 27);
            textBox_Type.TabIndex = 21;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(126, 248);
            label3.Name = "label3";
            label3.Size = new Size(88, 20);
            label3.TabIndex = 20;
            label3.Text = "Loại thiết bị";
            // 
            // Btn_Cancel
            // 
            Btn_Cancel.Cursor = Cursors.Hand;
            Btn_Cancel.Location = new Point(271, 540);
            Btn_Cancel.Name = "Btn_Cancel";
            Btn_Cancel.Size = new Size(100, 29);
            Btn_Cancel.TabIndex = 19;
            Btn_Cancel.Text = "Hủy";
            Btn_Cancel.UseVisualStyleBackColor = true;
            Btn_Cancel.Click += Btn_Cancel_Click;
            // 
            // Btn_Accept
            // 
            Btn_Accept.Cursor = Cursors.Hand;
            Btn_Accept.Location = new Point(126, 540);
            Btn_Accept.Name = "Btn_Accept";
            Btn_Accept.Size = new Size(100, 29);
            Btn_Accept.TabIndex = 18;
            Btn_Accept.Text = "Xác nhận";
            Btn_Accept.UseVisualStyleBackColor = true;
            Btn_Accept.Click += Btn_Accept_Click;
            // 
            // textBox_Name
            // 
            textBox_Name.Location = new Point(126, 199);
            textBox_Name.Name = "textBox_Name";
            textBox_Name.Size = new Size(245, 27);
            textBox_Name.TabIndex = 17;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(126, 166);
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
            label6.Size = new Size(510, 54);
            label6.TabIndex = 26;
            label6.Text = "SỬA THÔNG TIN THIẾT BỊ";
            // 
            // SuaThietBi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1020, 594);
            Controls.Add(label6);
            Controls.Add(panel1);
            Controls.Add(comboBox_Status);
            Controls.Add(label5);
            Controls.Add(textBox_Price);
            Controls.Add(label4);
            Controls.Add(textBox_Type);
            Controls.Add(label3);
            Controls.Add(Btn_Cancel);
            Controls.Add(Btn_Accept);
            Controls.Add(textBox_Name);
            Controls.Add(label2);
            Name = "SuaThietBi";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sửa thông tin thiết bị";
            Load += SuaThietBi_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button Btn_Logout;
        private Label label1;
        private ComboBox comboBox_Status;
        private Label label5;
        private TextBox textBox_Price;
        private Label label4;
        private TextBox textBox_Type;
        private Label label3;
        private Button Btn_Cancel;
        private Button Btn_Accept;
        private TextBox textBox_Name;
        private Label label2;
        private Label label6;
    }
}