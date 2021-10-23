namespace HotelManager
{
    partial class fManagement
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fManagement));
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.panelRight = new System.Windows.Forms.Panel();
            this.btnQuanlyphong = new System.Windows.Forms.Button();
            this.btnThongkedt = new System.Windows.Forms.Button();
            this.btnNhanphong = new System.Windows.Forms.Button();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.label2 = new System.Windows.Forms.Label();
            this.btnQLnhanvien = new System.Windows.Forms.Button();
            this.btnQLhoadon = new System.Windows.Forms.Button();
            this.btnQLdichvu = new System.Windows.Forms.Button();
            this.btnThanhtoan = new System.Windows.Forms.Button();
            this.btnQLkhachhang = new System.Windows.Forms.Button();
            this.btnQuydinh = new System.Windows.Forms.Button();
            this.btnDatphong = new System.Windows.Forms.Button();
            this.bunifuFlatButton1 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnHelp = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnLogOut = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnIntroduce = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnNavigationPanel = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panelLeft = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.btnAccountProfile = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.panelRight.SuspendLayout();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.panelRight;
            this.bunifuDragControl1.Vertical = true;
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.DarkGray;
            this.panelRight.Controls.Add(this.btnClose);
            this.panelRight.Controls.Add(this.btnQuydinh);
            this.panelRight.Controls.Add(this.btnQLkhachhang);
            this.panelRight.Controls.Add(this.btnThanhtoan);
            this.panelRight.Controls.Add(this.btnQLdichvu);
            this.panelRight.Controls.Add(this.btnQLhoadon);
            this.panelRight.Controls.Add(this.btnQLnhanvien);
            this.panelRight.Controls.Add(this.btnQuanlyphong);
            this.panelRight.Controls.Add(this.btnThongkedt);
            this.panelRight.Controls.Add(this.btnDatphong);
            this.panelRight.Controls.Add(this.btnNhanphong);
            this.panelRight.Controls.Add(this.bunifuSeparator1);
            this.panelRight.Controls.Add(this.label2);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(174, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(942, 583);
            this.panelRight.TabIndex = 1;
            this.panelRight.Paint += new System.Windows.Forms.PaintEventHandler(this.panelRight_Paint);
            // 
            // btnQuanlyphong
            // 
            this.btnQuanlyphong.BackColor = System.Drawing.Color.LightGray;
            this.btnQuanlyphong.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuanlyphong.BackgroundImage")));
            this.btnQuanlyphong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuanlyphong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuanlyphong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanlyphong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnQuanlyphong.ForeColor = System.Drawing.Color.Black;
            this.btnQuanlyphong.Location = new System.Drawing.Point(330, 214);
            this.btnQuanlyphong.Name = "btnQuanlyphong";
            this.btnQuanlyphong.Size = new System.Drawing.Size(135, 135);
            this.btnQuanlyphong.TabIndex = 63;
            this.btnQuanlyphong.Text = "Quản Lý Phòng";
            this.btnQuanlyphong.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuanlyphong.UseVisualStyleBackColor = false;
            this.btnQuanlyphong.Click += new System.EventHandler(this.btnQuanlyphong_Click);
            // 
            // btnThongkedt
            // 
            this.btnThongkedt.BackColor = System.Drawing.Color.LightGray;
            this.btnThongkedt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnThongkedt.BackgroundImage")));
            this.btnThongkedt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnThongkedt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThongkedt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongkedt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnThongkedt.ForeColor = System.Drawing.Color.Black;
            this.btnThongkedt.Location = new System.Drawing.Point(330, 73);
            this.btnThongkedt.Name = "btnThongkedt";
            this.btnThongkedt.Size = new System.Drawing.Size(276, 135);
            this.btnThongkedt.TabIndex = 61;
            this.btnThongkedt.Text = "Thống Kê Doanh Thu";
            this.btnThongkedt.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnThongkedt.UseVisualStyleBackColor = false;
            this.btnThongkedt.Click += new System.EventHandler(this.btnThongkedt_Click);
            // 
            // btnNhanphong
            // 
            this.btnNhanphong.BackColor = System.Drawing.Color.LightGray;
            this.btnNhanphong.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNhanphong.BackgroundImage")));
            this.btnNhanphong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNhanphong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNhanphong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhanphong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnNhanphong.ForeColor = System.Drawing.Color.Black;
            this.btnNhanphong.Location = new System.Drawing.Point(170, 73);
            this.btnNhanphong.Name = "btnNhanphong";
            this.btnNhanphong.Size = new System.Drawing.Size(135, 276);
            this.btnNhanphong.TabIndex = 57;
            this.btnNhanphong.Text = "Nhận Phòng";
            this.btnNhanphong.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNhanphong.UseVisualStyleBackColor = false;
            this.btnNhanphong.Click += new System.EventHandler(this.btnNhanphong_Click);
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(29, 42);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(879, 10);
            this.bunifuSeparator1.TabIndex = 54;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(21, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(237, 37);
            this.label2.TabIndex = 21;
            this.label2.Text = "Quản Lí Khách Sạn";
            // 
            // btnQLnhanvien
            // 
            this.btnQLnhanvien.BackColor = System.Drawing.Color.LightGray;
            this.btnQLnhanvien.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQLnhanvien.BackgroundImage")));
            this.btnQLnhanvien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQLnhanvien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQLnhanvien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLnhanvien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnQLnhanvien.ForeColor = System.Drawing.Color.Black;
            this.btnQLnhanvien.Location = new System.Drawing.Point(471, 214);
            this.btnQLnhanvien.Name = "btnQLnhanvien";
            this.btnQLnhanvien.Size = new System.Drawing.Size(135, 135);
            this.btnQLnhanvien.TabIndex = 65;
            this.btnQLnhanvien.Text = "Nhân Viên";
            this.btnQLnhanvien.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQLnhanvien.UseVisualStyleBackColor = false;
            this.btnQLnhanvien.Click += new System.EventHandler(this.btnQLnhanvien_Click);
            // 
            // btnQLhoadon
            // 
            this.btnQLhoadon.BackColor = System.Drawing.Color.LightGray;
            this.btnQLhoadon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQLhoadon.BackgroundImage")));
            this.btnQLhoadon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQLhoadon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQLhoadon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLhoadon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnQLhoadon.ForeColor = System.Drawing.Color.Black;
            this.btnQLhoadon.Location = new System.Drawing.Point(632, 73);
            this.btnQLhoadon.Name = "btnQLhoadon";
            this.btnQLhoadon.Size = new System.Drawing.Size(135, 276);
            this.btnQLhoadon.TabIndex = 67;
            this.btnQLhoadon.Text = "Quản Lý Hóa Đơn";
            this.btnQLhoadon.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQLhoadon.UseVisualStyleBackColor = false;
            this.btnQLhoadon.Click += new System.EventHandler(this.btnQLhoadon_Click);
            // 
            // btnQLdichvu
            // 
            this.btnQLdichvu.BackColor = System.Drawing.Color.LightGray;
            this.btnQLdichvu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQLdichvu.BackgroundImage")));
            this.btnQLdichvu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQLdichvu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQLdichvu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLdichvu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnQLdichvu.ForeColor = System.Drawing.Color.Black;
            this.btnQLdichvu.Location = new System.Drawing.Point(773, 73);
            this.btnQLdichvu.Name = "btnQLdichvu";
            this.btnQLdichvu.Size = new System.Drawing.Size(135, 276);
            this.btnQLdichvu.TabIndex = 69;
            this.btnQLdichvu.Text = "Quản Lý Dịch Vụ";
            this.btnQLdichvu.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQLdichvu.UseVisualStyleBackColor = false;
            this.btnQLdichvu.Click += new System.EventHandler(this.btnQLdichvu_Click);
            // 
            // btnThanhtoan
            // 
            this.btnThanhtoan.BackColor = System.Drawing.Color.LightGray;
            this.btnThanhtoan.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnThanhtoan.BackgroundImage")));
            this.btnThanhtoan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnThanhtoan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThanhtoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhtoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnThanhtoan.ForeColor = System.Drawing.Color.Black;
            this.btnThanhtoan.Location = new System.Drawing.Point(28, 377);
            this.btnThanhtoan.Name = "btnThanhtoan";
            this.btnThanhtoan.Size = new System.Drawing.Size(277, 135);
            this.btnThanhtoan.TabIndex = 71;
            this.btnThanhtoan.Text = "Sử Dụng Dịch Vụ Và Thanh Toán";
            this.btnThanhtoan.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnThanhtoan.UseVisualStyleBackColor = false;
            this.btnThanhtoan.Click += new System.EventHandler(this.btnThanhtoan_Click);
            // 
            // btnQLkhachhang
            // 
            this.btnQLkhachhang.BackColor = System.Drawing.Color.LightGray;
            this.btnQLkhachhang.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQLkhachhang.BackgroundImage")));
            this.btnQLkhachhang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQLkhachhang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQLkhachhang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLkhachhang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnQLkhachhang.ForeColor = System.Drawing.Color.Black;
            this.btnQLkhachhang.Location = new System.Drawing.Point(331, 377);
            this.btnQLkhachhang.Name = "btnQLkhachhang";
            this.btnQLkhachhang.Size = new System.Drawing.Size(276, 135);
            this.btnQLkhachhang.TabIndex = 73;
            this.btnQLkhachhang.Text = "Quản Lý Khách Hàng";
            this.btnQLkhachhang.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQLkhachhang.UseVisualStyleBackColor = false;
            this.btnQLkhachhang.Click += new System.EventHandler(this.btnQLkhachhang_Click);
            // 
            // btnQuydinh
            // 
            this.btnQuydinh.BackColor = System.Drawing.Color.LightGray;
            this.btnQuydinh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuydinh.BackgroundImage")));
            this.btnQuydinh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuydinh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuydinh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuydinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnQuydinh.ForeColor = System.Drawing.Color.Black;
            this.btnQuydinh.Location = new System.Drawing.Point(632, 377);
            this.btnQuydinh.Name = "btnQuydinh";
            this.btnQuydinh.Size = new System.Drawing.Size(276, 135);
            this.btnQuydinh.TabIndex = 75;
            this.btnQuydinh.Text = "Quy Định";
            this.btnQuydinh.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuydinh.UseVisualStyleBackColor = false;
            this.btnQuydinh.Click += new System.EventHandler(this.btnQuydinh_Click);
            // 
            // btnDatphong
            // 
            this.btnDatphong.BackColor = System.Drawing.Color.LightGray;
            this.btnDatphong.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDatphong.BackgroundImage")));
            this.btnDatphong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDatphong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDatphong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatphong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnDatphong.ForeColor = System.Drawing.Color.Black;
            this.btnDatphong.Location = new System.Drawing.Point(28, 73);
            this.btnDatphong.Name = "btnDatphong";
            this.btnDatphong.Size = new System.Drawing.Size(135, 276);
            this.btnDatphong.TabIndex = 59;
            this.btnDatphong.Text = "Đặt Phòng";
            this.btnDatphong.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDatphong.UseVisualStyleBackColor = false;
            this.btnDatphong.Click += new System.EventHandler(this.btnDatphong_Click);
            // 
            // bunifuFlatButton1
            // 
            this.bunifuFlatButton1.Active = false;
            this.bunifuFlatButton1.Activecolor = System.Drawing.Color.Maroon;
            this.bunifuFlatButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.bunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton1.BorderRadius = 0;
            this.bunifuFlatButton1.ButtonText = "Giới Thiệu";
            this.bunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton1.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton1.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton1.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuFlatButton1.Iconimage")));
            this.bunifuFlatButton1.Iconimage_right = null;
            this.bunifuFlatButton1.Iconimage_right_Selected = null;
            this.bunifuFlatButton1.Iconimage_Selected = null;
            this.bunifuFlatButton1.IconMarginLeft = 0;
            this.bunifuFlatButton1.IconMarginRight = 0;
            this.bunifuFlatButton1.IconRightVisible = true;
            this.bunifuFlatButton1.IconRightZoom = 0D;
            this.bunifuFlatButton1.IconVisible = true;
            this.bunifuFlatButton1.IconZoom = 90D;
            this.bunifuFlatButton1.IsTab = false;
            this.bunifuFlatButton1.Location = new System.Drawing.Point(0, 670);
            this.bunifuFlatButton1.Name = "bunifuFlatButton1";
            this.bunifuFlatButton1.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.bunifuFlatButton1.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.bunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton1.selected = false;
            this.bunifuFlatButton1.Size = new System.Drawing.Size(206, 46);
            this.bunifuFlatButton1.TabIndex = 1;
            this.bunifuFlatButton1.Text = "Giới Thiệu";
            this.bunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton1.Textcolor = System.Drawing.Color.White;
            this.bunifuFlatButton1.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnHelp
            // 
            this.btnHelp.Active = false;
            this.btnHelp.Activecolor = System.Drawing.Color.SeaGreen;
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHelp.BackColor = System.Drawing.Color.Gray;
            this.btnHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHelp.BorderRadius = 0;
            this.btnHelp.ButtonText = "    Trợ Giúp";
            this.btnHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHelp.DisabledColor = System.Drawing.Color.Gray;
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Iconcolor = System.Drawing.Color.Transparent;
            this.btnHelp.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnHelp.Iconimage")));
            this.btnHelp.Iconimage_right = null;
            this.btnHelp.Iconimage_right_Selected = null;
            this.btnHelp.Iconimage_Selected = null;
            this.btnHelp.IconMarginLeft = 0;
            this.btnHelp.IconMarginRight = 0;
            this.btnHelp.IconRightVisible = true;
            this.btnHelp.IconRightZoom = 0D;
            this.btnHelp.IconVisible = true;
            this.btnHelp.IconZoom = 50D;
            this.btnHelp.IsTab = false;
            this.btnHelp.Location = new System.Drawing.Point(0, 486);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Normalcolor = System.Drawing.Color.Gray;
            this.btnHelp.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.btnHelp.OnHoverTextColor = System.Drawing.Color.White;
            this.btnHelp.selected = false;
            this.btnHelp.Size = new System.Drawing.Size(206, 40);
            this.btnHelp.TabIndex = 3;
            this.btnHelp.Text = "    Trợ Giúp";
            this.btnHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHelp.Textcolor = System.Drawing.Color.White;
            this.btnHelp.TextFont = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Active = false;
            this.btnLogOut.Activecolor = System.Drawing.Color.SeaGreen;
            this.btnLogOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLogOut.BackColor = System.Drawing.Color.Gray;
            this.btnLogOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogOut.BorderRadius = 0;
            this.btnLogOut.ButtonText = "    Đăng Xuất";
            this.btnLogOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogOut.DisabledColor = System.Drawing.Color.Gray;
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.Iconcolor = System.Drawing.Color.Transparent;
            this.btnLogOut.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnLogOut.Iconimage")));
            this.btnLogOut.Iconimage_right = null;
            this.btnLogOut.Iconimage_right_Selected = null;
            this.btnLogOut.Iconimage_Selected = null;
            this.btnLogOut.IconMarginLeft = 0;
            this.btnLogOut.IconMarginRight = 0;
            this.btnLogOut.IconRightVisible = true;
            this.btnLogOut.IconRightZoom = 0D;
            this.btnLogOut.IconVisible = true;
            this.btnLogOut.IconZoom = 50D;
            this.btnLogOut.IsTab = false;
            this.btnLogOut.Location = new System.Drawing.Point(0, 440);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Normalcolor = System.Drawing.Color.Gray;
            this.btnLogOut.OnHovercolor = System.Drawing.Color.DarkGray;
            this.btnLogOut.OnHoverTextColor = System.Drawing.Color.White;
            this.btnLogOut.selected = false;
            this.btnLogOut.Size = new System.Drawing.Size(206, 40);
            this.btnLogOut.TabIndex = 4;
            this.btnLogOut.Text = "    Đăng Xuất";
            this.btnLogOut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogOut.Textcolor = System.Drawing.Color.White;
            this.btnLogOut.TextFont = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnIntroduce
            // 
            this.btnIntroduce.Active = false;
            this.btnIntroduce.Activecolor = System.Drawing.Color.SeaGreen;
            this.btnIntroduce.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnIntroduce.BackColor = System.Drawing.Color.Gray;
            this.btnIntroduce.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnIntroduce.BorderRadius = 0;
            this.btnIntroduce.ButtonText = "    Giới Thiệu";
            this.btnIntroduce.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIntroduce.DisabledColor = System.Drawing.Color.Gray;
            this.btnIntroduce.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIntroduce.Iconcolor = System.Drawing.Color.Transparent;
            this.btnIntroduce.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnIntroduce.Iconimage")));
            this.btnIntroduce.Iconimage_right = null;
            this.btnIntroduce.Iconimage_right_Selected = null;
            this.btnIntroduce.Iconimage_Selected = null;
            this.btnIntroduce.IconMarginLeft = 0;
            this.btnIntroduce.IconMarginRight = 0;
            this.btnIntroduce.IconRightVisible = true;
            this.btnIntroduce.IconRightZoom = 0D;
            this.btnIntroduce.IconVisible = true;
            this.btnIntroduce.IconZoom = 50D;
            this.btnIntroduce.IsTab = false;
            this.btnIntroduce.Location = new System.Drawing.Point(0, 531);
            this.btnIntroduce.Name = "btnIntroduce";
            this.btnIntroduce.Normalcolor = System.Drawing.Color.Gray;
            this.btnIntroduce.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.btnIntroduce.OnHoverTextColor = System.Drawing.Color.White;
            this.btnIntroduce.selected = false;
            this.btnIntroduce.Size = new System.Drawing.Size(206, 40);
            this.btnIntroduce.TabIndex = 2;
            this.btnIntroduce.Text = "    Giới Thiệu";
            this.btnIntroduce.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIntroduce.Textcolor = System.Drawing.Color.White;
            this.btnIntroduce.TextFont = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnIntroduce.Click += new System.EventHandler(this.btnIntroduce_Click);
            // 
            // btnNavigationPanel
            // 
            this.btnNavigationPanel.Active = false;
            this.btnNavigationPanel.Activecolor = System.Drawing.Color.Silver;
            this.btnNavigationPanel.BackColor = System.Drawing.Color.Gray;
            this.btnNavigationPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNavigationPanel.BorderRadius = 0;
            this.btnNavigationPanel.ButtonText = "";
            this.btnNavigationPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavigationPanel.DisabledColor = System.Drawing.Color.Gray;
            this.btnNavigationPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavigationPanel.Iconcolor = System.Drawing.Color.Transparent;
            this.btnNavigationPanel.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnNavigationPanel.Iconimage")));
            this.btnNavigationPanel.Iconimage_right = null;
            this.btnNavigationPanel.Iconimage_right_Selected = null;
            this.btnNavigationPanel.Iconimage_Selected = null;
            this.btnNavigationPanel.IconMarginLeft = 0;
            this.btnNavigationPanel.IconMarginRight = 0;
            this.btnNavigationPanel.IconRightVisible = true;
            this.btnNavigationPanel.IconRightZoom = 0D;
            this.btnNavigationPanel.IconVisible = true;
            this.btnNavigationPanel.IconZoom = 50D;
            this.btnNavigationPanel.IsTab = false;
            this.btnNavigationPanel.Location = new System.Drawing.Point(0, 0);
            this.btnNavigationPanel.Name = "btnNavigationPanel";
            this.btnNavigationPanel.Normalcolor = System.Drawing.Color.Gray;
            this.btnNavigationPanel.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.btnNavigationPanel.OnHoverTextColor = System.Drawing.Color.White;
            this.btnNavigationPanel.selected = false;
            this.btnNavigationPanel.Size = new System.Drawing.Size(206, 40);
            this.btnNavigationPanel.TabIndex = 6;
            this.btnNavigationPanel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavigationPanel.Textcolor = System.Drawing.Color.White;
            this.btnNavigationPanel.TextFont = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnNavigationPanel.Click += new System.EventHandler(this.btnNavigationPanel_Click_1);
            // 
            // panelLeft
            // 
            this.panelLeft.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelLeft.BackgroundImage")));
            this.panelLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelLeft.Controls.Add(this.btnNavigationPanel);
            this.panelLeft.Controls.Add(this.btnAccountProfile);
            this.panelLeft.Controls.Add(this.btnIntroduce);
            this.panelLeft.Controls.Add(this.btnLogOut);
            this.panelLeft.Controls.Add(this.btnHelp);
            this.panelLeft.Controls.Add(this.bunifuFlatButton1);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.ForeColor = System.Drawing.Color.Black;
            this.panelLeft.GradientBottomLeft = System.Drawing.Color.Gray;
            this.panelLeft.GradientBottomRight = System.Drawing.Color.Gray;
            this.panelLeft.GradientTopLeft = System.Drawing.Color.Gray;
            this.panelLeft.GradientTopRight = System.Drawing.Color.Gray;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Quality = 10;
            this.panelLeft.Size = new System.Drawing.Size(174, 583);
            this.panelLeft.TabIndex = 0;
            // 
            // btnAccountProfile
            // 
            this.btnAccountProfile.Active = false;
            this.btnAccountProfile.Activecolor = System.Drawing.Color.SeaGreen;
            this.btnAccountProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAccountProfile.BackColor = System.Drawing.Color.Gray;
            this.btnAccountProfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAccountProfile.BorderRadius = 0;
            this.btnAccountProfile.ButtonText = "    Thông Tin Cá Nhân";
            this.btnAccountProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccountProfile.DisabledColor = System.Drawing.Color.Gray;
            this.btnAccountProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccountProfile.Iconcolor = System.Drawing.Color.Transparent;
            this.btnAccountProfile.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnAccountProfile.Iconimage")));
            this.btnAccountProfile.Iconimage_right = null;
            this.btnAccountProfile.Iconimage_right_Selected = null;
            this.btnAccountProfile.Iconimage_Selected = null;
            this.btnAccountProfile.IconMarginLeft = 0;
            this.btnAccountProfile.IconMarginRight = 0;
            this.btnAccountProfile.IconRightVisible = true;
            this.btnAccountProfile.IconRightZoom = 0D;
            this.btnAccountProfile.IconVisible = true;
            this.btnAccountProfile.IconZoom = 50D;
            this.btnAccountProfile.IsTab = false;
            this.btnAccountProfile.Location = new System.Drawing.Point(0, 394);
            this.btnAccountProfile.Name = "btnAccountProfile";
            this.btnAccountProfile.Normalcolor = System.Drawing.Color.Gray;
            this.btnAccountProfile.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.btnAccountProfile.OnHoverTextColor = System.Drawing.Color.Black;
            this.btnAccountProfile.selected = false;
            this.btnAccountProfile.Size = new System.Drawing.Size(196, 40);
            this.btnAccountProfile.TabIndex = 5;
            this.btnAccountProfile.Text = "    Thông Tin Cá Nhân";
            this.btnAccountProfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccountProfile.Textcolor = System.Drawing.Color.White;
            this.btnAccountProfile.TextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccountProfile.Click += new System.EventHandler(this.btnAccountProfile_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Location = new System.Drawing.Point(898, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(32, 32);
            this.btnClose.TabIndex = 76;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // fManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1116, 583);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lí khách sạn";
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private System.Windows.Forms.Button btnNhanphong;
        private System.Windows.Forms.Button btnThongkedt;
        private System.Windows.Forms.Button btnQuanlyphong;
        private System.Windows.Forms.Button btnQLnhanvien;
        private System.Windows.Forms.Button btnQLhoadon;
        private System.Windows.Forms.Button btnQLdichvu;
        private System.Windows.Forms.Button btnThanhtoan;
        private System.Windows.Forms.Button btnQLkhachhang;
        private System.Windows.Forms.Button btnQuydinh;
        private System.Windows.Forms.Button btnDatphong;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton1;
        private Bunifu.Framework.UI.BunifuFlatButton btnHelp;
        private Bunifu.Framework.UI.BunifuFlatButton btnLogOut;
        private Bunifu.Framework.UI.BunifuFlatButton btnIntroduce;
        private Bunifu.Framework.UI.BunifuFlatButton btnNavigationPanel;
        private Bunifu.Framework.UI.BunifuGradientPanel panelLeft;
        private Bunifu.Framework.UI.BunifuFlatButton btnAccountProfile;
        private System.Windows.Forms.PictureBox btnClose;
    }
}