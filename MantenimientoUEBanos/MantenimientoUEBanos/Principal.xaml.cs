using MantenimientoUEBanos.WS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MantenimientoUEBanos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Principal : ContentPage
    {
        string codigousuario;
        public Principal()
        {
            InitializeComponent();
            LoginMantenimiento login = new LoginMantenimiento();

             codigousuario = login.traeusuario();
        }

       

        private async void btnMiPrefil_Clicked(object sender, EventArgs e)
        {
           

            await Navigation.PushAsync(new PerfilUsuario(codigousuario));
        }

        private async void btnPerfilequipos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new listaEquipos());
        }
    }
}