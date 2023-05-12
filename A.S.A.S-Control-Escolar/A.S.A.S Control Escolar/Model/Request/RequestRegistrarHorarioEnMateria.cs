using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace A.S.A.S_Control_Escolar.Model.Request
{
    [Keyless]
    public class RequestRegistrarHorarioEnMateria
    {
        [Required]
        public string? NombreMateria { get; set; }
        [Required]
        public string? NombreHorario { get; set; }
        [Required]
        public string? NombreAula { get; set; }
        [Required]
        public string? NombreDia { get; set; }
        [Required]
        public Int32? LimiteCupo { get; set; }
    }
}
