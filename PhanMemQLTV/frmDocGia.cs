using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PhanMemQLTV
{
    public partial class frmDocGia : Form
    {
        public string taikhoan;
        private SqlConnection myConnection;
        private SqlCommand myCommand;
        private SqlDataAdapter myDataAdapter;
        private DataTable myTable;

        public frmDocGia()
        {
            InitializeComponent();
        }
        
        private DataTable ketnoi(string truyvan)
        {
            myConnection = new SqlConnection(Config.chuoiKetNoi());
            myConnection.Open();
            string thuchiencaulenh = truyvan;
            myCommand = new SqlCommand(thuchiencaulenh, myConnection);
            myDataAdapter = new SqlDataAdapter(myCommand);
            myTable = new DataTable();
            myDataAdapter.Fill(myTable);
            dataGridViewDSSach0.DataSource = myTable;
            return myTable;
        }

       
        
        private void frmDocGia_Load(object sender, EventArgs e)
        {
            string view = "select * from tblSach";
            ketnoi(view);
            myCommand.ExecuteNonQuery();
            dataGridViewDSSach0.DataSource = myTable;
            dataGridViewDSSach0.AutoGenerateColumns = false;
            myConnection.Close();
        }

        private void txtNDTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (radMaSach.Checked)
            {
                string timkiemMS = "select * from tblSach where MaSach like '%" + txtNDTimKiem.Text + "%'";
                ketnoi(timkiemMS);
                myCommand.ExecuteNonQuery();
                dataGridViewDSSach0.DataSource = myTable;
                dataGridViewDSSach0.AutoGenerateColumns = false;
                myConnection.Close();
            }
            else if (radTenSach.Checked)
            {
                string timkiemTS = "select * from tblSach where TenSach like N'%" + txtNDTimKiem.Text + "%'";
                ketnoi(timkiemTS);
                myCommand.ExecuteNonQuery();
                dataGridViewDSSach0.DataSource = ketnoi(timkiemTS);
                dataGridViewDSSach0.AutoGenerateColumns = false;
                myConnection.Close();
            }
            else if (radTenTG.Checked)
            {
                string timkiemMS = "select * from tblSach where TacGia like N'%" + txtNDTimKiem.Text + "%'";
                ketnoi(timkiemMS);
                myCommand.ExecuteNonQuery();
                dataGridViewDSSach0.DataSource = myTable;
                dataGridViewDSSach0.AutoGenerateColumns = false;
                myConnection.Close();
            }
            else if (radTenCD.Checked)
            {
                string timkiemMS = "select * from tblSach where ChuDe like N'%" + txtNDTimKiem.Text + "%'";
                ketnoi(timkiemMS);
                myCommand.ExecuteNonQuery();
                dataGridViewDSSach0.DataSource = myTable;
                dataGridViewDSSach0.AutoGenerateColumns = false;
                myConnection.Close();
            }
        }

        private void doiMatKhauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau("dg");
            frm.taikhoan = taikhoan.ToUpper();
            frm.Show();
        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmDocGia_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
