using Ilumno.Model.Formulario;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Ilumno.Service
{
    public class FormularioService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        // Constructor que inicializa HttpClient y obtiene la URL base de la API desde el web.config
        public FormularioService()
        {
            _httpClient = new HttpClient();
            _apiUrl = ConfigurationManager.AppSettings["URL_API_FORMULARIO"]; // Lee la URL del web.config
        }

        // Método para obtener la lista de formularios desde la API y mapear los datos
        public List<FormularioDto> ObtenerFormularios()
        {
            try
            {
                // Construye la URL completa para la solicitud
                string requestUri = $"{_apiUrl}data";

                // Realiza la solicitud GET de manera sincrónica y obtiene la respuesta en formato JSON
                var response = _httpClient.GetStringAsync(requestUri).Result;

                // Deserializa el JSON en una lista de ResponseFormularioDto
                var responseFormularios = JsonConvert.DeserializeObject<List<ResponseFormularioDto>>(response);

                // Mapea ResponseFormularioDto a FormularioDto
                var formularios = responseFormularios.Select(dto => new FormularioDto
                {
                    //Id = Guid.Parse(dto.Id), // Convierte el Id a Guid
                    Apellido = dto.Apellido,
                    Nombre = dto.Nombre,
                    TipoDocumento = dto.TipoDocumento.Nombre, // Usa el Id del TipoDocumento
                    NumeroDocumento = dto.NumeroDocumento,
                    CorreoElectronico = dto.CorreoElectronico,
                    Telefono = dto.Telefono,
                    Pais = dto.Pais.Nombre // Usa el Id del Pais
                }).ToList();

                return formularios;
            }
            catch (System.Exception)
            {
                // Manejo de excepciones adecuado
                throw;
            }
        }

        // Método para enviar un nuevo formulario usando POST (Sincrónico)
        public (bool success, string errorMessage) EnviarFormulario(RequestFormulario request)
        {
            try
            {
                // Construye la URL completa para la solicitud POST
                string requestUri = $"{_apiUrl}create"; // Ajustado para el endpoint "/create"
                string json = JsonConvert.SerializeObject(request);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                // Crear y configurar HttpClient
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_apiUrl); // Asegúrate de que _apiUrl sea la base correcta

                    // Enviar solicitud POST
                    HttpResponseMessage response = client.PostAsync("create", content).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        return (true, null);
                    }
                    else
                    {
                        // Leer el contenido de la respuesta de error
                        string errorJson = response.Content.ReadAsStringAsync().Result;

                        // Verifica si la respuesta es un mensaje de error personalizado
                        if (response.Content.Headers.ContentType.MediaType == "application/json")
                        {
                            ApiErrorResponse errorResponse = JsonConvert.DeserializeObject<ApiErrorResponse>(errorJson);

                            if (errorResponse != null && errorResponse.Errors != null)
                            {
                                StringBuilder errorMessages = new StringBuilder();
                                foreach (var error in errorResponse.Errors)
                                {
                                    errorMessages.AppendLine($"Campo: {error.Field}, Mensaje: {error.Message}, Severidad: {error.Severity}");
                                }
                                return (false, errorMessages.ToString());
                            }
                            else
                            {
                                return (false, "Error desconocido al procesar la solicitud.");
                            }
                        }
                        else
                        {
                            return (false, "Error desconocido al procesar la solicitud.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción y devolver un mensaje de error
                return (false, $"Error al enviar el formulario: {ex.Message}");
            }
        }
    }
}
