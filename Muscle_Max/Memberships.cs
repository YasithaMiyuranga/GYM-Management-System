using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muscle_Max
{
    public partial class Memberships : Form
    {
        Functions Con;
        public Memberships()
        {
            InitializeComponent();
            Con = new Functions();
            showMShips();
        }
        private void showMShips()
        {
            string Query = "Select * from MembershipsTbl";
            MShipList.DataSource = Con.GetData(Query);
        }
        private void Reset()
        {
            MNameTb.Text = "";
            CostTb.Text = "";
            MDurationTb.Text = "";
            GoalTb.Text = "";
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MNameTb.Text == "" || MDurationTb.Text == "" || GoalTb.Text == "" || CostTb.Text == "")
                {
                    MessageBox.Show("Missing Data !!!");
                }
                else
                {
                    string MName = MNameTb.Text;
                    int Duration = Convert.ToInt32(MDurationTb.Text);
                    string Goal = GoalTb.Text;
                    int Cost = Convert.ToInt32(CostTb.Text);
                    string Query = "insert into MembershipsTbl values( '{0}',{1},'{2}',{3})";
                    Query = string.Format(Query, MName, Duration, Goal, Cost);
                    Con.setData(Query);
                    showMShips();
                    MessageBox.Show("Membership Added!!!");
                    Reset();
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }
        }
        int Key = 0;
        private void MShipList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MNameTb.Text = MShipList.SelectedRows[0].Cells[1].Value.ToString();
            MDurationTb.Text = MShipList.SelectedRows[0].Cells[2].Value.ToString();
            GoalTb.Text = MShipList.SelectedRows[0].Cells[3].Value.ToString();
            CostTb.Text = MShipList.SelectedRows[0].Cells[4].Value.ToString();

            if (MNameTb.Text == "")
            {
                Key = 0;

            }
            else
            {
                Key = Convert.ToInt32(MShipList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Key == 0)
                {
                    MessageBox.Show("Select a Membership !!!");
                }
                else
                {

                    string Query = "delete from MembershipsTbl Where MShipId ={0}";
                    Query = string.Format(Query, Key);
                    Con.setData(Query);
                    showMShips();
                    MessageBox.Show("Membership Deleted!!!");
                    Reset();
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MNameTb.Text == "" || MDurationTb.Text == "" || GoalTb.Text == "" || CostTb.Text == "")
                {
                    MessageBox.Show("Missing Data !!!");
                }
                else
                {
                    string MName = MNameTb.Text;
                    int Duration = Convert.ToInt32(MDurationTb.Text);
                    string Goal = GoalTb.Text;
                    int Cost = Convert.ToInt32(CostTb.Text);
                    string Query = "update MembershipsTbl set MName =  '{0}',MDuration = {1},MGoal = '{2}',MCost = {3} where MShipId = {4}";
                    Query = string.Format(Query, MName, Duration, Goal, Cost, Key);
                    Con.setData(Query);
                    showMShips();
                    MessageBox.Show("Membership Updated!!!");
                    Reset();
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }
        }

        private void CoachLbl_Click(object sender, EventArgs e)
        {
            Coachs obj = new Coachs();
            obj.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }
    }
}
