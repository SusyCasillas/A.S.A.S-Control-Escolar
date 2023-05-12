using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace A.S.A.S_Control_Escolar.Model.Request
{
    [Keyless]
    public class RequestBajaAlumnoClase
    {
        [Required]
        public string? NombreAlumno { get; set; }
        [Required]
        public string? CodigoAlumno { get; set; }
        [Required]
        public string? RazonBaja { get; set; }
    }
}
