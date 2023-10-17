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

        NetworkStream stream;
        string[] words;

        Server server;
        bool awaiting_secure = false;

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

        public string API_IAmMorph() {
            if (server.morph_handler != null) {
                return "Morph exists!";
            }

            return "";
        }
        public string API_MorphSecure() {
            if (words[1] != server.secure) {
                return "Wrong secure!";
            }
            server.morph_handler = this;
            return "Confirmed!";
        }

        public string API_MorphList() {

            return "";
        }

        public string API_BroadcastMorph() {
            return "";
        }

        public string API_SendPrivate() {
            return "";
        }

        public string API_NeoRegister() {
            return "";
        }

        public void HandleConnection(Object stateInfo) {
            try {
                stream = client.GetStream();
                // send_data("Hello");
                while (true) {
                    string message = get_data();
                    string response = "";
                    words = message.Split(':');

                    if (awaiting_secure && words[0] != "MorphSecure") {
                        send_data("Awaiting secure!");
                        continue;
                    } 

                    switch (words[0]) {
                        case "IAmMorph": {
                            response = API_IAmMorph();
                            break;
                        }
                        case "MorphSecure": {
                            response = API_MorphSecure();
                            break;
                        }
                        case "MorphList": {
                            response = API_MorphList();
                            break;
                        }
                        case "BroadcastMorph": {
                            response = API_BroadcastMorph();
                            break;
                        }
                        case "SendPrivate": {
                            response = API_SendPrivate();
                            break;
                        }
                        case "NeoRegister": {
                            response = API_NeoRegister();
                            break;
                        }
                        default: {
                            response = "Wrong request!";
                            break;
                        }
                    }
                    send_data(response);
                }
            }
            catch (Exception e) {
                Console.WriteLine("Error in 'HandleConnection(Object)': " + e.Message);
            }

            server.clients.Remove(this);
        }
    }
}
