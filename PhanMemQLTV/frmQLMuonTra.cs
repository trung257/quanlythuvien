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
using System.Configuration;
using System.Globalization;

namespace PhanMemQLTV
{
    public partial class frmQLMuonTra : Form
    {
        public frmQLMuonTra()
        {
            InitializeComponent();
        }

        private SqlConnection myConnection;
        private SqlDataAdapter myDataAdapter;
        private SqlCommand myCommand;
        private DataTable myTable;

        private DataTable myTableSach;
        private DataTable myTableDG;
        private SqlDataReader myDataReaderSach;
        private SqlDataReader myDataReaderSLSachDaMuon;

        private void frmQLMuonTra_Load(object sender, EventArgs e)
        {
            string cauTruyVan = "select * from tblHSPhieuMuon";
            dataGridViewDSMuon0.DataSource = ketnoi(cauTruyVan);
            dataGridViewDSMuon0.AutoGenerateColumns = false;
            dataGridViewDSMuon1.DataSource = ketnoi(cauTruyVan);
            dataGridViewDSMuon1.AutoGenerateColumns = false;
            myConnection.Close();
            radMaDG.Checked = true;
            radMaDG1.Checked = true;
            btnChoMuon0.Text = "Cho Mượn";
            btnChoMuon0.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnChoMuon0.Enabled = false;
            btnHuy0.Enabled = false;
            txtMaPhieu0.Enabled = false;
            txtTTMaSach.Enabled = false;
            txtTTTenSach.Enabled = false;
            txtTTSLCon.Enabled = false;
            txtTTTenTG.Enabled = false;
            btnThem_Click(sender, e);
            btnHuy0_Click(sender, e);
            setControlsMuon(false);
            setControlsTra(false);
        }

        private DataTable ketnoi(string truyvan)
        {
            string chuoiKetNoi = Config.chuoiKetNoi();
            myConnection = new SqlConnection(chuoiKetNoi);
            myConnection.Open();
            string thuchiencaulenh = truyvan;
            myCommand = new SqlCommand(thuchiencaulenh,myConnection);
            myDataAdapter = new SqlDataAdapter(myCommand);
            myTable=new DataTable();
            myDataAdapter.Fill(myTable);
            dataGridViewDSMuon0.DataSource=myTable;
            return myTable;
        }

        // Lấy mã sách lên cboMasach0
        public void layMaSachMuon()
        { 
            string strLayMaSach = "select MaSach from tblSach";
            cboMaSach0.DataSource = ketnoitblSach(strLayMaSach);
            cboMaSach0.DisplayMember = "MaSach";
            cboMaSach0.ValueMember = "MaSach";
            myConnection.Close();
        }

        // lấy Mã DG lên cboMaDG
        public void layMaDGMuon()
        {
            string strLayMaDG = "select * from tblDocGia";
            cboMaDG0.DataSource = ketnoitblDocGia(strLayMaDG);
            cboMaDG0.DisplayMember = "MaDG";
            cboMaDG0.ValueMember = "MaDG";
            myConnection.Close();
        }

        // Kết nối tới tblDocGia
        private DataTable ketnoitblDocGia(string truyvan)
        {
            string chuoiKetNoi = Config.chuoiKetNoi();
            myConnection = new SqlConnection(chuoiKetNoi);
            myConnection.Open();
            string thuchiencaulenh = truyvan;
            myCommand = new SqlCommand(thuchiencaulenh, myConnection);
            myDataAdapter = new SqlDataAdapter(myCommand);
            myTableDG = new DataTable();
            myDataAdapter.Fill(myTableDG);
            return myTableDG;
        }

