using HotelManager.DAO;
using HotelManager.DTO;
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
    public partial class fAddService : Form
    {
        public fAddService()
        {
            InitializeComponent();
            txbPrice.Text = IntToString("100000");

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

        private void TxbPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void TxbPrice_Leave(object sender, EventArgs e)
        {
            if (txbPrice.Text == string.Empty)
                txbPrice.Text = txbPrice.Tag as string;
            else
                txbPrice.Text = IntToString(txbPrice.Text);
        }
        private void TxbPrice_Enter(object sender, EventArgs e)
        {
            txbPrice.Tag = txbPrice.Text;
            txbPrice.Text = StringToInt(txbPrice.Text);
        }
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
