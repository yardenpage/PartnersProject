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
        ObservableCollection<Post> l;
        public MainWindow()
        {
            InitializeComponent();
            l = new ObservableCollection<Post>();
            l.Add(new Post("title1", "1", "reut1"));
            l.Add(new Post("title2", "2", "yarden1"));
            posts.ItemsSource = l;
        }

        private void posts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void signIn(object sender, RoutedEventArgs e)
        {

        }

        private void newUser(object sender, RoutedEventArgs e)
        {

        }
    }
}
