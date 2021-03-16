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
    public partial class frmReg : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "RexrG6OuogoAu6dghwvsZtLkCi3z5ig2NfaRtnsK",
            BasePath = "https://blood-donor-9af63-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        public frmReg()
        {
            InitializeComponent();
        }
        public void Clear()
        {
            txtID.Clear();
            txtPassword.Clear();
            txtUserName.Clear();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtID.Text!=null || txtUserName.Text!=null || txtPassword.Text!=null)
            {
                try
                {
                    MyUser user = new MyUser()
                    {
                        Username = txtUserName.Text,
                        Password = txtPassword.Text,
                        ID = txtID.Text
                    };

                    SetResponse set = client.Set(@"Users/" + txtUserName.Text, user);
                    MessageBox.Show("Successfully registered!");
                    Clear();
                }
                catch (Exception)
                {
                    MessageBox.Show("Check your connection and try again!");
                }
            }
            else
            {
                MessageBox.Show("Please fill all the fields!");
            }
            
        }

        private void frmReg_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(config);

                if (client != null)
                {
                    client = new FireSharp.FirebaseClient(config);
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.ShowDialog();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
