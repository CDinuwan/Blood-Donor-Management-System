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
    public partial class frmCampaign : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "RexrG6OuogoAu6dghwvsZtLkCi3z5ig2NfaRtnsK",
            BasePath = "https://blood-donor-9af63-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        public frmCampaign()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmCampaign_Load(object sender, EventArgs e)
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
            catch (Exception)
            {
                MessageBox.Show("Check your connection again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
        }
        public void Clear()
        {
            txtContactNumber.Clear();
            txtDescription.Clear();
            txtOrganizedby.Clear();
            txtPlace.Clear();
            textBox1.Clear();
            dateTimePicker1.ResetText();
            dateTimePicker2.ResetText();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (txtPlace.Text != String.Empty && dateTimePicker1.Text != String.Empty)
            {
                if (MessageBox.Show("Are you sure you want to add this record?", "Insert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var data = new CampaignData
                    {
                        OrganizedBy= txtOrganizedby.Text,
                        ContactNumber = txtContactNumber.Text,
                        Place = txtPlace.Text,
                        EndDate = dateTimePicker1.Value,
                        StartDate = dateTimePicker2.Value,
                        Description = txtDescription.Text,
                    };

                    try
                    {
                        SetResponse response = await client.SetTaskAsync("Campaign/" + txtPlace.Text, data);
                        CampaignData result = response.ResultAs<CampaignData>();
                        MessageBox.Show("Your record has been successfully added!");
                        Clear();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Please check your data again!");
                    }
                }

            }
            else
            {
                MessageBox.Show("You should enter atleast your Place and Start date.");
            }
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            try
            {
                FirebaseResponse response = await client.GetTaskAsync("Campaign/" + textBox1.Text);
                {
                    CampaignData obj = response.ResultAs<CampaignData>();

                    txtPlace.Text = obj.Place;
                    txtDescription.Text = obj.Description;
                    txtOrganizedby.Text = obj.OrganizedBy;
                    txtContactNumber.Text = obj.OrganizedBy;
                    txtDescription.Text = obj.Description;
                    dateTimePicker1.Value = obj.StartDate;
                    dateTimePicker2.Value = obj.EndDate;
                    MessageBox.Show("Your result is ready");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Some error occured! Please restart the system.");
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (txtPlace.Text != String.Empty && dateTimePicker1.Text != String.Empty)
            {
                if (MessageBox.Show("Are you sure you want to add this record?", "save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    try
                    {
                        var data = new CampaignData
                        {
                            OrganizedBy = txtOrganizedby.Text,
                            ContactNumber = txtContactNumber.Text,
                            Place = txtPlace.Text,
                            EndDate = dateTimePicker1.Value,
                            StartDate = dateTimePicker2.Value,
                            Description = txtDescription.Text,
                        };


                        FirebaseResponse response = await client.UpdateTaskAsync("Campaign/" + textBox1.Text, data);
                        CampaignData result = response.ResultAs<CampaignData>();
                        MessageBox.Show("Your message has been successfully updated.");
                        Clear();
                    }
                    catch (Exception er)
                    {
                        //////MessageBox.Show("Please check your detail again.");
                        MessageBox.Show(er.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("You should enter atleast your Place and Start date.");
            }
        }
    }
}
