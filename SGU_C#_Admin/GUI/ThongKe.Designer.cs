namespace SGU_C__User.GUI
{
    partial class ThongKe
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
            panel2 = new Panel();
            label2 = new Label();
            Btn_Logout = new Button();
            label1 = new Label();
            Btn_Back = new Button();
            panel1 = new Panel();
            dateTimePicker1 = new DateTimePicker();
            label3 = new Label();
            button_filter = new Button();
            button_reset = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Location = new Point(58, 232);
            panel2.Name = "panel2";
            panel2.Size = new Size(1094, 384);
            panel2.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(49, 103);
            label2.Name = "label2";
            label2.Size = new Size(197, 54);
            label2.TabIndex = 0;
            label2.Text = "Thống kê";
            // 
            // Btn_Logout
            // 
            Btn_Logout.BackColor = Color.White;
            Btn_Logout.Cursor = Cursors.Hand;
            Btn_Logout.Location = new Point(1003, 17);
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
            // Btn_Back
            // 
            Btn_Back.Cursor = Cursors.Hand;
            Btn_Back.Location = new Point(58, 68);
            Btn_Back.Name = "Btn_Back";
            Btn_Back.Size = new Size(83, 32);
            Btn_Back.TabIndex = 14;
            Btn_Back.Text = "Quay lại";
            Btn_Back.UseVisualStyleBackColor = true;
            Btn_Back.Click += Btn_Back_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Blue;
            panel1.Controls.Add(Btn_Logout);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1161, 62);
            panel1.TabIndex = 12;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(129, 178);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(58, 178);
            label3.Name = "label3";
            label3.Size = new Size(44, 20);
            label3.TabIndex = 16;
            label3.Text = "Ngày";
            // 
            // button_filter
            // 
            button_filter.Location = new Point(420, 179);
            button_filter.Name = "button_filter";
            button_filter.Size = new Size(94, 29);
            button_filter.TabIndex = 17;
            button_filter.Text = "Lọc";
            button_filter.UseVisualStyleBackColor = true;
            button_filter.Click += button_filter_Click;
            // 
            // button_reset
            // 
            button_reset.Location = new Point(534, 179);
            button_reset.Name = "button_reset";
            button_reset.Size = new Size(94, 29);
            button_reset.TabIndex = 18;
            button_reset.Text = "Reset";
            button_reset.UseVisualStyleBackColor = true;
            button_reset.Click += button_reset_Click;
            // 
            // ThongKe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1161, 639);
            Controls.Add(button_reset);
            Controls.Add(button_filter);
            Controls.Add(label3);
            Controls.Add(dateTimePicker1);
            Controls.Add(label2);
            Controls.Add(panel2);
            Controls.Add(Btn_Back);
            Controls.Add(panel1);
            Name = "ThongKe";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thống kê";
            Load += ThongKe_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel2;
        private Label label2;
        private Button Btn_Logout;
        private Label label1;
        private Button Btn_Back;
        private Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart Chart;
        private DateTimePicker dateTimePicker1;
        private Label label3;
        private Button button_filter;
        private Button button_reset;
    }
}