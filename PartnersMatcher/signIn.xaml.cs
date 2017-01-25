using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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

        public signIn()
        {
            InitializeComponent();
            userMail = "";
            password = "";
        }

        private void sign(object sender, RoutedEventArgs e)
        {
            userMail = this.UserNametextBox.Text;
            password = this.PasswordtextBox.Password;
            if (password == "" || userMail == "")
            {
                MessageBox.Show("Missing fields", "Error");
            }
            else if (!MainWindow.users_passwords.ContainsKey(userMail))
            {
                MessageBox.Show("User name doesn't exist in the system", "Error");
            }
            else if (MainWindow.users_passwords[userMail] != password)
            {
                MessageBox.Show("Incorect password", "Error");
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
            this.Close();
        }

        private void UserName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void Password_TextChanged(object sender, RoutedEventArgs e)
        {

        }

        private void foreget_password(object sender, RoutedEventArgs e)
        {
            userMail = this.UserNametextBox.Text;
            if (userMail == "")
            {
                MessageBox.Show("Missing user mail", "Error");
            }
            else if (!MainWindow.users_passwords.ContainsKey(userMail))
            {
                MessageBox.Show("user name dosn't exist in the system", "Error");
            }
            else
            {
                try
                {
                    SmtpClient client = new SmtpClient();
                    client.Port = 587;
                    client.Host = "smtp.gmail.com";
                    client.EnableSsl = true;
                    client.Timeout = 10000;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential("emailyad2@gmail.com", "mailyad2");

                    MailMessage mm = new MailMessage("donotreply@domain.com", userMail, "Your password to PartnersMatcher", "Your password is: " + MainWindow.users_passwords[userMail]);
                    mm.BodyEncoding = UTF8Encoding.UTF8;
                    mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                    client.Send(mm);

                    MessageBox.Show("email sended to your account", "Mail");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
