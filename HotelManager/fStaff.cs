using HotelManager.Class;
using HotelManager.DAO;
using HotelManager.DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fStaff : Form
    {
        Class.Functions dtBase = new Class.Functions();
        #region Constructor
        internal fStaff()
        {
            InitializeComponent();
            txbSearch.KeyPress += TxbSearch_KeyPress;
            KeyPress += FStaff_KeyPress;
            dataGridStaff.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            LoaddataGridStaff("SELECT UserName,DisplayName,StaffType.Name,IDCard,PhoneNumber,Address from Staff join StaffType on Staff.IDStaffType = StaffType.ID");
        }


        #endregion

        #region Click
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnInsert_Click(object sender, EventArgs e)
        {
            new fAddStaff().ShowDialog();
            if (btnCancel.Visible == false)
            {
                LoaddataGridStaff("SELECT UserName,DisplayName,StaffType.Name,IDCard,PhoneNumber,Address from Staff join StaffType on Staff.IDStaffType = StaffType.ID");
            }

            else
                BtnCancel_Click(null, null);
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show( "Bạn có muốn cập nhật nhân viên này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                if(txbName.Text !=string.Empty && txbIDcard.Text != string.Empty && txbPhoneNumber.Text != string.Empty && txbAddress.Text != string.Empty)
                {
                    if (CheckDate())
                    {
                        Functions.Chaysql("UPDATE Staff SET DisplayName = N'"+txbName.Text+"',Sex = N'"+comboBoxSex.Text+"',PhoneNumber = '"+txbPhoneNumber.Text+"',IDStaffType = '"+comboBoxStaffType.SelectedValue.ToString()+"',Address = '"+txbAddress.Text+"',StartDay = '"+datePickerStartDay.Value+"',DateOfBirth = '"+datepickerDateOfBirth.Value+"' where UserName = '"+txbUserName.Text+"'");
                        MessageBox.Show("Cập nhập nhân viên thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoaddataGridStaff("SELECT UserName,DisplayName,StaffType.Name,IDCard,PhoneNumber,Address from Staff join StaffType on Staff.IDStaffType = StaffType.ID");
                    }
                }
                else
                {
                    MessageBox.Show("Không được để trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void BtnReset_Click(object sender, EventArgs e)
        {
            if (fCustomer.CheckFillInText(new Control[] { txbUserName }))
            {
                DialogResult result = MessageBox.Show( "Bạn có muốn đặt lại mật khẩu với tên đăng nhập " + txbUserName.Text + " không?", "Thông báo",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.OK)
                {
                    Functions.Chaysql("UPDATE Staff SET PassWord  = '"+Functions.HashPass("123456")+"'");
                    MessageBox.Show("Đặt lại mật khẩu thành công. Mật khẩu mặc định là : 123456 ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show( "Không được để trống tên đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ToolStripLabel1_Click(object sender, EventArgs e)
        {
            if (saveStaff.ShowDialog() == DialogResult.Cancel)
                return;
            else
            {
                bool check;
                try
                {
                    switch (saveStaff.FilterIndex)
                    {
                        case 2:
                            check = ExportToExcel.Instance.Export(dataGridStaff, saveStaff.FileName, ModeExportToExcel.XLSX);
                            break;
                        case 3:
                            check = ExportToExcel.Instance.Export(dataGridStaff, saveStaff.FileName, ModeExportToExcel.PDF);
                            break;
                        default:
                            check = ExportToExcel.Instance.Export(dataGridStaff, saveStaff.FileName, ModeExportToExcel.XLS);
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
        private void BindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            txbUserName.Text = string.Empty;
            txbName.Text = string.Empty;
            txbIDcard.Text = string.Empty;
            txbPhoneNumber.Text = string.Empty;
            txbAddress.Text = string.Empty;
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            txbSearch.Text = txbSearch.Text.Trim();
            if (txbSearch.Text != string.Empty)
            {
                txbUserName.Text = string.Empty;
                txbName.Text = string.Empty;
                txbIDcard.Text = string.Empty;
                txbPhoneNumber.Text = string.Empty;
                txbAddress.Text = string.Empty;

                btnSearch.Visible = false;
                btnCancel.Visible = true;
                txbSearch.Enabled = false;
                Search();
            }
        }
        public void Search()
        {
            LoaddataGridStaff("SELECT UserName,DisplayName,StaffType.Name,IDCard,PhoneNumber,Address from Staff join StaffType on Staff.IDStaffType = StaffType.ID where IDCard like '%"+txbSearch.Text+"%' or PhoneNumber like '%"+txbSearch.Text+"%'");
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        { 
            btnCancel.Visible = false;
            btnSearch.Visible = true;
            txbSearch.Enabled = true;
            LoaddataGridStaff("SELECT UserName,DisplayName,StaffType.Name,IDCard,PhoneNumber,Address from Staff join StaffType on Staff.IDStaffType = StaffType.ID");

        }
        #endregion

        #region Method

        internal static void Trim(Bunifu.Framework.UI.BunifuMetroTextbox[] textboxes)
        {
            for (int i = 0; i < textboxes.Length; i++)
            {
                textboxes[i].Text = textboxes[i].Text.Trim();
            }
        }
        private void TxbPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        private bool CheckTrueDate(DateTime date1, DateTime date2)
        {
            if (date2.Subtract(date1).Days < 6574)
                return false;
            return true;
        }
        private bool CheckDate()
        {
            if (!CheckTrueDate(datepickerDateOfBirth.Value, DateTime.Now))
            {
                MessageBox.Show( "Ngày sinh không hợp lệ (Tuổi phải lớn hơn 18)", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                if (!CheckTrueDate(datepickerDateOfBirth.Value, datePickerStartDay.Value))
            {
                MessageBox.Show( "Ngày vào làm không hợp lệ (Lớn hơn 18 tuổi)", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void TxbUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '.' || e.KeyChar == '-' ||
                e.KeyChar == '_' || e.KeyChar == '@'))
                e.Handled = true;
            // ^ ([a - zA - Z0 - 9\.\-_ ?@] +)$

        }
        #endregion

        #region ChangeText
        public void LoadStaff()
        {
            txbUserName.Text = dataGridStaff.CurrentRow.Cells[0].Value.ToString();
            txbName.Text = dataGridStaff.CurrentRow.Cells[1].Value.ToString();
            comboBoxStaffType.Text = dataGridStaff.CurrentRow.Cells[2].Value.ToString();
            txbIDcard.Text = dataGridStaff.CurrentRow.Cells[3].Value.ToString();
            txbPhoneNumber.Text = dataGridStaff.CurrentRow.Cells[4].Value.ToString();
            txbAddress.Text = dataGridStaff.CurrentRow.Cells[5].Value.ToString();
            comboBoxSex.Text = Functions.Laygiatri("select Sex From Staff where UserName = '"+ dataGridStaff.CurrentRow.Cells[0].Value.ToString() + "'");
            datepickerDateOfBirth.Value = DateTime.Parse(Functions.Laygiatri("select DateOfBirth From Staff where UserName = '" + dataGridStaff.CurrentRow.Cells[0].Value.ToString() + "'"));
            datePickerStartDay.Value = DateTime.Parse(Functions.Laygiatri("select StartDay From Staff where UserName = '" + dataGridStaff.CurrentRow.Cells[0].Value.ToString() + "'"));
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
        private void FStaff_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27 && btnCancel.Visible == true)
                BtnCancel_Click(sender, null);
        }
        #endregion

        #region Enter & Leave
        private void Txb_Enter(object sender, EventArgs e)
        {
            Bunifu.Framework.UI.BunifuMetroTextbox textbox = sender as Bunifu.Framework.UI.BunifuMetroTextbox;
            textbox.Tag = textbox.Text;
        }
        private void Txb_Leave(object sender, EventArgs e)
        {
            Bunifu.Framework.UI.BunifuMetroTextbox textbox = sender as Bunifu.Framework.UI.BunifuMetroTextbox;
            if(textbox.Text == string.Empty)
            {
                textbox.Text = textbox.Tag as string;
            }
        }
        #endregion

        #region Close
        private void FStaff_FormClosing(object sender, FormClosingEventArgs e)
        {
            BtnCancel_Click(null, null);
        }
        #endregion

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            string name = dataGridStaff.SelectedRows[0].Cells[0].Value.ToString();
            fAccess f = new fAccess(name);
            f.ShowDialog();
            LoaddataGridStaff("SELECT UserName,DisplayName,StaffType.Name,IDCard,PhoneNumber,Address from Staff join StaffType on Staff.IDStaffType = StaffType.ID");
        }
        public void LoaddataGridStaff(string sql)
        {
            dataGridStaff.DataSource = dtBase.DataReader(sql);
            dataGridStaff.Columns[0].HeaderText = "Tên Đăng Nhập";
            dataGridStaff.Columns[1].HeaderText = "Tên";
            dataGridStaff.Columns[2].HeaderText = "Loại";
            dataGridStaff.Columns[3].HeaderText = "CMND";
            dataGridStaff.Columns[4].HeaderText = "SĐT";
            dataGridStaff.Columns[5].HeaderText = "Địa Chỉ";
            dataGridStaff.Columns[1].Width = 200;
            dataGridStaff.Columns[5].Width = 130;
            BindingSource source = new BindingSource();
            source.DataSource = dtBase.DataReader(sql);
            dataGridStaff.DataSource = source;
            bindingStaff.BindingSource = source;
        }
        private void fStaff_Load(object sender, EventArgs e)
        {
            LoadStaff();
            comboBoxSex.SelectedIndex = 0;
            comboBoxStaffType.DataSource = dtBase.DataReader("SELECT Name,ID FROM StaffType");
            comboBoxStaffType.DisplayMember = "Name";
            comboBoxStaffType.ValueMember = "ID";
            comboBoxStaffType.SelectedIndex = 0;
        }

        private void dataGridStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridStaff_SelectionChanged(object sender, EventArgs e)
        {
            LoadStaff();
        }
    }
}
