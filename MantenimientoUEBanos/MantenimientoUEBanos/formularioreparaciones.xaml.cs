using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MantenimientoUEBanos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class formularioreparaciones : ContentPage
    {
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

        private async void btn_registrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient reparacionesporequipo = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();

                parametros.Add("Cod_Reparacion", "");
                parametros.Add("No_Caso_Reparacion", lbl_No_Caso_Reparacion.Text);
                parametros.Add("descripcion_problema_Reparacion", lbl_descripcion_problema_Reparacion.Text);
                //parametros.Add("fecha_ingreso_Reparacion",Convert.ToDateTime(dtp_fechaingreso);
                // parametros.Add("fecha_entrega_Reparacion", Convert.ToString(tipo));
                parametros.Add("estado_Reparacion", "1");
                parametros.Add("primerreporte_Reparacion", lbl_primerreporte_Reparacion.Text);
                parametros.Add("segundoreporte_Reparacion", lbl_segundoreporte_Reparacion.Text);
                parametros.Add("componentesreemplazados_Reparacion", lbl_componentesreemplazados_Reparacion.Text);
                parametros.Add("Usuario_Cod_Usuario", "1");
                parametros.Add("Equipos_Cod_Equipo", "2");
                parametros.Add("Equipos_Usuario_Cod_Usuario", "2");



                reparacionesporequipo.UploadValues("http://200.12.169.100/uebanos/consultas/Reparacionesporequipo.php?Cod_Reparacion=" + "" + "No_Caso_Reparacion=" + lbl_No_Caso_Reparacion 
                    + "descripcion_problema_Reparacion=" + lbl_descripcion_problema_Reparacion.Text 
                    + "estado_Reparacion=1"
                    + "primerreporte_Reparacion=" + lbl_primerreporte_Reparacion.Text
                 + "segundoreporte_Reparacion=" + lbl_segundoreporte_Reparacion 
                 + "componentesreemplazados_Reparacion=" + lbl_componentesreemplazados_Reparacion 
                 + "Usuario_Cod_Usuario=1" 
                 + "Equipos_Cod_Equipo=2" + "Equipos_Usuario_Cod_Usuario=2", "POST", parametros);



                await DisplayAlert("Alerta", "Equipo Ingresado Correctamente", "Ok");


            }
            catch (Exception ex)
            {

                await DisplayAlert("Error", "Equipo No Ingresado" + ex.Message, "Ok");
            }

            limpiarRegistros();
            await Navigation.PushAsync(new listadoEstadoMantenimientos(1));
        }
    }
}