using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PhanMemQLTV
{
    public partial class frmQLDocGia : Form
    {
        public frmQLDocGia()
        {
            InitializeComponent();
        }

        // Khai báo 
        private SqlConnection myConnection; // kết nối tới csdl
        private SqlDataAdapter myDataAdapter;   // Vận chuyển csdl qa DataSet
        private DataTable myTable;  // Dùng để lưu bảng lấy từ c#
        SqlCommand myCommand;   // Thực hiện cách lệnh truy vấn
        private bool changePass = false;

        // Phương thức kết nối
        private DataTable ketnoi(string truyvan)
        {
            myConnection = new SqlConnection(Config.chuoiKetNoi());
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
            txtTenTK.Enabled = edit;
            txtMK.Enabled = edit;
            txtGhiChu.Enabled = edit;
            cboLoaiDG.Enabled = edit;
        }

        // Load
        private void frmQLDocGia_Load(object sender, EventArgs e)
        {
            string cauTruyVan = "select * from tblDocGia";
            dataGridViewDSDocGia.DataSource = ketnoi(cauTruyVan);
            dataGridViewDSDocGia.AutoGenerateColumns = false;
            dataGridViewDSDocGia.Columns[9].Visible = false;
            myConnection.Close();
            setControls(false);
            dataGridViewDSDocGia.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            txtMaDG.Enabled = false;
            txtMK.UseSystemPasswordChar = true;
        }

        // Phương thức hiển thị các thuộc tính bảng Độc Giả lên txt
        public string maDG, tenDG, gioiTinhDG, ngaySinhDG, diaChiDG, sdtDG, loaiDG, ghiChu, tenTK, mK;
        private void dataGridViewDSDocGia_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int row = e.RowIndex;
                txtMaDG.Text = myTable.Rows[row]["MaDG"].ToString();
                maDG = txtMaDG.Text;
                txtTenDG.Text = myTable.Rows[row]["TenDG"].ToString();
                tenDG = txtTenDG.Text;
                cboGioiTinh.Text = myTable.Rows[row]["GioiTinhDG"].ToString();
                gioiTinhDG = cboGioiTinh.Text;
                dtmNgaySinh.Text = myTable.Rows[row]["NgaySinhDG"].ToString();
                ngaySinhDG = dtmNgaySinh.Text;
                txtSoDT.Text = myTable.Rows[row]["SDTDG"].ToString();
                sdtDG = txtSoDT.Text;
                txtDiaChi.Text = myTable.Rows[row]["DiaChiDG"].ToString();
                diaChiDG = txtDiaChi.Text;
                cboLoaiDG.Text = myTable.Rows[row]["LoaiDG"].ToString();
                loaiDG = cboLoaiDG.Text;
                txtGhiChu.Text = myTable.Rows[row]["GhiChu"].ToString();
                ghiChu = txtGhiChu.Text;
                txtTenTK.Text = myTable.Rows[row]["taikhoan"].ToString();
                tenTK = txtTenTK.Text;
                txtMK.Text = myTable.Rows[row]["matkhau"].ToString();
                mK = txtMK.Text;
            }
            catch
            {

            }
        }

        // Phương thức thêm ĐG
        private void btnThem_Click(object sender, EventArgs e)
        {
            frmDangKyDG frm = new frmDangKyDG();
            frm.isTT = true;
            frm.Show();
        }

        // Phương thức sửa thông tin độc giả
        private void suaDG()
        {
            setControls(true);
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnThem.Enabled = false;
            txtTenDG.Focus();
            dataGridViewDSDocGia.Enabled = false;
            txtMK.Enabled = false;
            txtTenTK.Enabled = false;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            suaDG();
            chkSuaMk.Visible = true;
        }

        private void chkSuaMk_CheckedChanged(object sender, EventArgs e)
        {
            changePass = chkSuaMk.Checked;
            txtMK.Enabled = changePass;
        }

        // Phương thức xóa độc giả
        private void btnXoa_Click(object sender, EventArgs e)
        {
            xoaDG();
        }
        private void xoaDG()
        {
            DialogResult dlr;
            dlr = MessageBox.Show("Bạn chắc chắn muốn xóa.", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                try
                {
                    string xoadongsql = "delete from tblDocGia where MaDG='" + txtMaDG.Text + "'";
                    ketnoi(xoadongsql);
                    myCommand.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công.", "Thông Báo");
                    //btnXoa.Enabled = false;
                }
                catch (Exception)
                {
                    MessageBox.Show("Xóa thất bại.\nĐộc Giả này đang mượn sách.", "Thông Báo");
                }
            }
            string cauTruyVan = "select * from tblDocGia";
            dataGridViewDSDocGia.DataSource = ketnoi(cauTruyVan);
            dataGridViewDSDocGia.AutoGenerateColumns = false;
            myConnection.Close();
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            // code mới
            bool check = true;
            if (!Validation.isNameValid(txtTenDG.Text.Trim()))
            {
                check = false;
                errTenDG.SetError(txtTenDG, "Tên có độ dài từ 1 đến 50 ký tự (không được chỉ chứa khoảng trắng,\nkhông được chứa số và ký tự đặc biệt!");
            }
            else
            {
                errTenDG.Clear();
            }

            if (changePass) {
                if (!Validation.isPassValid(txtMK.Text))
                {
                    check = false;
                    errMK.SetError(txtMK, "Mật khẩu có độ dài từ 8 đến 10 ký tự,\nchứa ít nhất 1 chữ hoa, chữ thường, số và ký tự đặc biệt!");
                }
                else
                {
                    errMK.Clear();
                }
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
            // code cũ

            if (cboGioiTinh.Text == "")
            {
                check = false;
                errGT.SetError(cboGioiTinh, "Vui lòng chọn Giới Tính");
            }
            else
            {
                errGT.Clear();
            }

            if (cboLoaiDG.Text == "")
            {
                check = false;
                errLoaiDG.SetError(cboLoaiDG, "Vui lòng nhập Loại ĐG");
            }
            else
            {
                errLoaiDG.Clear();
            }

            if (check)
            {
                string whereClause = "' where MaDG='" + txtMaDG.Text + "'";
                string capnhatdongsql = "update tblDocGia set TenDG=N'" + txtTenDG.Text + "',GioiTinhDG=N'" + cboGioiTinh.Text + "',NgaySinhDG='" + dtmNgaySinh.Text + "',DiaChiDG=N'" + txtDiaChi.Text + "',SDTDG='" + txtSoDT.Text + "',LoaiDG=N'" + cboLoaiDG.Text + "',GhiChu=N'" + txtGhiChu.Text + "',taikhoan='" + txtTenTK.Text;
                capnhatdongsql += changePass ? "',matkhau='" + Config.md5_Hash(txtMK.Text) : "";
                capnhatdongsql += whereClause;
                ketnoi(capnhatdongsql);
                myCommand.ExecuteNonQuery();
                MessageBox.Show("Sửa thành công.", "Thông Báo");
                //
                string cauTruyVan = "select * from tblDocGia";
                dataGridViewDSDocGia.DataSource = ketnoi(cauTruyVan);
                dataGridViewDSDocGia.AutoGenerateColumns = false;
                myConnection.Close();
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                chkSuaMk.Visible = false;
                setControls(false);
                dataGridViewDSDocGia.Enabled = true;
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin hợp lệ!", "Thông Báo");
            }
        }

        // Phương thức nút hủy
        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaDG.Text = maDG;
            txtTenDG.Text = tenDG;
            txtSoDT.Text = sdtDG;
            txtDiaChi.Text = diaChiDG;
            cboGioiTinh.Text = gioiTinhDG;
            dtmNgaySinh.Text = ngaySinhDG;
            cboLoaiDG.Text = loaiDG;
            txtGhiChu.Text = ghiChu;
            txtTenTK.Text = tenTK;
            txtMK.Text = mK;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            setControls(false);
            dataGridViewDSDocGia.Enabled = true;
            chkSuaMk.Visible = false;
            errMK.Clear();
            errSDT.Clear();
            errTenTK.Clear();
            errTenDG.Clear();
            errDC.Clear();
            errLoaiDG.Clear();
            errGT.Clear();
        }

        // Tìm kiếm 
        private void txtNDTimKiem_TextChanged(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            //btnSua.Enabled = false;
            if (radMaDG.Checked)
            {
                string timkiem = "select * from tblDocGia where MaDG like '%" + txtNDTimKiem.Text + "%'";
                ketnoi(timkiem);
                myCommand.ExecuteNonQuery();
                dataGridViewDSDocGia.DataSource = ketnoi(timkiem);
                dataGridViewDSDocGia.AutoGenerateColumns = false;
                myConnection.Close();
            }
            else if (radTenDG.Checked)
            {
                string timkiem = "select * from tblDocGia where TenDG like N'%" + txtNDTimKiem.Text + "%'";
                ketnoi(timkiem);
                myCommand.ExecuteNonQuery();
                dataGridViewDSDocGia.DataSource = ketnoi(timkiem);
                dataGridViewDSDocGia.AutoGenerateColumns = false;
                myConnection.Close();
            }
        }

        // Phương thức nút Load DS
        private void btnLoadDS_Click(object sender, EventArgs e)
        {
            lblNhapTenDG.Text = "";
            lblNhapNgaySinh.Text = "";
            lblNhapGioiTinh.Text = "";
            lblNhapSDT.Text = "";
            lblNhapDiaChi.Text = "";
            setControls(false);
            txtNDTimKiem.Text = "";
            string cauTruyVan = "select * from tblDocGia";
            dataGridViewDSDocGia.DataSource = ketnoi(cauTruyVan);
            dataGridViewDSDocGia.AutoGenerateColumns = false;
            myConnection.Close();
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        // Thoát form
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
