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
    public partial class formularioEquipos : ContentPage
    {
        public formularioEquipos()
        {
            InitializeComponent();
           
        }

        private void lbl_no_serie_Completed(object sender, EventArgs e)
        {
           
        }

        private void lbl_descripcion_Completed(object sender, EventArgs e)
        {

        }

        private void lbl_marca_Completed(object sender, EventArgs e)
        {

        }

        private void lbl_tipo_Completed(object sender, EventArgs e)
        {

        }

        private void lbl_accesorios_Completed(object sender, EventArgs e)
        {

        }

        private void lbl_no_serie_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void lbl_descripcion_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void lbl_marca_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        

        private void lbl_accesorios_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void cbox_escritorio_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (cbox_escritorio.IsChecked)
            {
                cbox_laptop.IsChecked = false;
            }
        }

        private void cbox_laptop_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (cbox_laptop.IsChecked)
            {
                cbox_escritorio.IsChecked = false;
            }
        }

        private async void btn_registrar_Clicked(object sender, EventArgs e)
        {
            int tipo = 0;
            if (cbox_laptop.IsChecked)
            {
                tipo = 1;
            }

            if (cbox_escritorio.IsChecked)
            {
                tipo = 2;
            }

            try
            {
                WebClient equipos = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();

                parametros.Add("Cod_Equipo", "");
                parametros.Add("no_Serie_Equipo", lbl_no_serie.Text);
                parametros.Add("descripcion_Equipo", lbl_descripcion.Text);
                parametros.Add("marca_Equipo", lbl_marca.Text);
                parametros.Add("tipo_Equipo", Convert.ToString(tipo));
                parametros.Add("accesorios_Equipo", lbl_accesorios.Text);
                parametros.Add("qrimagen_Equipos","");
               
                

                

                    equipos.UploadValues("http://200.12.169.100/uebanos/consultas/Equipos.php?","POST", parametros);



                    await DisplayAlert("Alerta", "Equipo Ingresado Correctamente", "Ok");

                btn_generaqrequipo.IsVisible = true;
                btn_registrar.IsVisible = false;

                    }
                    catch (Exception ex)
                    {

                        await DisplayAlert("Error", "Equipo No Ingresado" + ex.Message, "Ok");
                    }

                    limpiarRegistros();
                    await Navigation.PushAsync(new listaEquipos());



                }

        private void limpiarRegistros()
        {
            lbl_no_serie.Text = "";
            lbl_descripcion.Text = "";
            lbl_marca.Text = "";
            cbox_laptop.IsChecked=false;
            cbox_escritorio.IsChecked = false;
            lbl_accesorios.Text = "";
            
        }

        private void btn_generaqrequipo_Clicked(object sender, EventArgs e)
        {

        }
    }

        
    }
