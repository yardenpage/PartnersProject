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
        ObservableCollection<Post> l_const; //always contains all posts
        ObservableCollection<Post> l_view; //posts to show
        List<string> location;
        string chooseD;
        string chooseL;

        public registeredUserView()
        {
            DataContext = this; 
            InitializeComponent();
            chooseD = "";
            chooseL = "";
            location = new List<string>();
            location.Add("South");
            location.Add("North");
            location.Add("Center");
            location.Add("All");
            l_const = new ObservableCollection<Post>();
            l_const.Add(new Post("I wan't you to basketball team!", "Center", "Sports"));
            l_const.Add(new Post("Needed Partner to Beer Sheva Immidiatly", "South", "Accomodation"));
            l_view = new ObservableCollection<Post>(l_const);
            posts.ItemsSource = l_view;
            domains_combo.ItemsSource = MainWindow.domains;
            location_combo.ItemsSource = location;
        }

        private void _exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void domain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            chooseD = domains_combo.SelectedItem.ToString();
            l_view.Clear();
            if (chooseD == "All" && (chooseL=="All" || chooseL==""))
            {
                foreach(Post p in l_const)
                {
                    l_view.Add(p);
                }
            }
            else
            {
                foreach (Post p in l_const)
                {
                    if(chooseL=="" || chooseL=="All")
                    {
                        if (p.Domain == chooseD)
                            l_view.Add(p);
                    }
                    else if (p.Domain == chooseD && p.Location==chooseL)
                        l_view.Add(p);
                    else if(chooseD=="All" && p.Location==chooseL)
                        l_view.Add(p);
                }
            }        
        }

        private void location_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            chooseL = location_combo.SelectedItem.ToString();
            l_view.Clear();
            if (chooseL == "All" && (chooseD == "All" || chooseD == ""))
            {
                foreach (Post p in l_const)
                {
                    l_view.Add(p);
                }
            }
            else
            {
                foreach (Post p in l_const)
                {
                    if (chooseD == "" || chooseD == "All")
                    {
                        if (p.Location == chooseL)
                            l_view.Add(p);
                    }
                    else if (p.Domain == chooseD && p.Location == chooseL)
                        l_view.Add(p);
                    else if (chooseL == "All" && p.Domain == chooseD)
                        l_view.Add(p);
                }
            }
        }
    }
}
