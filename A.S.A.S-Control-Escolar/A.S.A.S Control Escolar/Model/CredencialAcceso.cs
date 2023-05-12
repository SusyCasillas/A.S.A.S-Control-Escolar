using System;
using System.Collections.Generic;

namespace A.S.A.S_Control_Escolar.Model;

public partial class CredencialAcceso
{
    public long CredencialesAccesoId { get; set; }

    public long? UsuarioId { get; set; }

    public byte[] Password { get; set; } = null!;

    public DateTime FechaInsercion { get; set; }
}
