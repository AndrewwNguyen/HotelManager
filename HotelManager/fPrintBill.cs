
using HotelManager.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fPrintBill : Form
    {
        Class.Functions dtBase = new Class.Functions();

        int idroom;
        int idbill;
        public fPrintBill(int _idRoom, int _idBill)
        {
            idbill = _idBill;
            idroom = _idRoom;
            InitializeComponent();
            ShowBillPreView(idbill);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnClose__Click(object sender, EventArgs e)
        {
            Close();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap,58,70);
            bitmap.Dispose();
        }
        Bitmap bitmap;
        private void btnPrint_Click(object sender, EventArgs e)
        {
            Graphics graphics = this.CreateGraphics();
            bitmap = new Bitmap(708, 647, graphics);
            Graphics _graphics = Graphics.FromImage(bitmap);
            _graphics.CopyFromScreen(this.Location.X, this.Location.Y+28,0,0,new Size(708, 647));
            bitmap.Save(Application.StartupPath+ @"\Bill.Png", ImageFormat.Png);
            bitmap = new Bitmap(Application.StartupPath + @"\Bill.Png");
            if (printDialog1.ShowDialog() == DialogResult.OK)
                printDocument1.Print();
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void fPrintBill_Load(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = new CultureInfo("vi-vn");
            lblIDBill.Text = idbill.ToString();
            string sql;
            sql  = "select Customer.Name from Customer join BookRoom on Customer.ID = BookRoom.IDCustomer join ReceiveRoom on ReceiveRoom.IDBookRoom = BookRoom.ID join Bill on Bill.IDReceiveRoom = ReceiveRoom.ID where Bill.ID = '" + idbill+"'";
            lblCustomerName.Text= Functions.Laygiatri(sql);
            sql = "select Customer.IDCard from Customer join BookRoom on Customer.ID = BookRoom.IDCustomer join ReceiveRoom on ReceiveRoom.IDBookRoom = BookRoom.ID join Bill on Bill.IDReceiveRoom = ReceiveRoom.ID where Bill.ID = '" + idbill + "'";
            lblIDCard.Text = Functions.Laygiatri(sql);
            sql = "select CustomerType.Name from Customer join BookRoom on Customer.ID = BookRoom.IDCustomer join ReceiveRoom on ReceiveRoom.IDBookRoom = BookRoom.ID join Bill on Bill.IDReceiveRoom = ReceiveRoom.ID join CustomerType on Customer.IDCustomerType = CustomerType.ID where Bill.ID = '" + idbill + "'";
            lblCustomerTypeName.Text = Functions.Laygiatri(sql);
            sql = "select Customer.Address from Customer join BookRoom on Customer.ID = BookRoom.IDCustomer join ReceiveRoom on ReceiveRoom.IDBookRoom = BookRoom.ID join Bill on Bill.IDReceiveRoom = ReceiveRoom.ID where Bill.ID = '" + idbill + "'";
            lblAddress.Text = Functions.Laygiatri(sql);
            sql = "select Customer.Nationality from Customer join BookRoom on Customer.ID = BookRoom.IDCustomer join ReceiveRoom on ReceiveRoom.IDBookRoom = BookRoom.ID join Bill on Bill.IDReceiveRoom = ReceiveRoom.ID where Bill.ID = '" + idbill + "'";
            lblNationality.Text = Functions.Laygiatri(sql);
            sql = "select Customer.PhoneNumber from Customer join BookRoom on Customer.ID = BookRoom.IDCustomer join ReceiveRoom on ReceiveRoom.IDBookRoom = BookRoom.ID join Bill on Bill.IDReceiveRoom = ReceiveRoom.ID where Bill.ID = '" + idbill + "'";
            lblPhoneNumber.Text = Functions.Laygiatri(sql);
            sql = "select DisplayName from Staff join Bill on Bill.StaffSetUp = Staff.UserName where Bill.ID = '"+idbill+"'";
            lblStaffSetUp.Text = Functions.Laygiatri(sql);
            sql = "select DateOfCreate from Bill where  Bill.ID = '" + idbill + "'";
            lblDateCreate.Text = Functions.Laygiatri(sql);
            sql = "select Room.Name from Customer join BookRoom on Customer.ID = BookRoom.IDCustomer join ReceiveRoom on ReceiveRoom.IDBookRoom = BookRoom.ID join Bill on Bill.IDReceiveRoom = ReceiveRoom.ID join Room on Room.ID = ReceiveRoom.IDRoom join RoomType on RoomType.ID = Room.IDRoomType where Bill.ID = '" + idbill+"'";
            lblRoomName.Text = Functions.Laygiatri(sql);
            sql = "select RoomType.Name from Customer join BookRoom on Customer.ID = BookRoom.IDCustomer join ReceiveRoom on ReceiveRoom.IDBookRoom = BookRoom.ID join Bill on Bill.IDReceiveRoom = ReceiveRoom.ID join Room on Room.ID = ReceiveRoom.IDRoom join RoomType on RoomType.ID = Room.IDRoomType where Bill.ID = '" + idbill + "'";
            lblRoomTypeName.Text = Functions.Laygiatri(sql);
            sql = "select DateCheckIn from BookRoom join ReceiveRoom on ReceiveRoom.IDBookRoom = BookRoom.ID join Bill on Bill.IDReceiveRoom = ReceiveRoom.ID where Bill.ID = '"+idbill+"'";
            lblDateCheckIn.Text = Functions.Laygiatri(sql);
            sql = "select Days from BookRoom join ReceiveRoom on ReceiveRoom.IDBookRoom = BookRoom.ID join Bill on Bill.IDReceiveRoom = ReceiveRoom.ID where Bill.ID = '" + idbill + "'";
            lblDays.Text = Functions.Laygiatri(sql);
            sql = "select COUNT(*) from ReceiveRoomDetails join ReceiveRoom on ReceiveRoom.ID = ReceiveRoomDetails.IDReceiveRoom join Bill on Bill.IDReceiveRoom = ReceiveRoom.ID where Bill.ID = '"+idbill+"'";
            lblPeoples.Text = Functions.Laygiatri(sql);
            sql = "select RoomType.Price from Customer join BookRoom on Customer.ID = BookRoom.IDCustomer join ReceiveRoom on ReceiveRoom.IDBookRoom = BookRoom.ID join Bill on Bill.IDReceiveRoom = ReceiveRoom.ID join Room on Room.ID = ReceiveRoom.IDRoom join RoomType on RoomType.ID = Room.IDRoomType where Bill.ID = '" + idbill + "'";
            lblRoomPrice_.Text = IntToString(Functions.Laygiatri(sql));
            lblRoomPrice.Text = IntToString(Functions.Laygiatri(sql));
            lblSurcharge.Text = IntToString("2500000");
            sql = "select ServicePrice from Bill where  Bill.ID = '" + idbill + "'";
            lblServicePrice.Text = IntToString(Functions.Laygiatri(sql));
            int Service = Int32.Parse(Functions.Laygiatri("select ServicePrice from Bill where  Bill.ID = '" + idbill + "'"));
            int RoomPrice = Int32.Parse(Functions.Laygiatri("select RoomType.Price from Customer join BookRoom on Customer.ID = BookRoom.IDCustomer join ReceiveRoom on ReceiveRoom.IDBookRoom = BookRoom.ID join Bill on Bill.IDReceiveRoom = ReceiveRoom.ID join Room on Room.ID = ReceiveRoom.IDRoom join RoomType on RoomType.ID = Room.IDRoomType where Bill.ID = '" + idbill + "'"));
            int x = RoomPrice + 2500000 + Service;
            lblTotalPrice.Text = IntToString(x + "");
            int Discount = Int32.Parse(Functions.Laygiatri("select Discount from Bill where  Bill.ID = '" + idbill + "'"));
            double sid = x - (x * (1.0 * Discount / 100));
            lblDiscount.Text = Discount+ "%";
            lblFinalPrice.Text = sid.ToString("c0", cultureInfo);


        }
        private string DoubleToString(string text)
        {
            if (text == string.Empty)
                return 0.ToString("C0", CultureInfo.CreateSpecificCulture("vi-VN"));
            if (text.Contains(".") || text.Contains(" "))
                return text;
            else
                return (double.Parse(text).ToString("C0", CultureInfo.CreateSpecificCulture("vi-VN")));
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
        private string StringToInt(string text)
        {
            if (text.Contains(".") || text.Contains(" "))
            {
                string[] vs = text.Split(new char[] { '.', ' ' });
                StringBuilder textNow = new StringBuilder();
                for (int i = 0; i < vs.Length - 1; i++)
                {
                    textNow.Append(vs[i]);
                }
                return textNow.ToString();
            }
            else return text;
        }
        int id = 0;
        public void ShowBillPreView(int idBill)
        {
            listViewUseService.Items.Clear();
            DataTable dataTable = dtBase.DataReader("select D.Name [Tên dịch vụ],D.Price[Đơn giá],B.Count[Số lượng],B.TotalPrice[Thành tiền] from Bill A, BillDetails B, ReceiveRoom C, Service D where A.ID = b.IDBill and A.IDReceiveRoom = C.ID and B.IDService = D.ID and A.ID = '"+idbill+"'");
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

    }
}
