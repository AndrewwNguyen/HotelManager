﻿using HotelManager.Class;
using System;
using HotelManager.DAO;
using HotelManager.DTO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fUseService : Form
    {
        Class.Functions dtBase = new Class.Functions();
        string staffSetUp;
        public fUseService(string userName)
        {
            staffSetUp = userName;
            InitializeComponent();
            LoadData();
            ShowSurcharge();
        }
        private void LoadData()
        {
            LoadListRoomType();
            LoadListFullRoom();
        }
        public void LoadListRoomType()
        {
            List<RoomType> roomTypes = RoomTypeDAO.Instance.LoadListRoomType();
            switch (roomTypes.Count)
            {
                case 0:
                    {
                        color1.Visible = color2.Visible = color3.Visible = color4.Visible = color5.Visible = false;
                        lblRoomType1.Visible = lblRoomType2.Visible = lblRoomType3.Visible = lblRoomType4.Visible = lblRoomType5.Visible = false;
                        break;
                    }
                case 1:
                    {
                        lblRoomType1.Text = roomTypes[0].Name;
                        color2.Visible = color3.Visible = color4.Visible = color5.Visible = false;
                        lblRoomType2.Visible = lblRoomType3.Visible = lblRoomType4.Visible = lblRoomType5.Visible = false;
                        break;
                    }
                case 2:
                    {
                        lblRoomType1.Text = roomTypes[0].Name;
                        lblRoomType2.Text = roomTypes[1].Name;
                        color3.Visible = color4.Visible = color5.Visible = false;
                        lblRoomType3.Visible = lblRoomType4.Visible = lblRoomType5.Visible = false;
                        break;
                    }
                case 3:
                    {
                        lblRoomType1.Text = roomTypes[0].Name;
                        lblRoomType2.Text = roomTypes[1].Name;
                        lblRoomType3.Text = roomTypes[2].Name;
                        color4.Visible = color5.Visible = false;
                        lblRoomType4.Visible = lblRoomType5.Visible = false;
                        break;
                    }
                case 4:
                    {
                        lblRoomType1.Text = roomTypes[0].Name;
                        lblRoomType2.Text = roomTypes[1].Name;
                        lblRoomType3.Text = roomTypes[2].Name;
                        lblRoomType4.Text = roomTypes[3].Name;
                        color5.Visible = false;
                        lblRoomType5.Visible = false;
                        break;
                    }
            }
        }
        public void DrawControl(Room1 room, Bunifu.Framework.UI.BunifuTileButton button)
        {
            int idRoomTypeName = Int32.Parse(Functions.Laygiatri("	select B.* from Room A, RoomType B where A.IDRoomType = B.ID and A.ID ='" + room.Id + "'"));
            switch (idRoomTypeName)
            {
                case 1:
                    {
                        button.BackColor = System.Drawing.Color.Tomato;
                        button.color = System.Drawing.Color.Tomato;
                        button.colorActive = System.Drawing.Color.LightSalmon;
                        break;
                    }
                case 2:
                    {
                        button.BackColor = System.Drawing.Color.Violet;
                        button.color = System.Drawing.Color.Violet;
                        button.colorActive = System.Drawing.Color.Thistle;
                        break;
                    }
                case 3:
                    {
                        button.BackColor = System.Drawing.Color.DeepSkyBlue;
                        button.color = System.Drawing.Color.DeepSkyBlue;
                        button.colorActive = System.Drawing.Color.LightSkyBlue;
                        break;
                    }
                case 4:
                    {
                        button.BackColor = System.Drawing.Color.LimeGreen;
                        button.color = System.Drawing.Color.LimeGreen;
                        button.colorActive = System.Drawing.Color.LightGreen;
                        break;
                    }
                default:
                    {
                        button.BackColor = System.Drawing.Color.Gray;
                        button.color = System.Drawing.Color.Gray;
                        button.colorActive = System.Drawing.Color.Silver;
                        break;
                    }
            }
        }
        public List<Room1> LoadListFullRoom1()
        {
            string sql = "	select distinct A.*from Room A,ReceiveRoom B, BookRoom C where A.IDStatusRoom = 2 and A.ID = B.IDRoom and B.IDBookRoom = C.ID and C.DateCheckOut >= '" + DateTime.Now.Date + "' order by A.ID asc";
            List<Room1> rooms = new List<Room1>();
            DataTable data = dtBase.DataReader(sql);
            foreach (DataRow item in data.Rows)
            {
                Room1 room = new Room1(item);
                rooms.Add(room);
            }
            return rooms;
        }
        public void LoadListFullRoom()
        {
            flowLayoutRooms.Controls.Clear();
            listViewBillRoom.Items.Clear();
            listViewUseService.Items.Clear();
            List<Room1> rooms =LoadListFullRoom1();
            foreach (Room1 item in rooms)
            {
                Bunifu.Framework.UI.BunifuTileButton button = new Bunifu.Framework.UI.BunifuTileButton();
                button.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                button.ForeColor = System.Drawing.Color.White;
                button.Image = global::HotelManager.Properties.Resources.Room;
                button.ImagePosition = 14;
                button.ImageZoom = 36;
                button.LabelPosition = 29;
                button.Size = new System.Drawing.Size(110, 95);
                button.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
                button.Tag = item;
                button.LabelText = item.Name;
                button.Click += Button_Click;
                DrawControl(item, button);
                flowLayoutRooms.Controls.Add(button);
            }

        }

        private void Button_Click(object sender, EventArgs e)
        {
            listViewBillRoom.Items.Clear();
            totalPrice = 0;
            Bunifu.Framework.UI.BunifuTileButton button = sender as Bunifu.Framework.UI.BunifuTileButton;
            flowLayoutRooms.Tag = button.Tag;
            button.BackColor = System.Drawing.Color.SeaGreen;
            button.color = System.Drawing.Color.SeaGreen;
            button.colorActive = System.Drawing.Color.MediumSeaGreen;
            foreach (var item in flowLayoutRooms.Controls)
            {
                if (item != button)
                    DrawControl((item as Bunifu.Framework.UI.BunifuTileButton).Tag as Room1, item as Bunifu.Framework.UI.BunifuTileButton); //Trả về màu cũ
            }
            Room1 room = button.Tag as Room1;
            ShowBill(room.Id);
            string sql = "select * from Bill A, ReceiveRoom B,BookRoom C where A.IDStatusBill = 1 and   A.IDReceiveRoom = B.ID and C.ID = B.IDBookRoom and B.IDRoom = '"+room.Id+"' and DateCheckOut >'"+DateTime.Now+"' ";
            string idbill = Functions.Laygiatri("select * from Bill A, ReceiveRoom B,BookRoom C where A.IDStatusBill = 1 and   A.IDReceiveRoom = B.ID and C.ID = B.IDBookRoom and B.IDRoom = '" + room.Id + "' and DateCheckOut >'" + DateTime.Now + "' ");
            Functions.Laygiatri(sql);
            if(!Functions.ktra(sql))
            {
                int a = Functions.key();
                int idReceiveRoom =Int32.Parse( Functions.Laygiatri("select *from ReceiveRoom where IDRoom = '"+room.Id+"' order by ID desc")) ;
                int price = Int32.Parse(Functions.Laygiatri("select Price from Room join RoomType on Room.IDRoomType = RoomType.ID where Room.ID ='"+room.Id+"'"));
                string sql2;
                sql2 = "INSERT [Bill] ([ID], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES ('"+a+"', '"+idReceiveRoom+"',N'"+staffSetUp+"', '"+DateTime.Now+"','"+price+"', 0, '"+ (price+2500000) + "', 0, 1, 2500000)";
                Functions.Chaysql(sql2);
            }
            ShowBillRoom(room.Id);
            txbTotalPrice.Text = totalPrice.ToString("c0", new CultureInfo("vi-vn"));
        }

        public void ShowBillRoom(int idRoom)
        {
            CultureInfo cultureInfo = new CultureInfo("vi-vn");
            listViewBillRoom.Items.Clear();
            string sql = "select A.Name [Tên phòng],D.Price[Đơn giá] ,C.DateCheckIn [Ngày nhận],C.DateCheckOut[Ngày trả] ,E.RoomPrice[Tiền phòng],E.Surcharge[Phụ thu] from Room A, ReceiveRoom B, BookRoom C, RoomType D, Bill E where E.IDReceiveRoom = B.ID and IDStatusRoom = 2 and A.ID = B.IDRoom and B.IDBookRoom = C.ID and A.IDRoomType = D.ID and B.IDRoom = '" + idRoom + "' and E.IDStatusBill = 1";
            DataTable data = dtBase.DataReader(sql);
            foreach (DataRow item in data.Rows)
            {
                ListViewItem listViewItem = new ListViewItem(item["Tên Phòng"].ToString());
                ListViewItem.ListViewSubItem subItem1 = new ListViewItem.ListViewSubItem(listViewItem, ((int)item["Đơn giá"]).ToString("c0", cultureInfo));
                ListViewItem.ListViewSubItem subItem2 = new ListViewItem.ListViewSubItem(listViewItem, ((DateTime)item["Ngày nhận"]).ToString().Split(' ')[0]);
                ListViewItem.ListViewSubItem subItem3 = new ListViewItem.ListViewSubItem(listViewItem, ((DateTime)item["Ngày trả"]).ToString().Split(' ')[0]);
                ListViewItem.ListViewSubItem subItem4 = new ListViewItem.ListViewSubItem(listViewItem, ((int)item["Tiền phòng"]).ToString("c0", cultureInfo));
                ListViewItem.ListViewSubItem subItem5 = new ListViewItem.ListViewSubItem(listViewItem, ((int)item["Phụ thu"]).ToString("c0", cultureInfo));
                int roomPrice = (int)item["Tiền phòng"] + (int)item["Phụ thu"];
                ListViewItem.ListViewSubItem subItem6 = new ListViewItem.ListViewSubItem(listViewItem, roomPrice.ToString("c0", cultureInfo));
                totalPrice += roomPrice;
                listViewItem.SubItems.Add(subItem1);
                listViewItem.SubItems.Add(subItem2);
                listViewItem.SubItems.Add(subItem3);
                listViewItem.SubItems.Add(subItem4);
                listViewItem.SubItems.Add(subItem5);
                listViewItem.SubItems.Add(subItem6);
                listViewBillRoom.Items.Add(listViewItem);
            }
        }
        int id = 1;
        int totalPrice = 0;
        public void ShowSurcharge()
        {
            string sql = "select * from Parameter";
            DataTable data = dtBase.DataReader(sql);
            foreach (DataRow item in data.Rows)
            {
                ListViewItem listViewItem = new ListViewItem(id.ToString());
                id++;

                ListViewItem.ListViewSubItem subItem1 = new ListViewItem.ListViewSubItem(listViewItem, item["Name"].ToString());
                ListViewItem.ListViewSubItem subItem2 = new ListViewItem.ListViewSubItem(listViewItem, ((double)item["Value"]).ToString());
                ListViewItem.ListViewSubItem subItem3 = new ListViewItem.ListViewSubItem(listViewItem, (item["Describe"]).ToString());

                listViewItem.SubItems.Add(subItem1);
                listViewItem.SubItems.Add(subItem2);
                listViewItem.SubItems.Add(subItem3);

                listViewSurcharge.Items.Add(listViewItem);
            }
            id = 0;
        }
        public void ShowBill(int idRoom)
        {
            listViewUseService.Items.Clear();
            DataTable dataTable = dtBase.DataReader("select D.Name [Tên dịch vụ],D.Price[Đơn giá],B.Count[Số lượng],B.TotalPrice[Thành tiền] from Bill A, BillDetails B, ReceiveRoom C, Service D where A.IDStatusBill = 1 and A.ID = b.IDBill and A.IDReceiveRoom = C.ID and C.IDRoom = '"+idRoom+"' and B.IDService = D.ID");
            CultureInfo cultureInfo = new CultureInfo("vi-vn");
            int _totalPrice = 0;
            foreach (DataRow item in dataTable.Rows)
            {
                ListViewItem listViewItem = new ListViewItem(id.ToString());
                id++;
                ListViewItem.ListViewSubItem subItem1 = new ListViewItem.ListViewSubItem(listViewItem, item["Tên dịch vụ"].ToString());
                ListViewItem.ListViewSubItem subItem2 = new ListViewItem.ListViewSubItem(listViewItem, ((int)item["Đơn giá"]).ToString("c0", cultureInfo));
                ListViewItem.ListViewSubItem subItem3 = new ListViewItem.ListViewSubItem(listViewItem, ((int)item["Số lượng"]).ToString());
                ListViewItem.ListViewSubItem subItem4 = new ListViewItem.ListViewSubItem(listViewItem, ((int)item["Thành tiền"]).ToString("c0", cultureInfo));

                _totalPrice += (int)item["Thành tiền"];

                listViewItem.SubItems.Add(subItem1);
                listViewItem.SubItems.Add(subItem2);
                listViewItem.SubItems.Add(subItem3);
                listViewItem.SubItems.Add(subItem4);

                listViewUseService.Items.Add(listViewItem);
            }
            totalPrice += _totalPrice;

            ListViewItem listViewItemTotalPrice = new ListViewItem();
            ListViewItem.ListViewSubItem subItemTotalPrice = new ListViewItem.ListViewSubItem(listViewItemTotalPrice, _totalPrice.ToString("c0", cultureInfo));
            ListViewItem.ListViewSubItem _subItem1 = new ListViewItem.ListViewSubItem(listViewItemTotalPrice, "");
            ListViewItem.ListViewSubItem _subItem2 = new ListViewItem.ListViewSubItem(listViewItemTotalPrice, "");
            ListViewItem.ListViewSubItem _subItem3 = new ListViewItem.ListViewSubItem(listViewItemTotalPrice, "");
            listViewItemTotalPrice.SubItems.Add(_subItem1);
            listViewItemTotalPrice.SubItems.Add(_subItem2);
            listViewItemTotalPrice.SubItems.Add(_subItem3);
            listViewItemTotalPrice.SubItems.Add(subItemTotalPrice);
            listViewUseService.Items.Add(listViewItemTotalPrice);

            id = 1;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Room1 room = flowLayoutRooms.Tag as Room1;
            string sql1 = "select Bill.ID from Bill join ReceiveRoom on Bill.IDReceiveRoom = ReceiveRoom.ID join Room on Room.ID = ReceiveRoom.IDRoom where IDStatusBill=1 and Room.ID = '" + room.Id+"'";
            Functions.Laygiatri(sql1);
            int price = Int32.Parse(Functions.Laygiatri("select Price from Service where ID ='" + cbService.SelectedValue.ToString() +"' ")) ;
            string sql2 = "	select * from Bill A,BillDetails B, ReceiveRoom C where A.ID = B.IDBill and A.IDStatusBill=1 and C.ID = A.IDReceiveRoom and C.IDRoom = '" + room.Id+"' and B.IDService = '"+cbService.SelectedValue.ToString()+"'";
            if(numericUpDownCount.Value>=1)
            {
                if (!Functions.ktra(sql2))
                {
                    string sql = "INSERT BillDetails(IDBill,IDService,Count,TotalPrice)VALUES('" + Functions.Laygiatri(sql1) + "','" + cbService.SelectedValue.ToString() + "','" + numericUpDownCount.Value + "','" + price * numericUpDownCount.Value + "')";
                    Functions.Chaysql(sql);
                    txbTotalPrice.Text = totalPrice.ToString("c0", new CultureInfo("vi-vn"));
                    ShowBill(room.Id);

                }
                else
                {
                    string sql10 = "select Count from Bill A,BillDetails B, ReceiveRoom C where A.IDStatusBill = 1 and A.ID = B.IDBill and C.ID = A.IDReceiveRoom and C.IDRoom = '" + room.Id + "' and B.IDService = '" + cbService.SelectedValue.ToString() + "'";
                    string sql = "UPDATE BillDetails SET Count ='" + numericUpDownCount.Value + Int32.Parse(Functions.Laygiatri(sql10)) + "',TotalPrice = '" + price * (numericUpDownCount.Value + Int32.Parse(Functions.Laygiatri(sql10))) + "' where IDService = '" + Functions.Laygiatri(sql1) + "'";
                    Functions.Chaysql(sql);
                    txbTotalPrice.Text = totalPrice.ToString("c0", new CultureInfo("vi-vn"));
                    ShowBill(room.Id);
                }
            }
            else
            {
                MessageBox.Show("Số lượng phải lớn hơn 0 !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        private void btnClose__Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txbIDRoom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            Room1 room = flowLayoutRooms.Tag as Room1;
            if (MessageBox.Show("Bạn có chắc chắn thanh toán cho " + room.Name + " không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string sql = "select Bill.ID from Bill join ReceiveRoom on Bill.IDReceiveRoom = ReceiveRoom.ID join Room on Room.ID = ReceiveRoom.IDRoom where Room.ID = '"+room.Id+"'";
                int idBill = Int32.Parse(Functions.Laygiatri(sql));
                string roomprice = Functions.Laygiatri("select RoomType.Price from Bill join ReceiveRoom on Bill.IDReceiveRoom = ReceiveRoom.ID join Room on Room.ID = ReceiveRoom.IDRoom join RoomType on Room.IDRoomType = RoomType.ID  where Room.ID = '" + room.Id + "'");
                string ServicePrice= Functions.Laygiatri("select SUM(TotalPrice) from BillDetails where IDBill = '"+idBill+"'");
                if (ServicePrice == "")
                {
                    Functions.Chaysql("UPDATE Bill SET DateOfCreate ='" + DateTime.Now + "' , Discount ='" + numericUpDown1.Value + "' ,TotalPrice =('"+ Int32.Parse(roomprice) + "') -('"+ Int32.Parse(roomprice)+ "'*" + (numericUpDown1.Value / 100) + "),IDStatusBill = '2',ServicePrice = 0 where Bill.ID = '" + idBill + "'");
                }
                else
                {
                    int totalprice = Int32.Parse(roomprice) + Int32.Parse(ServicePrice);
                    string c="UPDATE Bill SET DateOfCreate ='" + DateTime.Now + "' , Discount ='" + numericUpDown1.Value + "' ,TotalPrice =('" + totalprice + "')-('" + totalprice + "'*" +"("+numericUpDown1.Value  +"/100)" + "),IDStatusBill = '2',ServicePrice = '" + Int32.Parse(ServicePrice) + "' where Bill.ID = '" + idBill + "'";
                    Functions.Chaysql(c);
                }
                sql = "UPDATE Room SET IDStatusRoom = 1 where ID = '"+room.Id+"'";
                Functions.Chaysql(sql);
                //ReportDAO.Instance.InsertReport(idBill);
                MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                fPrintBill fPrintBill = new fPrintBill(room.Id, idBill);
                fPrintBill.ShowDialog();
                this.Show();
                LoadListFullRoom();
                listViewBillRoom.Items.Clear();
                listViewUseService.Items.Clear();
            }
        }
        private string IntToString(string text)
        {
            if (text == string.Empty)
                return 0.ToString("C0", CultureInfo.CreateSpecificCulture("vi-VN"));
            if (text.Contains(".") || text.Contains(" "))
                return text;
            else
                return (int.Parse(text).ToString("C0", CultureInfo.CreateSpecificCulture("vi-VN")));
        }
        private void fUseService_Load(object sender, EventArgs e)
        {
            cbServiceType.DataSource = dtBase.DataReader("SELECT Name,ID FROM ServiceType");
            cbServiceType.DisplayMember = "Name";
            cbServiceType.ValueMember = "ID";
            cbServiceType.SelectedIndex = 0;
            LoadService();
        }
        public void LoadService()
        {
            cbService.DataSource = dtBase.DataReader("SELECT Service.Name,Service.ID FROM Service join ServiceType on ServiceType.ID = Service.IDServiceType where ServiceType.Name = N'" + cbServiceType.Text + "'");
            cbService.DisplayMember = "Name";
            cbService.ValueMember = "ID";
        }
        private void cbServiceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadService();
        }
        private void cbService_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPrice();
        }
        public void LoadPrice()
        {
            string sql = "Select Price from Service where Name = N'" + cbService.Text + "'";
            txbPrice.Text = IntToString(Functions.Laygiatri(sql));
        }
    }
}
