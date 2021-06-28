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
    public partial class frmBloodRequests : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "RexrG6OuogoAu6dghwvsZtLkCi3z5ig2NfaRtnsK",
            BasePath = "https://blood-donor-9af63-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        public frmBloodRequests()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void Clear()
        {
            txtRequestID.Clear();
            txtPlace.Clear();
            txtName.Clear();
            txtContactNumber.Clear();
            txtAge.Clear();
            cboBoodGroup.ResetText();
            cboEmergencyState.ResetText();
            cboSex.ResetText();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
