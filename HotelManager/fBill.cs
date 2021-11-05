
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
        //private readonly fPrintBill fPrintBill = new fPrintBill();

        public fBill()
        {
            InitializeComponent();
            dataGridViewBill.Font = new Font("Segoe UI", 9.75F);
            comboboxID.DisplayMember = "ID";
            cbBillSearch.SelectedIndex = 0;
        }
        private void ChangePrice(DataTable table)
        {
            table.Columns.Add("totalPrice_New", typeof(string));
            table.Columns.Add("finalprice_New", typeof(string));
            for (int i = 0; i < table.Rows.Count; i++)
            {
                table.Rows[i]["finalprice_New"] = ((int)table.Rows[i]["finalprice"]).ToString("C0", CultureInfo.CreateSpecificCulture("vi-VN"));
                table.Rows[i]["totalPrice_New"] = ((int)table.Rows[i]["totalPrice"]).ToString("C0", CultureInfo.CreateSpecificCulture("vi-VN"));
            }
            table.Columns.Remove("finalprice");
            table.Columns.Remove("totalPrice");
            table.Columns["totalPrice_New"].ColumnName = "totalPrice";
            table.Columns["finalprice_New"].ColumnName = "finalprice";

        }
        private void BtnSeenBill_Click(object sender, EventArgs e)
        {
           
        }

        #region Click
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            txbSearch.Text = txbSearch.Text.Trim();
            if (txbSearch.Text != string.Empty)
            {
                txbDateCreate.Text = string.Empty;
                txbName.Text = string.Empty;
                txbPrice.Text = string.Empty;
                txbStatusRoom.Text = string.Empty;
                txbUser.Text = string.Empty;

                btnSearch.Visible = false;
                btnCancel.Visible = true;
  
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {

            btnCancel.Visible = false;
            btnSearch.Visible = true;
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

    }
}
