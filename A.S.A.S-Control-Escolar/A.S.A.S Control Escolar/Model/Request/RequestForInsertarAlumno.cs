using Microsoft.EntityFrameworkCore;

namespace A.S.A.S_Control_Escolar.Model.Request
{
    [Keyless]
    public class RequestForInsertarAlumno
    {
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public Int32? Edad { get; set; }
        public IFormFile? Foto { get; set; }
    }
}