        //kết nốt tblSach
        private DataTable ketnoitblSach(string truyvan)
        {
            string chuoiKetNoi = Config.chuoiKetNoi();
            myConnection = new SqlConnection(chuoiKetNoi);
            myConnection.Open();
            string thuchiencaulenh = truyvan;
            myCommand = new SqlCommand(thuchiencaulenh, myConnection);
            myDataAdapter = new SqlDataAdapter(myCommand);
            myTableSach = new DataTable();
            myDataAdapter.Fill(myTableSach);
            return myTableSach;
        }

        private void setControlsMuon(bool edit)
        {
            cboMaDG0.Enabled = edit;
            cboMaSach0.Enabled = edit;
            txtSLMuon0.Enabled = edit;
            txtGhiChu0.Enabled = edit;
            dtmNgayTra0.Enabled = edit;
            dtmNgayMuon0.Enabled = edit;
            cboTinhTrang0.Enabled = edit;
        }

        public string maPhieu0, maDG0, maSach0, slMuon0, ngayMuon0, ngayTra0, ghiChu0, tinhTrang0;
        private void dataGridViewDSMuon0_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            txtMaPhieu0.Text = myTable.Rows[row]["MaPhieu"].ToString();
            maPhieu0 = txtMaPhieu0.Text;
            cboMaDG0.Text = myTable.Rows[row]["MaDG"].ToString();
            maDG0 = cboMaDG0.Text;
            cboMaSach0.Text = myTable.Rows[row]["MaSach"].ToString();
            maSach0 = cboMaSach0.Text;
            txtSLMuon0.Text = myTable.Rows[row]["SLMuon"].ToString();
            slMuon0 = txtSLMuon0.Text;
            dtmNgayMuon0.Text = myTable.Rows[row]["NgayMuon"].ToString(); 
            ngayMuon0 = dtmNgayMuon0.Text;
            dtmNgayTra0.Text = myTable.Rows[row]["NgayTra"].ToString();
            ngayTra0 = dtmNgayTra0.Text;
            cboTinhTrang0.Text = myTable.Rows[row]["TinhTrang"].ToString();
            tinhTrang0 = cboTinhTrang0.Text;
            txtGhiChu0.Text = myTable.Rows[row]["GhiChu"].ToString();
            ghiChu0 = txtGhiChu0.Text;
        }

        private void txtNDTimKiem_TextChanged(object sender, EventArgs e)
        {
            setControlsMuon(false);
            btnNhap.Enabled = false;
            btnChoMuon0.Enabled = false;
            btnHuy0.Enabled = false;

            if (radMaDG.Checked)
            {
                string timkiemMaDG = "select * from tblHSPhieuMuon where MaDG like '%" + txtNDTimKiem.Text + "%'";
                ketnoi(timkiemMaDG);
                myCommand.ExecuteNonQuery();
                dataGridViewDSMuon0.DataSource = ketnoi(timkiemMaDG);
                dataGridViewDSMuon0.AutoGenerateColumns = false;
                myConnection.Close();
            }
            else if (radMaSach.Checked)
            {
                string timkiemMS = "select * from tblHSPhieuMuon where MaSach like '%" + txtNDTimKiem.Text + "%'";
                ketnoi(timkiemMS);
                myCommand.ExecuteNonQuery();
                dataGridViewDSMuon0.DataSource = ketnoi(timkiemMS);
                dataGridViewDSMuon0.AutoGenerateColumns = false;
                myConnection.Close();
            }
        }


        private void btnLoadDanhSach0_Click(object sender, EventArgs e)
        {
            txtNDTimKiem.Text = "";
            btnNhap.Enabled = true;
            btnChoMuon0.Enabled = false;
            btnHuy0.Enabled = false;
            setControlsMuon(false);

            string cauTruyVanLoad = "select * from tblHSPhieuMuon";
            dataGridViewDSMuon0.DataSource = ketnoi(cauTruyVanLoad);
            dataGridViewDSMuon0.AutoGenerateColumns = false;
            myConnection.Close();
        }

