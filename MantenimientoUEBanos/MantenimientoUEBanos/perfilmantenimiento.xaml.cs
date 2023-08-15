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

namespace MantenimientoUEBanos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class perfilmantenimiento : ContentPage
    {
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<MantenimientoUEBanos.WS.reparacionesporequipo> _post;
        public perfilmantenimiento(int codigoreparacion,string nocaso, string descripcion,int estadorep,string primerreporte, string segundoreporte, string componentes)
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



        private void btn_ActualizarUsuario_Clicked(object sender, EventArgs e)
        {

        }

        private void btn_finalizarproceso_Clicked(object sender, EventArgs e)
        {

        }

        private void btn_apprealidadaumentada_Clicked(object sender, EventArgs e)
        {
            Browser.OpenAsync("https://play.google.com/store/apps/details?id=com.ar.augment",BrowserLaunchMode.SystemPreferred);
        }
    }
}