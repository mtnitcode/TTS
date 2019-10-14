using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;

namespace Sbn.Libs.TCPListener
{
    public static class TCPClient
    {
        public static string SendMessage(String server, String message , int clientPort)
        {
            try
            {
                // Create a TcpClient.
                // Note, for this client to work you need to have a TcpServer 
                // connected to the same address as specified by the server, port
                // combination.
                Int32 port = clientPort;
                TcpClient client = new TcpClient(server, port);

                // Translate the passed message into ASCII and store it as a Byte array.
                Byte[] data = System.Text.Encoding.UTF8.GetBytes(message);

                // Get a client stream for reading and writing.
                //  Stream stream = client.GetStream();

                NetworkStream stream = client.GetStream();

                // Send the message to the connected TcpServer. 
                stream.Write(data, 0, data.Length);

                //Console.WriteLine("Sent: {0}", message);

                // Receive the TcpServer.response.

                // Buffer to store the response bytes.
                data = new Byte[1024];

                // String to store the response ASCII representation.
                String responseData = String.Empty;
                try
                {
                    // Read the first batch of the TcpServer response bytes.
                    Int32 bytes = stream.Read(data, 0, data.Length);
                    responseData = System.Text.Encoding.UTF8.GetString(data, 0, bytes);
                }
                catch
                {
                }
                //this.label1.Text = "Received: {0} " + responseData;

                // Close everything.
                stream.Close();
                client.Close();

                return responseData;
            }
            catch //(ArgumentNullException e)
            {
                throw;
               // Console.WriteLine("ArgumentNullException: {0}", e);
            }

            return "";
        }

    }
}
