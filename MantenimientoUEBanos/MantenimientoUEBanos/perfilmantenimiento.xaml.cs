using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Net;

namespace MantenimientoUEBanos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class perfilmantenimiento : ContentPage
    {
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<MantenimientoUEBanos.WS.reparacionesporequipo> _post;
        public perfilmantenimiento(int codigoreparacion, string nocaso, string descripcion, int estadorep, string primerreporte, string segundoreporte, string componentes)
        {
            InitializeComponent();
            // lbl_No_caso.Text = codigoUsuario;
            MantenimientoUEBanos.WS.reparacionesporequipo usuario = new MantenimientoUEBanos.WS.reparacionesporequipo();
            lbl_Cod_reparacion.Text = Convert.ToString(codigoreparacion);
            lbl_No_caso.Text = nocaso;
            lbl_descripcion.Text = descripcion;
            // dtp_fechaingreso.Date = Convert.ToDateTime( fechaing);
            //dtp_fechaentrega.Date = Convert.ToDateTime(fechaent);
            lbl_estado.Text = Convert.ToString(estadorep);
            lbl_primerreporte.Text = primerreporte;
            lbl_segundoreporte.Text = segundoreporte;
            lbl_componentes.Text = componentes;


        }

        public async void llamadatosmantenimiento()
        {
            string Url = "http://200.12.169.100/uebanos/consultas/reparacionesporequipo.php?Cod_Reparacion=" + lbl_Cod_reparacion.Text;
            WS.ViewModelUsuariocs client = new WS.ViewModelUsuariocs();
            var result = await client.Get<WS.reparacionesporequipo>(Url);
            string h = string.Empty;

            if (result != null)
            {
                lbl_No_caso.Text = result.No_Caso_Reparacion;
                lbl_descripcion.Text = result.descripcion_problema_Reparacion;
                //dtp_fechaingreso. = result.fecha_ingreso_Reparacion;
                // dtp_fechaentrega.Text = result.fecha_entrega_Reparacion;
                lbl_estado.Text = Convert.ToString(result.estado_Reparacion);
                lbl_primerreporte.Text = result.primerreporte_Reparacion;
                lbl_segundoreporte.Text = result.segundoreporte_Reparacion;
                lbl_componentes.Text = result.componentesreemplazados_Reparacion;

            }

        }


        public async void TraeInformacionreparaciones()
        {
            string Url = "http://200.12.169.100/uebanos/consultas/postbusqueda.php?No_Caso_Reparacion=" + lbl_No_caso.Text;
            MantenimientoUEBanos.WS.reparacionesporequipo reparacion = new MantenimientoUEBanos.WS.reparacionesporequipo();
            HttpResponseMessage response = await client.GetAsync($"{Url}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                //var content = await client.GetStringAsync($"{Url2}");

                List<MantenimientoUEBanos.WS.reparacionesporequipo> posts = JsonConvert.DeserializeObject<List<MantenimientoUEBanos.WS.reparacionesporequipo>>(json);
                _post = new ObservableCollection<MantenimientoUEBanos.WS.reparacionesporequipo>(posts);

                lbl_Cod_reparacion.Text = Convert.ToString(posts[0]);

                lbl_No_caso.Text = Convert.ToString(posts[1]);







            }



        }



        private async void btn_ActualizarUsuario_Clicked(object sender, EventArgs e)
        {
            try
            {


                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();

                parametros.Add("Cod_Reparacion", lbl_Cod_reparacion.Text);
                parametros.Add("No_Caso_Reparacion", lbl_No_caso.Text);
                parametros.Add("descripcion_problema_Reparacion", lbl_descripcion.Text);
                parametros.Add("estado_Reparacion", "1");
                parametros.Add("primerreporte_Reparacion", lbl_primerreporte.Text);
                parametros.Add("segundoreporte_Reparacion", lbl_segundoreporte.Text);
                parametros.Add("componentesreemplazados_Reparacion", lbl_componentes.Text);
               // parametros.Add("Cod_Equipo", .Text);


                cliente.UploadValues("http://200.12.169.100/uebanos/consultas/Reparacionesporequipo.php?Cod_Reparacion=" + lbl_Cod_reparacion.Text + "&No_Caso_Reparacion=" + lbl_No_caso.Text +

                                     "&descripcion_problema_Reparacion=" + lbl_descripcion.Text + "&estado_Reparacion= 1" +

                                      "&primerreporte_Reparacion=" + lbl_primerreporte.Text + "&segundoreporte_Reparacion=" + lbl_segundoreporte.Text + "&componentesreemplazados_Reparacion=" + lbl_componentes.Text
                                         , "PUT", parametros);




                await DisplayAlert("Alerta", "Usuario Actualizado Correctamente", "Ok");

                int codigoreparacion = Convert.ToInt32(lbl_Cod_reparacion.Text);

                int estadoreparacion = Convert.ToInt32(lbl_estado.Text);

                await Navigation.PushAsync(new Mantenimientos());


            }
            catch (Exception ex)
            {

                await DisplayAlert("Error", "Usuario No Actualizad" + ex.Message, "Ok");
            }

        }

        private async void btn_finalizarproceso_Clicked(object sender, EventArgs e)
        {
            try
            {


                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();

                parametros.Add("Cod_Reparacion", lbl_Cod_reparacion.Text);
                parametros.Add("No_Caso_Reparacion", lbl_No_caso.Text);
                parametros.Add("descripcion_problema_Reparacion", lbl_descripcion.Text);
                parametros.Add("estado_Reparacion", "3");
                parametros.Add("primerreporte_Reparacion", lbl_primerreporte.Text);
                parametros.Add("segundoreporte_Reparacion", lbl_segundoreporte.Text);
                parametros.Add("componentesreemplazados_Reparacion", lbl_componentes.Text);
                // parametros.Add("Cod_Equipo", .Text);


                cliente.UploadValues("http://200.12.169.100/uebanos/consultas/Reparacionesporequipo.php?Cod_Reparacion=" + lbl_Cod_reparacion.Text + "&No_Caso_Reparacion=" + lbl_No_caso.Text +

                                     "&descripcion_problema_Reparacion=" + lbl_descripcion.Text + "&estado_Reparacion=3 " +

                                      "&primerreporte_Reparacion=" + lbl_primerreporte.Text + "&segundoreporte_Reparacion=" + lbl_segundoreporte.Text + "&componentesreemplazados_Reparacion=" + lbl_componentes.Text
                                         , "PUT", parametros);




                await DisplayAlert("Alerta", "Usuario Actualizado Correctamente", "Ok");

                int codigoreparacion = Convert.ToInt32(lbl_Cod_reparacion.Text);

                int estadoreparacion = Convert.ToInt32(lbl_estado.Text);

                await Navigation.PushAsync(new Mantenimientos());


            }
            catch (Exception ex)
            {

                await DisplayAlert("Error", "Usuario No Actualizad" + ex.Message, "Ok");
            }

        }

        private void btn_apprealidadaumentada_Clicked(object sender, EventArgs e)
        {
            Browser.OpenAsync("https://play.google.com/store/apps/details?id=com.ar.augment", BrowserLaunchMode.SystemPreferred);
        }

        private async void btn_seleccionaequipo_Clicked(object sender, EventArgs e)
        {
           


        }

       
    } 
}