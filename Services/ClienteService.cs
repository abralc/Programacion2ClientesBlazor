using System.Net.Http.Json;
using Programacion2ClientesBlazor.Models;

namespace Programacion2ClientesBlazor.Services
{
    public class ClienteService
    {
        private readonly HttpClient _httpClient;

        public ClienteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: obtener todos los clientes
        public async Task<List<Cliente>> ObtenerClientesAsync()
        {
            return await _httpClient
                .GetFromJsonAsync<List<Cliente>>("api/clientes")
                ?? new List<Cliente>();
        }

        // GET: obtener cliente por ID
        public async Task<Cliente?> ObtenerClientePorIdAsync(int id)
        {
            return await _httpClient
                .GetFromJsonAsync<Cliente>($"api/clientes/{id}");
        }

        // POST: crear cliente
        public async Task<bool> CrearClienteAsync(Cliente cliente)
        {
            var response = await _httpClient.PostAsJsonAsync(
                "api/clientes",
                cliente
            );

            return response.IsSuccessStatusCode;
        }

        // PUT: actualizar cliente
        public async Task<bool> ActualizarClienteAsync(Cliente cliente)
        {
            var response = await _httpClient.PutAsJsonAsync(
                $"api/clientes/{cliente.Id_cliente}",
                cliente
            );

            return response.IsSuccessStatusCode;
        }

        // DELETE: eliminar cliente
        public async Task<bool> EliminarClienteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(
                $"api/clientes/{id}"
            );

            return response.IsSuccessStatusCode;
        }
    }
}