        public string tangMaTuDong()
        {
            string cauTruyVan = "select * from tblHSPhieuMuon";
            dataGridViewDSMuon0.DataSource = ketnoi(cauTruyVan);
            dataGridViewDSMuon0.AutoGenerateColumns = false;
            myConnection.Close();
            return Config.tangMaTuDong("mp", myTable);
        }

        public int xuly;
        public static DateTime today = DateTime.Now;
        public static DateTime newday = today.AddDays(21);
        private void btnThem_Click(object sender, EventArgs e)
        {
            layMaDGMuon();
            layMaSachMuon();
            btnChoMuon0.Text = "Cho Mượn";
            btnChoMuon0.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            setControlsMuon(true);
            btnNhap.Enabled = false;
            btnChoMuon0.Enabled = true;
            btnHuy0.Enabled = true;
            btnGiaHan.Enabled = false;
            dataGridViewDSMuon0.Enabled = false;

            txtMaPhieu0.Text = tangMaTuDong();
            cboMaDG0.Text = "";
            cboMaSach0.Text = "";
            txtSLMuon0.Text = "";
            dtmNgayMuon0.Text = Convert.ToString(today); ;
            dtmNgayTra0.Text = Convert.ToString(newday);
            txtGhiChu0.Text = "";
            lblNhapSLNhap.Text = "";
            xuly = 0;
        }

        public int soSanhNgay(string ngayMuonText, string ngayTraText)
        {
            DateTime ngayMuon, ngayTra;
            DateTime.TryParseExact(ngayMuonText, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngayMuon);
            DateTime.TryParseExact(ngayTraText, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngayTra);
            return ngayMuon.CompareTo(ngayTra);
        }

        public string slSachCon;
        private void cboMaSach0_SelectedIndexChanged(object sender, EventArgs e)
        {
            string chuoiKetNoi = Config.chuoiKetNoi();
            string strlaydulieu = "select * from tblSach where MaSach='" + cboMaSach0.SelectedValue.ToString() + "'";
            myConnection = new SqlConnection(chuoiKetNoi);
            myConnection.Open();
            string thuchiencaulenh = strlaydulieu;
            myCommand = new SqlCommand(thuchiencaulenh, myConnection);
            myDataReaderSach = myCommand.ExecuteReader();
            while (myDataReaderSach.Read())
            {
                txtTTMaSach.Text = myDataReaderSach.GetString(0);
                txtTTTenSach.Text = myDataReaderSach.GetString(1);
                txtTTTenTG.Text = myDataReaderSach.GetString(2);
                txtTTSLCon.Text = myDataReaderSach.GetInt32(6).ToString();
                slSachCon = txtTTSLCon.Text;
            }
        }

        // Kiểm tra số lượng sách đg đã mượn
        private int slSachDGDaMuon()
        {
            int slSach = 0;
            string chuoiKetNoi = Config.chuoiKetNoi();
            string strTinhSLSachDaMuon = "select sum(SLMuon) as Tong from tblHSPhieuMuon where MaDG='" + cboMaDG0.Text + "' group by MaDG";
            myConnection = new SqlConnection(chuoiKetNoi);
            myConnection.Open();
            string thuchiencaulenh = strTinhSLSachDaMuon;
            myCommand = new SqlCommand(thuchiencaulenh, myConnection);
            myDataReaderSLSachDaMuon = myCommand.ExecuteReader();
            while (myDataReaderSLSachDaMuon.Read())
            {
                slSach = Convert.ToInt32(myDataReaderSLSachDaMuon.GetInt32(0).ToString());
            }
            return slSach;
        }

