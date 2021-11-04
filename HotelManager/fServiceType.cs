using System.Data;
using System.Windows.Forms;
using HotelManager.DAO;
using HotelManager.DTO;
using System;

namespace HotelManager
{
    public partial class fServiceType : Form
    {
        #region Properties
        DataTable _tableSerViceType;
        public fServiceType()
        {
            InitializeComponent();
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnUpdateServiceType_Click(object sender, EventArgs e)
        {

        }
        private void BtnCLose1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BtnInsert_Click(object sender, EventArgs e)
        {

        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            txbName.Text = string.Empty;
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
                btnSearch.Visible = false;
                btnCancel.Visible = true;
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Visible = false;
            btnSearch.Visible = true;
        }

        private void DataGridViewServiceType_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void fServiceType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnUpdateServiceType_Click(sender, e);
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

        #endregion

        #region Close
        private void FServiceType_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.BtnCancel_Click(sender, null);
            this.txbSearch.Text = string.Empty;
        }

        #endregion
    }
}
