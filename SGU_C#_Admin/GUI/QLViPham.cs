using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace SGU_C__User
{
    public partial class QLViPham : Form
    {
        public QLViPham()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            TrangChu mainForm = new TrangChu();
            mainForm.Show();
            this.Close(); // Đóng form hiện tại
        }

        private void QLViPham_Load(object sender, EventArgs e)
        {

        }
    }
}
