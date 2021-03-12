using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

namespace Blood_donor_management_System
{
    public partial class frmInsert : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret= "RexrG6OuogoAu6dghwvsZtLkCi3z5ig2NfaRtnsK",
            BasePath= "https://blood-donor-9af63-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        public frmInsert()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(config);

                if (client != null)
                {
                    
                }
                else
                {
                    MessageBox.Show("Check your connection again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Exit();
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Check your connection again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
            
        }
        public void Clear()
        {
            txtAge.Clear();
            txtContactNumber.Clear();
            txtDescription.Clear();
            txtID.Clear();
            txtName.Clear();
            txtRAddress.Clear();
            cboBoodGroup.ResetText();
            cboSex.ResetText();
        }


        private async void button1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to add this record?","Insert",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                var data = new Data
                {
                    ID = txtID.Text,
                    Name = txtName.Text,
                    Address = txtRAddress.Text,
                    ContactNum = txtContactNumber.Text,
                    Age = txtAge.Text,
                    Description = txtDescription.Text,
                    Gender = cboSex.Text,
                    BloodGroup = cboBoodGroup.Text
                };

                try
                {
                    SetResponse response = await client.SetTaskAsync("Donor/" + txtID.Text, data);
                    Data result = response.ResultAs<Data>();
                    MessageBox.Show("Your record has been successfully added!");
                    Clear();
                }catch(Exception)
                {
                    MessageBox.Show("Please check your data again!");
                }
            }
            
            
        }

        private void txtContactNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void cboSex_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboBoodGroup_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmDeleteDonor frm = new frmDeleteDonor();
            frm.ShowDialog();
        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (txtID.Text != String.Empty)
            {
                if (MessageBox.Show("Are you sure you want to add this record?", "save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    try
                    {
                        var data = new Data
                        {
                            ID = txtID.Text,
                            Address = txtRAddress.Text,
                            Age = txtAge.Text,
                            ContactNum = txtContactNumber.Text,
                            BloodGroup = cboBoodGroup.Text,
                            Gender = cboSex.Text,
                            Description = txtDescription.Text,
                            Name = txtName.Text
                        };


                        FirebaseResponse response = await client.UpdateTaskAsync("Donor/" + textBox1.Text, data);
                        Data result = response.ResultAs<Data>();
                        MessageBox.Show("Your message has been successfully updated.");
                        Clear();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Please check your detail again.");
                    }
                }
            }
            else
            {
                MessageBox.Show("You should enter atleast your ID number.");
            }

        }

        private async void button5_Click(object sender, EventArgs e)
        {
            try
            {
                FirebaseResponse response = await client.GetTaskAsync("Donor/" + textBox1.Text);
                {
                        Data obj = response.ResultAs<Data>();

                        txtID.Text = obj.ID;
                        txtName.Text = obj.Name;
                        txtRAddress.Text = obj.Address;
                        txtDescription.Text = obj.Description;
                        txtContactNumber.Text = (obj.ContactNum).ToString();
                        txtAge.Text = obj.Age;
                        cboBoodGroup.Text = obj.BloodGroup;
                        cboSex.Text = obj.Gender;

                    MessageBox.Show("Your result is ready");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Some error occured! Please restart the system.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
