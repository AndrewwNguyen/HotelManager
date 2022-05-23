
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
    public partial class fBill : Form
    {
        Class.Functions dtBase = new Class.Functions();
        private void LoadFullBill(DataTable table)
        {
            ChangePrice(table);
        }
        public fBill()
            
        {
            LoadFullBill(dtBase.DataReader("select Bill.ID,Room.Name,Customer.Name,DateOfCreate,StatusBill.Name,ServicePrice+RoomPrice+Surcharge as N'Thành tiền',Discount,TotalPrice as N'Đơn giá' from Bill join ReceiveRoom on ReceiveRoom.ID = Bill.IDReceiveRoom join Room on ReceiveRoom.IDRoom = Room.ID join BookRoom on BookRoom.ID = ReceiveRoom.IDBookRoom join Customer on Customer.ID = BookRoom.IDCustomer join StatusBill on StatusBill.ID = Bill.IDStatusBill"));
            InitializeComponent();
            dataGridViewBill.Font = new Font("Segoe UI", 9.75F);
            comboboxID.DisplayMember = "ID";
            cbBillSearch.SelectedIndex = 0;
            LoaddataGridViewBill("select Bill.ID,Room.Name,Customer.Name,DateOfCreate,StatusBill.Name,ServicePrice+RoomPrice+Surcharge,Discount,TotalPrice from Bill join ReceiveRoom on ReceiveRoom.ID = Bill.IDReceiveRoom join Room on ReceiveRoom.IDRoom = Room.ID join BookRoom on BookRoom.ID = ReceiveRoom.IDBookRoom join Customer on Customer.ID = BookRoom.IDCustomer join StatusBill on StatusBill.ID = Bill.IDStatusBill");
        }
        private void ChangePrice(DataTable table)
        {
            table.Columns.Add("totalPrice_New", typeof(string));
            table.Columns.Add("finalprice_New", typeof(string));
            for (int i = 0; i < table.Rows.Count; i++)
            {
                table.Rows[i]["finalprice_New"] = ((int)table.Rows[i]["Thành tiền"]).ToString("C0", CultureInfo.CreateSpecificCulture("vi-VN"));
                table.Rows[i]["totalPrice_New"] = ((int)table.Rows[i]["Đơn giá"]).ToString("C0", CultureInfo.CreateSpecificCulture("vi-VN"));
            }
            table.Columns.Remove("Thành tiền");
            table.Columns.Remove("Đơn giá");
            table.Columns["totalPrice_New"].ColumnName = "Đơn giá";
            table.Columns["finalprice_New"].ColumnName = "Thành tiền";

        }
        private void BtnSeenBill_Click(object sender, EventArgs e)
        {
            int idroom = Int32.Parse(Functions.Laygiatri("select Bill.ID,Room.Name,Customer.Name,DateOfCreate,StatusBill.Name,ServicePrice+RoomPrice+Surcharge,Discount,TotalPrice from Bill join ReceiveRoom on ReceiveRoom.ID = Bill.IDReceiveRoom join Room on ReceiveRoom.IDRoom = Room.ID join BookRoom on BookRoom.ID = ReceiveRoom.IDBookRoom join Customer on Customer.ID = BookRoom.IDCustomer join StatusBill on StatusBill.ID = Bill.IDStatusBill where Bill.ID = '"+comboboxID.Text+"'"));
            fPrintBill fPrintBill = new fPrintBill(idroom, Int32.Parse(comboboxID.Text));
            fPrintBill.ShowDialog();
        }
        #region Click
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            txbSearch.Text = txbSearch.Text.Trim();
                btnSearch.Visible = false;
                btnCancel.Visible = true;
                Search();
        }
        public void Search()
        {
            if(cbBillSearch.Text == "Mã hoá đơn")
            {
                LoaddataGridViewBill("select Bill.ID,Room.Name,Customer.Name,DateOfCreate,StatusBill.Name,ServicePrice+RoomPrice+Surcharge,Discount,TotalPrice from Bill join ReceiveRoom on ReceiveRoom.ID = Bill.IDReceiveRoom join Room on ReceiveRoom.IDRoom = Room.ID join BookRoom on BookRoom.ID = ReceiveRoom.IDBookRoom join Customer on Customer.ID = BookRoom.IDCustomer join StatusBill on StatusBill.ID = Bill.IDStatusBill where Bill.ID like '%"+txbSearch.Text+"%'");
            }
            if (cbBillSearch.Text == "Tên khách hàng")
            {
                LoaddataGridViewBill("select Bill.ID,Room.Name,Customer.Name,DateOfCreate,StatusBill.Name,ServicePrice+RoomPrice+Surcharge,Discount,TotalPrice from Bill join ReceiveRoom on ReceiveRoom.ID = Bill.IDReceiveRoom join Room on ReceiveRoom.IDRoom = Room.ID join BookRoom on BookRoom.ID = ReceiveRoom.IDBookRoom join Customer on Customer.ID = BookRoom.IDCustomer join StatusBill on StatusBill.ID = Bill.IDStatusBill where Customer.Name like N'%" + txbSearch.Text + "%'");
            }
            if (cbBillSearch.Text == "Số CMND")
            {
                LoaddataGridViewBill("select Bill.ID,Room.Name,Customer.Name,DateOfCreate,StatusBill.Name,ServicePrice+RoomPrice+Surcharge,Discount,TotalPrice from Bill join ReceiveRoom on ReceiveRoom.ID = Bill.IDReceiveRoom join Room on ReceiveRoom.IDRoom = Room.ID join BookRoom on BookRoom.ID = ReceiveRoom.IDBookRoom join Customer on Customer.ID = BookRoom.IDCustomer join StatusBill on StatusBill.ID = Bill.IDStatusBill where Customer.IDCard like N'%" + txbSearch.Text + "%'");
            }
            if (cbBillSearch.Text == "Số điện thoại")
            {
                LoaddataGridViewBill("select Bill.ID,Room.Name,Customer.Name,DateOfCreate,StatusBill.Name,ServicePrice+RoomPrice+Surcharge,Discount,TotalPrice from Bill join ReceiveRoom on ReceiveRoom.ID = Bill.IDReceiveRoom join Room on ReceiveRoom.IDRoom = Room.ID join BookRoom on BookRoom.ID = ReceiveRoom.IDBookRoom join Customer on Customer.ID = BookRoom.IDCustomer join StatusBill on StatusBill.ID = Bill.IDStatusBill where Customer.PhoneNumber like N'%" + txbSearch.Text + "%'");
            }
            if (cbBillSearch.Text == "Hóa đơn chưa thanh toán")
            {
                LoaddataGridViewBill("select Bill.ID,Room.Name,Customer.Name,DateOfCreate,StatusBill.Name,ServicePrice+RoomPrice+Surcharge,Discount,TotalPrice from Bill join ReceiveRoom on ReceiveRoom.ID = Bill.IDReceiveRoom join Room on ReceiveRoom.IDRoom = Room.ID join BookRoom on BookRoom.ID = ReceiveRoom.IDBookRoom join Customer on Customer.ID = BookRoom.IDCustomer join StatusBill on StatusBill.ID = Bill.IDStatusBill where StatusBill.ID = 1 ");
            }
            if (cbBillSearch.Text == "Hóa đơn đã thanh toán")
            {
                LoaddataGridViewBill("select Bill.ID,Room.Name,Customer.Name,DateOfCreate,StatusBill.Name,ServicePrice+RoomPrice+Surcharge,Discount,TotalPrice from Bill join ReceiveRoom on ReceiveRoom.ID = Bill.IDReceiveRoom join Room on ReceiveRoom.IDRoom = Room.ID join BookRoom on BookRoom.ID = ReceiveRoom.IDBookRoom join Customer on Customer.ID = BookRoom.IDCustomer join StatusBill on StatusBill.ID = Bill.IDStatusBill where StatusBill.ID = 2 ");
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {

            btnCancel.Visible = false;
            btnSearch.Visible = true;
            LoaddataGridViewBill("select Bill.ID,Room.Name,Customer.Name,DateOfCreate,StatusBill.Name,ServicePrice+RoomPrice+Surcharge,Discount,TotalPrice from Bill join ReceiveRoom on ReceiveRoom.ID = Bill.IDReceiveRoom join Room on ReceiveRoom.IDRoom = Room.ID join BookRoom on BookRoom.ID = ReceiveRoom.IDBookRoom join Customer on Customer.ID = BookRoom.IDCustomer join StatusBill on StatusBill.ID = Bill.IDStatusBill");

        }

        #endregion

        #region Key
        private void TxbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                BtnSearch_Click(sender, null);
            else
                if (e.KeyChar == 27 && btnCancel.Visible == true)
                BtnCancel_Click(sender, null);
        }
        private void FBill_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27 && btnCancel.Visible == true)
                BtnCancel_Click(sender, null);
        }
        #endregion
        public void LoaddataGridViewBill(string sql )
        {
            dataGridViewBill.DataSource = dtBase.DataReader(sql);
            dataGridViewBill.Columns[0].HeaderText = "Mã hóa đơn";
            dataGridViewBill.Columns[1].HeaderText = "Tên phòng";
            dataGridViewBill.Columns[2].HeaderText = "Tên khách hàng";
            dataGridViewBill.Columns[3].HeaderText = "Ngày tạo";
            dataGridViewBill.Columns[4].HeaderText = "Trạng thái";
            dataGridViewBill.Columns[5].HeaderText = "Đơn giá";
            dataGridViewBill.Columns[6].HeaderText = "Giảm giá";
            dataGridViewBill.Columns[7].HeaderText = "Thành tiền";
            dataGridViewBill.Columns[6].Width = 70;
            BindingSource source = new BindingSource();
            source.DataSource = dtBase.DataReader(sql);
            dataGridViewBill.DataSource = source;
            bindingBill.BindingSource = source;
        }
        public void LoadBill()
        {
            string sql;
            sql = "select Room.Name from Bill join ReceiveRoom on ReceiveRoom.ID = Bill.IDReceiveRoom join Room on ReceiveRoom.IDRoom = Room.ID join BookRoom on BookRoom.ID = ReceiveRoom.IDBookRoom join Customer on Customer.ID = BookRoom.IDCustomer join StatusBill on StatusBill.ID = Bill.IDStatusBill join Staff on Staff.UserName = Bill.StaffSetUp where Bill.ID = '"+comboboxID.Text+"'";
            txbName.Text = Functions.Laygiatri(sql);
            sql = "select UserName from Bill join ReceiveRoom on ReceiveRoom.ID = Bill.IDReceiveRoom join Room on ReceiveRoom.IDRoom = Room.ID join BookRoom on BookRoom.ID = ReceiveRoom.IDBookRoom join Customer on Customer.ID = BookRoom.IDCustomer join StatusBill on StatusBill.ID = Bill.IDStatusBill join Staff on Staff.UserName = Bill.StaffSetUp where Bill.ID = '" + comboboxID.Text + "'";
            txbUser.Text = Functions.Laygiatri(sql);
            sql = "select Bill.DateOfCreate from Bill join ReceiveRoom on ReceiveRoom.ID = Bill.IDReceiveRoom join Room on ReceiveRoom.IDRoom = Room.ID join BookRoom on BookRoom.ID = ReceiveRoom.IDBookRoom join Customer on Customer.ID = BookRoom.IDCustomer join StatusBill on StatusBill.ID = Bill.IDStatusBill join Staff on Staff.UserName = Bill.StaffSetUp where Bill.ID = '" + comboboxID.Text + "'";
            txbDateCreate.Text = Functions.Laygiatri(sql);
            sql = "select StatusBill.Name from Bill join ReceiveRoom on ReceiveRoom.ID = Bill.IDReceiveRoom join Room on ReceiveRoom.IDRoom = Room.ID join BookRoom on BookRoom.ID = ReceiveRoom.IDBookRoom join Customer on Customer.ID = BookRoom.IDCustomer join StatusBill on StatusBill.ID = Bill.IDStatusBill join Staff on Staff.UserName = Bill.StaffSetUp where Bill.ID = '" + comboboxID.Text + "'";
            txbStatusRoom.Text = Functions.Laygiatri(sql);
            sql = "select ServicePrice+RoomPrice+Surcharge from Bill join ReceiveRoom on ReceiveRoom.ID = Bill.IDReceiveRoom join Room on ReceiveRoom.IDRoom = Room.ID join BookRoom on BookRoom.ID = ReceiveRoom.IDBookRoom join Customer on Customer.ID = BookRoom.IDCustomer join StatusBill on StatusBill.ID = Bill.IDStatusBill join Staff on Staff.UserName = Bill.StaffSetUp where Bill.ID = '" + comboboxID.Text + "'";
            txbPrice.Text = IntToString(Functions.Laygiatri(sql));
            sql = "select TotalPrice from Bill join ReceiveRoom on ReceiveRoom.ID = Bill.IDReceiveRoom join Room on ReceiveRoom.IDRoom = Room.ID join BookRoom on BookRoom.ID = ReceiveRoom.IDBookRoom join Customer on Customer.ID = BookRoom.IDCustomer join StatusBill on StatusBill.ID = Bill.IDStatusBill join Staff on Staff.UserName = Bill.StaffSetUp where Bill.ID = '" + comboboxID.Text + "'";
            txbFinalPrice.Text = IntToString(Functions.Laygiatri(sql));
            sql = "select Discount from Bill join ReceiveRoom on ReceiveRoom.ID = Bill.IDReceiveRoom join Room on ReceiveRoom.IDRoom = Room.ID join BookRoom on BookRoom.ID = ReceiveRoom.IDBookRoom join Customer on Customer.ID = BookRoom.IDCustomer join StatusBill on StatusBill.ID = Bill.IDStatusBill join Staff on Staff.UserName = Bill.StaffSetUp where Bill.ID = '" + comboboxID.Text + "'";
            txbDiscount.Text = Functions.Laygiatri(sql);

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
        private string IntToString(string text)
        {
            if (text == string.Empty)
                return 0.ToString("C0", CultureInfo.CreateSpecificCulture("vi-VN"));
            if (text.Contains(".") || text.Contains(" "))
                return text;
            else
                return (int.Parse(text).ToString("C0", CultureInfo.CreateSpecificCulture("vi-VN")));
        }
        private void fBill_Load(object sender, EventArgs e)
        {
            
            comboboxID.DataSource = dtBase.DataReader("SELECT ID FROM Bill");
            comboboxID.DisplayMember = "ID";
            comboboxID.ValueMember = "ID";
            comboboxID.SelectedIndex = 0;
        }

        private void comboboxID_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBill();
        }

        private void dataGridViewBill_SelectionChanged(object sender, EventArgs e)
        {
            comboboxID.Text = dataGridViewBill.CurrentRow.Cells[0].Value.ToString();
            txbName.Text = dataGridViewBill.CurrentRow.Cells[1].Value.ToString();
            txbUser.Text = Functions.Laygiatri("select UserName from Bill join ReceiveRoom on ReceiveRoom.ID = Bill.IDReceiveRoom join Room on ReceiveRoom.IDRoom = Room.ID join BookRoom on BookRoom.ID = ReceiveRoom.IDBookRoom join Customer on Customer.ID = BookRoom.IDCustomer join StatusBill on StatusBill.ID = Bill.IDStatusBill join Staff on Staff.UserName = Bill.StaffSetUp where Bill.ID = '" + dataGridViewBill.CurrentRow.Cells[0].Value.ToString() + "'");
            txbDateCreate.Text = dataGridViewBill.CurrentRow.Cells[3].Value.ToString();
            txbStatusRoom.Text = dataGridViewBill.CurrentRow.Cells[4].Value.ToString();
            txbPrice.Text = IntToString(dataGridViewBill.CurrentRow.Cells[5].Value.ToString());
            txbDiscount.Text = dataGridViewBill.CurrentRow.Cells[6].Value.ToString() + "%";
            txbFinalPrice.Text = IntToString(dataGridViewBill.CurrentRow.Cells[7].Value.ToString());
        }
    }
}
