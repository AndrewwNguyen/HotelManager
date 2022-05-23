
using HotelManager.Class;
using System;
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
    
    public partial class fReceiveRoom : Form
    {
        Class.Functions dtBase = new Class.Functions();
        int IDBookRoom = -1;
        string staffSetUp;
        public fReceiveRoom( string userName)
        {
            staffSetUp = userName;
            InitializeComponent();
        }
        public void LoadInfoIdRoom()
        {
            string str;
            str = "SELECT Customer.Name from Customer join BookRoom on Customer.ID = BookRoom.IDCustomer where BookRoom.ID = '" + txbIDBookRoom.Text + "'";
            txbFullName.Text = Functions.Laygiatri(str);
            str = "SELECT Customer.IDCard from Customer join BookRoom on Customer.ID = BookRoom.IDCustomer where BookRoom.ID = '" + txbIDBookRoom.Text + "'";
            txbIDCard.Text = Functions.Laygiatri(str);
            str = "SELECT Room.Name from BookRoom join RoomType on BookRoom.IDRoomType = RoomType.ID join Room on Room.IDRoomType= RoomType.ID where BookRoom.ID = '" + txbIDBookRoom.Text + "'";
            txbRoomName.Text = Functions.Laygiatri(str);
            str = "SELECT RoomType.Name from Customer join BookRoom on Customer.ID = BookRoom.IDCustomer Join RoomType on BookRoom.IDRoomType=RoomType.ID where BookRoom.ID = '" + txbIDBookRoom.Text + "'";
            txbRoomTypeName.Text = Functions.Laygiatri(str);
            str = "SELECT DateCheckIn from Customer join BookRoom on Customer.ID = BookRoom.IDCustomer where BookRoom.ID = '" + txbIDBookRoom.Text + "'";
            txbDateCheckIn.Text = Functions.Laygiatri(str);
            str = "SELECT DateCheckOut from Customer join BookRoom on Customer.ID = BookRoom.IDCustomer where BookRoom.ID = '" + txbIDBookRoom.Text + "'";
            txbDateCheckOut.Text = Functions.Laygiatri(str);
            str = "SELECT RoomType.LimitPerson from Customer join BookRoom on Customer.ID = BookRoom.IDCustomer Join RoomType on BookRoom.IDRoomType=RoomType.ID where BookRoom.ID = '" + txbIDBookRoom.Text + "'";
            txbAmountPeople.Text = Functions.Laygiatri(str);
            str = "SELECT Price from Customer join BookRoom on Customer.ID = BookRoom.IDCustomer Join RoomType on BookRoom.IDRoomType=RoomType.ID where BookRoom.ID = '" + txbIDBookRoom.Text + "'";
            txbPrice.Text = IntToString(Functions.Laygiatri(str));
            cbRoomType.Text = txbRoomTypeName.Text;
            cbRoom.Text = txbRoomName.Text;

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
        public void ReLoad()
        {
            cbRoom.DataSource = dtBase.DataReader("select Room.ID,Room.Name from Room join RoomType on Room.IDRoomType= RoomType.ID where RoomType.ID= '" + cbRoomType.SelectedValue + "'and IDStatusRoom = '" + 1 + "'");
            cbRoom.DisplayMember = "Room.Name";
            cbRoom.ValueMember = "Room.ID";
        }
        public fReceiveRoom()
        {
            InitializeComponent();

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbRoomTypeName.Text = cbRoomType.Text;
        }

        private void cbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbRoomName.Text = cbRoom.Text;
        }

        private void txbIDBookRoom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
            if (e.KeyChar == 13)
                btnSearch_Click(sender, null);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = "select Checked from BookRoom where ID = '" + txbIDBookRoom.Text + "'";
            if (Functions.Laygiatri(sql) != "Đã Nhận Phòng")
            {
                LoadInfoIdRoom();
            }
            else
            {
                MessageBox.Show("Mã đặt phòng không tồn tại hoặc đã được nhận phòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if (txbRoomName.Text != string.Empty && txbRoomTypeName.Text != string.Empty && txbFullName.Text != string.Empty && txbIDCard.Text != string.Empty && txbDateCheckIn.Text != string.Empty && txbDateCheckOut.Text != string.Empty && txbAmountPeople.Text != string.Empty && txbPrice.Text != string.Empty)
            {
                int a = Int32.Parse(txbIDBookRoom.Text);
                fAddCustomerInfo fAddCustomerInfo = new fAddCustomerInfo(a);
                fAddCustomerInfo.ShowDialog();
                this.Show();
            }
            else
                MessageBox.Show("Vui lòng nhập lại đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnReceiveRoom_Click(object sender, EventArgs e)
        {
            string sql5 = "select Checked from BookRoom where ID = '"+txbIDBookRoom.Text+"'";
            if(Functions.Laygiatri(sql5)!="Đã Nhận Phòng")
            {
                if (MessageBox.Show("Bạn có muốn nhận phòng không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    string sql, sql2, sql3;
                    int a = Functions.key();
                    sql2 = "UPDATE Room SET IDStatusRoom= '" + 2 + "' from Room join ReceiveRoom on ReceiveRoom.IDRoom = Room.ID where Room.ID = '" + cbRoom.SelectedValue.ToString() + "'";
                    string sql6 = "UPDATE BookRoom SET Checked =N'Đã Nhận Phòng' where ID ='"+txbIDBookRoom.Text+"'";
                    Functions.Chaysql(sql6);
                    sql = "INSERT ReceiveRoom(ID, IDBookRoom, IDRoom)VALUES('" + a + "','" + txbIDBookRoom.Text + "','" + cbRoom.SelectedValue.ToString() + "')";
                    Functions.Chaysql(sql);
                    string sql4 = "SELECT Customer.ID FROM  Customer join BookRoom on BookRoom.IDCustomer = Customer.ID join ReceiveRoom on ReceiveRoom.IDBookRoom = BookRoom.ID Where ReceiveRoom.ID = '" + a + "'";
                    string b = Functions.Laygiatri(sql4);
                    sql3 = "INSERT ReceiveRoomDetails(IDReceiveRoom,IDCustomerOther) VALUES ('" + a + "','" + b + "')";
                    Functions.Chaysql(sql2);
                    Functions.Chaysql(sql3);
                    int Totals = Int32.Parse(Functions.Laygiatri("select RoomType.Price from RoomType join Room on Room.IDRoomType = RoomType.ID join ReceiveRoom on ReceiveRoom.IDRoom = Room.ID where ReceiveRoom.ID = '" + a + "'"))+2500000;
                    sql2 = "INSERT [Bill] ([ID], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES ('" + Functions.key() + "', '" + a + "',N'" + staffSetUp + "', '" + DateTime.Now + "','" + Int32.Parse(Functions.Laygiatri("select RoomType.Price from RoomType join Room on Room.IDRoomType = RoomType.ID join ReceiveRoom on ReceiveRoom.IDRoom = Room.ID where ReceiveRoom.ID = '" + a + "'")) + "', 0, '" + Totals+ "', 0, 1, 2500000)";
                    Functions.Chaysql(sql2);
                    MessageBox.Show("Nhận Phòng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoaddataGridViewReceiveRoom();
                    ReLoad();
                }
            } 
        }
        public void ClearData()
        {
            txbFullName.Text = txbIDCard.Text = txbRoomTypeName.Text = txbDateCheckIn.Text = txbDateCheckOut.Text = txbAmountPeople.Text = txbPrice.Text = string.Empty;

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void btnClose__Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            fReceiveRoomDetails f = new fReceiveRoomDetails((int)dataGridViewReceiveRoom.SelectedRows[0].Cells[0].Value);
            f.ShowDialog();
            Show();
            LoaddataGridViewReceiveRoom();
        }

        private void fReceiveRoom_Load(object sender, EventArgs e)
        {
            cbRoomType.DataSource = dtBase.DataReader("SELECT Name,ID FROM Roomtype");
            cbRoomType.DisplayMember = "Name";
            cbRoomType.ValueMember = "ID";
            cbRoomType.SelectedIndex = 0;
            cbRoom.DataSource = dtBase.DataReader("SELECT Name,ID FROM Room");
            cbRoom.DisplayMember = "Name";
            cbRoom.ValueMember = "ID";
            cbRoom.SelectedIndex = 0;
            LoaddataGridViewReceiveRoom();
        }

        private void cbRoom_DropDown(object sender, EventArgs e)
        {
            ReLoad();
        }
        public void LoaddataGridViewReceiveRoom()
        {

            dataGridViewReceiveRoom.DataSource = dtBase.DataReader("SELECT ReceiveRoom.ID,Customer.Name,Customer.IDCard,Room.Name, DateCheckIn,DateCheckOut from ReceiveRoom join BookRoom on ReceiveRoom.IDBookRoom=BookRoom.ID join Customer on Customer.ID=BookRoom.IDCustomer join Room on Room.ID=ReceiveRoom.IDRoom");
            dataGridViewReceiveRoom.Columns[0].HeaderText = "Mã nhận phòng";
            dataGridViewReceiveRoom.Columns[1].HeaderText = "Họ tên";
            dataGridViewReceiveRoom.Columns[2].HeaderText = "CMND";
            dataGridViewReceiveRoom.Columns[3].HeaderText = "Tên phòng";
            dataGridViewReceiveRoom.Columns[4].HeaderText = "Ngày nhận";
            dataGridViewReceiveRoom.Columns[5].HeaderText = "Ngày trả";
        }
        public void CLearData()
        {
            txbIDBookRoom.Text = string.Empty;
            txbIDCard.Text = string.Empty;
            txbPrice.Text = string.Empty;
            txbFullName.Text = string.Empty;
            txbRoomTypeName.Text = string.Empty;
            txbDateCheckIn.Text = string.Empty;
            txbDateCheckOut.Text = string.Empty;
        }
    }
}
