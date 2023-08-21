using MantenimientoUEBanos.WS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MantenimientoUEBanos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class formularioreparaciones : ContentPage
    {
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<MantenimientoUEBanos.WS.reparacionesporequipo> _post;
        public formularioreparaciones()
        {
            InitializeComponent();
        }

        private void lbl_Cod_Reparaciones_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void lbl_No_Caso_Reparacion_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void lbl_descripcion_problema_Reparacion_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void estado_Reparacion_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void primerreporte_Reparacion_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void segundoreporte_Reparacion_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void componentesreemplazados_Reparacion_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void lbl_Cod_Reparaciones_Completed(object sender, EventArgs e)
        {

        }

        private void lbl_No_Caso_Reparacion_Completed(object sender, EventArgs e)
        {

        }

        private void lbl_descripcion_problema_Reparacion_Completed(object sender, EventArgs e)
        {

        }

        private void estado_Reparacion_Completed(object sender, EventArgs e)
        {

        }

        private void primerreporte_Reparacion_Completed(object sender, EventArgs e)
        {

        }

        private void segundoreporte_Reparacion_Completed(object sender, EventArgs e)
        {

        }

        private void componentesreemplazados_Reparacion_Completed(object sender, EventArgs e)
        {

        }

        private async void btn_registrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient reparacionesporequipo = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();

                //parametros.Add("Cod_Reparacion", "");
                parametros.Add("No_Caso_Reparacion", lbl_No_Caso_Reparacion.Text);
                parametros.Add("descripcion_problema_Reparacion", lbl_descripcion_problema_Reparacion.Text);
                //parametros.Add("fecha_ingreso_Reparacion",Convert.ToDateTime(dtp_fechaingreso);
                // parametros.Add("fecha_entrega_Reparacion", Convert.ToString(tipo));
                parametros.Add("estado_Reparacion", "1");
                parametros.Add("primerreporte_Reparacion", lbl_primerreporte_Reparacion.Text);
                parametros.Add("segundoreporte_Reparacion", lbl_segundoreporte_Reparacion.Text);
                parametros.Add("componentesreemplazados_Reparacion", lbl_componentesreemplazados_Reparacion.Text);
                parametros.Add("Cod_Equipo", lbl_Cod_equipo.Text);
                // parametros.Add("Usuario_Cod_Usuario", "1");
                // parametros.Add("Equipos_Cod_Equipo", "2");
                // parametros.Add("Equipos_Usuario_Cod_Usuario", "2");



                reparacionesporequipo.UploadValues("http://200.12.169.100/uebanos/consultas/Reparacionesporequipo.php?","POST", parametros);



                await DisplayAlert("Alerta", "Equipo Ingresado Correctamente", "Ok");


            }
            catch (Exception ex)
            {

                await DisplayAlert("Error", "Equipo No Ingresado" + ex.Message, "Ok");
            }

            limpiarRegistros();
            await Navigation.PushAsync(new listadoEstadoMantenimientos(1,0));
        }
        private void limpiarRegistros()
        {
            lbl_Cod_Reparaciones.Text = "";
            lbl_No_Caso_Reparacion.Text = "";
            lbl_descripcion_problema_Reparacion.Text = "";
            //lbl_estado_Reparacion.Text = "";
            lbl_primerreporte_Reparacion.Text = "";
            lbl_segundoreporte_Reparacion.Text = "";
            lbl_componentesreemplazados_Reparacion.Text = "";
        }

        private async void btn_seleccionaequipo_Clicked(object sender, EventArgs e)
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

                    string codigoequipo = text;

                    int codigoverificado = Convert.ToInt32(codigoequipo);

                    if (codigoverificado > 0)
                    {
                        string Url2 = "http://200.12.169.100/uebanos/consultas/buscaequipoporcodigo.php?codigo=" + codigoequipo;

                        HttpResponseMessage response = await client.GetAsync($"{Url2}");

                        if (response.IsSuccessStatusCode)
                        {


                            var json = await response.Content.ReadAsStringAsync();

                            var content = await client.GetStringAsync($"{Url2}");


                            //IEnumerable<PatitasFelices2.WS.Animales> posts = JsonConvert.DeserializeObject<IEnumerable<PatitasFelices2.WS.Animales>>(json);

                            if (content.Count() > 0)
                            {
                                lbl_Cod_equipo.Text = codigoequipo;
                                btn_registrar.IsEnabled = true;
                            }

                            else
                            {
                                await DisplayAlert("Alerta", "El código no esta registrado en el sistema", "Ok");

                            }

                        }

                        else
                        {
                            await DisplayAlert("Alerta", "El código no esta registrado en el sistema", "Ok");

                        }



                    }



                }
            }
            catch (Exception)
            {

                await DisplayAlert("Error", "El Codigo QR no esta registrado en el sistema", "OK");
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