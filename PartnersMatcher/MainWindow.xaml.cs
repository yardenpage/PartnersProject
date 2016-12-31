using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void signIn(object sender, RoutedEventArgs e)
        {
            signIn s = new signIn();
            s.Show();
            this.Close();
        }

        private void newUser(object sender, RoutedEventArgs e)
        {
            NewUserWindow nu = new NewUserWindow();
            nu.Show();
            this.Close();
        }

        private void guest(object sender, RoutedEventArgs e)
        {
            //do nothing
        }
    }
}
