using Ilumno.Model.Pais;
using Ilumno.Model.TipoDocumento;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;

namespace Ilumno.Service
{
    public class TipoDocumentoService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        // Constructor que inicializa HttpClient y obtiene la URL base de la API desde el web.config

        public TipoDocumentoService()
        {
            _httpClient = new HttpClient();
            _apiUrl = ConfigurationManager.AppSettings["URL_API_VOCABULARIO"]; // Lee la URL del web.config
        }

        // Método para obtener la lista de países desde la API de manera sincrónica
        public List<TipoDocumentoResponseDto> ObtenerTipoDocumentos()
        {
            try
            {
                // Construye la URL completa para la solicitud
                string requestUri = $"{_apiUrl}TipoDocumentos";

                // Realiza la solicitud GET de manera sincrónica y obtiene la respuesta en formato JSON
                var response = _httpClient.GetStringAsync(requestUri).Result;

                // Deserializa el JSON en una lista de PaisResponseDto
                return JsonConvert.DeserializeObject<List<TipoDocumentoResponseDto>>(response);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
