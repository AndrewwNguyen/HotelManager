
using System;
using System.Data;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fParameter : Form
    { 
        #region Click
        private void BtnCLose1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show( "Bạn có muốn cập nhật không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                comboboxName.Focus();
            }
        }
        private void ToolStripLabel1_Click(object sender, EventArgs e)
        {
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            txbDescribe.Text = string.Empty;
            txbValue.Text = "0";
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            txbSearch.Text = txbSearch.Text.Trim();
            if (txbSearch.Text != string.Empty)
            {
                txbValue.Text = string.Empty;
                btnSearch.Visible = false;
                btnCancel.Visible = true;
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Visible = false;
            btnSearch.Visible = true;
        }
 

        private void TxbPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '.'))
                e.Handled = true;
        }


        private void DataGridSurcharge_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewParameter.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewParameter.SelectedRows[0];
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
        private void FParameter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27 && btnCancel.Visible == true)
                BtnCancel_Click(sender, null);
        }
        private void Txb_Enter(object sender, EventArgs e)
        {
            var textBox = sender as Bunifu.Framework.UI.BunifuMetroTextbox;
            textBox.Tag = textBox.Text;
        }
        private void Txb_Leave(object sender, EventArgs e)
        {
            var textBox = sender as Bunifu.Framework.UI.BunifuMetroTextbox;
            if(textBox.Text == string.Empty)
            {
                textBox.Text = textBox.Tag as string;
            }
        }

        private void FParameter_FormClosing(object sender, FormClosingEventArgs e)
        {
            BtnCancel_Click(sender, null);
        }
        #endregion
    }
}
