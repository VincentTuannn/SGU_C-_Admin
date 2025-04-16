
namespace SGU_C__User
{
    partial class TrangChu_Admin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            button2 = new Button();
            label1 = new Label();
            panel2 = new Panel();
            Btn_QLMuonPhong = new Button();
            Btn_QLMuonThietBi = new Button();
            Btn_QLViPham = new Button();
            Btn_QLPhongBan = new Button();
            Btn_QLThanhToan = new Button();
            Btn_QLThietBi = new Button();
            Btn_QLTaiKhoan = new Button();
            label2 = new Label();
            panel3 = new Panel();
            panel7 = new Panel();
            panel6 = new Panel();
            panel5 = new Panel();
            Btn_QLCheckIn = new Button();
            panel4 = new Panel();
            label3 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Blue;
            panel1.Controls.Add(button2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1080, 62);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.Cursor = Cursors.Hand;
            button2.Location = new Point(898, 17);
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
            label1.Click += label1_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(Btn_QLMuonPhong);
            panel2.Controls.Add(Btn_QLMuonThietBi);
            panel2.Controls.Add(Btn_QLViPham);
            panel2.Controls.Add(Btn_QLPhongBan);
            panel2.Controls.Add(Btn_QLThanhToan);
            panel2.Controls.Add(Btn_QLThietBi);
            panel2.Controls.Add(Btn_QLTaiKhoan);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(33, 123);
            panel2.Name = "panel2";
            panel2.Size = new Size(234, 620);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // Btn_QLMuonPhong
            // 
            Btn_QLMuonPhong.Cursor = Cursors.Hand;
            Btn_QLMuonPhong.Location = new Point(0, 566);
            Btn_QLMuonPhong.Name = "Btn_QLMuonPhong";
            Btn_QLMuonPhong.Size = new Size(228, 51);
            Btn_QLMuonPhong.TabIndex = 6;
            Btn_QLMuonPhong.Text = "Quản lý mượn phòng";
            Btn_QLMuonPhong.TextAlign = ContentAlignment.MiddleLeft;
            Btn_QLMuonPhong.UseVisualStyleBackColor = true;
            Btn_QLMuonPhong.Click += Btn_QLMuonPhong_Click;
            // 
            // Btn_QLMuonThietBi
            // 
            Btn_QLMuonThietBi.Cursor = Cursors.Hand;
            Btn_QLMuonThietBi.Location = new Point(0, 489);
            Btn_QLMuonThietBi.Name = "Btn_QLMuonThietBi";
            Btn_QLMuonThietBi.Size = new Size(228, 51);
            Btn_QLMuonThietBi.TabIndex = 5;
            Btn_QLMuonThietBi.Text = "Quản lý mượn thiết bị";
            Btn_QLMuonThietBi.TextAlign = ContentAlignment.MiddleLeft;
            Btn_QLMuonThietBi.UseVisualStyleBackColor = true;
            Btn_QLMuonThietBi.Click += Btn_QLMuonThietBi_Click;
            // 
            // Btn_QLViPham
            // 
            Btn_QLViPham.Cursor = Cursors.Hand;
            Btn_QLViPham.Location = new Point(0, 408);
            Btn_QLViPham.Name = "Btn_QLViPham";
            Btn_QLViPham.Size = new Size(228, 51);
            Btn_QLViPham.TabIndex = 4;
            Btn_QLViPham.Text = "Quản lý vi phạm";
            Btn_QLViPham.TextAlign = ContentAlignment.MiddleLeft;
            Btn_QLViPham.UseVisualStyleBackColor = true;
            Btn_QLViPham.Click += Btn_QLViPham_Click;
            // 
            // Btn_QLPhongBan
            // 
            Btn_QLPhongBan.Cursor = Cursors.Hand;
            Btn_QLPhongBan.Location = new Point(0, 335);
            Btn_QLPhongBan.Name = "Btn_QLPhongBan";
            Btn_QLPhongBan.Size = new Size(228, 51);
            Btn_QLPhongBan.TabIndex = 4;
            Btn_QLPhongBan.Text = "Quản lý phòng ban";
            Btn_QLPhongBan.TextAlign = ContentAlignment.MiddleLeft;
            Btn_QLPhongBan.UseVisualStyleBackColor = true;
            Btn_QLPhongBan.Click += Btn_QLPhongBan_Click;
            // 
            // Btn_QLThanhToan
            // 
            Btn_QLThanhToan.Cursor = Cursors.Hand;
            Btn_QLThanhToan.Location = new Point(0, 260);
            Btn_QLThanhToan.Name = "Btn_QLThanhToan";
            Btn_QLThanhToan.Size = new Size(228, 51);
            Btn_QLThanhToan.TabIndex = 3;
            Btn_QLThanhToan.Text = "Quản lý thanh toán";
            Btn_QLThanhToan.TextAlign = ContentAlignment.MiddleLeft;
            Btn_QLThanhToan.UseVisualStyleBackColor = true;
            Btn_QLThanhToan.Click += Btn_QLThanhToan_Click;
            // 
            // Btn_QLThietBi
            // 
            Btn_QLThietBi.Cursor = Cursors.Hand;
            Btn_QLThietBi.Location = new Point(3, 186);
            Btn_QLThietBi.Name = "Btn_QLThietBi";
            Btn_QLThietBi.Size = new Size(228, 51);
            Btn_QLThietBi.TabIndex = 2;
            Btn_QLThietBi.Text = "Quản lý thiết bị";
            Btn_QLThietBi.TextAlign = ContentAlignment.MiddleLeft;
            Btn_QLThietBi.UseVisualStyleBackColor = true;
            Btn_QLThietBi.Click += Btn_QLThietBi_Click;
            // 
            // Btn_QLTaiKhoan
            // 
            Btn_QLTaiKhoan.Cursor = Cursors.Hand;
            Btn_QLTaiKhoan.Location = new Point(3, 112);
            Btn_QLTaiKhoan.Name = "Btn_QLTaiKhoan";
            Btn_QLTaiKhoan.Size = new Size(228, 51);
            Btn_QLTaiKhoan.TabIndex = 1;
            Btn_QLTaiKhoan.Text = "Quản lý tài khoản";
            Btn_QLTaiKhoan.TextAlign = ContentAlignment.MiddleLeft;
            Btn_QLTaiKhoan.UseVisualStyleBackColor = true;
            Btn_QLTaiKhoan.Click += Btn_QLTaiKhoan_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 17);
            label2.Name = "label2";
            label2.Size = new Size(113, 46);
            label2.TabIndex = 0;
            label2.Text = "Menu";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(panel7);
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(panel4);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(307, 123);
            panel3.Name = "panel3";
            panel3.Size = new Size(761, 552);
            panel3.TabIndex = 2;
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(255, 192, 255);
            panel7.Location = new Point(430, 324);
            panel7.Name = "panel7";
            panel7.Size = new Size(297, 146);
            panel7.TabIndex = 8;
            panel7.Paint += panel7_Paint;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(192, 255, 192);
            panel6.Location = new Point(430, 108);
            panel6.Name = "panel6";
            panel6.Size = new Size(300, 142);
            panel6.TabIndex = 7;
            panel6.Paint += panel6_Paint;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(255, 255, 192);
            panel5.Controls.Add(Btn_QLCheckIn);
            panel5.Location = new Point(39, 324);
            panel5.Name = "panel5";
            panel5.Size = new Size(310, 146);
            panel5.TabIndex = 7;
            panel5.Paint += panel5_Paint;
            // 
            // Btn_QLCheckIn
            // 
            Btn_QLCheckIn.BackColor = Color.Blue;
            Btn_QLCheckIn.Cursor = Cursors.Hand;
            Btn_QLCheckIn.ForeColor = Color.White;
            Btn_QLCheckIn.Location = new Point(70, 59);
            Btn_QLCheckIn.Name = "Btn_QLCheckIn";
            Btn_QLCheckIn.Size = new Size(149, 46);
            Btn_QLCheckIn.TabIndex = 3;
            Btn_QLCheckIn.Text = "Xem chi tiết";
            Btn_QLCheckIn.UseVisualStyleBackColor = false;
            Btn_QLCheckIn.Click += Btn_QLCheckIn_Click;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(192, 255, 255);
            panel4.Location = new Point(39, 108);
            panel4.Name = "panel4";
            panel4.Size = new Size(310, 142);
            panel4.TabIndex = 6;
            panel4.Paint += panel4_Paint;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(39, 17);
            label3.Name = "label3";
            label3.Size = new Size(193, 46);
            label3.TabIndex = 5;
            label3.Text = "Dashboard";
            // 
            // TrangChu_Admin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1080, 755);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "TrangChu_Admin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Trang chủ";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            //throw new NotImplementedException();
            using (Pen pen = new Pen(Color.Black, 2))
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                e.Graphics.DrawRectangle(pen, 0, 0, panel4.Width - 1, panel4.Height - 1);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Button button2;
        private Panel panel2;
        private Label label2;
        private Button Btn_QLViPham;
        private Button Btn_QLPhongBan;
        private Button Btn_QLThanhToan;
        private Button Btn_QLThietBi;
        private Button Btn_QLTaiKhoan;
        private Panel panel3;
        private Panel panel7;
        private Panel panel6;
        private Panel panel5;
        private Panel panel4;
        private Label label3;
        private Button Btn_QLCheckIn;
        private Button button9;
        private Button Btn_QLMuonThietBi;
        private Button Btn_QLMuonPhong;
    }
}
