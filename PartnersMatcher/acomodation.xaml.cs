using PartnersMatcher.Model.Domains;
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
    /// Interaction logic for acomodation.xaml
    /// </summary>
    public partial class acomodation : Window
    {
        List<string> opt;//options for combobox:Owner,partner..--Role
        List<string> yesNo;////options for combobox: is Smoking?
        string Role;
        string isSmoking;
        string Animals;
        int NumberOfPartners;
        string religion;

        public acomodation()
        {
            InitializeComponent();
            //init
            Role = "";
            isSmoking = "";
            Animals = "";
            NumberOfPartners = -1;
            religion = "";
            //init combo boxes
            opt = new List<string>();
            opt.Add("Owner");
            opt.Add("Search Room");
            opt.Add("Partner");
            yesNo = new List<string>();
            yesNo.Add("Yes");
            yesNo.Add("No");
            options.ItemsSource = opt;
            smoking.ItemsSource = yesNo;
        }

        private void _exit(object sender, RoutedEventArgs e)
        {
            this.Close();            
        }

        private void create(object sender, RoutedEventArgs e)
        {
            Animals = this.AnimalstextBox.Text;
            if(this.NumOfPartnertextBox.Text!="")
                NumberOfPartners = Int32.Parse(this.NumOfPartnertextBox.Text);
            religion = this.ReltextBox.Text;
            IDomain d = new Accomodation(Role, isSmoking, Animals, NumberOfPartners, religion);
            //send domain to user's domain list in EditProfile window
            EditUserProfile.l.Add(d);
            this.Close();
        }

        private void Animals_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PartnersNum_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Rel_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void smoking_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            isSmoking = smoking.SelectedItem.ToString();
        }

        private void options_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Role = options.SelectedItem.ToString();
        }
    }
}