        public int luuSLCon, luuSLMuon;
        public int luuSLSauChoMuon;
        public int ktmuonchua;
        private void muonSach()
        {
            bool checkSLValid = true;
            if (!Validation.isQuantityValid(txtSLMuon0.Text))
            {
                checkSLValid = false;
                errSLMuon0.SetError(txtSLMuon0, "Phải là số không âm!");
            }
            else
            {
                errSLMuon0.Clear();
            }

            if (checkSLValid)
            {
                int SLMuon = Convert.ToInt32(txtSLMuon0.Text);
                int SLSachCon = Convert.ToInt32(slSachCon);
                if (SLMuon <= SLSachCon)
                {
                    if (soSanhNgay(dtmNgayMuon0.Text, dtmNgayTra0.Text) < 0)
                    {
                        if ((slSachDGDaMuon() + SLMuon) <= 5)
                        {
                            string themdongsqlMuon = "insert into tblHSPhieuMuon values ('" + txtMaPhieu0.Text + "','" + cboMaDG0.Text + "','" + cboMaSach0.Text + "','" + dtmNgayMuon0.Text + "','" + dtmNgayTra0.Text + "','" + txtSLMuon0.Text + "',N'" + cboTinhTrang0.Text + "',N'" + txtGhiChu0.Text + "')";
                            ketnoi(themdongsqlMuon);
                            myConnection.Close();
                            MessageBox.Show("Cho mượn thành công.", "Thông Báo");

                            //Cập nhật lại SL sách
                            int SLConLai = SLSachCon - SLMuon;
                            string strCapNhatSLCon = "update tblSach set SLNhap='" + SLConLai + " ' where MaSach='" + cboMaSach0.Text + "'";
                            ketnoi(strCapNhatSLCon);
                            myCommand.ExecuteNonQuery();

                            string cauTruyVan = "select * from tblHSPhieuMuon";
                            dataGridViewDSMuon0.DataSource = ketnoi(cauTruyVan);
                            dataGridViewDSMuon0.AutoGenerateColumns = false;
                            myConnection.Close();
                            btnNhap.Enabled = true;
                            btnChoMuon0.Enabled = false;
                            btnHuy0.Enabled = false;
                            btnGiaHan.Enabled = true;
                            setControlsMuon(false);
                            dataGridViewDSMuon0.Enabled = true;
                        }
                        else
                        {    
                            MessageBox.Show("Không thể mượn!\nSố sách đang mượn đã vượt quá 5 cuốn!", "Thông Báo");
                            txtSLMuon0.Text = "";
                            txtSLMuon0.Focus();
                        }
                    }
                    else
                        MessageBox.Show("Ngày trả phải sau ngày mượn!", "Thông Báo");
                }
                else
                    MessageBox.Show("Số lượng sách không đủ để mượn!", "Thông Báo");
            }
            else
                MessageBox.Show("Vui lòng nhập đúng số lượng!", "Thông Báo");
        }

        private void giaHanSach()
        {
            if (soSanhNgay(dtmNgayMuon0.Text, dtmNgayTra0.Text) < 0)
            {
                string strCapNhatSLCon = "update tblHSPhieuMuon set NgayMuon='" + dtmNgayMuon0.Text + " ', NgayTra='" + dtmNgayTra0.Text + "' where MaPhieu='" + txtMaPhieu0.Text + "'";
                ketnoi(strCapNhatSLCon);
                myCommand.ExecuteNonQuery();
                MessageBox.Show("Gia hạn thành công.", "Thông Báo");

                string cauTruyVan = "select * from tblHSPhieuMuon";
                dataGridViewDSMuon0.DataSource = ketnoi(cauTruyVan);
                dataGridViewDSMuon0.AutoGenerateColumns = false;
                myConnection.Close();

                setControlsMuon(false);
                btnNhap.Enabled = true;
                btnChoMuon0.Text = "Cho Mượn";
                btnChoMuon0.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                btnChoMuon0.Enabled = false;
                btnGiaHan.Enabled = true;
                btnHuy0.Enabled = false;

                dataGridViewDSMuon0.Enabled = true;
            }
            else
            {
                MessageBox.Show("Ngày trả phải sau ngày mượn!", "Thông Báo");
            }
                
        }
        private void btnChoMuon0_Click(object sender, EventArgs e)
        {
            if(xuly==0)
            {
                muonSach();
            }
            else if(xuly==1)
            {
                giaHanSach();
            }
        }

        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            
            txtMaPhieu0.Text = maPhieu0;
            cboMaDG0.Text = maDG0;
            cboMaSach0.Text = maSach0;
            txtSLMuon0.Text = slMuon0;
            dtmNgayMuon0.Text = ngayMuon0;

