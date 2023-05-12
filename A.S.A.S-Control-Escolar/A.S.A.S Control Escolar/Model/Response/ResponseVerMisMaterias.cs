using Microsoft.EntityFrameworkCore;

namespace A.S.A.S_Control_Escolar.Model.Response
{
    [Keyless]
    public class ResponseVerMisMaterias
    {
        public string? CodigoClase { get; set; }
        public string? Dia { get; set; }
        public string? Horario { get; set; }
        public string? Materia { get; set; }
        public string? Profesor { get; set; }
    }
}
