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
            Btn_Logout = new Button();
            label1 = new Label();
            label2 = new Label();
            Input_Search = new TextBox();
            Btn_Add = new Button();
            panel2 = new Panel();
            importExcel = new Button();
            btn_delete = new Button();
            btn_fix = new Button();
            dataGridView1 = new DataGridView();
            Btn_Back = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Blue;
            panel1.Controls.Add(Btn_Logout);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(5, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1022, 61);
            panel1.TabIndex = 1;
            // 
            // Btn_Logout
            // 
            Btn_Logout.BackColor = Color.White;
            Btn_Logout.Cursor = Cursors.Hand;
            Btn_Logout.Location = new Point(851, 17);
            Btn_Logout.Name = "Btn_Logout";
            Btn_Logout.Size = new Size(149, 35);
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(30, 24);
            label2.Name = "label2";
            label2.Size = new Size(180, 31);
            label2.TabIndex = 0;
            label2.Text = "Quản lý thiết bị";
            // 
            // Input_Search
            // 
            Input_Search.ForeColor = Color.Gray;
            Input_Search.Location = new Point(30, 59);
            Input_Search.Name = "Input_Search";
            Input_Search.Size = new Size(167, 27);
            Input_Search.TabIndex = 1;
            Input_Search.TextChanged += Input_Search_TextChanged;
            // 
            // Btn_Add
            // 
            Btn_Add.BackColor = Color.Black;
            Btn_Add.Cursor = Cursors.Hand;
            Btn_Add.ForeColor = Color.White;
            Btn_Add.Location = new Point(634, 55);
            Btn_Add.Name = "Btn_Add";
            Btn_Add.Size = new Size(131, 35);
            Btn_Add.TabIndex = 2;
            Btn_Add.Text = "Thêm thiết bị";
            Btn_Add.UseVisualStyleBackColor = false;
            Btn_Add.Click += Btn_Add_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(importExcel);
            panel2.Controls.Add(btn_delete);
            panel2.Controls.Add(btn_fix);
            panel2.Controls.Add(dataGridView1);
            panel2.Controls.Add(Btn_Add);
            panel2.Controls.Add(Input_Search);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(62, 117);
            panel2.Name = "panel2";
            panel2.Size = new Size(913, 349);
            panel2.TabIndex = 2;
            panel2.Paint += panel2_Paint;
            // 
            // importExcel
            // 
            importExcel.BackColor = Color.MediumSeaGreen;
            importExcel.Cursor = Cursors.Hand;
            importExcel.ForeColor = Color.White;
            importExcel.Location = new Point(771, 55);
            importExcel.Name = "importExcel";
            importExcel.Size = new Size(131, 35);
            importExcel.TabIndex = 6;
            importExcel.Text = "Import Excel";
            importExcel.UseVisualStyleBackColor = false;
            importExcel.Click += importExcel_Click;
            // 
            // btn_delete
            // 
            btn_delete.Cursor = Cursors.Hand;
            btn_delete.Location = new Point(813, 245);
            btn_delete.Name = "btn_delete";
            btn_delete.Size = new Size(86, 35);
            btn_delete.TabIndex = 5;
            btn_delete.Text = "Xóa";
            btn_delete.UseVisualStyleBackColor = true;
            btn_delete.Click += btn_delete_Click;
            // 
            // btn_fix
            // 
            btn_fix.Cursor = Cursors.Hand;
            btn_fix.Location = new Point(813, 137);
            btn_fix.Name = "btn_fix";
            btn_fix.Size = new Size(86, 35);
            btn_fix.TabIndex = 4;
            btn_fix.Text = "Sửa";
            btn_fix.UseVisualStyleBackColor = true;
            btn_fix.Click += btn_fix_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(98, 112);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(699, 197);
            dataGridView1.TabIndex = 3;
            // 
            // Btn_Back
            // 
            Btn_Back.Cursor = Cursors.Hand;
            Btn_Back.Location = new Point(62, 69);
            Btn_Back.Name = "Btn_Back";
            Btn_Back.Size = new Size(86, 35);
            Btn_Back.TabIndex = 3;
            Btn_Back.Text = "Quay lại";
            Btn_Back.UseVisualStyleBackColor = true;
            Btn_Back.Click += Btn_Back_Click;
            // 
            // QLThietBi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 499);
            Controls.Add(Btn_Back);
            Controls.Add(panel2);
            Controls.Add(panel1);
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
        private Button Btn_Logout;
        private Label label1;
        private Label label2;
        private TextBox Input_Search;
        private Button Btn_Add;
        private Panel panel2;
        private DataGridViewButtonColumn AdjustButton;
        private Button Btn_Back;
        private DataGridView dataGridView1;
        private Button btn_delete;
        private Button btn_fix;
        private Button importExcel;
    }
}