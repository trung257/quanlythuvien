using System;
using System.Windows.Forms;

namespace PhanMemQLTV
{
    public partial class frmGiaoDienChinh : Form
    {
        public string taikhoan;
        public frmGiaoDienChinh()
        {
            InitializeComponent();
        }

        private void QLSachToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmQLSach frm = new frmQLSach();
            frm.Show();
        }

        private void QLDGToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmQLDocGia QLDocGia = new frmQLDocGia();
            QLDocGia.Show();
        }

        private void QLMuonTraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQLMuonTra frm = new frmQLMuonTra();
            frm.Show();
        }

        private void BCTKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBaoCaoThongKe frm = new frmBaoCaoThongKe();
            frm.Show();
        }

        private void DangKyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDangKyTT DKTT = new frmDangKyTT();
            DKTT.Show();
        }

        private void DoiMatKhauToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmDoiMatKhau DMK = new frmDoiMatKhau("tt");
            DMK.taikhoan = taikhoan.ToUpper();
            DMK.Show();
        }

        private void frmGiaoDienChinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ThoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
