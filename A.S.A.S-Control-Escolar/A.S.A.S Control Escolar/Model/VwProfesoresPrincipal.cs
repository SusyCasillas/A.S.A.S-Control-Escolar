using System;
using System.Collections.Generic;

namespace A.S.A.S_Control_Escolar.Model;

public partial class VwProfesoresPrincipal
{
    public int ProfesorId { get; set; }

    public long UsuarioId { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public byte Edad { get; set; }

    public string? Foto { get; set; }
}
