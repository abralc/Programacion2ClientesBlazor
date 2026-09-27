using System.ComponentModel.DataAnnotations;

namespace Programacion2ClientesBlazor.Models
{
    public class Cliente
    {
        public int Id_cliente { get; set; }

        [Required(ErrorMessage = "El CUI es obligatorio.")]
        [StringLength(13, MinimumLength = 13,
            ErrorMessage = "El CUI debe contener 13 caracteres.")]
        public string CUI { get; set; } = string.Empty;

        [Required(ErrorMessage = "El NIT es obligatorio.")]
        [StringLength(15)]
        public string NIT { get; set; } = string.Empty;

        [Required(ErrorMessage = "Los nombres son obligatorios.")]
        [StringLength(100)]
        public string Nombres { get; set; } = string.Empty;

        [Required(ErrorMessage = "Los apellidos son obligatorios.")]
        [StringLength(100)]
        public string Apellidos { get; set; } = string.Empty;

        [StringLength(250)]
        public string? Direccion { get; set; }

        [StringLength(20)]
        public string? Telefono { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        public DateTime Fecha_Nacimiento { get; set; } = DateTime.Today;
    }
}