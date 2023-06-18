using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace MiniProject
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string[] NewEventName = new string[3];
            double[] NewVIPPrice = new double[3];
            
            object myValue;
            
            for (int intEventCount = 0; intEventCount<3; intEventCount++)
            {
                myValue = Interaction.InputBox("Please enter the event name", "Event Input");
                NewEventName[intEventCount] = myValue.ToString();
                myValue = Interaction.InputBox("Please enter VIP price", "Price Input");
                NewVIPPrice[intEventCount] = Convert.ToDouble(myValue);
            }
            BookingArrayClass.EventName = NewEventName;
            BookingArrayClass.VIPPrice = NewVIPPrice;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoginForm frmLogin = new LoginForm();
            this.Visible = false;
            frmLogin.ShowDialog();
        }
    }
}
