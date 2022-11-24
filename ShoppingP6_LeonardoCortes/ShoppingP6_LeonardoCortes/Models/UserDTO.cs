using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingP6_LeonardoCortes.Models
{
    public class UserDTO
    {
        public RestRequest request { get; set; }
        const string mimetype = "application/json";
        const string contentType = "Content-Type";

        public int IDUsuario { get; set; }
        public string Nombre { get; set; } = null!;
        public string CorreoElectronico { get; set; } = null!;
        public string Contrasennia { get; set; } = null!;
        public string CorreoRespaldo { get; set; } = null!;
        public string NumeroTelefono { get; set; } = null!;
        public int IDRol { get; set; }
        public int IDPais { get; set; }
        public string RolDescripcion { get; set; } = null!;
        public string PaisNombre { get; set; } = null!;

        public async Task<UserDTO> GetUserData(string email)
        {
            try
            {
                string RouteSufix = string.Format("Users/GetUserInfo?email={0}", email);

                string FinalURL = Services.CnnToP6API.ProductionURL + RouteSufix;

                RestClient client = new RestClient(FinalURL);

                request = new RestRequest(FinalURL, Method.Get);

                //agregar la info de seguridad del api, en este caso ApiKey
                request.AddHeader(Services.CnnToP6API.ApiKeyName, Services.CnnToP6API.ApiKeyValue);
                request.AddHeader(contentType, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    var list = JsonConvert.DeserializeObject<List<UserDTO>>(response.Content);   
                    
                    var item = list[0];

                    return item;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                //TODO: guardar estos errores en una bitácora para su posterior análisis
                throw;
            }
        }


        //función para acutualizar la info de una usuario usando el DTO en lugar del objeto completo
        public async Task<bool> UpdateUser()
        {
            try
            {
                string RouteSufix = string.Format("TODO");
                string FinalURL = Services.CnnToP6API.ProductionURL + RouteSufix;

                RestClient client = new RestClient(FinalURL);

                request = new RestRequest(FinalURL, Method.Put); //normalmente se usa PUT o PATCH para actualizar

                //agregar la info de seguridad del api, en este caso ApiKey
                request.AddHeader(Services.CnnToP6API.ApiKeyName, Services.CnnToP6API.ApiKeyValue);
                request.AddHeader(contentType, mimetype);

                //tenemos que serializar la clase para poderla enviar al API
                string SerialClass = JsonConvert.SerializeObject(this);

                request.AddBody(SerialClass, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                //TODO: guardar estos errores en una bitácora para su posterior análisis
                throw;
            }
        }

    }
}
