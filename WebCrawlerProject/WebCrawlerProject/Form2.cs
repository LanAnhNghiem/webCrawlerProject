using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Quobject.SocketIoClientDotNet.Client;
using System.Management;
using System.Text.RegularExpressions;

namespace WebCrawlerProject
{
    public partial class Form2 : Form
    {
        Socket socket = IO.Socket("https://web-crawler-app.herokuapp.com");
        public Form2()
        {
            InitializeComponent();
            //socketIOManager();
        }
        private void socketIOManager()
        {
            socket.On(Socket.EVENT_CONNECT, () => {

            });
        }

        #region Original Device ID Getting Code
        //Return a hardware identifier
        private string identifier
        (string wmiClass, string wmiProperty, string wmiMustBeTrue)
        {
            string result = "";
            System.Management.ManagementClass mc =
        new System.Management.ManagementClass(wmiClass);
            System.Management.ManagementObjectCollection moc = mc.GetInstances();
            foreach (System.Management.ManagementObject mo in moc)
            {
                if (mo[wmiMustBeTrue].ToString() == "True")
                {
                    //Only get the first one
                    if (result == "")
                    {
                        try
                        {
                            result = mo[wmiProperty].ToString();
                            break;
                        }
                        catch
                        {
                        }
                    }
                }
            }
            return result;
        }
        //Return a hardware identifier
        private string identifier(string wmiClass, string wmiProperty)
        {
            string result = "";
            System.Management.ManagementClass mc =
        new System.Management.ManagementClass(wmiClass);
            System.Management.ManagementObjectCollection moc = mc.GetInstances();
            foreach (System.Management.ManagementObject mo in moc)
            {
                //Only get the first one
                if (result == "")
                {
                    try
                    {
                        result = mo[wmiProperty].ToString();
                        break;
                    }
                    catch
                    {
                    }
                }
            }
            return result;
        }
        private string cpuId()
        {
            //Uses first CPU identifier available in order of preference
            //Don't get all identifiers, as it is very time consuming
            string retVal = identifier("Win32_Processor", "UniqueId");
            if (retVal == "") //If no UniqueID, use ProcessorID
            {
                retVal = identifier("Win32_Processor", "ProcessorId");
                if (retVal == "") //If no ProcessorId, use Name
                {
                    retVal = identifier("Win32_Processor", "Name");
                    if (retVal == "") //If no Name, use Manufacturer
                    {
                        retVal = identifier("Win32_Processor", "Manufacturer");
                    }
                    //Add clock speed for extra security
                    retVal += identifier("Win32_Processor", "MaxClockSpeed");
                }
            }
            return retVal;
        }
        //BIOS Identifier
        private string biosId()
        {
            return identifier("Win32_BIOS", "Manufacturer")
            + identifier("Win32_BIOS", "SMBIOSBIOSVersion")
            + identifier("Win32_BIOS", "IdentificationCode")
            + identifier("Win32_BIOS", "SerialNumber")
            + identifier("Win32_BIOS", "ReleaseDate")
            + identifier("Win32_BIOS", "Version");
        }
        //Main physical hard drive ID
        private string diskId()
        {
            return identifier("Win32_DiskDrive", "Model")
            + identifier("Win32_DiskDrive", "Manufacturer")
            + identifier("Win32_DiskDrive", "Signature")
            + identifier("Win32_DiskDrive", "TotalHeads");
        }
        //Motherboard ID
        private string baseId()
        {
            return identifier("Win32_BaseBoard", "Model")
            + identifier("Win32_BaseBoard", "Manufacturer")
            + identifier("Win32_BaseBoard", "Name")
            + identifier("Win32_BaseBoard", "SerialNumber");
        }
        #endregion
        private bool isValidEmail(string email)
        {
            Regex regex = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                    + "@"
                                    + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");
            Match match = regex.Match(email);
            if (match.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
      
        private bool isValidDay(string day)
        {
            Regex regex = new Regex("^[1-9]\\d*$");
            Match match = regex.Match(day);
            if (match.Success)
                return true;
            else
                return false;
        }

        private void getKeyBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(emailTxt.Text) && isValidEmail(emailTxt.Text) &&
                !string.IsNullOrWhiteSpace(daysTxt.Text) && isValidDay(daysTxt.Text))
            {
                MessageBox.Show("Please check your email to get Your Serial Key.");
                sendInfo();
                socket.On("server-send-client-id", data =>
                {
                    Properties.Settings.Default.ID = data;
                    Properties.Settings.Default.Save();
                    //MessageBox.Show((string)Properties.Settings.Default.ID);
                });
                getKeyBtn.Enabled = false;
            }
            else
            {
                emailLb.Text = "Enter your email.";
                dayLb.Text = "Enter trial days";
            }
        }
        private void sendInfo()
        {
            string infoPC = cpuId() + biosId() + baseId();
            socket.Emit("client-send-PC-info", (infoPC));
            string info = emailTxt.Text +"*" +daysTxt.Text + "*"+DateTime.Now+"*"+DateTime.Now.AddDays(int.Parse(daysTxt.Text));
            socket.Emit("client-send-email-days", (info));
        }
        private void emailTxt_TextChanged(object sender, EventArgs e)
        {
            if (isValidEmail(emailTxt.Text))
            {
                emailLb.Text = "Valid Email";
            }
            else
            {
                emailLb.Text = "Invalid Email";
            }
        }

        private void daysTxt_TextChanged(object sender, EventArgs e)
        {
            if (!isValidDay(daysTxt.Text))
            {
                dayLb.Text = "Day only contains number from 1 to 99";
            }
            else
            {
                dayLb.Text = "Valid Day";
            }
        }

        private void keyTxt_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            string dataString = "";
            if (!string.IsNullOrEmpty((string)Properties.Settings.Default.ID) && !string.IsNullOrWhiteSpace(keyTxt.Text))
            {
                socket.Emit("check-valid-key", (keyTxt.Text + "*" + Properties.Settings.Default.ID));
                socket.On("check-valid-key-result", data => {
                    dataString = data.ToString();
                });
                if (dataString == "0")
                {
                    keyLb.Text = "Invalid Serial Key.";
                }
                else
                {
                    keyLb.Text = "Valid Serial Key.";
                    this.Hide();
                    Form1 form1 = new Form1();
                    form1.ShowDialog();
                    this.Close();
                }
            }
            else
                keyLb.Text = "Invalid Serial Key.";
        }

        private void checkRegistration()
        {
            socket.Emit("client-check-registration", (Properties.Settings.Default.ID + "*" + DateTime.Now));
            socket.On("server-reply-registration", data => {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.ID.ToString()))
            {
                Properties.Settings.Default.ID = Properties.Settings.Default.ID +"*" + data.ToString();
                Properties.Settings.Default.Save();
            }
                
            });
        }
    }
}
