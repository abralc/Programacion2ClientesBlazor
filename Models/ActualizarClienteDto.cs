namespace Programacion2ClientesBlazor.Models;

public class ActualizarClienteDto
{
    public string CUI { get; set; } = string.Empty;
    public string NIT { get; set; } = string.Empty;
    public string Nombres { get; set; } = string.Empty;
    public string Apellidos { get; set; } = string.Empty;
    public string? Direccion { get; set; }
    public string? Telefono { get; set; }
    public DateTime Fecha_Nacimiento { get; set; }
}
