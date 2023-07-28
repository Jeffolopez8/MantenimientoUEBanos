﻿using MantenimientoUEBanos.WS;
using Newtonsoft.Json;
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
    public partial class listadoEstadoMantenimientos : ContentPage
    {
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<MantenimientoUEBanos.WS.reparacionesporequipo> _post;
        public listadoEstadoMantenimientos(int estado)
        {
            InitializeComponent();
            if (estado==1)
            {
                listaequiposenproceso();
            }
            if (estado==3)
            {
                listaequiposfinalizados();
            }
        }

        private async void cllestadoequipos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (WS.reparacionesporequipo)e.SelectedItem;
            var item = obj.Cod_Reparacion.ToString();
            int codigoreparacion = Convert.ToInt32(item);
            var nocasoreparacion = obj.No_Caso_Reparacion.ToString();
            string nocaso = nocasoreparacion.ToString();
            var descripcionreparacion = obj.descripcion_problema_Reparacion.ToString();
            string descripcion = descripcionreparacion.ToString();
            //var fechaingreso = obj.fecha_ingreso_Reparacion.ToString();
            //string fechaing = fechaingreso.ToString();
           // var fechaentrega = obj.fecha_entrega_Reparacion.ToString();
            //string fechaent = fechaentrega.ToString();
            var estadoreparacion = obj.estado_Reparacion.ToString();
            int estadorep = Convert.ToInt32(estadoreparacion);
            var primerreport = obj.primerreporte_Reparacion.ToString();
            string primerreporte = primerreport.ToString();
            var segundoreport = obj.segundoreporte_Reparacion.ToString();
            string segundoreporte = segundoreport.ToString();
            var componentesremplazados = obj.componentesreemplazados_Reparacion.ToString();
            string componentes = componentesremplazados.ToString();


            await Navigation.PushAsync(new perfilmantenimiento(codigoreparacion,nocaso, descripcion, estadorep, primerreporte, segundoreporte, componentes));
        }

        public async void listaequiposenproceso()
        {
            try
            {
                string Url2 = "http://200.12.169.100/uebanos/consultas/reparacionesingresadosporusuario.php";
                HttpResponseMessage response = await client.GetAsync($"{Url2}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    //var content = await client.GetStringAsync($"{Url2}");

                    List<MantenimientoUEBanos.WS.reparacionesporequipo> posts = JsonConvert.DeserializeObject<List<MantenimientoUEBanos.WS.reparacionesporequipo>>(json);
                    _post = new ObservableCollection<MantenimientoUEBanos.WS.reparacionesporequipo>(posts);
                    cllestadoequipos.ItemsSource = _post;


                }
                else
                {
                    var content = await client.GetStringAsync($"{Url2}");

                    List<MantenimientoUEBanos.WS.reparacionesporequipo> posts = JsonConvert.DeserializeObject<List<MantenimientoUEBanos.WS.reparacionesporequipo>>(content);
                    _post = new ObservableCollection<MantenimientoUEBanos.WS.reparacionesporequipo>(posts);
                }

            }
            catch (Exception e)
            {

                await DisplayAlert("Alerta", e.Message, "Ok");
            }





        }

        public async void listaequiposfinalizados()
        {
            try
            {
                string Url2 = "http://200.12.169.100/uebanos/consultas/reparacionesfinalizadas.php";
                HttpResponseMessage response = await client.GetAsync($"{Url2}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    //var content = await client.GetStringAsync($"{Url2}");

                    List<MantenimientoUEBanos.WS.reparacionesporequipo> posts = JsonConvert.DeserializeObject<List<MantenimientoUEBanos.WS.reparacionesporequipo>>(json);
                    _post = new ObservableCollection<MantenimientoUEBanos.WS.reparacionesporequipo>(posts);
                    cllestadoequipos.ItemsSource = _post;


                }
                else
                {
                    var content = await client.GetStringAsync($"{Url2}");

                    List<MantenimientoUEBanos.WS.reparacionesporequipo> posts = JsonConvert.DeserializeObject<List<MantenimientoUEBanos.WS.reparacionesporequipo>>(content);
                    _post = new ObservableCollection<MantenimientoUEBanos.WS.reparacionesporequipo>(posts);
                }

            }
            catch (Exception e)
            {

                await DisplayAlert("Alerta", e.Message, "Ok");
            }





        }
    }
}