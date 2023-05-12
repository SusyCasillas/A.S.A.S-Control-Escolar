using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace A.S.A.S_Control_Escolar.Model.Request
{
    [Keyless]
    public class RequestDesactivarClase
    {
        [Required]
        public string NombreAula { get; set; }
    }
}
