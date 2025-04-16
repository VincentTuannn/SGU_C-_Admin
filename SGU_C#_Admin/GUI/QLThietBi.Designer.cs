namespace SGU_C__User
{
    partial class QLThietBi
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
            label2 = new Label();
            Input_Search = new TextBox();
            button3 = new Button();
            panel2 = new Panel();
            btn_delete = new Button();
            btn_fix = new Button();
            dataGridView1 = new DataGridView();
            button6 = new Button();
            importExcel = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Blue;
            panel1.Controls.Add(button2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(4, 2);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(894, 46);
            panel1.TabIndex = 1;
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.Cursor = Cursors.Hand;
            button2.Location = new Point(745, 13);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(130, 26);
            button2.TabIndex = 2;
            button2.Text = "Logout";
            button2.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(113, 18);
            label1.Name = "label1";
            label1.Size = new Size(149, 15);
            label1.TabIndex = 0;
            label1.Text = "Smart Library Hub-Admin";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(26, 18);
            label2.Name = "label2";
            label2.Size = new Size(147, 25);
            label2.TabIndex = 0;
            label2.Text = "Quản lý thiết bị";
            // 
            // Input_Search
            // 
            Input_Search.ForeColor = Color.Gray;
            Input_Search.Location = new Point(26, 44);
            Input_Search.Margin = new Padding(3, 2, 3, 2);
            Input_Search.Name = "Input_Search";
            Input_Search.Size = new Size(147, 23);
            Input_Search.TabIndex = 1;
            Input_Search.TextChanged += Input_Search_TextChanged;
            // 
            // button3
            // 
            button3.BackColor = Color.Black;
            button3.Cursor = Cursors.Hand;
            button3.ForeColor = Color.White;
            button3.Location = new Point(555, 41);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(115, 26);
            button3.TabIndex = 2;
            button3.Text = "Thêm thiết bị";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(importExcel);
            panel2.Controls.Add(btn_delete);
            panel2.Controls.Add(btn_fix);
            panel2.Controls.Add(dataGridView1);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(Input_Search);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(54, 88);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(799, 262);
            panel2.TabIndex = 2;
            panel2.Paint += panel2_Paint;
            // 
            // btn_delete
            // 
            btn_delete.Location = new Point(711, 184);
            btn_delete.Margin = new Padding(3, 2, 3, 2);
            btn_delete.Name = "btn_delete";
            btn_delete.Size = new Size(75, 26);
            btn_delete.TabIndex = 5;
            btn_delete.Text = "Xóa";
            btn_delete.UseVisualStyleBackColor = true;
            btn_delete.Click += btn_delete_Click;
            // 
            // btn_fix
            // 
            btn_fix.Location = new Point(711, 103);
            btn_fix.Margin = new Padding(3, 2, 3, 2);
            btn_fix.Name = "btn_fix";
            btn_fix.Size = new Size(75, 26);
            btn_fix.TabIndex = 4;
            btn_fix.Text = "Sửa";
            btn_fix.UseVisualStyleBackColor = true;
            btn_fix.Click += btn_fix_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(86, 84);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(612, 148);
            dataGridView1.TabIndex = 3;
            // 
            // button6
            // 
            button6.Location = new Point(54, 52);
            button6.Margin = new Padding(3, 2, 3, 2);
            button6.Name = "button6";
            button6.Size = new Size(75, 26);
            button6.TabIndex = 3;
            button6.Text = "Quay lại";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // importExcel
            // 
            importExcel.BackColor = Color.MediumSeaGreen;
            importExcel.Cursor = Cursors.Hand;
            importExcel.ForeColor = Color.White;
            importExcel.Location = new Point(675, 41);
            importExcel.Margin = new Padding(3, 2, 3, 2);
            importExcel.Name = "importExcel";
            importExcel.Size = new Size(115, 26);
            importExcel.TabIndex = 6;
            importExcel.Text = "Import Excel";
            importExcel.UseVisualStyleBackColor = false;
            importExcel.Click += importExcel_Click;
            // 
            // QLThietBi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 374);
            Controls.Add(button6);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "QLThietBi";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý thiết bị";
            Load += Device_Management_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button2;
        private Label label1;
        private Label label2;
        private TextBox Input_Search;
        private Button button3;
        private Panel panel2;
        private DataGridViewButtonColumn AdjustButton;
        private Button button6;
        private DataGridView dataGridView1;
        private Button btn_delete;
        private Button btn_fix;
        private Button importExcel;
    }
}