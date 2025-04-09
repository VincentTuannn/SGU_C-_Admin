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
            textBox1 = new TextBox();
            button3 = new Button();
            panel2 = new Panel();
            dataGridView1 = new DataGridView();
            button6 = new Button();
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
            panel1.Name = "panel1";
            panel1.Size = new Size(1022, 62);
            panel1.TabIndex = 1;
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.Cursor = Cursors.Hand;
            button2.Location = new Point(851, 17);
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
            // textBox1
            // 
            textBox1.ForeColor = Color.Gray;
            textBox1.Location = new Point(30, 58);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(167, 27);
            textBox1.TabIndex = 1;
            // 
            // button3
            // 
            button3.BackColor = Color.Black;
            button3.Cursor = Cursors.Hand;
            button3.ForeColor = Color.White;
            button3.Location = new Point(730, 50);
            button3.Name = "button3";
            button3.Size = new Size(131, 35);
            button3.TabIndex = 2;
            button3.Text = "Thêm thiết bị";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(dataGridView1);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(62, 117);
            panel2.Name = "panel2";
            panel2.Size = new Size(913, 349);
            panel2.TabIndex = 2;
            panel2.Paint += panel2_Paint;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(98, 112);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(699, 198);
            dataGridView1.TabIndex = 3;
            // 
            // button6
            // 
            button6.Location = new Point(62, 70);
            button6.Name = "button6";
            button6.Size = new Size(86, 34);
            button6.TabIndex = 3;
            button6.Text = "Quay lại";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // QLThietBi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 499);
            Controls.Add(button6);
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
        private Button button2;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Button button3;
        private Panel panel2;
        private DataGridViewButtonColumn AdjustButton;
        private Button button6;
        private DataGridView dataGridView1;
    }
}