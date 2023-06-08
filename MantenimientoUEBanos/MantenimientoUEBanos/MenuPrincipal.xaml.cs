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
    public partial class MenuPrincipal : ContentPage
    {
        public MenuPrincipal()
        {
            InitializeComponent();


        }

        private void btnUsuarios_Clicked(object sender, EventArgs e)
        {

        }

        private void btnEquipos_Clicked(object sender, EventArgs e)
        {

        }

        private void btnEquipos_Clicked_1(object sender, EventArgs e)
        {

        }

        private void btnPerfil_Clicked(object sender, EventArgs e)
        {

        }

        private void BuscaUsuario()
        {
            LoginMantenimiento login = new LoginMantenimiento();
            string codigousuario = login.traeusuario();


           // lbl_UsuarioConectado.Text = Usuario;
            lbl_Hora.Text = DateTime.Now.ToString();
        }
    }
}