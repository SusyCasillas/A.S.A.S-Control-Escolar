using System;
using System.Collections.Generic;

namespace A.S.A.S_Control_Escolar.Model;

public partial class Materium
{
    public int MateriaId { get; set; }

    public string Nombre { get; set; } = null!;

    public byte GradoId { get; set; }

    public DateTime FechaInsercion { get; set; }

    public virtual Grado Grado { get; set; } = null!;

    public virtual ICollection<MateriaHorario> MateriaHorarios { get; } = new List<MateriaHorario>();
}
