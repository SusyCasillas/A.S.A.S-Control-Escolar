using System;
using System.Collections.Generic;

namespace A.S.A.S_Control_Escolar.Model;

public partial class VwClasesDiaVistum
{
    public string? IdClase { get; set; }

    public string Materia { get; set; } = null!;

    public string Aula { get; set; } = null!;

    public string Dia { get; set; } = null!;

    public string Hora { get; set; } = null!;
}
