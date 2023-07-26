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

        private void cllequipos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void btnregistrarequipo_Clicked(object sender, EventArgs e)
        {

        }
    }
}