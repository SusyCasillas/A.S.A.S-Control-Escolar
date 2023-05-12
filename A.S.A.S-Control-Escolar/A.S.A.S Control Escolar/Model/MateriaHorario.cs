using System;
using System.Collections.Generic;

namespace A.S.A.S_Control_Escolar.Model;

public partial class MateriaHorario
{
    public int MateriaHorarioId { get; set; }

    public int? MateriaId { get; set; }

    public int? HorarioId { get; set; }

    public long? AulaId { get; set; }

    public byte? DiaClaseId { get; set; }

    public int LimiteCupo { get; set; }

    public DateTime FechaInsercion { get; set; }

    public virtual Horario? Horario { get; set; }

    public virtual Materium? Materia { get; set; }
}
