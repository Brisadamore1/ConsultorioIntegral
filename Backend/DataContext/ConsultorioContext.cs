using Microsoft.EntityFrameworkCore;
using Service.Models;

namespace Backend.DataContext;

public partial class ConsultorioContext : DbContext
{
    public ConsultorioContext()
    {
    }

    public ConsultorioContext(DbContextOptions<ConsultorioContext> options) : base(options)
    {
    }

    public virtual DbSet<ContactoEmergencia> ContactosEmergencia { get; set; }
    public virtual DbSet<Deuda> Deudas { get; set; }
    public virtual DbSet<EstadoTurno> EstadosTurno { get; set; }
    public virtual DbSet<ModalidadPago> ModalidadesPago { get; set; }
    public virtual DbSet<Paciente> Pacientes { get; set; }
    public virtual DbSet<Pago> Pagos { get; set; }
    public virtual DbSet<Profesional> Profesionales { get; set; }
    public virtual DbSet<Sesion> Sesiones { get; set; }
    public virtual DbSet<Turno> Turnos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
            string? cadenaConexion = configuration.GetConnectionString("mysqlLocal");

            optionsBuilder.UseMySql(cadenaConexion, ServerVersion.AutoDetect(cadenaConexion));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        #region datos semilla
        //carga de datos semilla ContactoEmergencia
        modelBuilder.Entity<ContactoEmergencia>().HasData(
            new ContactoEmergencia() {
                Id = 1, 
                PacienteId = 1, 
                Nombre = "Alba Russo", 
                Relacion = "Madre", 
                Telefono= "3498487726" 
            },
            new ContactoEmergencia() { 
                Id = 2,
                PacienteId = 2, 
                Nombre = "Julia Urriaga", 
                Relacion = "Madre", 
                Telefono = "3498193565" },
            new ContactoEmergencia() { 
                Id = 3,
                PacienteId = 3, 
                Nombre = "Benjamín Ferro", 
                Relacion = "Padre", 
                Telefono = "349827446" }
            );

        //carga de datos semilla Deuda
        modelBuilder.Entity<Deuda>().HasData(
            new Deuda() { 
                Id = 1,
                PacienteId = 1, 
                ProfesionalId = 1, 
                Monto = 10000, 
                Fecha = DateTime.Now, 
                Descripcion = "Consulta inicial", 
                Cancelada = false },
            new Deuda() { 
                Id = 2, 
                PacienteId = 2, 
                ProfesionalId = 2, 
                Monto = 5000, 
                Fecha = DateTime.Now.AddDays(-10), 
                Descripcion = "Seguimiento", 
                Cancelada = true }
            );

        //carga de datos semilla EstadoTurno
        modelBuilder.Entity<EstadoTurno>().HasData(
            new EstadoTurno() { Id = 1, Estado = "Reservado" },
            new EstadoTurno() { Id = 2, Estado = "Confirmado" },
            new EstadoTurno() { Id = 3, Estado = "Cancelado" },
            new EstadoTurno() { Id = 4, Estado = "Atendido" },
            new EstadoTurno() { Id = 5, Estado = "Ausente" }
            );

        //carga de datos semilla ModalidadPago
        modelBuilder.Entity<ModalidadPago>().HasData(
            new ModalidadPago() { Id = 1, Modalidad = "Efectivo" },
            new ModalidadPago() { Id = 2, Modalidad = "Tarjeta de crédito" },
            new ModalidadPago() { Id = 3, Modalidad = "Tarjeta de débito" },
            new ModalidadPago() { Id = 4, Modalidad = "Transferencia" }
            );

        //carga de datos semilla Paciente
        modelBuilder.Entity<Paciente>().HasData(
            new Paciente() { 
                Id = 1, 
                Nombre = "Abril Costa", 
                FechaNacimiento = new DateTime(1999, 5, 15), 
                Dni = "37138426", 
                Telefono = "3498123456", 
                Email = "abrilcosta@gmail.com",
                Direccion = "Italia 4787",
                EsParticular = false,
                ObraSocial = "Sancor Salud",
                NumeroAfiliado = "265488245",
                ProfesionalId = 1
            },
            new Paciente() { 
                Id = 2, 
                Nombre = "Joaquín Vargas", 
                FechaNacimiento = new DateTime(1995, 8, 20), 
                Dni = "39420170", 
                Telefono = "3498234567", 
                Email = "joaquinvargas@gmail.com",
                Direccion = "Belgrano 2410",
                EsParticular = true,
                ObraSocial = "Particular",
                NumeroAfiliado = "",
                ProfesionalId = 1
            },
            new Paciente() { 
                Id = 3, 
                Nombre = "Emma Ferro", 
                FechaNacimiento = new DateTime(1995, 2, 18),
                Dni = "39421170", 
                Telefono = "3498232687", 
                Email = "emmaferro@gmail.com",
                Direccion = "25 de mayo 4254",
                EsParticular = true,
                ObraSocial = "Particular",
                NumeroAfiliado = "",
                ProfesionalId = 2
            }
            );