            dtmNgayTra0.Text = ngayTra0;
            txtGhiChu0.Text = ghiChu0;

            setControlsMuon(true);
            cboMaDG0.Enabled = false;
            cboMaSach0.Enabled = false;
            txtSLMuon0.Enabled = false;

            btnNhap.Enabled = false;
            btnChoMuon0.Text = "Lưu";
            btnChoMuon0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            btnChoMuon0.Enabled = true;
            btnGiaHan.Enabled = false;
            btnHuy0.Enabled = true;
            xuly = 1;
            dtmNgayMuon0.Enabled = false;
            cboTinhTrang0.Enabled = false;
        }

        private void btnHuy0_Click(object sender, EventArgs e)
        {
            txtMaPhieu0.Text = maPhieu0;
            cboMaDG0.Text = maDG0;
            cboMaSach0.Text = maSach0;
            txtSLMuon0.Text = slMuon0;
            dtmNgayMuon0.Text = ngayMuon0;
            dtmNgayTra0.Text = ngayTra0;
            txtGhiChu0.Text = ghiChu0;

            btnChoMuon0.Text = "Cho Mượn";
            btnChoMuon0.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            btnNhap.Enabled = true;
            btnChoMuon0.Enabled = false;
            btnGiaHan.Enabled = true;
            btnHuy0.Enabled = false;
            setControlsMuon(false);
            dataGridViewDSMuon0.Enabled = true;

            lblNhapSLNhap.Text = "";
        }

        private void btnThoat0_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /////////////////////////////////////////////////////////////////

        //TAB trả sách
        private void setControlsTra(bool edit)
        {
            txtMaPhieu1.Enabled = edit;
            txtMaDG1.Enabled = edit;
            txtMaSach1.Enabled = edit;
            txtSLMuon1.Enabled = edit;
            dtmNgayMuon1.Enabled = edit;
            dtmNgayTra1.Enabled = edit;
            txtGhiChu1.Enabled = edit;
            txtTinhTrang1.Enabled = edit;
        }

        public string maPhieu1, maDG1, maSach1, luuSLTra1, ngayMuon1, ngayTra1, ghiChu1, tinhTrang1;
        private void dataGridViewDSMuon1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int row = e.RowIndex;
                txtMaPhieu1.Text=myTable.Rows[row]["MaPhieu"].ToString();
                maPhieu1 = txtMaPhieu1.Text;
                txtMaDG1.Text = myTable.Rows[row]["MaDG"].ToString();
                maDG1 = txtMaDG1.Text;
                txtMaSach1.Text = myTable.Rows[row]["MaSach"].ToString();
                maSach1 = txtMaSach1.Text;
                txtSLMuon1.Text = myTable.Rows[row]["SLMuon"].ToString();
                luuSLTra1 = txtSLMuon1.Text;
                dtmNgayMuon1.Text = myTable.Rows[row]["NgayMuon"].ToString();
                ngayMuon1 = dtmNgayMuon1.Text;
                dtmNgayTra1.Text = myTable.Rows[row]["NgayTra"].ToString();
                ngayTra1 = dtmNgayTra1.Text;
                txtTinhTrang1.Text = myTable.Rows[row]["TinhTrang"].ToString();
                tinhTrang1 = txtTinhTrang1.Text;
                txtGhiChu1.Text = myTable.Rows[row]["GhiChu"].ToString();
                ghiChu1 = txtGhiChu1.Text;
            }
            catch(Exception)
            {

            }
        }

        public int luuSLSauTra;
        public string luuSLConTabMuon;

        private void traSach()
        {
            string chuoiKetNoi = Config.chuoiKetNoi();
            string strlaydulieu = "select * from tblSach where MaSach='" + txtMaSach1.Text + "'";
            myConnection = new SqlConnection(chuoiKetNoi);
            myConnection.Open();
            string thuchiencaulenh = strlaydulieu;
            myCommand = new SqlCommand(thuchiencaulenh, myConnection);
            myDataReaderSach = myCommand.ExecuteReader();
            while (myDataReaderSach.Read())
            {
                luuSLConTabMuon = myDataReaderSach.GetInt32(6).ToString();
            }

            luuSLSauTra = Convert.ToInt32(luuSLTra1) + Convert.ToInt32(luuSLConTabMuon);
            DialogResult dlr;
            dlr = MessageBox.Show("Bạn chắc chắn muốn trả sách.", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                try
                {
                    string xoadongsql;
                    xoadongsql = "delete from tblHSPhieuMuon where MaPhieu='" + txtMaPhieu1.Text + "'";
                    ketnoi(xoadongsql);
                    myCommand.ExecuteNonQuery();
                    MessageBox.Show("Trả sách thành công.", "Thông Báo");
                    myConnection.Close();
                    try
                    {
                        string strluuSLSauTra = luuSLSauTra.ToString();
                        string strCapNhatSLCon = "update tblSach set SLNhap='" + strluuSLSauTra + " ' where MaSach='" + txtMaSach1.Text + "'";
                        ketnoi(strCapNhatSLCon);
                        myCommand.ExecuteNonQuery();
                        MessageBox.Show("Đã cập nhật SL Sách vào kho.", "Thông Báo");
                        myConnection.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Cập nhật SL Sách thất bại.", "Thông Báo");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Trả sách thất bại.", "Thông Báo");
                }
            }

            string cauTruyVan = "select * from tblHSPhieuMuon";
            dataGridViewDSMuon1.DataSource = ketnoi(cauTruyVan);
            dataGridViewDSMuon1.AutoGenerateColumns = false;
            myConnection.Close();
        }
        private void btnTraSach1_Click(object sender, EventArgs e)
        {
            traSach();
        }
 

        private void txtNDTimKiem1_TextChanged(object sender, EventArgs e)
        {
            if (radMaDG1.Checked)
            {
                string timkiemDG1 = "select * from tblHSPhieuMuon where MaDG like '%" + txtNDTimKiem1.Text + "%'";
                ketnoi(timkiemDG1);
                myCommand.ExecuteNonQuery();
                dataGridViewDSMuon1.DataSource = ketnoi(timkiemDG1);
                dataGridViewDSMuon1.AutoGenerateColumns = false;
                myConnection.Close();
            }
            else if (radMaSach1.Checked)
            {
                string timkiemMS2 = "select * from tblHSPhieuMuon where MaSach like '%" + txtNDTimKiem1.Text + "%'";
                ketnoi(timkiemMS2);
                myCommand.ExecuteNonQuery();
                dataGridViewDSMuon1.DataSource = ketnoi(timkiemMS2);
                dataGridViewDSMuon1.AutoGenerateColumns = false;
                myConnection.Close();
            }
        }

        private void btnLoadDS1_Click(object sender, EventArgs e)
        {
            string cauTruyVan = "select * from tblHSPhieuMuon";
            dataGridViewDSMuon1.DataSource = ketnoi(cauTruyVan);
            dataGridViewDSMuon1.AutoGenerateColumns = false;
            myConnection.Close();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            string cauTruyVan = "select * from tblHSPhieuMuon";
            dataGridViewDSMuon1.DataSource = ketnoi(cauTruyVan);
            dataGridViewDSMuon1.AutoGenerateColumns = false;
            myConnection.Close();
        }

        private void btnThoat1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
