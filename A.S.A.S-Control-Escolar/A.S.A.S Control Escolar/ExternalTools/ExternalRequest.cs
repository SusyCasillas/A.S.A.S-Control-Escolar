using A.S.A.S_Control_Escolar.Model;
using A.S.A.S_Control_Escolar.Model.Response;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace A.S.A.S_Control_Escolar.ExternalTools
{
    public class ExternalRequest
    {
        public static async Task PostRequest(List<ResponseVistaAlumnosAsistenciaCodigoClase> responseVistaAlumnos)
        {
            HttpClient client = new();
            var values = new Dictionary<string, string>
            {
               { "contentJson", JsonSerializer.Serialize(responseVistaAlumnos)},
               { "tkn", "Ma. Daniela" }
            };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync(
                   "http://localhost/FEC/PHP/ValidateFileControler.php", content);
            var result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
        }
        public static async Task PostRequest(List<VwClasesDiaVistum> vistaClaseAula, string nombreAula)
        {
            HttpClient client = new();
            var values = new Dictionary<string, string>
            {
               { "contentFile", JsonSerializer.Serialize(vistaClaseAula)},
               { "fileName", nombreAula}
            };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync(
                   "http://localhost/FEC/PHP/CreateFileAulaController.php", content);
            var result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
        }
        static async Task<HttpResponseMessage> Request(HttpMethod pMethod, string pUrl, string pJsonContent, Dictionary<string, string> pHeaders,HttpClient _client)
        {
            var httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = pMethod;
            httpRequestMessage.RequestUri = new Uri(pUrl);
            httpRequestMessage.Headers.Add("Accept", "*/*");
            switch (pMethod.Method)
            {
                case "POST":
                    HttpContent httpContent = new StringContent(pJsonContent, Encoding.UTF8, "application/json");
                    httpRequestMessage.Content = httpContent;
                    break;

            }
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            return await _client.SendAsync(httpRequestMessage);
        }

    }
    class InfoRequest
    {
        public string? contentJson { get; set; }
        public string? tkn { get; set; }
    }
}
