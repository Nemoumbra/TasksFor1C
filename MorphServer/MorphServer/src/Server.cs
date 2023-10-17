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
        public string secure;

        public ClientHandler morph_handler;
        public List<ClientHandler> clients;

        public Server(string ip, int port, string secure) {
            try {
                this.secure = secure;
                server = new TcpListener(IPAddress.Parse(ip), port);
                server.Start();
                clients = new List<ClientHandler>();
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
                        clients.Add(client);
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
