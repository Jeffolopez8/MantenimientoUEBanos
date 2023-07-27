using MantenimientoUEBanos.WS;
using Newtonsoft.Json;
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
    public partial class listadoEstadoMantenimientos : ContentPage
    {
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<MantenimientoUEBanos.WS.reparacionesporequipo> _post;
        public listadoEstadoMantenimientos(int estado)
        {
            InitializeComponent();
            if (estado==1)
            {
                listaequiposenproceso();
            }
            if (estado==3)
            {
                listaequiposfinalizados();
            }
        }

        private async void cllestadoequipos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (WS.reparacionesporequipo)e.SelectedItem;
            var item = obj.Cod_Reparacion.ToString();
            int codigoreparacion = Convert.ToInt32(item);



            await Navigation.PushAsync(new perfilmantenimiento(codigoreparacion));
        }

        public async void listaequiposenproceso()
        {
            try
            {
                string Url2 = "http://200.12.169.100/uebanos/consultas/reparacionesingresadosporusuario.php";
                HttpResponseMessage response = await client.GetAsync($"{Url2}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    //var content = await client.GetStringAsync($"{Url2}");

                    List<MantenimientoUEBanos.WS.reparacionesporequipo> posts = JsonConvert.DeserializeObject<List<MantenimientoUEBanos.WS.reparacionesporequipo>>(json);
                    _post = new ObservableCollection<MantenimientoUEBanos.WS.reparacionesporequipo>(posts);
                    cllestadoequipos.ItemsSource = _post;


                }
                else
                {
                    var content = await client.GetStringAsync($"{Url2}");

                    List<MantenimientoUEBanos.WS.reparacionesporequipo> posts = JsonConvert.DeserializeObject<List<MantenimientoUEBanos.WS.reparacionesporequipo>>(content);
                    _post = new ObservableCollection<MantenimientoUEBanos.WS.reparacionesporequipo>(posts);
                }

            }
            catch (Exception e)
            {

                await DisplayAlert("Alerta", e.Message, "Ok");
            }





        }

        public async void listaequiposfinalizados()
        {
            try
            {
                string Url2 = "http://200.12.169.100/uebanos/consultas/reparacionesfinalizadas.php";
                HttpResponseMessage response = await client.GetAsync($"{Url2}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    //var content = await client.GetStringAsync($"{Url2}");

                    List<MantenimientoUEBanos.WS.reparacionesporequipo> posts = JsonConvert.DeserializeObject<List<MantenimientoUEBanos.WS.reparacionesporequipo>>(json);
                    _post = new ObservableCollection<MantenimientoUEBanos.WS.reparacionesporequipo>(posts);
                    cllestadoequipos.ItemsSource = _post;


                }
                else
                {
                    var content = await client.GetStringAsync($"{Url2}");

                    List<MantenimientoUEBanos.WS.reparacionesporequipo> posts = JsonConvert.DeserializeObject<List<MantenimientoUEBanos.WS.reparacionesporequipo>>(content);
                    _post = new ObservableCollection<MantenimientoUEBanos.WS.reparacionesporequipo>(posts);
                }

            }
            catch (Exception e)
            {

                await DisplayAlert("Alerta", e.Message, "Ok");
            }





        }
    }
}