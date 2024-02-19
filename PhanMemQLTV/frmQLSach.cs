using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PhanMemQLTV
{
    public partial class frmQLSach : Form
    {
        public frmQLSach()
        {
            InitializeComponent();
        }
        private SqlConnection myConnection;
        private SqlDataAdapter myDataAdapter;
        private DataTable myTable;
        private SqlCommand myCommand;

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
            dataGridViewDSSach.DataSource = myTable;
            return myTable;
        }

        private void setControls(bool edit)
        {
            txtTenSach.Enabled = edit;
            txtChuDe.Enabled = edit;
            txtTacGia.Enabled = edit;
            txtNXB.Enabled = edit;
            txtNamXB.Enabled = edit;
            txtSLNhap.Enabled = edit;
            cboTinhTrang.Enabled = edit;
            txtDonGia.Enabled = edit;
            txtGhiChu.Enabled = edit;
        }

        private void frmQLSach_Load(object sender, EventArgs e)
        {
            string cauTruyVan = "select * from tblSach";
            dataGridViewDSSach.DataSource = ketnoi(cauTruyVan);
            dataGridViewDSSach.AutoGenerateColumns = false;
            myConnection.Close();
            setControls(false);
            dataGridViewDSSach.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            txtMaSach.Enabled = false;   
        }

        public string maSach, tenSach, tacGia, chuDe, nXB, namXB, slNhap, donGia, tinhTrang, ghiChu;
        private void dataGridViewDSSach_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            txtMaSach.Text = myTable.Rows[row]["MaSach"].ToString();
            maSach = txtMaSach.Text;
            txtTenSach.Text = myTable.Rows[row]["TenSach"].ToString();
            tenSach = txtTenSach.Text;
            txtChuDe.Text = myTable.Rows[row]["ChuDe"].ToString();
            chuDe = txtChuDe.Text;
            txtTacGia.Text = myTable.Rows[row]["TacGia"].ToString();
            tacGia = txtTacGia.Text;
            txtNXB.Text = myTable.Rows[row]["NXB"].ToString();
            nXB = txtNXB.Text;
            txtNamXB.Text = myTable.Rows[row]["NamXB"].ToString();
            namXB = txtNamXB.Text;
            txtSLNhap.Text = myTable.Rows[row]["SLNhap"].ToString();
            slNhap = txtSLNhap.Text;
            txtDonGia.Text = myTable.Rows[row]["DonGia"].ToString();
            donGia = txtDonGia.Text;
            cboTinhTrang.Text = myTable.Rows[row]["TinhTrang"].ToString();
            tinhTrang = cboTinhTrang.Text;
            txtGhiChu.Text = myTable.Rows[row]["GhiChu"].ToString();
            ghiChu = txtGhiChu.Text;
        }

        public int xuly;
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaSach.Text = tangMaTuDong();
            txtTenSach.Text = "";
            txtChuDe.Text = "";
            txtTacGia.Text = "";
            txtNXB.Text = "";
            txtSLNhap.Text = "";
            txtNamXB.Text = "";
            txtDonGia.Text = "";
            txtGhiChu.Text = "";

            setControls(true);
            dataGridViewDSSach.Enabled = false;
            txtTenSach.Focus();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            xuly = 0;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            setControls(true);
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            dataGridViewDSSach.Enabled = false;
            txtTenSach.Focus();
            xuly = 1;
        }

        private void xoaSach()
        {
            DialogResult dlr;
            dlr = MessageBox.Show("Bạn chắc chắn muốn xóa.", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                try
                {
                    string xoadongSql;
                    xoadongSql = "DELETE FROM tblSach WHERE MaSach='" + txtMaSach.Text + "'";
                    ketnoi(xoadongSql);
                    myCommand.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công.", "Thông Báo");
                }
                catch
                {
                    MessageBox.Show("Xóa thất bại.\nSách này đang được mượn.", "Thông Báo");
                }
            }
            string cauTruyVan = "select * from tblSach";
            dataGridViewDSSach.DataSource = ketnoi(cauTruyVan);
            myConnection.Close();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            xoaSach();
        }

        private void themSach()
        {
            try
            {
                string themdongSql;
                themdongSql = "insert into tblSach values ('" + txtMaSach.Text + "',N'" + txtTenSach.Text + "',N'" + txtChuDe.Text + "',N'" + txtTacGia.Text + "',N'" + txtNXB.Text + "','" + txtNamXB.Text + "','" + txtSLNhap.Text + "','" + txtDonGia.Text + "',N'" + cboTinhTrang.Text + "',N'" + txtGhiChu.Text + "')";
                ketnoi(themdongSql);
                MessageBox.Show("Thêm thành công.", "Thông Báo");
                myCommand.ExecuteNonQuery();
                myConnection.Close();
            }
            catch
            {
            }
        }

        private void suaSach()
        {
            try
            {
                string capnhatdong;
                capnhatdong = "update tblSach set TenSach=N'" + txtTenSach.Text + "',ChuDe=N'" + txtChuDe.Text + "',TacGia=N'" + txtTacGia.Text + "',NXB=N'" + txtNXB.Text + "',NamXB='" + txtNamXB.Text + "',SLNhap='" + txtSLNhap.Text + "',DonGia='" + txtDonGia.Text + "',TinhTrang=N'" + cboTinhTrang.Text + "',GhiChu=N'" + txtGhiChu.Text + "' where MaSach='" + txtMaSach.Text + "'";
                ketnoi(capnhatdong);
                myCommand.ExecuteNonQuery();
                MessageBox.Show("Sửa thành công.", "Thông Báo");
            }
            catch
            {
                MessageBox.Show("Sửa thất bại.\nVui lòng kiểm tra lại dữ liệu.", "Thông Báo");
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            //code mới
            bool check = true;
            if (!Validation.isNameValid(txtTenSach.Text))
            {
                check = false;
                errTenSach.SetError(txtTenSach, "Tên sách có độ dài từ 1 đến 50 ký tự (không được chỉ chứa khoảng trắng,\nkhông được chứa số và ký tự đặc biệt!");
            }
            else
            {
                errTenSach.Clear();
            }

            if (!Validation.isNameValid(txtChuDe.Text))
            {
                check = false;
                errCD.SetError(txtChuDe, "Chủ đề có độ dài từ 1 đến 50 ký tự (không được chỉ chứa khoảng trắng,\nkhông được chứa số và ký tự đặc biệt!");
            }
            else
            {
                errCD.Clear();
            }

            if (!Validation.isNameValid(txtTacGia.Text))
            {
                errTG.SetError(txtTacGia, "Tên tác giả có độ dài từ 1 đến 50 ký tự (không được chỉ chứa khoảng trắng,\nkhông được chứa số và ký tự đặc biệt!");
            }
            else
            {
                errTG.Clear();
            }

            if (!Validation.isNameValid(txtNXB.Text))
            {
                check = false;
                errNXB.SetError(txtNXB, "NXB có độ dài từ 1 đến 50 ký tự (không được chỉ chứa khoảng trắng,\nkhông được chứa số và ký tự đặc biệt!");
            }
            else
            {
                errNXB.Clear();
            }

            if (!Validation.isYearValid(txtNamXB.Text))
            {
                check = false;
                errNamXB.SetError(txtNamXB, "Năm xuất bản nằm trong khoảng 1900 đến nay!");
            }
            else
            {
                errNXB.Clear();
            }

            if (!Validation.isQuantityValid(txtSLNhap.Text))
            {
                check = false;
                errSLNhap.SetError(txtSLNhap, "Số lượng nằm trong khoảng từ 1-999");
            }
            else
            {
                errSLNhap.Clear();
            }

            if (!Validation.isPriceValid(txtDonGia.Text))
            {
                check = false;
                errDonGia.SetError(txtDonGia, "Đơn giá chỉ chứa số");
            }
            else
            {
                errDonGia.Clear();
            }

            if (check) {
                if (xuly == 0)
                {
                    themSach();
                }
                else
                {
                    suaSach();

                }
                string cauTruyVan = "select * from tblSach";
                dataGridViewDSSach.DataSource = ketnoi(cauTruyVan);
                dataGridViewDSSach.AutoGenerateColumns = false;
                myConnection.Close();
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                setControls(false);
                dataGridViewDSSach.Enabled = true;

                errTenSach.Clear();
                errCD.Clear();
                errTG.Clear();
                errNamXB.Clear();
                errNXB.Clear();
                errDonGia.Clear();
                errSLNhap.Clear();
                errTinhTrang.Clear();
            
            }
            else
            {
                MessageBox.Show("Vui lòng nhập thông tin hợp lệ!", "Thông Báo");
            }      
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaSach.Text = maSach;
            txtTenSach.Text = tenSach;
            txtChuDe.Text = chuDe;
            txtTacGia.Text = tacGia;
            txtNXB.Text = nXB;
            txtSLNhap.Text = slNhap;
            txtDonGia.Text = donGia;
            cboTinhTrang.Text = tinhTrang;
            txtGhiChu.Text = ghiChu;
            setControls(false);
            dataGridViewDSSach.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;

            errTenSach.Clear();
            errCD.Clear();
            errTG.Clear();
            errNamXB.Clear();
            errNXB.Clear();
            errDonGia.Clear();
            errSLNhap.Clear();
            errTinhTrang.Clear();
        }

        private void btnLoadDS_Click(object sender, EventArgs e)
        {
            lblNhapCD.Text = "";
            lblNhapDonGia.Text = "";
            lblNhapSLCon.Text = "";
            lblNhapSLNhap.Text = "";
            lblNhapTenNXB.Text = "";
            lblNhapTenSach.Text = "";
            lblNhapTenTG.Text = "";
            lblNhapTinhTrang.Text = "";
            setControls(false);
            txtNDTimKiem.Text = "";
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            string cauTruyVan = "select * from tblSach";
            dataGridViewDSSach.DataSource = ketnoi(cauTruyVan);
            dataGridViewDSSach.AutoGenerateColumns = false;
            myConnection.Close();
        }
        private void timKiemSach()
        {
            if (radMaSach.Checked)
            {
                string timkiemMS = "select * from tblSach where MaSach like '%" + txtNDTimKiem.Text + "%'";
                ketnoi(timkiemMS);
                myCommand.ExecuteNonQuery();
                dataGridViewDSSach.DataSource = myTable;
                dataGridViewDSSach.AutoGenerateColumns = false;
                myConnection.Close();
            }
            else if (radTenSach.Checked)
            {
                string timkiemTS = "select * from tblSach where TenSach like N'%" + txtNDTimKiem.Text + "%'";
                ketnoi(timkiemTS);
                myCommand.ExecuteNonQuery();
                dataGridViewDSSach.DataSource = ketnoi(timkiemTS);
                dataGridViewDSSach.AutoGenerateColumns = false;
                myConnection.Close();
            }
            else if (radTenTG.Checked)
            {
                string timkiemMS = "select * from tblSach where TacGia like N'%" + txtNDTimKiem.Text + "%'";
                ketnoi(timkiemMS);
                myCommand.ExecuteNonQuery();
                dataGridViewDSSach.DataSource = myTable;
                dataGridViewDSSach.AutoGenerateColumns = false;
                myConnection.Close();
            }
            else if (radTenCD.Checked)
            {
                string timkiemMS = "select * from tblSach where ChuDe like N'%" + txtNDTimKiem.Text + "%'";
                ketnoi(timkiemMS);
                myCommand.ExecuteNonQuery();
                dataGridViewDSSach.DataSource = myTable;
                dataGridViewDSSach.AutoGenerateColumns = false;
                myConnection.Close();
            }
        }
        private void txtNDTimKiem_TextChanged(object sender, EventArgs e)
        {
            timKiemSach();
        }
        public string tangMaTuDong()
        {
            string cauTruyVan = "select * from tblSach";
            dataGridViewDSSach.DataSource = ketnoi(cauTruyVan);
            dataGridViewDSSach.AutoGenerateColumns = false;
            myConnection.Close();
            return Config.tangMaTuDong("ms", myTable);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
