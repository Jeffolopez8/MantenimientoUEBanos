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
    public partial class FormularioCliente : ContentPage
    {
        public FormularioCliente()
        {
            InitializeComponent();
            progress.ProgressTo(.0, 250, Easing.Linear);
            lbl_progress.Text = "0%";
        }

        private void lbl_nombre_Completed(object sender, EventArgs e)
        {
            
        }

        private void lbl_nombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            string nombre = lbl_nombre.Text.ToString();
            string cadena = $"Bienvenido  {nombre}, llena tus datos";
            lbl_principal1.Text = cadena;
            progress.ProgressTo(.10, 250, Easing.Linear);
            lbl_progress.Text = "10%";
        }

        private async void btn_registrar_Clicked(object sender, EventArgs e)
        {
            if (lbl_progress.Text == "100%")
            {

                if (lbl_password.Text == lbl_password2.Text)
                {
                    try
                    {
                        WebClient usuario = new WebClient();
                        var parametros = new System.Collections.Specialized.NameValueCollection();

                        //parametros.Add("Cod_Cliente", "");
                        parametros.Add("nombre_Usuario", lbl_nombre.Text);
                        parametros.Add("usuarioingreso_Usuario", lbl_usuario.Text);
                        parametros.Add("correo_Usuario", lbl_correo.Text);
                        parametros.Add("telefono_Usuario", lbl_telefono.Text);
                        parametros.Add("contrasena_Usuario", lbl_password.Text);
                        parametros.Add("tipo_Usuario", "2");
                        var response = usuario.UploadValues("http://200.12.169.100/uebanos/consultas/postbusqueda.php?", "POST", parametros);





                        await DisplayAlert("Alerta", "Usuario Ingresado Correctamente", "Ok");


                    }
                    catch (Exception ex)
                    {

                        await DisplayAlert("Error", "Usuario No Ingresado" + ex.Message, "Ok");
                    }

                    limpiarRegistros();
                    await Navigation.PushAsync(new LoginMantenimiento());



                }
                else
                {
                    await DisplayAlert("Contraseña diferente", "Ambas contraseñas deben ser iguales", "modificar");
                    lbl_password.Text = "";
                    lbl_password2.Text = "";
                }
            }
            else

            {
                await DisplayAlert("Registro Faliido", "Debe llenar todos los campos reuqeridos", "Ok");
            }

        
    }

       
        private void lbl_usuario_Completed(object sender, EventArgs e)
        {
            
        }

        private void lbl_telefono_Completed(object sender, EventArgs e)
        {
           
        }

        private void lbl_correo_Completed(object sender, EventArgs e)
        {

        }

        private void lbl_password_Completed(object sender, EventArgs e)
        {

        }

        private void lbl_password2_Completed(object sender, EventArgs e)
        {

        }

        private void lbl_usuario_TextChanged(object sender, TextChangedEventArgs e)
        {
            progress.ProgressTo(.30, 250, Easing.Linear);
            lbl_progress.Text = "30%";
        }

        private void lbl_telefono_TextChanged(object sender, TextChangedEventArgs e)
        {
            progress.ProgressTo(.50, 250, Easing.Linear);
            lbl_progress.Text = "50%";
        }

        private void lbl_correo_TextChanged(object sender, TextChangedEventArgs e)
        {
            progress.ProgressTo(.70, 250, Easing.Linear);
            lbl_progress.Text = "70%";
        }

        private void cbox_terminos_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (cbox_terminos.IsChecked)
                btn_registrar.IsEnabled = true;
            else
                btn_registrar.IsEnabled = false;
        }

        private void lbl_password_TextChanged(object sender, TextChangedEventArgs e)
        {
            progress.ProgressTo(.90, 250, Easing.Linear);
            lbl_progress.Text = "90%";
        }

        private void lbl_password2_TextChanged(object sender, TextChangedEventArgs e)
        {
            progress.ProgressTo(.99, 250, Easing.Linear);
            lbl_progress.Text = "100%";
        }

        private void limpiarRegistros()
        {
            lbl_nombre.Text = "";
            lbl_telefono.Text = "";
            lbl_correo.Text = "";
            lbl_usuario.Text = "";
            lbl_password.Text = "";
            lbl_password2.Text = "";
        }
    }
}