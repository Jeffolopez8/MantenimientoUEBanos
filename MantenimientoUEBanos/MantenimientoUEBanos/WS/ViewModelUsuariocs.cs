using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MantenimientoUEBanos.WS
{
    internal class ViewModelUsuariocs
    {
        public async Task<T> Get<T>(string url)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();
            var listUsuario = JsonConvert.DeserializeObject<List<T>>(json);
            return listUsuario[0];

        }


        public async Task<T> Login<T>(string url)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();
            var listaLog = JsonConvert.DeserializeObject<List<T>>(json);

            if (listaLog.Count > 0)
            {
                return listaLog[0];

            }
            else
            {
                return default(T);


            }



        }

    }
}
