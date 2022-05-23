
using HotelManager.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fAccess : Form
    {
        string name;
        Class.Functions dtBase = new Class.Functions();
        private int idStaffType = -1;
        public fAccess(string _name)
        {
            InitializeComponent();
            name = _name;
            cbbStaffType.DisplayMember = "Name";
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            try
            {
                string idjob = Functions.Laygiatri("SELECT ID from JOB where Name = N'" + dataGridViewAccessRest.CurrentRow.Cells[0].Value.ToString() + "'");
                string sql = "INSERT INTO ACCESS(IDStaffType,IDJob) VALUES('" + Functions.Laygiatri("select IDStaffType from Staff where UserName = '" + name + "'") + "','" + idjob + "') select  ACCESS.IDStaffType,IDJob from Staff join StaffType on Staff.IDStaffType = StaffType.ID join ACCESS on ACCESS.IDStaffType = StaffType.ID join JOB on JOB.ID = ACCESS.IDJob where Staff.UserName ='" + name + "'";
                Functions.Chaysql(sql);
                LoadJob();
            }
            catch(Exception)
            {
                MessageBox.Show("Đã hết quyền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ACCESS()
        {
            if(cbbStaffType.Text == "Nhân Viên")
            {


            }    
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            
            string idjob = Functions.Laygiatri("SELECT ID from JOB where Name = N'" + dataGridViewAccessNow.CurrentRow.Cells[0].Value.ToString()+ "'");
            if(idjob =="6")
            {
                return;
            }
            else
            {
                string sql = "DELETE ACCESS from ACCESS join JOB on ACCESS.IDJob = JOB.ID join StaffType on StaffType.ID = ACCESS.IDStaffType join Staff on Staff.IDStaffType = StaffType.ID where JOB.ID = '" + idjob + "' and Staff.UserName ='" + name + "'";
                Functions.Chaysql(sql);
                LoadJob();
            }
        }
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {

        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string index = cbbStaffType.Text;
            new fAddStaffType(index).ShowDialog();
            cbbStaffType.DataSource = dtBase.DataReader("SELECT Name,ID FROM StaffType");
            cbbStaffType.DisplayMember = "Name";
            cbbStaffType.ValueMember = "ID";
            cbbStaffType.SelectedIndex = 0;
        }
        private void btnInsertStaffType_Click(object sender, EventArgs e)
        {

        }
        private void cbbStaffType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        public void LoadJob()
        {
            dataGridViewAccessNow.DataSource = dtBase.DataReader("SELECT JOB.Name FROM ACCESS join JOB on ACCESS.IDJob = JOB.ID join StaffType on StaffType.ID = ACCESS.IDStaffType join Staff on Staff.IDStaffType = StaffType.ID where Staff.UserName = '" + name + "'");
            dataGridViewAccessRest.DataSource = dtBase.DataReader("select JOB.Name from JOB where JOB.Name not in(select JOB.Name from ACCESS join JOB on ACCESS.IDJob = JOB.ID join StaffType on StaffType.ID = ACCESS.IDStaffType join Staff on Staff.IDStaffType = StaffType.ID where Staff.UserName = '" + name + "')");
            dataGridViewAccessNow.Columns[0].Width = 243;
            dataGridViewAccessRest.Columns[0].Width = 243;
        }
        private void fAccess_Load(object sender, EventArgs e)
        {
            LoadJob();
            cbbStaffType.DataSource = dtBase.DataReader("SELECT Name,ID FROM StaffType");
            cbbStaffType.DisplayMember = "Name";
            cbbStaffType.ValueMember = "ID";
            cbbStaffType.SelectedIndex = 0;
        }
    }
}
