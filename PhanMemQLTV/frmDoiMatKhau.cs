using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PhanMemQLTV
{
    public partial class frmDoiMatKhau : Form
    {
        private SqlConnection myConnection = new SqlConnection(Config.chuoiKetNoi());
        private SqlCommand myCommand;
        public string taikhoan;
        private string role;
        public frmDoiMatKhau(string role)
        {
            InitializeComponent();
            this.role = role;
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            frmDangNhap frmDangNhap = new frmDangNhap();
            if(frmDangNhap.checkInfo(role,taikhoan,txtMatKhau.Text) == 1)
            {
                if (Validation.isPassValid(txtMatKhauMoi.Text))
                {
                    if (txtMatKhau.Text != txtMatKhauMoi.Text)
                    {
                        if (txtMatKhauMoi.Text == txtNhapLaiMKMoi.Text)
                        {   
                            string table = role == "tt" ? "tblThuThu" : "tblDocGia";
                            string field = role == "tt" ? "MaTT" : "MaDG";
                            string luumk = "update " + table + " set matkhau='" + Config.md5_Hash(txtMatKhauMoi.Text) + "' where " + field + "='" + txtTenTaiKhoan.Text + "'";
                            myConnection.Open();
                            myCommand = new SqlCommand(luumk, myConnection);
                            myCommand.ExecuteNonQuery();
                            myConnection.Close();
                            MessageBox.Show("Đổi mật khẩu thành công.", "Thông Báo");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Mật khẩu nhập lại không khớp!", "Thông Báo");
                            txtMatKhauMoi.Clear();
                            txtNhapLaiMKMoi.Clear();
                            txtMatKhauMoi.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu mới không được trùng mật khẩu cũ!", "Thông Báo");
                        txtMatKhauMoi.Clear();
                        txtNhapLaiMKMoi.Clear();
                        txtMatKhauMoi.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu mới phải có độ dài từ 8 đến 10 ký tự,\nchứa ít nhất 1 chữ hoa, chữ thường, số và ký tự đặc biệt!");
                    txtMatKhauMoi.Clear();
                    txtNhapLaiMKMoi.Clear();
                    txtMatKhauMoi.Focus();
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu cũ không đúng!", "Thông báo");
                txtMatKhau.Clear();
                txtMatKhauMoi.Clear();
                txtNhapLaiMKMoi.Clear();
                txtMatKhau.Focus();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkMatKhauCu_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = chkMatKhauCu.Checked ? false : true;     
        }

        private void chkMatKhauMoi_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhauMoi.UseSystemPasswordChar = chkMatKhauMoi.Checked ? false : true;
        }

        private void chkNhapLaiMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            txtNhapLaiMKMoi.UseSystemPasswordChar = chkNhapLaiMatKhau.Checked ? false : true;
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            txtTenTaiKhoan.Text = taikhoan;
        }
    }
}
