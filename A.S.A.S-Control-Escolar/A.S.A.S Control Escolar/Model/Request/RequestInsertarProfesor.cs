using Microsoft.EntityFrameworkCore;

namespace A.S.A.S_Control_Escolar.Model.Request
{
    [Keyless]
    public class RequestInsertarProfesor
    {
        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
        public string? Edad { get; set; }
        public string? Especialidad { get; set; }
    }
}
