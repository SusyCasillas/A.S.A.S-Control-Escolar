using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace A.S.A.S_Control_Escolar.Model.Request
{
    [Keyless]
    public class RequestInsertarAsistenciaProfesor
    {
        [Required]
        public string? CodigoClase { get; set; }
        [Required]
        public string? NombreProfesor { get; set; }
    }
}
