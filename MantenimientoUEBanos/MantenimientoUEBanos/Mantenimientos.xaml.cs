using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MantenimientoUEBanos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Mantenimientos : ContentPage
    {
       
        public Mantenimientos()
        {
            InitializeComponent();
        }

        private  void btnNuevomantenimiento_Clicked(object sender, EventArgs e)
        {
            
        }

        private void cllmantenimiento_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private async void btnenprocesoo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new listadoEstadoMantenimientos(1));
        }

        private async void btnfinalizados_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new listadoEstadoMantenimientos(3));
        }

        private async void btnnuevomantenimiento_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new formularioreparaciones());
        }
    }
}