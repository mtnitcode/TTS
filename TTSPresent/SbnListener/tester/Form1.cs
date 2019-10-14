using Sbn.Libs.TCPListener;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace tester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {

                TCPListener.ReceivedData += TCPListener_ReceivedData;

                System.Net.DnsPermission per = new System.Net.DnsPermission(System.Security.Permissions.PermissionState.Unrestricted);

                System.Net.IPAddress[] ips = System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName());

                if (ips.Length >1)
                    TCPListener.StartListener(ips[1].ToString() , 2000 );
                else
                    TCPListener.StartListener(ips[0].ToString() , 2000);
            }
            catch(Exception ex)

            {

            }
        }

        void TCPListener_ReceivedData(string data)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                TCPClient.SendMessage("10.0.142.62", "تست" , 2000);
            }
            catch (Exception ex)
            {

            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            TCPListener.StopListener("192.168.1.43");
        }
    }
}