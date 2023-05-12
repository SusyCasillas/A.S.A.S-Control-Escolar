using Microsoft.EntityFrameworkCore;

namespace A.S.A.S_Control_Escolar.Model.Response
{
    [Keyless]
    public class LoginResponse
    {
        public Int32 Rsp { get; set; }
        public string? Token { get; set; }
        public string? Username { get; set; }
        public Int32? UserType { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Imagen { get; set; }
        public string? Secciones { get; set; }
    }
}
