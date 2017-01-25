using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PartnersMatcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Dictionary<string, string> users_passwords;
        public static Dictionary<string, User> all_users;
        public static HashSet<string> domains;
        
        //DB
        BinaryWriter bw_passW;
        BinaryWriter usersW;
        BinaryReader bw_passR;
        BinaryReader usersR;

        public MainWindow()
        {
            InitializeComponent();
            //string key - mail, string val - password
            users_passwords = new Dictionary<string, string>();
            all_users = new Dictionary<string, User>();
            domains = new HashSet<string>();
            domains.Add("Accomodation");
            domains.Add("Sports");
            domains.Add("Dates");
            domains.Add("Trip");
            domains.Add("All");
            //DB
            OpenDBFilesRead();
            string readLine;
            Dictionary<string,string> serialize;
            while ((bw_passR.BaseStream.Position != bw_passR.BaseStream.Length))
            {
                readLine = bw_passR.ReadString();
                serialize = JsonConvert.DeserializeObject<Dictionary<string, string>>(readLine);
                foreach (var v in serialize)
                {
                    users_passwords.Add(v.Key, v.Value);
                }
            }
            /*
            Dictionary<string, User> serialize2;
            while ((usersR.BaseStream.Position != usersR.BaseStream.Length))
            {
                readLine = usersR.ReadString();
                serialize2 = JsonConvert.DeserializeObject<Dictionary<string, User>>(readLine);
                foreach (var v in serialize2)
                {
                    all_users.Add(v.Key, v.Value);
                }
            }*/
            CloseDBFilesRead();
        }

        private void signIn(object sender, RoutedEventArgs e)
        {
            signIn s = new signIn();
            s.Show();
        }

        private void newUser(object sender, RoutedEventArgs e)
        {
            NewUserWindow nu = new NewUserWindow();
            nu.Show();
        }

        private void guest(object sender, RoutedEventArgs e)
        {
            registeredUserView ru = new registeredUserView();
            ru.Show();
        }

        private void OpenDBFilesWrite()
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            Directory.CreateDirectory(path + @"\nituz");
            bw_passW = new BinaryWriter(File.Open(path + @"\nituz\UsersPass.bin", FileMode.OpenOrCreate));
            usersW = new BinaryWriter(File.Open(path + @"\nituz\AllUsers.bin", FileMode.OpenOrCreate));
        }

        private void OpenDBFilesRead()
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            Directory.CreateDirectory(path + @"\nituz");
            bw_passR = new BinaryReader(File.Open(path + @"\nituz\UsersPass.bin", FileMode.OpenOrCreate));
            usersR = new BinaryReader(File.Open(path + @"\nituz\AllUsers.bin", FileMode.OpenOrCreate));
        }

        private void CloseDBFilesWrite()
        {
            bw_passW.Flush();
            bw_passW.Close();
            bw_passW.Dispose();
            usersW.Flush();
            usersW.Close();
            usersW.Dispose();
        }

        private void CloseDBFilesRead()
        {
            bw_passR.Close();
            bw_passR.Dispose();
            usersR.Close();
            usersR.Dispose();
        }

        private void close_click(object sender, EventArgs e)
        {
            OpenDBFilesWrite();
            string JsonPassDic = JsonConvert.SerializeObject(users_passwords);
            foreach(var v in all_users)
            {
                v.Value.ToStringAllDomains();
                v.Value.domains.Clear();
            }
            string JsonUsersDic = JsonConvert.SerializeObject(all_users);
            bw_passW.Write(JsonPassDic);
            usersW.Write(JsonUsersDic);
            CloseDBFilesWrite();
            this.Close();
        }
    }
}
