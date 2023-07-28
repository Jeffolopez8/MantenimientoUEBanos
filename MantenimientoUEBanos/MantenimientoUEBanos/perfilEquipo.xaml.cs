using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MantenimientoUEBanos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class perfilEquipo : ContentPage
    {
        public perfilEquipo(int codigoequipo, string noserie, string descripcion,string marca,int tipo,string accesorios,string qrimagen)
        {
            InitializeComponent();
            lbl_Cod_Equipo.Text = Convert.ToString(codigoequipo);
            lbl_no_Serie_Equipo.Text = noserie;
            lbl_descripcion_Equipo.Text = descripcion;
            lbl_marca_Equipo.Text = marca;
            lbl_tipo_Equipo.Text = Convert.ToString(tipo);
            lbl_accesorios_Equipo.Text = accesorios;
            lbl_qrimagen_Equipos.Text = qrimagen;
        }

        
       

        private async void btn_RegresarU_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new  listaEquipos());
        }

        private async void btn_generarqr_Clicked(object sender, EventArgs e)
        {
            int codigoequipo = Convert.ToInt32( lbl_Cod_Equipo.Text);
            string descripcionequipo = lbl_descripcion_Equipo.Text;
            string informacionequipo = lbl_marca_Equipo.Text +" "+ lbl_accesorios_Equipo;

            await Navigation.PushAsync(new QRequipos(codigoequipo,descripcionequipo,informacionequipo));
        }

        private async void btn_Actualizarequipo_Clicked(object sender, EventArgs e)
        {
            try
            {


                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();

                parametros.Add("Cod_Equipo", lbl_Cod_Equipo.Text);
                parametros.Add("no_Serie_Equipo", lbl_no_Serie_Equipo.Text);
                parametros.Add("descripcion_Equipo", lbl_descripcion_Equipo.Text);
                parametros.Add("marca_Equipo", lbl_marca_Equipo.Text);
                parametros.Add("tipo_Equipo", lbl_tipo_Equipo.Text);
                parametros.Add("accesorios_Equipo", lbl_accesorios_Equipo.Text);
                parametros.Add("qrimagen_Equipos", lbl_qrimagen_Equipos.Text);


                cliente.UploadValues("http://200.12.169.100/uebanos/consultas/Equipos.php?Cod_Equipo=" + lbl_Cod_Equipo.Text + "&no_Serie_Equipo=" + lbl_no_Serie_Equipo.Text +

                                     "&descripcion_Equipo=" + lbl_descripcion_Equipo.Text + "&marca_Equipo=" + lbl_marca_Equipo.Text +

                                      "&tipo_Equipo=" + lbl_tipo_Equipo.Text + "&accesorios_Equipo=" + lbl_accesorios_Equipo.Text + "&qrimagen_Equipos=" + lbl_qrimagen_Equipos.Text
                                         , "PUT", parametros);




                await DisplayAlert("Alerta", "Usuario Actualizado Correctamente", "Ok");

                int codigoequipo = Convert.ToInt32(lbl_Cod_Equipo.Text);
                int tipoequipo = Convert.ToInt32(lbl_tipo_Equipo.Text);

                await Navigation.PushAsync(new perfilEquipo(codigoequipo, lbl_no_Serie_Equipo.Text, lbl_descripcion_Equipo.Text, lbl_marca_Equipo.Text, tipoequipo, lbl_accesorios_Equipo.Text, lbl_qrimagen_Equipos.Text));


            }
            catch (Exception ex)
            {

                await DisplayAlert("Error", "Usuario No Actualizad" + ex.Message, "Ok");
            }

        }

        private async void btn_Eliminar_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Question?", "Esta seguro de eliminar el Equipo", "Si", "No");
            Debug.WriteLine("Answer: " + answer);

            if (answer)
            {
                try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();

                    parametros.Add("Cod_Equipo", lbl_Cod_Equipo.Text);

                    cliente.UploadValues("http://200.12.169.100/uebanos/consultas/Equipos.php?Cod_Equipo=" + lbl_Cod_Equipo.Text,"DELETE", parametros);

                await DisplayAlert("Alerta", "Equipo Eliminado Correctamente", "Ok");
                    
                
                await Navigation.PushAsync(new listaEquipos());


            }
            catch (Exception ex)
            {

                await DisplayAlert("Error", "Usuario No Eliminado" + ex.Message, "Ok");
            }
            }
        }

        
    }
}