using MantenimientoUEBanos.WS;
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
    public partial class QRcodigo : ContentPage
    {

        private const string Url = "http://200.12.169.100/patitas/mascota/postbusqueda.php?";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<MantenimientoUEBanos.WS.equipos> _post;
        public QRcodigo()
        {
            InitializeComponent();
        }

        private void btnConsultarQr_Clicked(object sender, EventArgs e)
        {

        }

        private async void btnConsultarQr_Clicked_1(object sender, EventArgs e)
        {
            try
            {
                var scanner = new ZXing.Mobile.MobileBarcodeScanner();
                scanner.TopText = "Mantenimientos UE Baños";
                scanner.BottomText = "ESCANEE EL CODIGO QR";
                var result = await scanner.Scan();
                if (result != null)
                {
                    String resultado = result.Text;

                    string word1 = ":";
                    string word2 = "*";
                    string text = stringBetween(resultado, word1, word2);

                    string codigoanimal = text;

                    int codigoverificado = Convert.ToInt32(codigoanimal);

                    if (codigoverificado > 0)
                    {
                        string Url2 = "http://200.12.169.100/patitas/mascota/postbusqueda.php?codigo=" + codigoanimal;

                        HttpResponseMessage response = await client.GetAsync($"{Url2}");

                        if (response.IsSuccessStatusCode)
                        {


                            var json = await response.Content.ReadAsStringAsync();

                            var content = await client.GetStringAsync($"{Url2}");


                            //IEnumerable<PatitasFelices2.WS.Animales> posts = JsonConvert.DeserializeObject<IEnumerable<PatitasFelices2.WS.Animales>>(json);

                            if (content.Count() > 0)
                            {
                                //await Navigation.PushAsync(new ListadoMascotasporQR(codigoanimal));

                            }

                            else
                            {
                                await DisplayAlert("Alerta", "El código no pertenece a Patitas Felices", "Ok");

                            }

                        }

                        else
                        {
                            await DisplayAlert("Alerta", "El código no pertenece a Patitas Felices", "Ok");

                        }



                    }



                }
            }
            catch (Exception)
            {

                await DisplayAlert("Error", "El Codigo QR no pertenece a Patitas Felices App", "OK");
            }
        }

        public static string stringBetween(string Source, string Start, string End)
        {
            string result = "";
            if (Source.Contains(Start) && Source.Contains(End))
            {
                int StartIndex = Source.IndexOf(Start, 0) + Start.Length;
                int EndIndex = Source.IndexOf(End, StartIndex);
                result = Source.Substring(StartIndex, EndIndex - StartIndex);
                return result;
            }

            return result;
        }
    }
}