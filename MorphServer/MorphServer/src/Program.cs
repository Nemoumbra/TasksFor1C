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
    
    class Program {
        private static Server server;
        public static string IP = "", port = "";

        static void collect_ip_and_port() {
            Console.WriteLine("Please enter the IP address or press enter to skip this step");
            IP = Console.ReadLine();
            if (IP.Equals("")) {
                IP = "127.0.0.1";
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
            }
            Console.WriteLine("Now enter the port or press enter to skip this step");
            port = Console.ReadLine();
            if (port.Equals("")) {
                port = "8888";
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
            }
        }

        static void parse_config_file() {
            Console.WriteLine("Parsed config file...");
        }


        static void Main(string[] args) {
            Console.WriteLine("MorphServer running...");
            // parse_config_file();
            collect_ip_and_port();

            server = new Server(IP, Convert.ToInt32(port));
            server.Run();
        }
    }
}
