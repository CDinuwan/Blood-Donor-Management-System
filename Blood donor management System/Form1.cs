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
    public partial class Form1 : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret= "RexrG6OuogoAu6dghwvsZtLkCi3z5ig2NfaRtnsK",
            BasePath= "https://blood-donor-9af63-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        public Form1()
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
                    MessageBox.Show("Connection Established");
                }
                else
                {
                    MessageBox.Show("Check your connection again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Exit();
                }
            }
            catch(Exception er)
            {
                MessageBox.Show("Check your connection again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
            
        }
    }
}
