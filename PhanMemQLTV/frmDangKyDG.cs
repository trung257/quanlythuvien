using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PhanMemQLTV
{
    public partial class frmDangKyDG : Form
    {
        public bool isTT = false;
        public frmDangKyDG()
        {
            InitializeComponent();
            if (isTT)
            {
                label11.Visible = !isTT;
                btnThem.Visible = isTT;
            }
        }

        // Khai báo 
        private SqlConnection myConnection; // kết nối tới csdl
        private SqlDataAdapter myDataAdapter;   // Vận chuyển csdl qa DataSet
        private DataTable myTable;  // Dùng để lưu bảng lấy từ c#
        SqlCommand myCommand;   // Thực hiện cách lệnh truy vấn

        // Load
        private void frmQLDocGia_Load(object sender, EventArgs e)
        {
            label11.Visible = !isTT;
            btnThem.Visible = isTT;
            setControls(false);
            btnThem_Click(sender, e);
            setMaDG();
            dataGridViewDSDocGia.Hide();
            txtMK.UseSystemPasswordChar = true;
            btnLuu.Enabled = true;
            btnThoat.Enabled = true;
            txtMaDG.Enabled = false;
        }

        // Phương thức kết nối
        private DataTable ketnoi(string truyvan)
        {
            string chuoiKetNoi = Config.chuoiKetNoi();
            myConnection = new SqlConnection(chuoiKetNoi);
            myConnection.Open();
            string thuchiencaulenh = truyvan;
            myCommand = new SqlCommand(thuchiencaulenh, myConnection);
            myDataAdapter = new SqlDataAdapter(myCommand);
            myTable = new DataTable();
            myDataAdapter.Fill(myTable);
            dataGridViewDSDocGia.DataSource = myTable;
            return myTable;
        }

        // Phương thức thiết lập Controls
        private void setControls(bool edit)
        {
            txtTenDG.Enabled = edit;
            dtmNgaySinh.Enabled = edit;
            cboGioiTinh.Enabled = edit;
            txtDiaChi.Enabled = edit;
            txtSoDT.Enabled = edit;
            txtMK.Enabled = edit;
            txtGhiChu.Enabled = edit;
            cboLoaiDG.Enabled = edit;
        }

        // Phương thức tăng mã DG tự động
        public void setMaDG()
        {
            string cauTruyVan = "select * from tblDocGia";
            dataGridViewDSDocGia.DataSource = ketnoi(cauTruyVan);
            dataGridViewDSDocGia.AutoGenerateColumns = false;
            myConnection.Close();
            txtMaDG.Text = Config.tangMaTuDong("dg",myTable);
            txtTenTK.Text = txtMaDG.Text;
        }

        public void clearData()
        {
            txtTenDG.Text = "";
            txtSoDT.Text = "";
            txtDiaChi.Text = "";
            cboGioiTinh.Text = "Nam";
            dtmNgaySinh.Text = "";
            cboLoaiDG.Text = "Sinh viên";
            txtGhiChu.Text = "";
            txtMK.Text = "";
        }

        // Phương thức thêm ĐG
        public int xuly;
        private void btnThem_Click(object sender, EventArgs e)
        {
            setControls(true);
            clearData();
            txtTenDG.Focus();
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnThoat.Enabled = true;
            xuly = 0;
            dataGridViewDSDocGia.Enabled = false;
            btnLuu.Focus();
        }
        // Lưu
        private void themDG()
        {
            try
            {
                string themdongsql = "insert into tblDocGia values ('" + txtMaDG.Text + "',N'" + txtTenDG.Text + "',N'" + cboGioiTinh.Text + "','" + dtmNgaySinh.Text + "','" + txtSoDT.Text + "',N'" + txtDiaChi.Text + "',N'" + cboLoaiDG.Text + "',N'" + txtGhiChu.Text + "','" + txtTenTK.Text + "','" + Config.md5_Hash(txtMK.Text) + "')";
                ketnoi(themdongsql);
                string message = isTT ? "Thêm thành công!" : "Đăng ký thành công!";
                MessageBox.Show(message, "Thông Báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool checkData()
        {
            bool check = true;
            if (!Validation.isNameValid(txtTenDG.Text))
            {
                check = false;
                errTenDG.SetError(txtTenDG, "Tên có độ dài từ 1 đến 50 ký tự (không được chỉ chứa khoảng trắng,\nkhông được chứa số và ký tự đặc biệt!");
            }
            else
            {
                errTenDG.Clear();
            }

            if (!Validation.isPassValid(txtMK.Text))
            {
                check = false;
                errMK.SetError(txtMK, "Mật khẩu có độ dài từ 8 đến 10 ký tự,\nchứa ít nhất 1 chữ hoa, chữ thường, số và ký tự đặc biệt!");
            }
            else
            {
                errMK.Clear();
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

            if (!Validation.isPhoneValid(txtSoDT.Text))
            {
                check = false;
                errSDT.SetError(txtSoDT, "Số điện thoại không hợp lệ!");
            }
            else
            {
                errSDT.Clear();
            }
            return check;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(checkData())
            {
                themDG();
                clearData();
                btnLuu.Enabled = false;
                btnThoat.Enabled = false;
                btnThem.Enabled = true;
                setMaDG();
                setControls(false);
                dataGridViewDSDocGia.Enabled = true;
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin hợp lệ!", "Thông Báo");
            }
        }

        private void dangNhap_Click(object sender, EventArgs e)
        {
            frmDangNhap frmDN = new frmDangNhap();
            this.Hide();
            frmDN.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (isTT)
            {
                this.Hide();
            }
            else
            {
                Application.Exit();
            }
        }

        private void frmDangKyDG_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(isTT)
            {
                this.Hide();
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
