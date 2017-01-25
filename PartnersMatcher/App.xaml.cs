using PartnersMatcher.Controler;
using PartnersMatcher.Model;
using PartnersMatcher.Model.Domains;
using PartnersMatcher.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PartnersMatcher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App() { }
        protected override void OnStartup(StartupEventArgs e)
        {
            IController ic = new Controller(); 
            IModel model = new MyModel(ic);
            IView view = new MainWindow(ic);
            ic.setModel(model);
            ic.setView(view);
            view.start();
        }
    }
}
