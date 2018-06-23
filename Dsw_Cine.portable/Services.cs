using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Dsw_Cine.portable
{
   public class Services
    {

        HttpClient http = new HttpClient();
        //Usuario usuario = new Usuario();
            
        // List<Usuario> listUsuarios = new List<Usuario>();
        private const string url = "http://webapirestcine.azurewebsites.net/api/";

        public async Task<string> RegistraCliente(int _dni, string _nom, string _correo, int _telef,int _telec)
        {

             
            var reg = $"registrocliente?dni={_dni}&nom={_nom}&correo={_correo}&telf_f={_telef}&telf_c={_telec}";

            var uri = url + reg;
             var http = new HttpClient();
            var response = await http.PutAsync(uri, null);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject(content).ToString();
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task<string> ActualizaCliente(int _dni, string _nom, string _correo, int _telef, int _telec)
        {


            var reg = $"actualizacliente?dni={_dni}&nom={_nom}&correo={_correo}&telf_f={_telef}&telf_c={_telec}";

            var uri = url + reg;
            var http = new HttpClient();
            var response = await http.PutAsync(uri, null);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject(content).ToString();
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task<Cliente> ValidaCliente(int _dni)
        {
            var clie = $"consultacliente?dni={_dni}";

            var uri = url + clie;
            var respuestaService = await http.GetAsync(uri);
            var contenido = respuestaService.Content.ReadAsStringAsync().Result.ToString();
            var cliente = JsonConvert.DeserializeObject<Cliente>(contenido);
            return cliente;

        }

        public async Task<Reserva> ConsultaReserva(int _id)
        {
            var res = $"consultareserva?id={_id}";

            var uri = url + res;
            var respuestaService = await http.GetAsync(uri);
            var contenido = respuestaService.Content.ReadAsStringAsync().Result.ToString();
            var reserva = JsonConvert.DeserializeObject<Reserva>(contenido);
            return reserva;

        }


    }
}
