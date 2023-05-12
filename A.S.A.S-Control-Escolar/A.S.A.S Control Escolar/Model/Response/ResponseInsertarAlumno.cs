using Microsoft.EntityFrameworkCore;

namespace A.S.A.S_Control_Escolar.Model.Response
{
    [Keyless]
    public class ResponseInsertarAlumno
    {
        public int? Rsp { get; set; }
        public string? Msg { get; set; }
    }
}
