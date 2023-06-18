using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniProject
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        //Global variables and constants
        string strAdminPassword = "Admin1";
        string strFanPassword = "Fan1";
        int intCounter = 0;
        private bool Validate(bool blnValid, string strUser, string strPassword)
        {
            if (strUser != "Admin" && strUser != "Fan")
            {
                blnValid = false;
                MessageBox.Show("Invalid user selected");
            }
            if ((strUser == "Admin" && strPassword != strAdminPassword) || (strUser == "Fan" && strPassword != strFanPassword))
            {
                blnValid = false;
                MessageBox.Show("Incorrect password!");
                intCounter++;
                if (intCounter == 3)
                {
                    MessageBox.Show("Password entered incorrectly too many times. Closing application...");
                    Application.Exit();
                }
            }


            return blnValid;
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //local variables
            string strUser, strPassword;
            bool blnValid;

            //get input
            strUser = cbLoginID.Text;
            strPassword = tbPassword.Text;

            //validate input
            blnValid = true;
            blnValid = Validate(blnValid, strUser, strPassword);

            //if it is valid
            if (blnValid == true)
            {
                //reset counter
                intCounter = 0;
                if (strUser == "Admin")
                {
                    Admin frmAdmin = new Admin();
                    this.Visible = false;
                    frmAdmin.ShowDialog();
                }
                else
                {
                    Booking frmBooking = new Booking();
                    this.Visible = false;
                    frmBooking.ShowDialog();
                }

            }

        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cbLoginID.Text = "";
            tbPassword.Text = "";
            cbLoginID.Focus();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
