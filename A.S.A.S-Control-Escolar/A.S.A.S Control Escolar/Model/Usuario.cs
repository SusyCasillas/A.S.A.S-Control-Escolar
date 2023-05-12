using System;
using System.Collections.Generic;

namespace A.S.A.S_Control_Escolar.Model;

public partial class Usuario
{
    public long UsuarioId { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public byte Edad { get; set; }

    public string? Foto { get; set; }

    public DateTime? FechaInsercion { get; set; }

    public virtual ICollection<Administradore> Administradores { get; } = new List<Administradore>();
}
