using System;
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
    /// Interaction logic for NewUserWindow.xaml
    /// </summary>
    public partial class NewUserWindow : Window
    {
        string userMail;
        string password1;
        string password2;

        public NewUserWindow()
        {
            InitializeComponent();
            userMail = "";
            password1 = "";
            password2 = "";
        }

        private void create(object sender, RoutedEventArgs e)
        {
            userMail = this.UserNametextBox.Text;
            password1 = this.PasswordtextBox.Password;
            password2 = this.PasswordContextBox.Password;
            if (password1 == "" || password2 == "" || userMail == "")
            {
                MessageBox.Show("Missing fields", "Error");
            }
            else if (MainWindow.users_passwords.ContainsKey(userMail))
            {
                MessageBox.Show("User Name allready exists in the system", "Error");
            }
            else if (!userMail.Contains('@'))
            {
                MessageBox.Show("User Mail is not legal", "Error");
            }
            else if(password1.Length < 8 || password2.Length < 8)
            {
                MessageBox.Show("Password is too short (need to be minimun 8 chars)", "Error");
            }
            else if (password1 != password2)
            {
                MessageBox.Show("Passwords data are not the same in the two fields", "Error");
            }         
            else
            {
                MainWindow.users_passwords.Add(userMail, password1);
                EditUserProfile r = new EditUserProfile(userMail);
                r.Show();
                this.Close();
            }
        }

        private void _exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void UserName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void Password_TextChanged(object sender, RoutedEventArgs e)
        {

        }
        private void PasswordCon_TextChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
