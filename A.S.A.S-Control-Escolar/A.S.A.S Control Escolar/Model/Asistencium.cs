using System;
using System.Collections.Generic;

namespace A.S.A.S_Control_Escolar.Model;

public partial class Asistencium
{
    public int AsistenciaId { get; set; }

    public int? MateriaHorarioProfesorAlumnoId { get; set; }

    public int? AlumnoId { get; set; }

    public bool? Asistio { get; set; }

    public DateTime FechaClase { get; set; }

    public DateTime? FechaAsistencia { get; set; }

    public virtual MateriaHorarioProfesorAlumno? MateriaHorarioProfesorAlumno { get; set; }
}
