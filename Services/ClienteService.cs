using System.Net.Http.Json;
using Programacion2ClientesBlazor.Models;

namespace Programacion2ClientesBlazor.Services;

public class ClienteService
{
    private readonly HttpClient _httpClient;

    public ClienteService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Cliente>> ObtenerClientesAsync()
    {
        using var response = await _httpClient.GetAsync("api/clientes");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<List<Cliente>>()
            ?? new List<Cliente>();
    }

    public async Task<Cliente?> ObtenerClientePorIdAsync(int id)
    {
        using var response = await _httpClient.GetAsync($"api/clientes/{id}");

        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return null;
        }

        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Cliente>();
    }

    public async Task<ResultadoOperacion> CrearClienteAsync(Cliente cliente)
    {
        var dto = new CrearClienteDto
        {
            CUI = cliente.CUI,
            NIT = cliente.NIT,
            Nombres = cliente.Nombres,
            Apellidos = cliente.Apellidos,
            Direccion = cliente.Direccion,
            Telefono = cliente.Telefono,
            Fecha_Nacimiento = cliente.Fecha_Nacimiento
        };

        using var response =
            await _httpClient.PostAsJsonAsync("api/clientes", dto);

        if (response.IsSuccessStatusCode)
        {
            return new ResultadoOperacion
            {
                Exito = true,
                Mensaje = "Cliente registrado correctamente."
            };
        }

        return await LeerErrorAsync(
            response,
            "No fue posible registrar el cliente.");
    }

    public async Task<ResultadoOperacion> ActualizarClienteAsync(
        Cliente cliente)
    {
        var dto = new ActualizarClienteDto
        {
            CUI = cliente.CUI,
            NIT = cliente.NIT,
            Nombres = cliente.Nombres,
            Apellidos = cliente.Apellidos,
            Direccion = cliente.Direccion,
            Telefono = cliente.Telefono,
            Fecha_Nacimiento = cliente.Fecha_Nacimiento
        };

        using var response = await _httpClient.PutAsJsonAsync(
            $"api/clientes/{cliente.Id_cliente}",
            dto
        );

        if (response.IsSuccessStatusCode)
        {
            return new ResultadoOperacion
            {
                Exito = true,
                Mensaje = "Cliente actualizado correctamente."
            };
        }

        return await LeerErrorAsync(
            response,
            "No fue posible actualizar el cliente.");
    }

    public async Task<ResultadoOperacion> EliminarClienteAsync(int id)
    {
        using var response =
            await _httpClient.DeleteAsync($"api/clientes/{id}");

        if (response.IsSuccessStatusCode)
        {
            return new ResultadoOperacion
            {
                Exito = true,
                Mensaje = "Cliente eliminado correctamente."
            };
        }

        return await LeerErrorAsync(
            response,
            "No fue posible eliminar el cliente.");
    }

    private static async Task<ResultadoOperacion> LeerErrorAsync(
        HttpResponseMessage response,
        string mensajePredeterminado)
    {
        try
        {
            var error =
                await response.Content.ReadFromJsonAsync<ErrorApi>();

            return new ResultadoOperacion
            {
                Exito = false,
                Mensaje = string.IsNullOrWhiteSpace(error?.Mensaje)
                    ? mensajePredeterminado
                    : error.Mensaje
            };
        }
        catch
        {
            return new ResultadoOperacion
            {
                Exito = false,
                Mensaje = mensajePredeterminado
            };
        }
    }
}
