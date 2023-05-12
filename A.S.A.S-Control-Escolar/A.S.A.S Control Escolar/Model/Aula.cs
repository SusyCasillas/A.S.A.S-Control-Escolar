using System;
using System.Collections.Generic;

namespace A.S.A.S_Control_Escolar.Model;

public partial class Aula
{
    public long AulaId { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime FechaInsercion { get; set; }

    public bool? Active { get; set; }
}
