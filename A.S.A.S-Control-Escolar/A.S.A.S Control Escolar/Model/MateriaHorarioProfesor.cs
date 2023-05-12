using System;
using System.Collections.Generic;

namespace A.S.A.S_Control_Escolar.Model;

public partial class MateriaHorarioProfesor
{
    public int MateriaHorarioProfesorId { get; set; }

    public int? MateriaHorarioId { get; set; }

    public int? ProfesorId { get; set; }

    public DateTime FechaInsercion { get; set; }

    public virtual ICollection<AsistenciaProfesor> AsistenciaProfesors { get; } = new List<AsistenciaProfesor>();

    public virtual Profesor? Profesor { get; set; }
}
