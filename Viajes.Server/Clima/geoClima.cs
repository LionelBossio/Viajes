using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Viajes.Server.Clima
{
    public class geoClima
    {
        private readonly HttpClient _httpCliente;
        private readonly string apiKey;

        public geoClima(HttpClient httpCliente)
        {
            _httpCliente = httpCliente;
            apiKey = "3107ce3aec0c598ae71a446571f8bc98";
        }

        public async Task<string> ObtenerClima(string cityName)
        {
            string url = $"https://pro.openweathermap.org/data/2.5/forecast/climate?q={cityName}&appid={apiKey}&cnt=10"; /* Muestra el clima de la ciudad hasta 10 dias */

            var respuesta = await _httpCliente.GetAsync(url);
            respuesta.EnsureSuccessStatusCode(); /* Si es falso tira un false */

            var StringJSON = await respuesta.Content.ReadAsStringAsync();
            var tipoClima = JsonConvert.DeserializeObject<dynamic>(StringJSON)!; // el ! suprime valores nulos

            var Clima = tipoClima.list.weather.main;

            return Clima;

        }

    }
}

