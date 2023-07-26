using Newtonsoft.Json;
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
    public partial class PerfilUsuario : ContentPage
    {

        
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<MantenimientoUEBanos.WS.usuario> _post;

        public PerfilUsuario(String codigoUsuario)
        {
            InitializeComponent();
            lbl_codigo.Text = codigoUsuario;
            MantenimientoUEBanos.WS.usuario usuario = new MantenimientoUEBanos.WS.usuario();
           // TraeInformacionUsuario();
            llamaUsuarios();
          

        }


        public async void llamaUsuarios()
        {
             string Url = "http://200.12.169.100/uebanos/consultas/postbusqueda.php?Cod_Usuario=" + lbl_codigo.Text;
             WS.ViewModelUsuariocs client = new WS.ViewModelUsuariocs();
            var result = await client.Get<WS.usuario>(Url);
            string h = string.Empty;

            if (result != null)
            {
                lbl_codigo.Text = Convert.ToString(result.Cod_Usuario);
                lbl_nombre.Text = result.nombre_Usuario;
                lbl_ingersousuario.Text = result.usuarioingreso_Usuario;
                lbl_correo.Text = result.correo_Usuario;
                lbl_telefono.Text = result.telefono_Usuario;
                lbl_contrasena.Text = result.contrasena_Usuario;
               
            }

        }


        public async void TraeInformacionUsuario()
        {
            string Url = "http://200.12.169.100/uebanos/consultas/postbusqueda.php?Cod_Usuario=" + lbl_codigo.Text;
            MantenimientoUEBanos.WS.usuario usuario = new MantenimientoUEBanos.WS.usuario();
            HttpResponseMessage response = await client.GetAsync($"{Url}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                //var content = await client.GetStringAsync($"{Url2}");

                List<MantenimientoUEBanos.WS.usuario> posts = JsonConvert.DeserializeObject<List<MantenimientoUEBanos.WS.usuario>>(json);
                _post = new ObservableCollection<MantenimientoUEBanos.WS.usuario>(posts);

                lbl_codigo.Text = Convert.ToString (posts[0]);

                lbl_nombre.Text = Convert.ToString(posts[1]);



              


               
            }

           

        }





        private async void btn_ActualizarUsuario_Clicked(object sender, EventArgs e)
        {
            try
            {


                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();

                parametros.Add("Cod_Usuario", lbl_codigo.Text);
                parametros.Add("nombre_Usuario", lbl_nombre.Text);
                parametros.Add("usuarioingreso_Usuario", lbl_ingersousuario.Text);
                parametros.Add("correo_Usuario", lbl_correo.Text);
                parametros.Add("telefono_Usuario", lbl_telefono.Text);
                parametros.Add("contrasena_Usuario", lbl_contrasena.Text);

                

                
                



                cliente.UploadValues("http://200.12.169.100/uebanos/consultas/postbusqueda.php?Cod_Usuario=" + lbl_codigo.Text + "&nombre_Usuario=" + lbl_nombre.Text +

                                     "&usuarioingreso_Usuario=" + lbl_ingersousuario.Text + "&correo_Usuario=" + lbl_correo.Text +

                                      "&telefono_Usuario=" + lbl_telefono.Text + "&contrasena_Usuario=" + lbl_contrasena.Text
                                         , "PUT",parametros);




                await DisplayAlert("Alerta", "Usuario Actualizado Correctamente", "Ok");

                await Navigation.PushAsync(new PerfilUsuario(lbl_codigo.Text));


            }
            catch (Exception ex)
            {

                await DisplayAlert("Error", "Usuario No Actualizad" + ex.Message, "Ok");
            }



        }

        private async void btn_RegresarU_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OpcionesPP(lbl_codigo.Text, lbl_nombre.Text));
        }

        private void btnCambioContrasena_Clicked(object sender, EventArgs e)
        {
            lbl_password.IsVisible = true;
            lbl_password2.IsVisible = true; 
        }
    }
}