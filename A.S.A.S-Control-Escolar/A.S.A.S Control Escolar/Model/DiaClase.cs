using System;
using System.Collections.Generic;

namespace A.S.A.S_Control_Escolar.Model;

public partial class DiaClase
{
    public byte DiaClaseId { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime FechaInsercion { get; set; }
}
