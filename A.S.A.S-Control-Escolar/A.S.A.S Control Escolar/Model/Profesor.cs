using System;
using System.Collections.Generic;

namespace A.S.A.S_Control_Escolar.Model;

public partial class Profesor
{
    public int ProfesorId { get; set; }

    public long? UsuarioId { get; set; }

    public string Correo { get; set; } = null!;

    public string? Especialidad { get; set; }

    public DateTime FechaInsercion { get; set; }

    public virtual ICollection<AsistenciaProfesor> AsistenciaProfesors { get; } = new List<AsistenciaProfesor>();

    public virtual ICollection<MateriaHorarioProfesor> MateriaHorarioProfesors { get; } = new List<MateriaHorarioProfesor>();
}
