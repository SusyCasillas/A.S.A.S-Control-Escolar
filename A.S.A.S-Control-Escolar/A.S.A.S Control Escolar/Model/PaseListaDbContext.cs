using System;
using System.Collections.Generic;
using A.S.A.S_Control_Escolar.Model.Response;
using Microsoft.EntityFrameworkCore;

namespace A.S.A.S_Control_Escolar.Model;

public partial class PaseListaDbContext : DbContext
{
    public PaseListaDbContext()
    {
    }

    public PaseListaDbContext(DbContextOptions<PaseListaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administradore> Administradores { get; set; }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<AsistenciaProfesor> AsistenciaProfesors { get; set; }

    public virtual DbSet<Asistencium> Asistencia { get; set; }

    public virtual DbSet<Aula> Aulas { get; set; }

    public virtual DbSet<CredencialAcceso> CredencialAccesos { get; set; }

    public virtual DbSet<DiaClase> DiaClases { get; set; }

    public virtual DbSet<Grado> Grados { get; set; }

    public virtual DbSet<Horario> Horarios { get; set; }

    public virtual DbSet<MateriaHorario> MateriaHorarios { get; set; }

    public virtual DbSet<MateriaHorarioProfesor> MateriaHorarioProfesors { get; set; }

    public virtual DbSet<MateriaHorarioProfesorAlumno> MateriaHorarioProfesorAlumnos { get; set; }

    public virtual DbSet<Materium> Materia { get; set; }

    public virtual DbSet<Profesor> Profesors { get; set; }

    public virtual DbSet<RazonBaja> RazonBajas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<VwAlumnosPrincipal> VwAlumnosPrincipals { get; set; }

    public virtual DbSet<VwClasesDiaVistum> VwClasesDiaVista { get; set; }

    public virtual DbSet<VwClasesSinProfesorAsginado> VwClasesSinProfesorAsginados { get; set; }

    public virtual DbSet<VwProfesoresPrincipal> VwProfesoresPrincipals { get; set; }

    public virtual DbSet<VwVistaClaseParaAlumno> VwVistaClaseParaAlumnos { get; set; }

    public virtual DbSet<VwVistasPrincipalClase> VwVistasPrincipalClases { get; set; }

    public virtual DbSet<LoginResponse> SpLogin { get; set; }

    public virtual DbSet<ResponseInsertarAsistencia> SpInsertarAsistencia { get; set; }

    public virtual DbSet<ResponseRegistrarAlumno> SpRegistrarAlumnoClase { get; set; }

    public virtual DbSet<ResponseVerMisMaterias> SpVerMisMaterias { get; set; }

    public virtual DbSet<ResponseInsertarAlumno> SpInsertarAlumno { get; set; }

    public virtual DbSet<ResponseInsertarProfesor> SpInsertarProfesor { get; set; }

    public virtual DbSet<ResponseInsertarMateria> SpInsertarMateria { get; set; }

    public virtual DbSet<ResponserClasesTotalVista> SpVistaClaseTotal { get; set; }

    public virtual DbSet<ResponseInsertarMaestroClase> SpInsertarMaestroClase { get; set; }

    public virtual DbSet<ResponseRegistrarHorarioEnMateria> SpRegistrarHorarioEnMateria { get; set; }

    public virtual DbSet<ResponseVistaAlumnosAsistenciaCodigoClase> SpVistaAlumnosCodigoClase { get; set; }

    public virtual DbSet<ResponseProcedureUniversal> SpInsertarAsistencioaProfesor { get; set; }

    public virtual DbSet<ResponseProcedureUniversal> SpBajaClaseAlumno { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
        IConfiguration _configuration = builder.Build();
        string cs = _configuration?.GetConnectionString("PrdlConnection");
        Console.WriteLine("Cadena de conexión traida desde JSON " + cs);
        optionsBuilder.UseSqlServer(cs);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administradore>(entity =>
        {
            entity.HasKey(e => e.AdministradoresId).HasName("PK__Administ__FBCF390EFE643214");

            entity.ToTable(tb => tb.HasTrigger("Tr_Insertar_Credenciales_Administrador"));

            entity.Property(e => e.Correo).HasMaxLength(150);
            entity.Property(e => e.FechaInsercion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Administradores)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("Fk_Administrator_UsuarioId");
        });

        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.AlumnoId).HasName("PK__Alumno__90A6AA13F55C8460");

            entity.ToTable("Alumno", tb => tb.HasTrigger("Tr_Insertar_Credenciales_Alumno"));

            entity.Property(e => e.AlumnoId).ValueGeneratedNever();
            entity.Property(e => e.FechaInsercion).HasColumnType("datetime");
        });

        modelBuilder.Entity<AsistenciaProfesor>(entity =>
        {
            entity.HasKey(e => e.AsistenciaProfesorId).HasName("PK__Asistenc__306B8630C2E85CC3");

            entity.ToTable("AsistenciaProfesor");

            entity.Property(e => e.Asistio).HasDefaultValueSql("((0))");
            entity.Property(e => e.FechaAsistencia)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaClase)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.MateriaHorarioProfesor).WithMany(p => p.AsistenciaProfesors)
                .HasForeignKey(d => d.MateriaHorarioProfesorId)
                .HasConstraintName("Fk_AsistenciaProfesor_MateriaHorarioProfesorId");

            entity.HasOne(d => d.Profesor).WithMany(p => p.AsistenciaProfesors)
                .HasForeignKey(d => d.ProfesorId)
                .HasConstraintName("Fk_AsistenciaProfesor_ProfesorId");
        });

        modelBuilder.Entity<Asistencium>(entity =>
        {
            entity.HasKey(e => e.AsistenciaId).HasName("PK__Asistenc__72710FA581F3DBFC");

            entity.Property(e => e.FechaAsistencia).HasColumnType("datetime");
            entity.Property(e => e.FechaClase).HasColumnType("datetime");

            entity.HasOne(d => d.MateriaHorarioProfesorAlumno).WithMany(p => p.Asistencia)
                .HasForeignKey(d => d.MateriaHorarioProfesorAlumnoId)
                .HasConstraintName("FK_MateriaHorarioProfesorAlumnoId_MateriaHorarioProfesorAlumno");
        });

        modelBuilder.Entity<Aula>(entity =>
        {
            entity.HasKey(e => e.AulaId).HasName("PK__Aula__A8529BF826AC0BD5");

            entity.ToTable("Aula");

            entity.Property(e => e.FechaInsercion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(20);
        });

        modelBuilder.Entity<CredencialAcceso>(entity =>
        {
            entity.HasKey(e => e.CredencialesAccesoId).HasName("PK__Credenci__D46CD889D0D559DC");

            entity.ToTable("CredencialAcceso", "Security");

            entity.Property(e => e.FechaInsercion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<DiaClase>(entity =>
        {
            entity.HasKey(e => e.DiaClaseId).HasName("PK__DiaClase__0622A7CF2FAB4EBC");

            entity.ToTable("DiaClase");

            entity.Property(e => e.DiaClaseId).ValueGeneratedOnAdd();
            entity.Property(e => e.FechaInsercion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(15);
        });

        modelBuilder.Entity<Grado>(entity =>
        {
            entity.HasKey(e => e.GradoId).HasName("PK__Grado__5A8DF6D40064AEA0");

            entity.ToTable("Grado");

            entity.Property(e => e.GradoId).ValueGeneratedOnAdd();
            entity.Property(e => e.FechaInsercion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(150);
        });

        modelBuilder.Entity<Horario>(entity =>
        {
            entity.HasKey(e => e.HorarioId).HasName("PK__Horario__BB881B7EC16877EE");

            entity.ToTable("Horario");

            entity.Property(e => e.Descripcion).HasMaxLength(90);
            entity.Property(e => e.FechaInsercion).HasColumnType("datetime");
        });

        modelBuilder.Entity<MateriaHorario>(entity =>
        {
            entity.HasKey(e => e.MateriaHorarioId).HasName("PK__MateriaH__6E57D44FB63D5BFE");

            entity.ToTable("MateriaHorario");

            entity.Property(e => e.FechaInsercion).HasColumnType("datetime");

            entity.HasOne(d => d.Horario).WithMany(p => p.MateriaHorarios)
                .HasForeignKey(d => d.HorarioId)
                .HasConstraintName("FK_HorarioId_Horario_MateriaHorario");

            entity.HasOne(d => d.Materia).WithMany(p => p.MateriaHorarios)
                .HasForeignKey(d => d.MateriaId)
                .HasConstraintName("FK_MateriaId_Materia_MateriaHorario");
        });

        modelBuilder.Entity<MateriaHorarioProfesor>(entity =>
        {
            entity.HasKey(e => e.MateriaHorarioProfesorId).HasName("PK__MateriaH__7981CCC57235D9F5");

            entity.ToTable("MateriaHorarioProfesor");

            entity.Property(e => e.FechaInsercion).HasColumnType("datetime");

            entity.HasOne(d => d.Profesor).WithMany(p => p.MateriaHorarioProfesors)
                .HasForeignKey(d => d.ProfesorId)
                .HasConstraintName("FK_ProfesorId_Profesor_MateriaHorarioProfesor");
        });

        modelBuilder.Entity<MateriaHorarioProfesorAlumno>(entity =>
        {
            entity.HasKey(e => e.MateriaHorarioProfesorAlumnoId).HasName("PK__MateriaH__1A7546083BA28E37");

            entity.ToTable("MateriaHorarioProfesorAlumno");

            entity.Property(e => e.FechaBaja)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaInsercion).HasColumnType("datetime");

            entity.HasOne(d => d.RazonBaja).WithMany(p => p.MateriaHorarioProfesorAlumnos)
                .HasForeignKey(d => d.RazonBajaId)
                .HasConstraintName("Fk_RazonBaja_RazonBajaId");
        });

        modelBuilder.Entity<Materium>(entity =>
        {
            entity.HasKey(e => e.MateriaId).HasName("PK__Materia__0D019DE159697E08");

            entity.Property(e => e.FechaInsercion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(60);

            entity.HasOne(d => d.Grado).WithMany(p => p.Materia)
                .HasForeignKey(d => d.GradoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GradoId_Grado_Materia");
        });

        modelBuilder.Entity<Profesor>(entity =>
        {
            entity.HasKey(e => e.ProfesorId).HasName("PK__Profesor__4DF3F0C88C77E818");

            entity.ToTable("Profesor", tb => tb.HasTrigger("Tr_Insertar_Credenciales_Profesor"));

            entity.Property(e => e.Correo).HasMaxLength(90);
            entity.Property(e => e.Especialidad).HasMaxLength(100);
            entity.Property(e => e.FechaInsercion).HasColumnType("datetime");
        });

        modelBuilder.Entity<RazonBaja>(entity =>
        {
            entity.HasKey(e => e.RazonBajaId).HasName("PK__RazonBaj__94BDE7BF14289B2F");

            entity.ToTable("RazonBaja");

            entity.Property(e => e.RazonBajaId).ValueGeneratedOnAdd();
            entity.Property(e => e.DescripcionRazon).HasMaxLength(25);
            entity.Property(e => e.FechaInsercion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuario__2B3DE7B8CC4D917A");

            entity.ToTable("Usuario");

            entity.Property(e => e.Apellidos).HasMaxLength(30);
            entity.Property(e => e.FechaInsercion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Foto).HasMaxLength(400);
            entity.Property(e => e.Nombres).HasMaxLength(30);
        });

        modelBuilder.Entity<VwAlumnosPrincipal>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Vw_Alumnos_Principal");

            entity.Property(e => e.Apellidos).HasMaxLength(30);
            entity.Property(e => e.Foto).HasMaxLength(400);
            entity.Property(e => e.Nombres).HasMaxLength(30);
        });

        modelBuilder.Entity<VwClasesDiaVistum>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Vw_Clases_Dia_Vista");

            entity.Property(e => e.Aula).HasMaxLength(20);
            entity.Property(e => e.Dia).HasMaxLength(15);
            entity.Property(e => e.Hora).HasMaxLength(90);
            entity.Property(e => e.IdClase)
                .HasMaxLength(151)
                .IsUnicode(false);
            entity.Property(e => e.Materia).HasMaxLength(60);
        });

        modelBuilder.Entity<VwClasesSinProfesorAsginado>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Vw_Clases_Sin_Profesor_Asginado");

            entity.Property(e => e.Aula).HasMaxLength(20);
            entity.Property(e => e.CodigoClase)
                .HasMaxLength(121)
                .IsUnicode(false);
            entity.Property(e => e.DiaClase).HasMaxLength(15);
            entity.Property(e => e.NombreHorario).HasMaxLength(90);
            entity.Property(e => e.NombreMateria).HasMaxLength(60);
        });

        modelBuilder.Entity<VwProfesoresPrincipal>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Vw_Profesores_Principal");

            entity.Property(e => e.Apellidos).HasMaxLength(30);
            entity.Property(e => e.Correo).HasMaxLength(90);
            entity.Property(e => e.Foto).HasMaxLength(400);
            entity.Property(e => e.Nombres).HasMaxLength(30);
        });

        modelBuilder.Entity<VwVistaClaseParaAlumno>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Vw_Vista_Clase_Para_Alumnos");

            entity.Property(e => e.Aula).HasMaxLength(20);
            entity.Property(e => e.CodigoClase)
                .HasMaxLength(151)
                .IsUnicode(false);
            entity.Property(e => e.DiaClase).HasMaxLength(15);
            entity.Property(e => e.LugaresDsiponibles)
                .HasMaxLength(61)
                .IsUnicode(false);
            entity.Property(e => e.NombreHorario).HasMaxLength(90);
            entity.Property(e => e.NombreMateria).HasMaxLength(60);
            entity.Property(e => e.Profesor).HasMaxLength(61);
        });

        modelBuilder.Entity<VwVistasPrincipalClase>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Vw_Vistas_Principal_Clase");

            entity.Property(e => e.Aula).HasMaxLength(20);
            entity.Property(e => e.CodigoClase)
                .HasMaxLength(121)
                .IsUnicode(false);
            entity.Property(e => e.DiaClase).HasMaxLength(15);
            entity.Property(e => e.NombreHorario).HasMaxLength(90);
            entity.Property(e => e.NombreMateria).HasMaxLength(60);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
