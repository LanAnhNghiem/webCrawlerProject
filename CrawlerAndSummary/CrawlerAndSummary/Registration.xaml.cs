﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Quobject.SocketIoClientDotNet.Client;
using System.Text.RegularExpressions;
using System.Xml;

namespace CrawlerAndSummary
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        private string checkemail;
        private string enteremail;
        private string enterday;
        private string validemail;
        private string invalidemail;
        private string validday;
        private string invalidday;
        private string validkey;
        private string invalidkey;
        Socket socket = IO.Socket("https://web-crawler-app.herokuapp.com");
        public Registration()
        {
            InitializeComponent();
            socketIOManager();
            readXml();
        }

        private void readXml()
        {
            XmlTextReader xmledit = new XmlTextReader("ThamSoEdit.xml");

            while (xmledit.Read())
            {
                if (xmledit.Name == "checkemail")
                {
                    checkemail = xmledit.ReadElementContentAsString();
                }
                if (xmledit.Name == "enteremail")
                {
                    enteremail = xmledit.ReadElementContentAsString(); ;
                }

                if (xmledit.Name == "enterday")
                {
                    enterday = xmledit.ReadElementContentAsString();
                }
                if (xmledit.Name == "validemail")
                {
                    validemail = xmledit.ReadElementContentAsString(); ;
                }
                if (xmledit.Name == "invalidemail")
                {
                    invalidemail = xmledit.ReadElementContentAsString();

                }
                if (xmledit.Name == "validday")
                {
                    validday = xmledit.ReadElementContentAsString();
                }
                if (xmledit.Name == "invalidday")
                {
                    invalidday = xmledit.ReadElementContentAsString();
                }
                if (xmledit.Name == "validkey")
                {
                    validkey = xmledit.ReadElementContentAsString();
                }
                if (xmledit.Name == "invalidkey")
                {
                    invalidkey = xmledit.ReadElementContentAsString();
                }
            }
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
            //hardcode regular exception
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
            //hardcode
            Regex regex = new Regex("^[1-9]\\d*$");
            Match match = regex.Match(day);
            if (match.Success)
                return true;
            else
                return false;
        }

        private void getKeyBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(emailTxtBox.Text) && isValidEmail(emailTxtBox.Text) &&
                !string.IsNullOrWhiteSpace(daysTxtBox.Text) && isValidDay(daysTxtBox.Text))
            {
                //hardcode "Please check your email to get Your Serial Key."
                MessageBox.Show(checkemail);
                sendInfo();
                socket.On("server-send-client-id", data =>
                {
                    Properties.Settings.Default.ID = (string)data;
                    Properties.Settings.Default.Save();
                    //MessageBox.Show((string)Properties.Settings.Default.ID);
                });
                getKeyBtn.IsEnabled = false;
            }
            else
            {
                //hardcode chuỗi
                //emailLb.Content = "Enter your email.";
                //daysLb.Content = "Enter trial days";
                emailLb.Content = enteremail;
                daysLb.Content = enterday;

            }
        }
        private void sendInfo()
        {
            string infoPC = cpuId() + biosId() + baseId();
            socket.Emit("client-send-PC-info", (infoPC));
            string info = emailTxtBox.Text + "*" + daysTxtBox.Text + "*" + DateTime.Now + "*" + DateTime.Now.AddDays(int.Parse(daysTxtBox.Text));
            socket.Emit("client-send-email-days", (info));
        }

        private void emailTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //hardcode chuỗi
            if (isValidEmail(emailTxtBox.Text))
            {
                //    emailLb.Content = "Valid Email";
                emailLb.Content = validemail;
            }
            else
            {
                // emailLb.Content = "Invalid Email";
                emailLb.Content = invalidemail;
            }
        }

        private void daysTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //hardcode chuỗi
            if (!isValidDay(daysTxtBox.Text))
            {
                //  daysLb.Content = "Day only contains number from 1 to 99";
                daysLb.Content = validday;
            }
            else
            {
                //   daysLb.Content = "Valid Day";
                daysLb.Content = invalidday;
            }
        }

        private void registerBtn_Click(object sender, RoutedEventArgs e)
        {
            string dataString = "";
            if (!string.IsNullOrEmpty((string)Properties.Settings.Default.ID) && !string.IsNullOrWhiteSpace(keyTxtBox.Text.Trim()))
            {
                socket.Emit("check-valid-key", (keyTxtBox.Text.Trim() + "*" + Properties.Settings.Default.ID));
                socket.On("check-valid-key-result", data => {
                    dataString = data.ToString();
                });
                //hardcode chuỗi
                if (dataString == "0")
                {
                    //   keyLb.Content = "Invalid Serial Key.";
                    keyLb.Content = invalidkey;
                }
                else
                {
                    //   keyLb.Content = "Valid Serial Key.";
                    keyLb.Content = validkey;
                    this.Hide();
                    MainWindow main = new MainWindow();
                    main.Show();
                    this.Close();
                }
            }
            else
                //  keyLb.Content = "Invalid Serial Key.";
                keyLb.Content = invalidkey;
        }
        
    }
}
