using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
 

namespace MantenimientoUEBanos
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new LoginMantenimiento());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
