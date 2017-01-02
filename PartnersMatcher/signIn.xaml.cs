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
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                    mail.From = new MailAddress("reut.chita@gmail.com");
                    mail.To.Add(userMail);
                    mail.Subject = "Your password to PartnersMatcher";
                    mail.Body = "Your password is: " + MainWindow.users_passwords[userMail];

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("reut.chita@gmail.com", "------");
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);
                    MessageBox.Show("mail Send");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
