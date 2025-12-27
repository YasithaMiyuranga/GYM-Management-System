using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muscle_Max
{
    public partial class Members : Form
    {
        Functions Con;
        public Members()
        {
            InitializeComponent();
            Con = new Functions();
            showMembers(); 

            GetCoaches();
            GetMships();

        }
        private void showMembers()
        {
            string Query = "Select * from MembersTbl";
            MembersList.DataSource = Con.GetData(Query);
        }

        private void CoachLbl_Click(object sender, EventArgs e)
        {
            Coachs obj = new Coachs();
            obj.Show();
            this.Hide();
        }

        private void GetCoaches()
        {
            String Query = "select * from CoachsTbl";
            CoachCb.DisplayMember = Con.GetData(Query).Columns["CName"].ToString();
            CoachCb.ValueMember = Con.GetData(Query).Columns["CId"].ToString();
            CoachCb.DataSource = Con.GetData(Query);

        }
        private void GetMships()
        {
            String Query = "select * from MembershipsTbl";
            MShipCb.DisplayMember = Con.GetData(Query).Columns["MName"].ToString();
            MShipCb.ValueMember = Con.GetData(Query).Columns["MshipId"].ToString();
            MShipCb.DataSource = Con.GetData(Query);

        }
        private void Reset()
        {
            MNameTb.Text = "";
            PhoneTb.Text = "";
            CoachCb.SelectedIndex = -1;
            GenCb.SelectedIndex = -1;
            MShipCb.SelectedIndex = -1;
            StatusCb.SelectedIndex = -1;
            TimingCb.SelectedIndex = -1;
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MNameTb.Text == "" || PhoneTb.Text == "" || CoachCb.SelectedIndex == -1 || GenCb.SelectedIndex == -1 || MShipCb.SelectedIndex == -1 || StatusCb.SelectedIndex == -1)
              
                    
                {
                    MessageBox.Show("Missing Data !!!");
                }
                else
                {
                    

                    string MName = MNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Phone = PhoneTb.Text;
                    string DOB = DOBTb.Value.Date.ToString();
                    string MJDate = JDateTb.Value.Date.ToString();
                    int MShip = Convert.ToInt32(MShipCb.SelectedValue.ToString());
                    int Coach = Convert.ToInt32(CoachCb.SelectedValue.ToString());
                    string Timing = TimingCb.SelectedIndex.ToString();
                    string Status = StatusCb.SelectedIndex.ToString();
                    string Query = "insert into MembersTbl values('{0}','{1}','{2}','{3}',{4},'{5}','{6}','{7}','{8}')";
                    Query = string.Format(Query, MName, Gender, DOBTb.Value.Date, JDateTb.Value.Date, MShip, Coach, Phone, Timing, Status);
                    Con.setData(Query);
                    showMembers();
                    Reset();
                    MessageBox.Show(" Member Added!!!");
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }
        }
        int Key = 0;
        private void MembersList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MNameTb.Text = MembersList.SelectedRows[0].Cells[1].Value.ToString();
            GenCb.SelectedItem = MembersList.SelectedRows[0].Cells[2].Value.ToString();
            DOBTb.Text = MembersList.SelectedRows[0].Cells[3].Value.ToString();
            JDateTb.Text = MembersList.SelectedRows[0].Cells[4].Value.ToString();
            MShipCb.Text = MembersList.SelectedRows[0].Cells[5].Value.ToString();
            CoachCb.Text = MembersList.SelectedRows[0].Cells[6].Value.ToString();
            PhoneTb.Text = MembersList.SelectedRows[0].Cells[7].Value.ToString();
            TimingCb.Text = MembersList.SelectedRows[0].Cells[8].Value.ToString();
            StatusCb.Text = MembersList.SelectedRows[0].Cells[9].Value.ToString();

            if (MNameTb.Text == "")
            {
                Key = 0;

            }
            else
            {
                Key = Convert.ToInt32(MembersList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void UpBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MNameTb.Text == "" || PhoneTb.Text == "" || CoachCb.SelectedIndex == -1 || GenCb.SelectedIndex == -1 || MShipCb.SelectedIndex == -1 || StatusCb.SelectedIndex == -1)
                {
                    MessageBox.Show("Missing Data !!!");
                }
                else
                {
                    string MName = MNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Phone = PhoneTb.Text;
                    string DOB = DOBTb.Value.Date.ToString();
                    string MJDate = JDateTb.Value.Date.ToString();
                    int MShip = Convert.ToInt32(MShipCb.SelectedValue.ToString());
                    int Coach = Convert.ToInt32(CoachCb.SelectedValue.ToString());
                    string Timing = TimingCb.SelectedIndex.ToString();
                    string Status = StatusCb.SelectedIndex.ToString();
                    string Query = "update  MembersTbl set MName = '{0}',MGen = '{1}',MDOB = '{2}',MJDate = '{3}',MMembership = {4},MCoach = '{5}',MPhone = '{6}' ,MTiming = '{7}',MStatus = '{8}' where MId = {9}";
                    Query = string.Format(Query, MName, Gender, DOBTb.Value.Date, JDateTb.Value.Date, MShip, Coach, Phone, Timing, Status);
                    Con.setData(Query);
                    showMembers();
                    Reset();
                    MessageBox.Show(" Member Updated!!!");
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Key == 0)
                {
                    MessageBox.Show("Select a Member !!!");
                }
                else
                {

                    string Query = "delete from MembersTbl Where MId ={0}";
                    Query = string.Format(Query, Key);
                    Con.setData(Query);
                    showMembers();

                    MessageBox.Show("Member Deleted!!!");
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Billing obj = new Billing();
            obj.Show();
            this.Hide();
        }

       

        private void label14_Click_1(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
