
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace HotelManager
{
    public partial class fCustomer : Form
    {

        #region Constructor
        internal fCustomer()
        {
            InitializeComponent();
            cbCustomerSearch.SelectedIndex = 3;
            comboBoxSex.SelectedIndex = 0;
            SaveCustomer.OverwritePrompt = true;
            comboboxID.DisplayMember = "id";
            FormClosing += FCustomer_FormClosing;
            txbSearch.KeyPress += TxbSearch_KeyPress;
            dataGridViewCustomer.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ToolStripLabel1_Click(object sender, EventArgs e)
        {
        }
        private void BtnAddCustomer_Click(object sender, EventArgs e)
        {
        }
        private void BindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            txbFullName.Text = string.Empty;
            txbAddress.Text = string.Empty;
            txbIDCard.Text = string.Empty;
            txbNationality.Text = string.Empty;
            txbPhoneNumber.Text = string.Empty;
        }
        private void BtnClose1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn cập nhật khách hàng này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
                if (CheckDate())
                {
                    comboboxID.Focus();
                }
                else
                    MessageBox.Show("Ngày sinh phải nhỏ hơn ngày hiện tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            txbSearch.Text = txbSearch.Text.Trim();
            if (txbSearch.Text != string.Empty)
            {
                txbAddress.Text = string.Empty;
                txbFullName.Text = string.Empty;
                txbIDCard.Text = string.Empty;
                txbPhoneNumber.Text = string.Empty;
                txbNationality.Text = string.Empty;

                btnSearch.Visible = false;
                btnCancel.Visible = true;
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Visible = false;
            btnSearch.Visible = true;
        }
        public static bool CheckFillInText(Control[] controls)
        {
            foreach (var control in controls)
            {
                if (control.Text == string.Empty)
                    return false;
            }
            return true;
        }
       
   
        private void DataGridViewCustomer_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewCustomer.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewCustomer.SelectedRows[0];
            }
        }
        #endregion

        #region Check isDigit

        private void TxbPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || e.KeyChar == '\b'))
                e.Handled = true;
        }
        private bool CheckDate()
        {
            if (DateTime.Now.Subtract(datepickerDateOfBirth.Value).Days <= 0)
                return false;
            else return true;
        }

        #endregion

        #region Enter
        private void Txb_Enter(object sender, EventArgs e)
        {
            Bunifu.Framework.UI.BunifuMetroTextbox text = sender as Bunifu.Framework.UI.BunifuMetroTextbox;
            text.Tag = text.Text;
        }
        #endregion

        #region Leave
        private void Txb_Leave(object sender, EventArgs e)
        {
            Bunifu.Framework.UI.BunifuMetroTextbox text = sender as Bunifu.Framework.UI.BunifuMetroTextbox;
            if (text.Text == string.Empty)
                text.Text = text.Tag as string;
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
        private void FCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27 && btnCancel.Visible == true)
                BtnCancel_Click(sender, null);
        }
        #endregion

        #region Close
        private void FCustomer_FormClosing(object sender, FormClosingEventArgs e)
        { 

        }
        #endregion
    }
}
