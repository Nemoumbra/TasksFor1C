using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace MorphServer {
    class Server {
        public TcpListener server;

        public Server(string ip, int port) {
            try {
                server = new TcpListener(IPAddress.Parse(ip), port);
                server.Start();
                Console.WriteLine("Server running");
            }
            catch (Exception exept) {
                Console.WriteLine("Error in 'Server()': " + exept.Message);
            }
        }

        public void Run() {
            Thread server_thread = new Thread(this.HandleConnections);
            server_thread.Start();
        }

        public void HandleConnections() {
            Console.WriteLine("'HandleConnections()' started!");

            while (true) {
                try {
                    if (server.Pending()) {
                        ClientHandler client = new ClientHandler(this);
                        ThreadPool.QueueUserWorkItem(client.HandleConnection);
                    }

                    Thread.Sleep(30);
                }
                catch (Exception exept) {
                    Console.WriteLine("Error in 'void HandleConnections()': " + exept.Message);
                }
            }

        }
    }
}
