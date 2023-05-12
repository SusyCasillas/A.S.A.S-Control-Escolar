using System;
using System.Collections.Generic;

namespace A.S.A.S_Control_Escolar.Model;

public partial class VwVistaClaseParaAlumno
{
    public string? CodigoClase { get; set; }

    public string Profesor { get; set; } = null!;

    public string NombreMateria { get; set; } = null!;

    public string NombreHorario { get; set; } = null!;

    public string Aula { get; set; } = null!;

    public string DiaClase { get; set; } = null!;

    public string? LugaresDsiponibles { get; set; }
}
