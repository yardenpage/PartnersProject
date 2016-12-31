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
        //string key - mail, string val - password
        Dictionary<string, string> users;
        public NewUserWindow()
        {
            InitializeComponent();
            userMail = "";
            password1 = "";
            password2 = "";
            users = new Dictionary<string, string>();
        }

        private void create(object sender, RoutedEventArgs e)
        {
            userMail = this.textBox.Text.Trim();
            password1 = this.textBox1.Text.Trim();
            password2 = this.textBox2.Text.Trim();
            if (password1 == "" || password2 == "" || userMail == "")
            {
                MessageBox.Show("Missing fields", "Error");
            }
            else if (users.ContainsKey(userMail))
            {
                MessageBox.Show("User Name allready exists in the system", "Error");
            }
            else if (password1 != password2)
            {
                MessageBox.Show("Passwords data are not the same in the two fields", "Error");
            }         
            else
            {
                users.Add(userMail, password1);
                MessageBox.Show("User had been added succefully", "OK");
                registeredUserView r = new registeredUserView();
                r.Show();
                this.Close();
            }
        }
    }
}
