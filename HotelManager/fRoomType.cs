
using System;
using System.Data;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fRoomType : Form
    {
       
        public fRoomType()
        {
            InitializeComponent();
        }

        private void BunifuImageButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            comboboxID.Text = "Tự Động";
            txbName.Text = string.Empty;
            txbPrice.Text = "0";
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
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
                txbName.Text = string.Empty;
                txbPrice.Text = string.Empty;
                btnSearch.Visible = false;
                btnCancel.Visible = true;
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {

            btnCancel.Visible = false;
            btnSearch.Visible = true;
        }

        private void DataGridViewRoomType_SelectionChanged(object sender, EventArgs e)
        {

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

        }
        private void TxbLimitPerson_Leave(object sender, EventArgs e)
        { 

        }


        #region Enter
        private void TxbPrice_Enter(object sender, EventArgs e)
        {
        }
        private void TxbName_Enter(object sender, EventArgs e)
        {
            txbName.Tag = txbName.Text;
        }
        private void TxbLimitPerson_Enter(object sender, EventArgs e)
        {
            txbLimitPerson.Tag = txbLimitPerson.Text;
        }

        #endregion

        #region Close
        private void FRoomType_FormClosing(object sender, FormClosingEventArgs e)
        {
            BtnCancel_Click(sender, null);
        }
        #endregion
    }
}
