using System;
using System.Collections.Generic;

namespace A.S.A.S_Control_Escolar.Model;

public partial class RazonBaja
{
    public byte RazonBajaId { get; set; }

    public string DescripcionRazon { get; set; } = null!;

    public DateTime? FechaInsercion { get; set; }

    public virtual ICollection<MateriaHorarioProfesorAlumno> MateriaHorarioProfesorAlumnos { get; } = new List<MateriaHorarioProfesorAlumno>();
}
