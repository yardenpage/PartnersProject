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

namespace PartnersMatcher
{
    /// <summary>
    /// Interaction logic for signIn.xaml
    /// </summary>
    public partial class signIn : Window
    {
        string userMail;
        string password;
        //string key - mail, string val - password
        Dictionary<string,string> users;

        public signIn()
        {
            InitializeComponent();
            userMail = "";
            password = "";
            users = new Dictionary<string, string>();
            users.Add("reut", "111");
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void sign(object sender, RoutedEventArgs e)
        {
            userMail = this.textBox.Text.Trim();
            password = this.textBox1.Text.Trim();
            if (password == "" || userMail == "")
            {
                MessageBox.Show("Missing fields", "Error");
            }
            else if(!users.ContainsKey(userMail))
            {
                MessageBox.Show("user name dosn't exist in the system", "Error");
            }
            else if(users[userMail]!= password)
            {
                MessageBox.Show("incorect password", "Error");
            }
            else
            {
                registeredUserView r = new registeredUserView();
                r.Show();
                this.Close();
            }
        }

        private void _exit(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }
    }
}
