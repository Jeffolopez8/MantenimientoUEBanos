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
	public partial class MantenimientoQR : ContentPage
	{
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<MantenimientoUEBanos.WS.reparacionesporequipo> _post;
        int codigoequipo = 0;

        public MantenimientoQR (int codigoverificado)
		{
			InitializeComponent ();
            codigoequipo = codigoverificado;
		}

        private async void btnenprocesoo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new listadoEstadoMantenimientos(1, codigoequipo));
        }

        private async void btnfinalizados_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new listadoEstadoMantenimientos(3, codigoequipo));
        }

        private void cllmantenimiento_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}