using MantenimientoUEBanos.WS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MantenimientoUEBanos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Logout : ContentPage
    {
        public Logout()
        {
            InitializeComponent();
        }

        private async void btnCerrarcesion_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginMantenimiento());
        }
    }
}