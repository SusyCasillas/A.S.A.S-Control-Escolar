using Microsoft.EntityFrameworkCore;

namespace A.S.A.S_Control_Escolar.Model.Response
{
    [Keyless]
    public class ResponseVistaAlumnosAsistenciaCodigoClase
    {
        public string? NumeroControl { get; set; }
        public string? NombreAlumno { get; set; }
        public DateTime? HoraLlegada { get; set; }
    }
}
