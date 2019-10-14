using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sbn.Controls.EventCalendar;

namespace Calendar
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Appointment App = new Appointment();
            App.StartDate = new  MyDateTime (this.faDatePicker1.SelectedDateTime);

            App.EndDate = new  MyDateTime (this.faDatePicker1.SelectedDateTime);

            App.EndDate.Hour += 1;

            App.Title = " ” ";

            
        }
    }
}