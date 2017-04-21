using Quobject.SocketIoClientDotNet.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebCrawlerProject
{
    static class Program
    {
        static Socket socket = IO.Socket("https://web-crawler-app.herokuapp.com");
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            /*socket.On(Socket.EVENT_CONNECT, () => {

            });
            checkRegistration();
            string idString = (string)Properties.Settings.Default.ID;
            //MessageBox.Show(idString);
            if (!String.IsNullOrEmpty(idString))
            {
                if (idString.Substring(0, 1) != "*")
                {
                    string id = Properties.Settings.Default.ID.ToString();
                    if (id.Contains("*") && id.Substring(id.Length - 1) == "0")
                        Application.Run(new Form1());
                    else
                        Application.Run(new Form2());
                }
            }
            else
                Application.Run(new Form2());*/
        }
        
        private static void checkRegistration()
        {
            socket.Emit("client-check-registration", (Properties.Settings.Default.ID + "*" + DateTime.Now));
            socket.On("server-reply-registration", data => {
                if (!string.IsNullOrEmpty(Properties.Settings.Default.ID.ToString()))
                {
                    Properties.Settings.Default.ID = Properties.Settings.Default.ID.ToString().Substring(0,24)+ "*" + data.ToString();
                    Properties.Settings.Default.Save();
                }

            });
        }
    }
}
