using Microsoft.EntityFrameworkCore;

namespace A.S.A.S_Control_Escolar.Model.Response
{
    [Keyless]
    public class ResponserClasesTotalVista
    {
        public string? Materia { get; set; }
        public char? Aula { get; set; }
        public string? Dia { get; set; }
        public string? Horario { get; set; }
    }
}