        //carga de datos semilla Pago
        modelBuilder.Entity<Pago>().HasData(
            new Pago() { 
                Id = 1, 
                SesionId = 1, 
                ModalidadPagoId = 1, 
                Monto = 20000, 
                Fecha = new DateTime(2025, 06, 24)
            },
            new Pago() { 
                Id = 2, 
                SesionId = 2, 
                ModalidadPagoId = 2,
                Monto = 22000,
                Fecha = new DateTime(2025, 06, 24)
            }
            );

        //carga de datos semilla Profesional
        modelBuilder.Entity<Profesional>().HasData(
            new Profesional() { 
                Id = 1, 
                Nombre = "Dr. Santiago Weber", 
                Matricula= "MAT. 4456",
                Especialidad = "Psicólogo", 
                Telefono = "3498114782", 
                Email = "webersantiago@gmail.com",
                Imagen = "https://consultoriointegral.azurewebsites.net/imagenes/psicologo.png"

            },
            new Profesional() { 
                Id = 2, 
                Nombre = "Dra. Valentina Urriaga",
                Matricula = "MAT.8015",
                Especialidad = "Psicóloga", 
                Telefono = "3498114789", 
                Email = "urriagavalentina@gmail.com",
                Imagen = "https://consultoriointegral.azurewebsites.net/imagenes/psicologa.png"
            }
            );
        //carga de datos semilla Sesion
        modelBuilder.Entity<Sesion>().HasData(
            new Sesion() { 
                Id = 1, 
                TurnoId = 1, 
                Notas = "Paciente se presentó puntual. Refirió sentirse ansioso por situaciones laborales. Se trabajó en identificar factores desencadenantes. Buena predisposición al diálogo.", 
                Honorarios = 20000,
                Pagado= true
            },
            new Sesion() { 
                Id = 2,
                TurnoId = 2, 
                Notas = "Paciente mencionó recuerdos de infancia que impactaron emocionalmente. Profundizar en vínculos afectivos en la próxima sesión.", 
                Honorarios = 20000,
                Pagado= true }
            );
        //carga de datos semilla Turno
        modelBuilder.Entity<Turno>().HasData(
            new Turno() { 
                Id = 1, 
                PacienteId = 1, 
                ProfesionalId = 1, 
                FechaHora = new DateTime(2025, 05, 15, 10, 0, 0), 
                DuracionMinutos = 60, 
                EstadoTurnoId = 4, 
                CanceladoPorProfesional = false, 
                MotivoCancelacion = null 
            },
            new Turno() { 
                Id = 2,
                PacienteId = 2, 
                ProfesionalId = 2, 
                FechaHora = new DateTime(2025, 06, 16, 11, 0, 0), 
                DuracionMinutos = 50,
                EstadoTurnoId = 4, 
                CanceladoPorProfesional = false, 
                MotivoCancelacion = null 
            }
            );
        #endregion

        //configuramos los query filters para que no trigan los registros marcados como eliminados. Son los mecanimos por el cual se indica que un registro esta eliminado sin borrarlo fisicamente de la base de datos.
        modelBuilder.Entity<ContactoEmergencia>().HasQueryFilter(c => !c.Eliminado);
        modelBuilder.Entity<Deuda>().HasQueryFilter(e => !e.Eliminado);
        modelBuilder.Entity<EstadoTurno>().HasQueryFilter(e => !e.Eliminado);
        modelBuilder.Entity<ModalidadPago>().HasQueryFilter(m => !m.Eliminado);
        modelBuilder.Entity<Paciente>().HasQueryFilter(pc => !pc.Eliminado);
        modelBuilder.Entity<Pago>().HasQueryFilter(p => !p.Eliminado);
        modelBuilder.Entity<Profesional>().HasQueryFilter(pr => !pr.Eliminado);
        modelBuilder.Entity<Sesion>().HasQueryFilter(s => !s.Eliminado);
        modelBuilder.Entity<Turno>().HasQueryFilter(t => !t.Eliminado);

    }
}
