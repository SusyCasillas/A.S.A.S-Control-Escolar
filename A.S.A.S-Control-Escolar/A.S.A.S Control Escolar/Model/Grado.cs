using System;
using System.Collections.Generic;

namespace A.S.A.S_Control_Escolar.Model;

public partial class Grado
{
    public byte GradoId { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime FechaInsercion { get; set; }

    public virtual ICollection<Materium> Materia { get; } = new List<Materium>();
}
