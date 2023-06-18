using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace MiniProject
{
    public partial class Booking : Form
    {
        public Booking()
        {
            InitializeComponent();
        }

        private void makeABookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //local variables
            string strEvent;
            int intNumPeople;
            DateTime dtDate;
            bool blnValid;
            string strCity;

            //extract details from components
            strEvent = cboEvent.Text;
            intNumPeople = Convert.ToInt32(numericUpDown1.Value);
            dtDate = dateTimePicker1.Value.Date;

            if (radioButton1.Checked)
            {
                strCity = "Johannesburg";

            }else if (radioButton2.Checked)
            {
                strCity = "Cape Town";
            }
            else
            {
                strCity = "Durban";
            }

            //validate details
            blnValid = true;
            blnValid = Validate(blnValid, strEvent, intNumPeople, dtDate);
            if (blnValid == true)
            {
                //get price of tickets
                double dblPrice = 0;
                dblPrice = calculate(dblPrice, intNumPeople, strEvent);
                //display output
                DisplayOutput(dblPrice, dtDate, strEvent, intNumPeople, strCity);
            }
        }
            private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //clearing the lables
            lblBooked.Text = string.Empty;
            lblPrice.Text = string.Empty;

            //unchecking components
            checkBox1.Checked= false;
            checkBox2.Checked= false;

            //unselecting radio buttons
            radioButton1.Checked= false;
            radioButton2.Checked= false;
            radioButton3.Checked= false;
            radioButton4.Checked= false;
            radioButton5.Checked= false;
            radioButton6.Checked= false;

            numericUpDown1.Value = 0;
            cboEvent.Text = string.Empty;

        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm frmLogin = new LoginForm();
            this.Visible = false;
            frmLogin.ShowDialog();
        }

        private void Booking_Load(object sender, EventArgs e)
        {
            int intEventCount;
            for (intEventCount = 0; intEventCount < BookingArrayClass.EventName.Length; ++intEventCount)
            {
                cboEvent.Items.Add(BookingArrayClass.EventName[intEventCount]);
            }

        }
        private bool Validate(bool blnValid, string strEvent, int intNumPeople, DateTime dtDate)
        {
            bool blnFound = false;
            for (int i = 0; i < 3; i++)
            {
                if (strEvent == BookingArrayClass.EventName[i])
                {
                    blnFound = true;
                }
            }
            if (blnFound == false)
            {
                blnValid = false;
                MessageBox.Show("Invalid Event selected");
            }
            //checking if invalid number of people
            if (intNumPeople < 1)
            {
                blnValid = false;
                MessageBox.Show("Invalid number of people selected");
            }
            if ((dateTimePicker1.Value - DateTime.Today.Date).TotalDays < 7)
            {
                blnValid = false;
                MessageBox.Show("Date selected must be 7 days from current date");
            }
            if(radioButton1.Checked==false && radioButton2.Checked == false && radioButton3.Checked == false)
            {
                blnValid = false;
                MessageBox.Show("Please select a City");
            }
            if(radioButton4.Checked == false && radioButton5.Checked== false && radioButton6.Checked == false)
            {
                blnValid = false;
                MessageBox.Show("Please select a seating option");
            }
            return blnValid;
        }
        private double calculate(double dblPrice, int intNumPeople, string strEvent)
        {
            int intIndex = cboEvent.Items.IndexOf(strEvent);
            double vipPrice = BookingArrayClass.VIPPrice[intIndex];
            
            if(radioButton5.Checked == true)
            {
                dblPrice = vipPrice * 0.8 * intNumPeople;

            }else if(radioButton6.Checked == true)
            {
                dblPrice = vipPrice * 0.75 * intNumPeople;
            }
            else
            {
                dblPrice = vipPrice * intNumPeople;
            }
            if (checkBox1.Checked)
            {
                dblPrice += 100;
                if (checkBox2.Checked) {
                    dblPrice += 1000;
                }
            }else if (checkBox2.Checked)
            {
                dblPrice += 1000;
            }

            return dblPrice;
        }
        private void DisplayOutput(double dblPrice, DateTime dtDate, string strEvent, int intNumPeople,string strCity)
        {
            string n = Convert.ToString(intNumPeople);
            string strPrice = dblPrice.ToString();
            string strDate = dtDate.ToString("dddd dd MMMM yyyy");
            lblBooked.Text = "You have booked " + n + " ticket(s) for " + strEvent + " on " + strDate + " in "+strCity;
            lblPrice.Text = "The cost will be R" + strPrice;
            
        }
    }
}
