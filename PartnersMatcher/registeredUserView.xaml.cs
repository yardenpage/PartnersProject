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
using System.Windows.Shapes;

namespace PartnersMatcher
{
    /// <summary>
    /// Interaction logic for registeredUserView.xaml
    /// </summary>
    public partial class registeredUserView : Window
    {
        ObservableCollection<Post> l;
        public registeredUserView()
        {
            DataContext = this; 
            InitializeComponent();
            l = new ObservableCollection<Post>();
            l.Add(new Post("title1", "1", "reut1"));
            l.Add(new Post("title2", "2", "yarden1"));
            posts.ItemsSource = l;           
        }

        private void _exit(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }
    }
}
