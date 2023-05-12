using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace A.S.A.S_Control_Escolar.Model.Response
{
    [Keyless]
    public class ResponseInsertarMateria
    {
        public Int32? Rsp { get; set; }
        public string? Msg { get; set; }
    }
}
