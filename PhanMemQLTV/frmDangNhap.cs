using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PhanMemQLTV
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        private SqlConnection myConnection = new SqlConnection(Config.chuoiKetNoi());
        private SqlCommand myCommand;


        // Phương thức kiểm tra Đk tài khoản
        private bool kTraDK()
        {
            if (txtTenDangNhap.Text.Length <= 0 && txtMatKhau.Text.Length <= 0)
            {
                MessageBox.Show("Vui lòng nhập Tài Khoản và Mật Khẩu!", "Thông Báo");
                return false;
            }
            return true;
        }
        public int checkInfo(string role, string taikhoan, string matkhau)
        {
            string table = role == "tt" ? "tblThuThu" : "tblDocGia";
            myConnection.Open();
            string strCauTruyVan = "select count(*) from " + table + " where taikhoan=@acc and matkhau=@pass";
            myCommand = new SqlCommand(strCauTruyVan, myConnection);
            myCommand.Parameters.Add(new SqlParameter("@acc", taikhoan));
            myCommand.Parameters.Add(new SqlParameter("@pass", Config.md5_Hash(matkhau)));
            int result = (int)myCommand.ExecuteScalar();
            myConnection.Close();
            return result; 
        }
        // Phương thức đăng nhập
        private void dangNhap(string role)
        {
            if (kTraDK())
            {
                if (checkInfo(role, txtTenDangNhap.Text, txtMatKhau.Text) == 1)
                {
                    MessageBox.Show("Đăng nhập thành công.", "Thông Báo");
                    if (role == "tt")
                    {
                        
                        frmGiaoDienChinh GiaoDienChinh = new frmGiaoDienChinh();
                        GiaoDienChinh.taikhoan = txtTenDangNhap.Text;
                        this.Hide();
                        GiaoDienChinh.Show();
                    }
                    else if (role == "dg")
                    {
                        frmDocGia frm = new frmDocGia();
                        frm.taikhoan = txtTenDangNhap.Text;
                        this.Hide();
                        frm.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Sai Tên Đăng Nhập hoặc Mật Khẩu.\nVui lòng nhập lại.", "Thông Báo");
                    txtMatKhau.Clear();
                    txtTenDangNhap.Focus();
                }
            }

        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (chkQuanTri.Checked)
            {
                try
                {
                    dangNhap("tt");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (chkDocGia.Checked)
            {
                try
                {
                    dangNhap("dg");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            frmDangKyDG frmDKDG = new frmDangKyDG();
            frmDKDG.isTT = false;
            this.Hide();
            frmDKDG.Show();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            chkQuanTri.Checked = true;
        }

        private void frmDangNhap_FormClosed(object sender, FormClosingEventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn chắc chắn muốn thoát?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dlr != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
