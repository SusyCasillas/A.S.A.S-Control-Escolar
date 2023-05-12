using System;
using System.Collections.Generic;

namespace A.S.A.S_Control_Escolar.Model;

public partial class Horario
{
    public int HorarioId { get; set; }

    public string Descripcion { get; set; } = null!;

    public DateTime FechaInsercion { get; set; }

    public virtual ICollection<MateriaHorario> MateriaHorarios { get; } = new List<MateriaHorario>();
}
