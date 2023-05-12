using System;
using System.Collections.Generic;

namespace A.S.A.S_Control_Escolar.Model;

public partial class MateriaHorarioProfesorAlumno
{
    public int MateriaHorarioProfesorAlumnoId { get; set; }

    public int? MateriaHorarioProfesorId { get; set; }

    public int? AlumnoId { get; set; }

    public DateTime FechaInsercion { get; set; }

    public DateTime? FechaBaja { get; set; }

    public byte? RazonBajaId { get; set; }

    public virtual ICollection<Asistencium> Asistencia { get; } = new List<Asistencium>();

    public virtual RazonBaja? RazonBaja { get; set; }
}
