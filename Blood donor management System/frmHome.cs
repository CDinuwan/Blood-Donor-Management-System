using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blood_donor_management_System
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmInsert frm = new frmInsert();
            frm.TopLevel=false;
            panel2.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmCampaign frm = new frmCampaign();
            frm.TopLevel = false;
            panel2.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            frmBloodRequests frm = new frmBloodRequests();
            frm.TopLevel = false;
            panel2.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }
    }
}
