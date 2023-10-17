using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace MorphServer {

    class ClientHandler {
        public TcpClient client;

        int timeout;
        string[] words;
        NetworkStream stream;

        Server server;

        public ClientHandler(Server server_ref) {
            server = server_ref;
            client = server.server.AcceptTcpClient();
            Console.WriteLine("ClientHandler inited!");
        }

        public void send_data(string message) {
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            stream.Write(buffer, 0, buffer.Length);
        }

        public string get_data() {
            string message = "";
            byte[] data = new byte[256];
            do {
                int bytes = stream.Read(data, 0, data.Length);
                message += Encoding.UTF8.GetString(data, 0, bytes);
            }
            while (stream.DataAvailable);
            return message;
        }

        public void HandleConnection(Object stateInfo) {
            try {
                stream = client.GetStream();
                send_data("Hello");

            }
            catch (Exception e) {
                Console.WriteLine("Error in 'HandleConnection(Object)': " + e.Message);
            }
        }
    }
}
