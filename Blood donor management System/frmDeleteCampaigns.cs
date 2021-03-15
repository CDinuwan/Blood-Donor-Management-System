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
using FireSharp.Interfaces;
using FireSharp.Response;

namespace Blood_donor_management_System
{
    public partial class frmDeleteCampaigns : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "RexrG6OuogoAu6dghwvsZtLkCi3z5ig2NfaRtnsK",
            BasePath = "https://blood-donor-9af63-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        public frmDeleteCampaigns()
        {
            InitializeComponent();
        }

        private async void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                if (MessageBox.Show("Are you really want to delete this record?", "Confrimation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        FirebaseResponse response = await client.DeleteTaskAsync("Campaign/" + textBox1.Text);
                        MessageBox.Show("Your record has been successfully deleted!");
                        frmCampaign frm = new frmCampaign();
                        frm.Clear();
                        this.Dispose();

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Some went wrong. Please check again your details.");
                        this.Dispose();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter your place!");
            }
            
        }

        private void frmDeleteCampaigns_Load(object sender, EventArgs e)
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            frmCampaign frm = new frmCampaign();
            frm.Clear();
        }
    }
}
