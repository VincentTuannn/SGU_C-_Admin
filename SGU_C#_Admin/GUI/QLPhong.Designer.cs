namespace SGU_C__User.GUI
{
    partial class QLPhong
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
            button3 = new Button();
            btn_delete = new Button();
            btn_fix = new Button();
            dataGridView1 = new DataGridView();
            Input_Search = new TextBox();
            label2 = new Label();
            button2 = new Button();
            label1 = new Label();
            button8 = new Button();
            panel1 = new Panel();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(button3);
            panel2.Controls.Add(btn_delete);
            panel2.Controls.Add(btn_fix);
            panel2.Controls.Add(dataGridView1);
            panel2.Controls.Add(Input_Search);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(61, 117);
            panel2.Name = "panel2";
            panel2.Size = new Size(1094, 359);
            panel2.TabIndex = 10;
            // 
            // button3
            // 
            button3.BackColor = Color.Black;
            button3.Cursor = Cursors.Hand;
            button3.ForeColor = Color.White;
            button3.Location = new Point(828, 26);
            button3.Name = "button3";
            button3.Size = new Size(131, 35);
            button3.TabIndex = 14;
            button3.Text = "Thêm phòng";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // btn_delete
            // 
            btn_delete.Location = new Point(986, 250);
            btn_delete.Name = "btn_delete";
            btn_delete.Size = new Size(83, 32);
            btn_delete.TabIndex = 13;
            btn_delete.Text = "Xóa";
            btn_delete.UseVisualStyleBackColor = true;
            btn_delete.Click += btn_delete_Click;
            // 
            // btn_fix
            // 
            btn_fix.Location = new Point(986, 135);
            btn_fix.Name = "btn_fix";
            btn_fix.Size = new Size(83, 32);
            btn_fix.TabIndex = 12;
            btn_fix.Text = "Sửa";
            btn_fix.UseVisualStyleBackColor = true;
            btn_fix.Click += btn_fix_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(134, 114);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(825, 193);
            dataGridView1.TabIndex = 2;
            // 
            // Input_Search
            // 
            Input_Search.ForeColor = Color.Gray;
            Input_Search.Location = new Point(30, 58);
            Input_Search.Name = "Input_Search";
            Input_Search.Size = new Size(188, 27);
            Input_Search.TabIndex = 1;
            Input_Search.TextChanged += Input_Search_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(30, 24);
            label2.Name = "label2";
            label2.Size = new Size(218, 31);
            label2.TabIndex = 0;
            label2.Text = "Quản lý phòng ban";
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.Cursor = Cursors.Hand;
            button2.Location = new Point(1003, 17);
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
            // button8
            // 
            button8.Location = new Point(61, 70);
            button8.Name = "button8";
            button8.Size = new Size(83, 32);
            button8.TabIndex = 11;
            button8.Text = "Quay lại";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click_1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Blue;
            panel1.Controls.Add(button2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1161, 62);
            panel1.TabIndex = 9;
            // 
            // QLPhong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1164, 570);
            Controls.Add(panel2);
            Controls.Add(button8);
            Controls.Add(panel1);
            Name = "QLPhong";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QLPhong";
            Load += QLPhong_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private DataGridView dataGridView1;
        private TextBox Input_Search;
        private Label label2;
        private Button button2;
        private Label label1;
        private Button button8;
        private Panel panel1;
        private Button btn_delete;
        private Button btn_fix;
        private Button button3;
    }
}