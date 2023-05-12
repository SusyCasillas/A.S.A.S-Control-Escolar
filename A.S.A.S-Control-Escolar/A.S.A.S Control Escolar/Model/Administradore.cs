using System;
using System.Collections.Generic;

namespace A.S.A.S_Control_Escolar.Model;

public partial class Administradore
{
    public int AdministradoresId { get; set; }

    public long? UsuarioId { get; set; }

    public string Correo { get; set; } = null!;

    public DateTime? FechaInsercion { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
