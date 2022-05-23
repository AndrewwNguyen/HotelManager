using HotelManager.Class;
using HotelManager.DAO;
using HotelManager.DTO;
using System;
using System.Data;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fRoom : Form
    {
        private fRoomType _fRoomtType;
        Class.Functions dtBase = new Class.Functions();
        public fRoom()
        {
            InitializeComponent();
            dataGridViewRoom.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            LoaddataGridViewRoom("select Room.ID,Room.Name,RoomType.Name,RoomType.Price,RoomType.LimitPerson,StatusRoom.Name from Room join RoomType on RoomType.ID = Room.IDRoomType join StatusRoom on StatusRoom.ID = Room.IDStatusRoom ");
            Loadvalues();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnAddRoom_Click(object sender, EventArgs e)
        {
            fAddRoom f = new fAddRoom();
            f.ShowDialog();
            LoaddataGridViewRoom("select Room.ID,Room.Name,RoomType.Name,RoomType.Price,RoomType.LimitPerson,StatusRoom.Name from Room join RoomType on RoomType.ID = Room.IDRoomType join StatusRoom on StatusRoom.ID = Room.IDStatusRoom ");
            Showvalues();

        }
        private void BtnRoomType_Click(object sender, EventArgs e)
        {
            fRoomType f = new fRoomType();
            f.ShowDialog();
            LoaddataGridViewRoom("select Room.ID,Room.Name,RoomType.Name,RoomType.Price,RoomType.LimitPerson,StatusRoom.Name from Room join RoomType on RoomType.ID = Room.IDRoomType join StatusRoom on StatusRoom.ID = Room.IDStatusRoom ");
            Showvalues();
        }
        private void BtnCLose1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            txbNameRoom.Text = string.Empty;
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn cập nhật lại phòng?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
                UpdateRoom();
            comboboxID.Focus();
        }
        public void UpdateRoom()
        {
            if(txbNameRoom.Text !=string.Empty)
            {
                Functions.Chaysql("UPDATE Room SET Room.Name = '" + txbNameRoom.Text + "' ,Room.IDRoomType ='" + comboBoxRoomType.SelectedValue + "',IDStatusRoom = '"+comboBoxStatusRoom.SelectedValue+"' from Room join RoomType on Room.IDRoomType = RoomType.ID join StatusRoom on StatusRoom.ID = Room.IDStatusRoom where Room.ID = '" + comboboxID.Text + "'");
                MessageBox.Show("Cập nhập phòng thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoaddataGridViewRoom("select Room.ID,Room.Name,RoomType.Name,RoomType.Price,RoomType.LimitPerson,StatusRoom.Name from Room join RoomType on RoomType.ID = Room.IDRoomType join StatusRoom on StatusRoom.ID = Room.IDStatusRoom ");
                Showvalues();
            }
            else
            {
                MessageBox.Show("Không được để trống", "lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void ToolStripLabel1_Click(object sender, EventArgs e)
        {
            if (saveRoom.ShowDialog() == DialogResult.Cancel)
                return;
            else
            {
                bool check;
                try
                {
                    switch (saveRoom.FilterIndex)
                    {
                        case 2:
                            check = ExportToExcel.Instance.Export(dataGridViewRoom, saveRoom.FileName, ModeExportToExcel.XLSX);
                            break;
                        case 3:
                            check = ExportToExcel.Instance.Export(dataGridViewRoom, saveRoom.FileName, ModeExportToExcel.PDF);
                            break;
                        default:
                            check = ExportToExcel.Instance.Export(dataGridViewRoom, saveRoom.FileName, ModeExportToExcel.XLS);
                            break;
                    }
                    if (check)
                        MessageBox.Show( "Xuất thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show( "Lỗi xuất thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch
                {
                    MessageBox.Show( "Lỗi (Cần cài đặt Office)", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void Search()
        {
            LoaddataGridViewRoom("select Room.ID,Room.Name,RoomType.Name,RoomType.Price,RoomType.LimitPerson,StatusRoom.Name from Room join RoomType on RoomType.ID = Room.IDRoomType join StatusRoom on StatusRoom.ID = Room.IDStatusRoom where Room.ID like '%"+txbSearch.Text+"%' or Room.Name like '%"+txbSearch.Text+"%'");
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
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Visible = false;
            btnSearch.Visible = true;
            txbSearch.Enabled = true;
            LoaddataGridViewRoom("select Room.ID,Room.Name,RoomType.Name,RoomType.Price,RoomType.LimitPerson,StatusRoom.Name from Room join RoomType on RoomType.ID = Room.IDRoomType join StatusRoom on StatusRoom.ID = Room.IDStatusRoom ");
        }


        public void Loadvalues()
        {
            string sql = "Select Price from RoomType where Name = N'" + comboBoxRoomType.Text + "'";
            txbPrice.Text = IntToString(Functions.Laygiatri(sql));
            sql = "Select LimitPerson Value from RoomType where Name = N'" + comboBoxRoomType.Text + "'";
            txbLimitPerson.Text = Functions.Laygiatri(sql);
        }
        private void ComboBoxRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Loadvalues();
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
        private void TxbNameRoom_Enter(object sender, EventArgs e)
        {
            txbNameRoom.Tag = txbNameRoom.Text;
        }
        private void TxbNameRoom_Leave(object sender, EventArgs e)
        {
            if (txbNameRoom.Text == string.Empty)
                txbNameRoom.Text = txbNameRoom.Tag as string;
        }
        private void TxbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                BtnSearch_Click(sender, null);
            else
                if (e.KeyChar == 27 && btnCancel.Visible == true)
                BtnCancel_Click(sender, null);
        }
        private void FRoom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27 && btnCancel.Visible == true)
                BtnCancel_Click(sender, null);
        }
        public void Showvalues()
        {
            comboboxID.Text = dataGridViewRoom.CurrentRow.Cells[0].Value.ToString();
            txbNameRoom.Text=dataGridViewRoom.CurrentRow.Cells[1].Value.ToString();
            comboBoxRoomType.Text = dataGridViewRoom.CurrentRow.Cells[2].Value.ToString();
            txbPrice.Text = IntToString(dataGridViewRoom.CurrentRow.Cells[3].Value.ToString());
            txbLimitPerson.Text = dataGridViewRoom.CurrentRow.Cells[4].Value.ToString();
            comboBoxStatusRoom.Text = dataGridViewRoom.CurrentRow.Cells[5].Value.ToString();
        }
        private void FRoom_FormClosing(object sender, FormClosingEventArgs e)
        {
            BtnCancel_Click(sender, null);
        }
        public void LoaddataGridViewRoom(string sql)
        {
            dataGridViewRoom.DataSource = dtBase.DataReader(sql);
            dataGridViewRoom.Columns[0].HeaderText = "Mã";
            dataGridViewRoom.Columns[1].HeaderText = "Tên";
            dataGridViewRoom.Columns[2].HeaderText = "Loại Phòng";
            dataGridViewRoom.Columns[3].HeaderText = "Giá";
            dataGridViewRoom.Columns[4].HeaderText = "Số người tối đa";
            dataGridViewRoom.Columns[5].HeaderText = "Trạng thái";
            dataGridViewRoom.Columns[2].Width = 170;
            dataGridViewRoom.Columns[0].Width = 55;
            dataGridViewRoom.Columns[1].Width = 90;
            dataGridViewRoom.Columns[3].Width = 80;
            dataGridViewRoom.Columns[5].Width = 130;
            BindingSource source = new BindingSource();
            source.DataSource = dtBase.DataReader(sql);
            dataGridViewRoom.DataSource = source;
            bindingRoom.BindingSource = source;
            comboboxID.DataSource = source;
        }
        private void fRoom_Load(object sender, EventArgs e)
        {
            comboBoxRoomType.DataSource = dtBase.DataReader("SELECT ID,Name FROM RoomType");
            comboBoxRoomType.DisplayMember = "Name";
            comboBoxRoomType.ValueMember = "ID";
            comboBoxRoomType.SelectedIndex = 0;
            comboBoxStatusRoom.DataSource = dtBase.DataReader("SELECT ID,Name FROM StatusRoom");
            comboBoxStatusRoom.DisplayMember = "Name";
            comboBoxStatusRoom.ValueMember = "ID";
            comboBoxStatusRoom.SelectedIndex = 0;
            comboboxID.DataSource = dtBase.DataReader("SELECT ID FROM Room");
            comboboxID.DisplayMember = "ID";
            comboboxID.ValueMember = "ID";
            comboboxID.DataSource = dtBase.DataReader("SELECT ID FROM Room");
            comboboxID.SelectedIndex = 0;
            Showvalues();
        }

        private void dataGridViewRoom_SelectionChanged_1(object sender, EventArgs e)
        {
            Showvalues();
        }

        private void comboboxID_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRoom();
        }
        public void LoadRoom()
        {
            string sql = "Select Price from Room join RoomType on Room.IDRoomType = RoomType.ID where Room.ID = N'" + comboboxID.SelectedIndex + "'";
            txbPrice.Text = IntToString(Functions.Laygiatri(sql));
            sql = "Select LimitPerson from Room join RoomType on Room.IDRoomType = RoomType.ID where Room.ID = N'" + comboboxID.SelectedIndex + "'";
            txbLimitPerson.Text = Functions.Laygiatri(sql);
            sql = "Select Room.Name from Room join RoomType on Room.IDRoomType = RoomType.ID where Room.ID = N'" + comboboxID.SelectedIndex + "'";
            txbNameRoom.Text = Functions.Laygiatri(sql);
            sql = "Select StatusRoom.Name from Room join RoomType on Room.IDRoomType = RoomType.ID join StatusRoom on StatusRoom.ID = Room.IDStatusRoom where Room.ID = N'" + comboboxID.SelectedIndex + "'";
            comboBoxStatusRoom.Text = Functions.Laygiatri(sql);
            sql = "Select RoomType.Name from Room join RoomType on Room.IDRoomType = RoomType.ID where Room.ID = N'" + comboboxID.SelectedIndex + "'";
            comboBoxRoomType.Text = Functions.Laygiatri(sql);
        }
    }
}
