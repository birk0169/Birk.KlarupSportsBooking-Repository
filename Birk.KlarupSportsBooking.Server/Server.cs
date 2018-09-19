using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Birk.KlarupSportsBooking.BIZ;

namespace Birk.KlarupSportsBooking.Server
{
    class Server
    {
        /// <summary>
        /// The TcpListener used to recieve the clients
        /// </summary>
        private TcpListener listener { get; }

        /// <summary>
        /// The IP Address of the server
        /// </summary>
        public IPAddress ServerIpAddress { get; }

        /// <summary>
        /// The constructor initializes the IP Address and the PcpListener.
        /// Uses either local IP Address, or the IPv4 Address of the computer.
        /// </summary>
        /// <param name="port">Which port to be used</param>
        /// <param name="useLocal">Optional, is true by default</param>
        public Server(int port, bool useLocal = true)
        {
            if (useLocal)
            {
                ServerIpAddress = IPAddress.Parse("127.0.0.1");
            }
            else
            {
                var hostName = Dns.GetHostName();
                var ipAddresses = Dns.GetHostAddresses(hostName);
                ServerIpAddress = ipAddresses.Where(ip => ip.AddressFamily == AddressFamily.InterNetwork).FirstOrDefault();
            }

            if (ServerIpAddress == null)
            {
                throw new NullReferenceException("No IPv4 address for the server");
            }

            listener = new TcpListener(ServerIpAddress, port);
        }

        /// <summary>
        /// This method starts the server listing for a client.
        /// It recieves the request, handles it, and returns the response.
        /// It runs in an infinite loop.
        /// </summary>
        public void Start()
        {
            listener.Start();

            while (true)
            {
                try
                {
                    using (TcpClient client = listener.AcceptTcpClient())
                    using (NetworkStream ns = client.GetStream())
                    using (StreamWriter writer = new StreamWriter(ns))
                    using (StreamReader reader = new StreamReader(ns))
                    {
                        writer.AutoFlush = true;

                        string request = reader.ReadLine();
                        string response = Handle(request);

                        writer.WriteLine(response);
                    }
                }
                catch (IOException ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// Method used to handle the request from the client
        /// </summary>
        /// <param name="request">The request from the client</param>
        /// <returns>
        /// Returns the response to the client,
        /// </returns>
        private string Handle(string request)
        {
            var splittedRequest = request.Split(',');
            bool isValid = VerifyRequest(splittedRequest);

            string response = "";

            

            if (isValid)
            {
                switch (int.Parse(splittedRequest[0]))
                {
                    
                    default:
                        response = "Error, wrong method call";
                        break;
                }
            }
            else
            {
                response = "Error, input needs to be an int";
            }

            return response;
        }


        /// <summary>
        /// Method used to validate the request.
        /// </summary>
        /// <param name="splittedRequest">The splitted CSV request</param>
        /// <returns>
        /// Returns true if valid
        /// </returns>
        private bool VerifyRequest(string[] splittedRequest)
        {
            foreach (string item in splittedRequest)
            {
                if (!int.TryParse(item, out int value))
                {
                    return false;
                }
            }
            return true;

        }
    }
}
