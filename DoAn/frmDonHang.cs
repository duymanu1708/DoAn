using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace DoAn
{
    public partial class frmDonHang : Form
    {
        public frmDonHang()
        {
            InitializeComponent();
        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            frmRP f = new frmRP();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }
    }
}
