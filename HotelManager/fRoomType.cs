
using HotelManager.Class;
using System;
using System.Data;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fRoomType : Form
    {

        Class.Functions dtBase = new Class.Functions();
        public fRoomType()
        {
            InitializeComponent();
            LoaddataGridViewRoomType("Select ID,Name,LimitPerson,Price from RoomType");
        }

        private void BunifuImageButton1_Click(object sender, EventArgs e)
        {
            Close();
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
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn cập nhật không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                UpdateSurcharge();
                comboboxID.Focus();
            }
        }
        public void UpdateSurcharge()
        {
            if (comboboxID.Text != string.Empty && comboboxID.Text != string.Empty && txbLimitPerson.Text != string.Empty && txbName.Text != string.Empty && txbPrice.Text != string.Empty)
            {
                Functions.Chaysql("Update RoomType SET Name ='" + txbName.Text + "', Price = '" + StringToInt(txbPrice.Text) + "',LimitPerson = '" + txbLimitPerson.Text + "' where ID = N'" + comboboxID.Text + "'");
                MessageBox.Show("Cập nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoaddataGridViewRoomType("Select ID,Name,LimitPerson,Price from RoomType");
            }
            else
            {
                MessageBox.Show("Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ToolStripLabel1_Click(object sender, EventArgs e)
        {
          
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            txbSearch.Text = txbSearch.Text.Trim();
            if (txbSearch.Text != string.Empty)
            {
                btnSearch.Visible = false;
                btnCancel.Visible = true;
                Search();
                txbSearch.Enabled = false;
            }
        }
        public void Search()
        {
            LoaddataGridViewRoomType("select  ID,Name, LimitPerson, Price From RoomType where ID Like '%" + txbSearch.Text + "%' or Name Like '%" + txbSearch.Text + "%'");
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Visible = false;
            btnSearch.Visible = true;
            txbSearch.Enabled = true;
        }

        private void DataGridViewRoomType_SelectionChanged(object sender, EventArgs e)
        {
            Showvalue();
        }
        public void Showvalue()
        {
            IntToString(txbPrice.Text);
            comboboxID.Text = dataGridViewRoomType.CurrentRow.Cells[0].Value.ToString();
            txbName.Text = dataGridViewRoomType.CurrentRow.Cells[1].Value.ToString();
            txbLimitPerson.Text = dataGridViewRoomType.CurrentRow.Cells[2].Value.ToString();
            txbPrice.Text = IntToString(dataGridViewRoomType.CurrentRow.Cells[3].Value.ToString());
        }
        private void TxbPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }

        }

        private void TxbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                BtnSearch_Click(sender, null);
            else
                if (e.KeyChar == 27 && btnCancel.Visible == true)
                BtnCancel_Click(sender, null);
        }
        private void FRoomType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27 && btnCancel.Visible == true)
                BtnCancel_Click(sender, null);
        }

        private void TxbName_Leave(object sender, EventArgs e)
        {
            if (txbName.Text == string.Empty)
                txbName.Text = txbName.Tag as String;

        }
        private void TxbPrice_Leave(object sender, EventArgs e)
        {
            if (txbPrice.Text == string.Empty)
            {
                txbPrice.Text = (string)txbPrice.Tag;
            }
            else
                txbPrice.Text = IntToString(txbPrice.Text);
        }
        private void TxbLimitPerson_Leave(object sender, EventArgs e)
        { 

        }
        private void TxbPrice_Enter(object sender, EventArgs e)
        {
            txbPrice.Tag = txbPrice.Text;
            txbPrice.Text = StringToInt(txbPrice.Text);
        }
        private void TxbName_Enter(object sender, EventArgs e)
        {
            txbName.Tag = txbName.Text;
        }
        private void TxbLimitPerson_Enter(object sender, EventArgs e)
        {
            txbLimitPerson.Tag = txbLimitPerson.Text;
        }


        private void FRoomType_FormClosing(object sender, FormClosingEventArgs e)
        {
            BtnCancel_Click(sender, null);
        }
        public void LoaddataGridViewRoomType(string sql)
        {
            dataGridViewRoomType.DataSource = dtBase.DataReader(sql);
            dataGridViewRoomType.Columns[0].HeaderText = "Mã";
            dataGridViewRoomType.Columns[1].HeaderText = "Tên Loại Phòng";
            dataGridViewRoomType.Columns[2].HeaderText = "Số Người tối đa";
            dataGridViewRoomType.Columns[3].HeaderText = "Giá";
            dataGridViewRoomType.Columns[2].Width = 80;
            dataGridViewRoomType.Columns[0].Width = 55;
            dataGridViewRoomType.Columns[1].Width = 250;
            dataGridViewRoomType.Columns[3].Width = 150;
            BindingSource source = new BindingSource();
            source.DataSource = dtBase.DataReader(sql);
            dataGridViewRoomType.DataSource = source;
            bindingCustomerType.BindingSource = source;
            comboboxID.DataSource = source;
        }
        public void Loadvalues()
        {
            //string sql = "Select Price from RoomType where ID = N'" + comboboxID.SelectedValue + "'";
            //txbPrice.Text = Functions.Laygiatri(sql);
            //sql = "Select LimitPerson Value from RoomType where ID = N'" + comboboxID.SelectedValue + "'";
            //txbLimitPerson.Text = Functions.Laygiatri(sql);
        }
        private void fRoomType_Load(object sender, EventArgs e)
        {
            comboboxID.DataSource = dtBase.DataReader("SELECT ID FROM RoomType");
            comboboxID.DisplayMember = "ID";
            comboboxID.ValueMember = "ID";
            comboboxID.SelectedIndex = 0;
            Loadvalues();
            txbPrice.Text = IntToString(txbPrice.Text);
        }

        private void comboboxID_SelectedIndexChanged(object sender, EventArgs e)
        {
            Loadvalues();
        }
    }
}
