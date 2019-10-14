using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace Sbn.Libs.TCPListener
{
    public delegate void FireReceived(string data);

    public static class TCPListener
    {
        public static string _ServerIPAddress = "";
        public static string _ReceivedData = "";
        static Thread _thread = null;
        public static string _ClientName = "";
        public static event FireReceived ReceivedData;
        private static bool _IsVisibleForAll = false;
        public static void StartListener(string ServerIPAddress , int clientPort , bool IsVisibleForAll = true)
        {
            try
            {
                _IsVisibleForAll = IsVisibleForAll;

                _ServerIPAddress = ServerIPAddress;
                _thread = new Thread(new ParameterizedThreadStart(SbnListener));
                _thread.SetApartmentState(ApartmentState.STA);
                _thread.Start(clientPort);
            }
            catch
            {
                throw;
            }

        }

        public static void StopListener(string ServerIPAddress)
        {
            _thread.Abort();

            try
            {
                server.Stop();

            }
            catch
            {

            }
        }

        static TcpListener server = null;
        static void SbnListener(object clientPort)
        {
            try
            {
                // Set the TcpListener on port 13000.
                Int32 port = (int)clientPort;
                IPAddress localAddr = IPAddress.Parse(_ServerIPAddress);

                // TcpListener server = new TcpListener(port);
                server = new TcpListener(localAddr, port);

                // Start listening for client requests.
                server.Start();

                // Buffer for reading data
                Byte[] bytes = new Byte[1024];
                String data = null;

                // Enter the listening loop.
                while (true)
                {
                    //                    label3.Text = "Waiting for a connection... ";
                    TcpClient client = server.AcceptTcpClient();

                    try
                    {
                        // Perform a blocking call to accept requests.
                        // You could also user server.AcceptSocket() here.
                        //                  label1.Text = "Connected!";

                        data = null;

                        // Get a stream object for reading and writing
                        NetworkStream stream = client.GetStream();

                        int i;

                        // Loop to receive all the data sent by the client.
                        while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            try
                            {
                                // Translate data bytes to a ASCII string.
                                data = System.Text.Encoding.UTF8.GetString(bytes, 0, i);
                                //                    label2.Text = "Received: {0}" + data;

                                // Process the data sent by the client.
                                //data = data.ToUpper();

                                _ReceivedData = data;

                                byte[] msg = System.Text.Encoding.ASCII.GetBytes("OK");

                                //Byte[] data = System.Text.Encoding.UTF8.GetBytes(message);
                                if (data == "Alive?" && _IsVisibleForAll)
                                    msg = System.Text.Encoding.UTF8.GetBytes("?Alive;#;" + _ClientName);

                                // Send back a response.
                                stream.Write(msg, 0, msg.Length);
                                //Console.WriteLine("Sent: {0}", data);

                                if (data != "Alive?")
                                    ReceivedData(_ReceivedData);

                            }
                            catch
                            {

                            }

                        }

                        // Shutdown and end connection
                        client.Close();
                    }
                    catch
                    {
                        if (client != null) client.Close();
                    }
                }
            }
            catch 
            {
                //throw ;
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
            }

        }


    }
}
