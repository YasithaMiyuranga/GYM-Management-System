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
    public partial class Receptionists : Form
    {
        Functions Con;
        public Receptionists()
        {
            InitializeComponent();
            Con = new Functions();
            showReceptionist();
        }
        private void showReceptionist()
        {
            string Query = "Select * from ReceptionistTbl";
            RecepList.DataSource = Con.GetData(Query);
        }
        private void Reset()
        {
            RecepNameTb.Text = "";
            PhoneTb.Text = "";
            PasswordTb.Text = "";
            RecepAddTb.Text = "";
            GenCb.SelectedIndex = -1;
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (RecepNameTb.Text == "" || PhoneTb.Text == "" || RecepAddTb.Text == "" || PhoneTb.Text == "" || GenCb.SelectedIndex == -1 || PasswordTb.Text == "")
                {
                    MessageBox.Show("Missing Data !!!");
                }
                else
                {
                    string RName = RecepNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    string DOB = RecepDOBTb.Value.Date.ToString();
                    string Add = RecepAddTb.Text;
                    string Phone = PhoneTb.Text;
                    string Password = PasswordTb.Text;
                    string Query = "insert into ReceptionistTbl values('{0}','{1}','{2}','{3}',{4},'{5}')";
                    Query = string.Format(Query, RName, Gender, DOB, Add, Phone, Add, Password);
                    Con.setData(Query);
                    showReceptionist();
                    MessageBox.Show("Receptionist Added!!!");
                    Reset();
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }
        }
        int Key = 0;

        private void RecepList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RecepNameTb.Text = RecepList.SelectedRows[0].Cells[1].Value.ToString();
            GenCb.SelectedItem = RecepList.SelectedRows[0].Cells[2].Value.ToString();
            RecepDOBTb.Text = RecepList.SelectedRows[0].Cells[3].Value.ToString();
            RecepAddTb.Text = RecepList.SelectedRows[0].Cells[4].Value.ToString();
            PhoneTb.Text = RecepList.SelectedRows[0].Cells[5].Value.ToString();
            PasswordTb.Text = RecepList.SelectedRows[0].Cells[6].Value.ToString();

            if (RecepNameTb.Text == "")
            {
                Key = 0;

            }
            else
            {
                Key = Convert.ToInt32(RecepList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Key == 0)
                {
                    MessageBox.Show("Select a Receptionist !!!");
                }
                else
                {

                    string Query = "delete from ReceptionistTbl Where RecepId ={0}";
                    Query = string.Format(Query, Key);
                    Con.setData(Query);
                    showReceptionist();

                    MessageBox.Show("Receptionist Deleted!!!");
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
                if (RecepNameTb.Text == "" || PhoneTb.Text == "" || RecepAddTb.Text == "" || PhoneTb.Text == "" || GenCb.SelectedIndex == -1 || PasswordTb.Text == "")
                {
                    MessageBox.Show("Missing Data !!!");
                }
                else
                {
                    string RName = RecepNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    string DOB = RecepDOBTb.Value.Date.ToString();
                    string Add = RecepAddTb.Text;
                    string Phone = PhoneTb.Text;
                    string Password = PasswordTb.Text;
                    string Query = "update ReceptionistTbl set RecepName = '{0}',RecepGen = '{1}',RecepDOB = '{2}',RecepAdd = '{3}',RecepPhone = {4},RecepPass = '{5}' where RecepId = {6}";
                    Query = string.Format(Query, RName, Gender, DOB, Add, Phone, Password, Key);
                    Con.setData(Query);
                    showReceptionist();
                    MessageBox.Show("Receptionist Updated!!!");
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

        
        private void label14_Click_1(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }
    }
}
