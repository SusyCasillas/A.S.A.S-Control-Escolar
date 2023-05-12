using System;
using System.Collections.Generic;

namespace A.S.A.S_Control_Escolar.Model;

public partial class Alumno
{
    public int AlumnoId { get; set; }

    public long UsuarioId { get; set; }

    public DateTime FechaInsercion { get; set; }
}
