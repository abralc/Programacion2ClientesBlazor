# Programacion2ClientesBlazor

Aplicación web desarrollada con **Blazor WebAssembly sobre .NET 10** para la administración de clientes.

La aplicación consume una **API REST externa** desarrollada previamente en ASP.NET Core y no accede directamente a la base de datos.

## Objetivo

Desarrollar un módulo de administración de clientes utilizando Blazor, Bootstrap y validaciones de formulario, consumiendo exclusivamente los endpoints expuestos por la API REST.

## Tecnologías utilizadas

- .NET 10
- Blazor WebAssembly
- ASP.NET Core
- Bootstrap
- C#
- HttpClient
- DataAnnotations
- API REST
- MySQL (accedido únicamente a través de la API)
- Visual Studio Code
- Git
- GitHub

## Arquitectura

```text
Blazor WebAssembly
        |
        | HTTP / JSON
        v
Programacion2ClientesAPI
        |
        | Entity Framework Core
        v
MySQL
```

La aplicación Blazor **no tiene acceso directo a MySQL**. Toda operación se realiza mediante la API REST.

## Funcionalidades

El módulo de clientes permite:

- Visualizar los clientes registrados.
- Agregar nuevos clientes.
- Modificar clientes existentes.
- Eliminar clientes.
- Actualizar automáticamente el listado después de cada operación.
- Mostrar mensajes de confirmación o error.
- Validar los datos ingresados en los formularios.
- Utilizar ventanas modales para crear, editar y eliminar clientes.

## Operaciones CRUD consumidas

| Operación              | Método HTTP | Endpoint             |
| ---------------------- | ----------- | -------------------- |
| Listar clientes        | GET         | `/api/clientes`      |
| Obtener cliente por ID | GET         | `/api/clientes/{id}` |
| Crear cliente          | POST        | `/api/clientes`      |
| Actualizar cliente     | PUT         | `/api/clientes/{id}` |
| Eliminar cliente       | DELETE      | `/api/clientes/{id}` |

## Modelo Cliente

La aplicación trabaja con los siguientes campos:

| Campo              | Descripción                         |
| ------------------ | ----------------------------------- |
| `Id_cliente`       | Identificador único del cliente     |
| `CUI`              | Código Único de Identificación      |
| `NIT`              | Número de Identificación Tributaria |
| `Nombres`          | Nombres del cliente                 |
| `Apellidos`        | Apellidos del cliente               |
| `Direccion`        | Dirección del cliente               |
| `Telefono`         | Número de teléfono                  |
| `Fecha_Nacimiento` | Fecha de nacimiento                 |

## Estructura principal del proyecto

```text
Programacion2ClientesBlazor/
│
├── Layout/
│   ├── MainLayout.razor
│   └── NavMenu.razor
│
├── Models/
│   └── Cliente.cs
│
├── Pages/
│   └── Clientes.razor
│
├── Services/
│   └── ClienteService.cs
│
├── wwwroot/
│
├── App.razor
├── Program.cs
├── _Imports.razor
├── Programacion2ClientesBlazor.csproj
└── README.md
```

## Servicio de clientes

`ClienteService.cs` utiliza `HttpClient` para consumir la API REST.

Ejemplo conceptual:

```csharp
await _httpClient.GetFromJsonAsync<List<Cliente>>("api/clientes");
```

La dirección base de la API se configura en `Program.cs`.

Ejemplo local:

```csharp
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("http://localhost:5169/")
});
```

## Requisitos previos

Antes de ejecutar Blazor, la API debe estar iniciada.

Repositorio de la API:

```text
https://github.com/abralc/Programacion2ClientesAPI
```

Ejemplo de dirección local de la API:

```text
http://localhost:5169
```

## Ejecutar la aplicación

Clonar el repositorio:

```bash
git clone git@github.com:abralc/Programacion2ClientesBlazor.git
```

Entrar al proyecto:

```bash
cd Programacion2ClientesBlazor
```

Restaurar dependencias:

```bash
dotnet restore
```

Compilar:

```bash
dotnet build
```

Ejecutar:

```bash
dotnet run
```

En el entorno de desarrollo utilizado para este proyecto, Blazor se ejecuta en:

```text
http://localhost:5122
```

El módulo de clientes está disponible en:

```text
http://localhost:5122/clientes
```

> El puerto puede cambiar según la configuración local de `launchSettings.json`.

## Validaciones

Los formularios utilizan `DataAnnotations` junto con los componentes de formulario de Blazor.

Entre las validaciones se incluyen:

- CUI obligatorio.
- CUI con longitud definida.
- NIT obligatorio.
- Nombres obligatorios.
- Apellidos obligatorios.
- Fecha de nacimiento obligatoria.
- Límites de longitud para los campos de texto.

Los mensajes de validación se muestran dentro de los formularios utilizados en los modales.

## Bootstrap

La interfaz utiliza Bootstrap para:

- Diseño responsive.
- Tabla de clientes.
- Botones.
- Alertas.
- Spinners.
- Formularios.
- Ventanas modales.
- Distribución mediante grid.

## Flujo de actualización

Después de crear, editar o eliminar un cliente, la aplicación vuelve a consultar la API para actualizar la información mostrada.

```text
Operación CRUD
      |
      v
API REST
      |
      v
CargarClientes()
      |
      v
Tabla actualizada
```

## Repositorios

Aplicación Blazor:

```text
https://github.com/abralc/Programacion2ClientesBlazor
```

API REST:

```text
https://github.com/abralc/Programacion2ClientesAPI
```

## Autor

**Abraham López**

Proyecto desarrollado para el curso de **Programación II**.
