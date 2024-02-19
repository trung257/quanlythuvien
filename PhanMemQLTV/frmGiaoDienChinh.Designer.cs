namespace PhanMemQLTV
{
    partial class frmGiaoDienChinh
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.mnuHeThong = new System.Windows.Forms.MenuStrip();
            this.taiKhoanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DangKyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DoiMatKhauToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QLDanhMucToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QLSachToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.QLDGToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.QLMuonTraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BCTKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ThoatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.picAnhNen = new System.Windows.Forms.PictureBox();
            this.mnuHeThong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnhNen)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.BackColor = System.Drawing.Color.Teal;
            this.lblTieuDe.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTieuDe.Font = new System.Drawing.Font("Times New Roman", 25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTieuDe.Location = new System.Drawing.Point(0, 0);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(774, 52);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "Quản Lý Thư Viện";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mnuHeThong
            // 
            this.mnuHeThong.Dock = System.Windows.Forms.DockStyle.None;
            this.mnuHeThong.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.mnuHeThong.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuHeThong.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.taiKhoanToolStripMenuItem,
            this.QLDanhMucToolStripMenuItem,
            this.QLMuonTraToolStripMenuItem,
            this.BCTKToolStripMenuItem,
            this.ThoatToolStripMenuItem});
            this.mnuHeThong.Location = new System.Drawing.Point(-8, 54);
            this.mnuHeThong.Name = "mnuHeThong";
            this.mnuHeThong.Size = new System.Drawing.Size(760, 28);
            this.mnuHeThong.TabIndex = 0;
            this.mnuHeThong.Text = "menuStrip1";
            // 
            // taiKhoanToolStripMenuItem
            // 
            this.taiKhoanToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DangKyToolStripMenuItem,
            this.DoiMatKhauToolStripMenuItem});
            this.taiKhoanToolStripMenuItem.Name = "taiKhoanToolStripMenuItem";
            this.taiKhoanToolStripMenuItem.Size = new System.Drawing.Size(92, 24);
            this.taiKhoanToolStripMenuItem.Text = "Tài Khoản";
            // 
            // DangKyToolStripMenuItem
            // 
            this.DangKyToolStripMenuItem.Name = "DangKyToolStripMenuItem";
            this.DangKyToolStripMenuItem.Size = new System.Drawing.Size(188, 26);
            this.DangKyToolStripMenuItem.Text = "Đăng Ký";
            this.DangKyToolStripMenuItem.Click += new System.EventHandler(this.DangKyToolStripMenuItem_Click);
            // 
            // DoiMatKhauToolStripMenuItem
            // 
            this.DoiMatKhauToolStripMenuItem.Name = "DoiMatKhauToolStripMenuItem";
            this.DoiMatKhauToolStripMenuItem.Size = new System.Drawing.Size(188, 26);
            this.DoiMatKhauToolStripMenuItem.Text = "Đổi Mật Khẩu";
            this.DoiMatKhauToolStripMenuItem.Click += new System.EventHandler(this.DoiMatKhauToolStripMenuItem_Click);
            // 
            // QLDanhMucToolStripMenuItem
            // 
            this.QLDanhMucToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.QLSachToolStripMenuItem1,
            this.QLDGToolStripMenuItem1});
            this.QLDanhMucToolStripMenuItem.Name = "QLDanhMucToolStripMenuItem";
            this.QLDanhMucToolStripMenuItem.Size = new System.Drawing.Size(154, 24);
            this.QLDanhMucToolStripMenuItem.Text = "Quản Lý Danh Mục";
            // 
            // QLSachToolStripMenuItem1
            // 
            this.QLSachToolStripMenuItem1.Name = "QLSachToolStripMenuItem1";
            this.QLSachToolStripMenuItem1.Size = new System.Drawing.Size(210, 26);
            this.QLSachToolStripMenuItem1.Text = "Quản Lý Sách";
            this.QLSachToolStripMenuItem1.Click += new System.EventHandler(this.QLSachToolStripMenuItem1_Click);
            // 
            // QLDGToolStripMenuItem1
            // 
            this.QLDGToolStripMenuItem1.Name = "QLDGToolStripMenuItem1";
            this.QLDGToolStripMenuItem1.Size = new System.Drawing.Size(210, 26);
            this.QLDGToolStripMenuItem1.Text = "Quản Lý Độc Giả";
            this.QLDGToolStripMenuItem1.Click += new System.EventHandler(this.QLDGToolStripMenuItem1_Click);
            // 
            // QLMuonTraToolStripMenuItem
            // 
            this.QLMuonTraToolStripMenuItem.Name = "QLMuonTraToolStripMenuItem";
            this.QLMuonTraToolStripMenuItem.Size = new System.Drawing.Size(155, 24);
            this.QLMuonTraToolStripMenuItem.Text = "Quản lý Mượn - Trả";
            this.QLMuonTraToolStripMenuItem.Click += new System.EventHandler(this.QLMuonTraToolStripMenuItem_Click);
            // 
            // BCTKToolStripMenuItem
            // 
            this.BCTKToolStripMenuItem.Name = "BCTKToolStripMenuItem";
            this.BCTKToolStripMenuItem.Size = new System.Drawing.Size(140, 24);
            this.BCTKToolStripMenuItem.Text = "Báo cáo thống kê";
            this.BCTKToolStripMenuItem.Click += new System.EventHandler(this.BCTKToolStripMenuItem_Click);
            // 
            // ThoatToolStripMenuItem
            // 
            this.ThoatToolStripMenuItem.Name = "ThoatToolStripMenuItem";
            this.ThoatToolStripMenuItem.Size = new System.Drawing.Size(61, 24);
            this.ThoatToolStripMenuItem.Text = "Thoát";
            this.ThoatToolStripMenuItem.Click += new System.EventHandler(this.ThoatToolStripMenuItem_Click);
            // 
            // picAnhNen
            // 
            this.picAnhNen.Image = global::PhanMemQLTV.Properties.Resources.thuvien;
            this.picAnhNen.Location = new System.Drawing.Point(6, 77);
            this.picAnhNen.Name = "picAnhNen";
            this.picAnhNen.Size = new System.Drawing.Size(761, 385);
            this.picAnhNen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAnhNen.TabIndex = 2;
            this.picAnhNen.TabStop = false;
            // 
            // frmGiaoDienChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 472);
            this.Controls.Add(this.picAnhNen);
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.mnuHeThong);
            this.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mnuHeThong;
            this.MaximizeBox = false;
            this.Name = "frmGiaoDienChinh";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm Quản Lý Thư Viện";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGiaoDienChinh_FormClosing);
            this.mnuHeThong.ResumeLayout(false);
            this.mnuHeThong.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnhNen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.MenuStrip mnuHeThong;
        private System.Windows.Forms.PictureBox picAnhNen;
        private System.Windows.Forms.ToolStripMenuItem QLMuonTraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ThoatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem QLDanhMucToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem QLSachToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem QLDGToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem taiKhoanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DangKyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DoiMatKhauToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BCTKToolStripMenuItem;
    }
}