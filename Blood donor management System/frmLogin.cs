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
    
    public partial class frmLogin : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "RexrG6OuogoAu6dghwvsZtLkCi3z5ig2NfaRtnsK",
            BasePath = "https://blood-donor-9af63-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text!=null || txtPassword.Text!=null)
            {
                try
                {
                    FirebaseResponse resp = client.Get("Users/" + txtUsername.Text);
                    MyUser ResUser = resp.ResultAs<MyUser>();

                    MyUser CurUser = new MyUser()
                    {
                        Username=txtUsername.Text,
                        Password=txtPassword.Text
                    };
                    if(MyUser.IsEqual(ResUser,CurUser))
                    {
                        frmHome frm = new frmHome();
                        frm.ShowDialog();
                        this.Hide();
                    }
                    else
                    {
                        MyUser.ShowError();
                    }
                }catch(Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
            else
            {
                MessageBox.Show("Please enter username and password!");
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
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

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmReg frm = new frmReg();
            frm.ShowDialog();
            this.Close();
        }
    }
}
