using System.ComponentModel.DataAnnotations;

namespace Service.Models
{
    public partial class Profesional
    {
        //normalmente los modelos van a ser publicos. Los modelos siempre van en SINGULAR
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "El campo Profesion es obligatorio.")]
        public string Profesion { get; set; } = null!;

        [Required(ErrorMessage = "El campo Matricula es obligatorio.")]
        public string Matricula { get; set; } = null!;

        [Required(ErrorMessage = "El campo Especialidad es obligatorio.")]
        public string Especialidad { get; set; } = null!;

        [EmailAddress(ErrorMessage = "El campo Email no tiene un formato válido.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "El campo Telefono es obligatorio.")]
        public string Telefono { get; set; } = null!;

        //Esto es una relacion de uno a muchos, un profesional puede tener muchos pacientes
        public virtual ICollection<Paciente?> Pacientes { get; set; } = new List<Paciente?>();

        public bool IsDeleted { get; set; } = false;
        public string? Imagen { get; set; } = string.Empty;
        public override string ToString()
        {
            return Nombre;
        }
    }
}
