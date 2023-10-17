using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;


namespace NeoClient
{
    class Client {
        TcpClient client;
        byte[] data = null;
        NetworkStream stream;

        string ip;
        int port;
        
        public Client(string ip, int port) {
            client = new TcpClient();
            this.ip = ip;
            this.port = port;
        }

        public void HandleSession(Object stateInfo) {
            try {
                client.Connect(ip, port);
                stream = client.GetStream();
                
                while (true) {

                }
            }
            catch (Exception e) {
                
            }
        }
    }
}
