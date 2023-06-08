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
    public partial class LoginMantenimiento : ContentPage
    {

        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<MantenimientoUEBanos.WS.Login> _post;

        public static String codusu { get; set; }


        public LoginMantenimiento()
        {
            InitializeComponent();
        }

        private async void iniciarsesionLogin_Clicked(object sender, EventArgs e)
        {
            WS.ViewModelUsuariocs client = new WS.ViewModelUsuariocs();
            var result = await client.Login<WS.Login>("http://200.12.169.100/uebanos/consultas/postlogin.php?usuarioingreso_Usuario=" + usuarioLogin.Text + "&contrasena_Usuario=" + passwordLogin.Text);
            string h = string.Empty;

            if (result != null)
            {
                string codigo = $"{result.Cod_Usuario}";
                string nombre = result.nombre_Usuario;

                codusu = codigo;



                await DisplayAlert("Bienvenido " + usuarioLogin.Text, "Se ha Iniciado sesión correctamente", "Ok");
                await Navigation.PushAsync(new MenuPrincipal());

            }

            else
            {
                await DisplayAlert("Error", "No se Encontraron Registros con el usuario Ingresado", "Ok");

            }

        }

        private void BtnRecuperarContrasena_Clicked(object sender, EventArgs e)
        {

        }

        private async void BtnRegistro_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FormularioCliente());
        }

        public string traeusuario()
        {

            return codusu;
        }
    }
}