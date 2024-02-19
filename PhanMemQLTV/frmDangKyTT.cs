using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PhanMemQLTV
{
    public partial class frmDangKyTT : Form
    {
        public frmDangKyTT()
        {
            InitializeComponent();
        }
        private SqlConnection myConnection; // kết nối tới csdl
        private SqlDataAdapter myDataAdapter;   // Vận chuyển csdl qa DataSet
        private DataTable myTable;  // Dùng để lưu bảng lấy từ c#
        private SqlCommand myCommand;   // Thực hiện cách lệnh truy vấn

        private DataTable ketnoi(string truyvan)
        {
            myConnection = new SqlConnection(Config.chuoiKetNoi());
            myConnection.Open();
            string thuchiencaulenh = truyvan;
            myCommand = new SqlCommand(thuchiencaulenh, myConnection);
            myDataAdapter = new SqlDataAdapter(myCommand);
            myTable = new DataTable();
            myDataAdapter.Fill(myTable);
            dataGridViewDSTT.DataSource = myTable;
            myConnection.Close();
            return myTable;
        }

        public string setMaTT()
        {
            string cauTruyVan = "select * from tblThuThu";
            dataGridViewDSTT.DataSource = ketnoi(cauTruyVan);
            dataGridViewDSTT.AutoGenerateColumns = false;
            myConnection.Close();
            return Config.tangMaTuDong("tt", myTable);
        }

        private void frmDangKyTT_Load(object sender, EventArgs e)
        {
            dataGridViewDSTT.Hide();
            txtMaTT.Text = setMaTT();
            txtTenTK.Text = txtMaTT.Text;
            cboGioiTinh.Text = "Nam";
            txtMK.UseSystemPasswordChar = true;
            txtNhapLaiMK.UseSystemPasswordChar = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        // Phương thức kiểm tra dữ liệu nhập vào
        private bool checkData()
        {
            bool check = true;
            if (!Validation.isNameValid(txtTenTT.Text))
            {
                check = false;
                errTenTT.SetError(txtTenTT, "Tên có độ dài từ 1 đến 50 ký tự (không được chỉ chứa khoảng trắng),\nkhông được chứa số và ký tự đặc biệt!");
            }
            else
            {
                errTenTT.Clear();
            }

            if (!Validation.isPhoneValid(txtSoDT.Text))
            {
                check = false;
                errSDT.SetError(txtSoDT, "Số điện thoại không hợp lệ!");
            }
            else
            {
                errSDT.Clear();
            }

            if (!Validation.isAddressValid(txtDiaChi.Text))
            {
                check = false;
                errDC.SetError(txtDiaChi, "Địa chỉ có độ dài từ 1 đến 100 ký tự và không chứa ký tự đặc biệt!");
            }
            else
            {
                errDC.Clear();
            }

            if (!Validation.isPassValid(txtMK.Text))
            {
                check = false;
                errMK.SetError(txtMK, "Mật khẩu có độ dài từ 8 đến 10 ký tự,\nchứa ít nhất 1 chữ hoa, chữ thường, số và ký tự đặc biệt!");
            }
            else
            {
                if (txtMK.Text != txtNhapLaiMK.Text)
                {
                    check = false;
                    errNhapLaiMK.SetError(txtNhapLaiMK, "Mật khẩu không trùng khớp!");
                }
                else
                {
                    errNhapLaiMK.Clear();
                }
                errMK.Clear();
            }
            return check;
        }

        private void clearData()
        {
            txtTenTT.Text = "";
            txtSoDT.Text = "";
            txtDiaChi.Text = ""; ;
            txtGhiChu.Text = "";
            txtMK.Text = "";
            txtNhapLaiMK.Text = "";
            cboGioiTinh.Text = "";
            txtMK.Text = "";
            txtMaTT.Text = setMaTT();
            txtTenTK.Text = txtMaTT.Text;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (checkData())
            {
                try
                {
                    string themdongsql = "insert into tblThuThu values ('" + txtMaTT.Text + "',N'" + txtTenTT.Text + "',N'" + cboGioiTinh.Text + "','" + dtmNgaySinh.Text + "','" + txtSoDT.Text + "',N'" + txtDiaChi.Text + "',N'" + txtGhiChu.Text + "','" + txtTenTK.Text + "','" + Config.md5_Hash(txtMK.Text) + "')";
                    ketnoi(themdongsql);
                    MessageBox.Show("Đăng ký thành công.", "Thông Báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                clearData();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin hợp lệ!", "Thông báo");
            }
        }
    }
}
