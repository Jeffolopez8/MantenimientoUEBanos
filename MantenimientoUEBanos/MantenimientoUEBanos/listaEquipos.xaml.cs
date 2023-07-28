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
    public partial class listaEquipos : ContentPage
    {
        
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<MantenimientoUEBanos.WS.equipos> _post;
        public listaEquipos()
        {
            InitializeComponent();
            listaequipos();

        }

        public async void listaequipos()
        {
            try
            {
                string Url2 = "http://200.12.169.100/uebanos/consultas/listaEquipos.php";
                HttpResponseMessage response = await client.GetAsync($"{Url2}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    //var content = await client.GetStringAsync($"{Url2}");

                    List<MantenimientoUEBanos.WS.equipos> posts = JsonConvert.DeserializeObject<List<MantenimientoUEBanos.WS.equipos>>(json);
                    _post = new ObservableCollection<MantenimientoUEBanos.WS.equipos>(posts);

                    cllequipos.ItemsSource = _post;


                }
                else
                {
                    var content = await client.GetStringAsync($"{Url2}");

                    List<MantenimientoUEBanos.WS.equipos> posts = JsonConvert.DeserializeObject<List<MantenimientoUEBanos.WS.equipos>>(content);
                    _post = new ObservableCollection<MantenimientoUEBanos.WS.equipos>(posts);
                }

            }
            catch (Exception e)
            {

                await DisplayAlert("Alerta", e.Message, "Ok");
            }





        }

        private async void cllequipos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (WS.equipos)e.SelectedItem;
            var item = obj.Cod_Equipo.ToString();
            int codigoequipo = Convert.ToInt32(item);
            var noserieequipo = obj.no_Serie_Equipo.ToString();
            string noserie = noserieequipo.ToString();
            var descripcionequipo = obj.descripcion_Equipo.ToString();
            string descripcion = descripcionequipo.ToString();

            var marcaequipo = obj.marca_Equipo.ToString();
            string marca = marcaequipo.ToString();

            var tipoequipo = obj.tipo_Equipo.ToString();
            int tipo = Convert.ToInt32(tipoequipo);

            var accesoriosequipo = obj.accesorios_Equipo.ToString();
            string accesorios = accesoriosequipo.ToString();

            var qrimagenequipo = obj.qrimagen_Equipos.ToString();
            string qrimagen = qrimagenequipo.ToString();

            


            await Navigation.PushAsync(new perfilEquipo(codigoequipo, noserie, descripcion, marca, tipo, accesorios, qrimagen));
        }

        private async void btnregistrarequipo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new formularioEquipos());
        }
    }
}