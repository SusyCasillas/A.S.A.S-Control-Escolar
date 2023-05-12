using System;
using System.Collections.Generic;

namespace A.S.A.S_Control_Escolar.Model;

public partial class AsistenciaProfesor
{
    public long AsistenciaProfesorId { get; set; }

    public int? MateriaHorarioProfesorId { get; set; }

    public int? ProfesorId { get; set; }

    public bool? Asistio { get; set; }

    public DateTime? FechaClase { get; set; }

    public DateTime? FechaAsistencia { get; set; }

    public virtual MateriaHorarioProfesor? MateriaHorarioProfesor { get; set; }

    public virtual Profesor? Profesor { get; set; }
}
