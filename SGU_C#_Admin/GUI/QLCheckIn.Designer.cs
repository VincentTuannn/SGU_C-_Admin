﻿namespace SGU_C__User.GUI
{
    partial class QLCheckIn
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
            dataGridView1 = new DataGridView();
            Input_Search = new TextBox();
            label2 = new Label();
            Btn_Logout = new Button();
            label1 = new Label();
            Btn_Back = new Button();
            panel1 = new Panel();
            btnCheckIn = new Button();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(dataGridView1);
            panel2.Controls.Add(Input_Search);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(btnCheckIn);
            panel2.Location = new Point(59, 116);
            panel2.Name = "panel2";
            panel2.Size = new Size(1094, 359);
            panel2.TabIndex = 10;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(134, 114);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(683, 193);
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
            label2.Size = new Size(190, 31);
            label2.TabIndex = 0;
            label2.Text = "Quản lý check in";
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
            Btn_Back.Location = new Point(59, 69);
            Btn_Back.Name = "Btn_Back";
            Btn_Back.Size = new Size(83, 32);
            Btn_Back.TabIndex = 11;
            Btn_Back.Text = "Quay lại";
            Btn_Back.UseVisualStyleBackColor = true;
            Btn_Back.Click += Btn_Back_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Blue;
            panel1.Controls.Add(Btn_Logout);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(1, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1161, 62);
            panel1.TabIndex = 9;
            // 
            // btnCheckIn
            // 
            btnCheckIn.Text = "Check-in";
            btnCheckIn.Location = new Point(240, 58);
            btnCheckIn.Size = new Size(100, 27);
            btnCheckIn.Click += btnCheckIn_Click;
            // 
            // QLCheckIn
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1164, 535);
            Controls.Add(panel2);
            Controls.Add(Btn_Back);
            Controls.Add(panel1);
            Name = "QLCheckIn";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý check in";
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
        private Button Btn_Logout;
        private Label label1;
        private Button Btn_Back;
        private Panel panel1;
        private Button btnCheckIn;
    }
}