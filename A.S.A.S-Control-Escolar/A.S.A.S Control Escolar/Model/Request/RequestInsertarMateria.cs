using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace A.S.A.S_Control_Escolar.Model.Request
{
    [Keyless]
    public class RequestInsertarMateria
    {
        [Required]
        public string? Nombre { get; set; }
        public string? NombreGrado { get; set; }
    }
}
