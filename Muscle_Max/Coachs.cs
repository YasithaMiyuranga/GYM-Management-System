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
    public partial class Coachs : Form
    {
        Functions Con;
        public Coachs()
        {
            InitializeComponent();
            Con = new Functions();
            showCoach();
        }
        private void showCoach()
        {
            string Query = "Select * from CoachsTbl";
            CoachsList.DataSource = Con.GetData(Query);
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ChNameTb.Text == "" || PhoneTb.Text == "" || ExpTb.Text == "" || PassTb.Text == "" || GenCb.SelectedIndex == -1)
                {
                    MessageBox.Show("Missing Data !!!");
                }
                else
                {
                    string CName = ChNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Phone = PhoneTb.Text;
                    int experience = Convert.ToInt32(ExpTb.Text);
                    string Add = AddTb.Text;
                    string Password = PassTb.Text;
                    string Query = "insert into CoachsTbl values('{0}','{1}','{2}','{3}',{4},'{5}','{6}')";
                    Query = string.Format(Query, CName, Gender, DOBTb.Value.Date, Phone, experience, Add, Password);
                    Con.setData(Query);
                    showCoach();
                    MessageBox.Show("Coach Added!!!");
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }
        }
        int Key = 0;
        private void CoachsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ChNameTb.Text = CoachsList.SelectedRows[0].Cells[1].Value.ToString();
            GenCb.SelectedItem = CoachsList.SelectedRows[0].Cells[2].Value.ToString();
            DOBTb.Text = CoachsList.SelectedRows[0].Cells[3].Value.ToString();
            PhoneTb.Text = CoachsList.SelectedRows[0].Cells[4].Value.ToString();
            ExpTb.Text = CoachsList.SelectedRows[0].Cells[5].Value.ToString();
            AddTb.Text = CoachsList.SelectedRows[0].Cells[6].Value.ToString();
            PassTb.Text = CoachsList.SelectedRows[0].Cells[7].Value.ToString();
            if (ChNameTb.Text == "")
            {
                Key = 0;

            }
            else
            {
                Key = Convert.ToInt32(CoachsList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Key == 0)
                {
                    MessageBox.Show("Select a Coach !!!");
                }
                else
                {
                    string CName = ChNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Phone = PhoneTb.Text;
                    int experience = Convert.ToInt32(ExpTb.Text);
                    string Add = AddTb.Text;
                    string Password = PassTb.Text;
                    string Query = "delete from CoachsTbl Where CId ={0}";
                    Query = string.Format(Query, Key);
                    Con.setData(Query);
                    showCoach();

                    MessageBox.Show("Coach Deleted!!!");
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
                if (ChNameTb.Text == "" || PhoneTb.Text == "" || ExpTb.Text == "" || PassTb.Text == "" || GenCb.SelectedIndex == -1)
                {
                    MessageBox.Show("Missing Data !!!");
                }
                else
                {
                    string CName = ChNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Phone = PhoneTb.Text;
                    int experience = Convert.ToInt32(ExpTb.Text);
                    string Add = AddTb.Text;
                    string Password = PassTb.Text;
                    string Query = "update CoachsTbl set CName '{0}',CGen = '{1}',CDOB = '{2}',CPhone = '{3}',CExperience = {4},CAddress = '{5}',CPass = '{6}' where CID = {7})";
                    Query = string.Format(Query, CName, Gender, DOBTb.Value.Date, Phone, experience, Add, Password,Key);
                    Con.setData(Query);
                    showCoach();
                    MessageBox.Show("Coach Updated!!!");
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }
        }

        private void MemberLbl_Click(object sender, EventArgs e)
        {
            Members obj = new Members();
            obj.Show();
            this.Hide();
        }

        private void MShipLbl_Click(object sender, EventArgs e)
        {
            Memberships obj = new Memberships();
            obj.Show();
            this.Hide();
        }

        private void RecepLbl_Click(object sender, EventArgs e)
        {
            Receptionists obj = new Receptionists();
            obj.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }
    }
}
