# Programacion2ClientesBlazor

Aplicación web desarrollada con **Blazor WebAssembly sobre .NET 10** para administrar clientes consumiendo la API REST `Programacion2ClientesAPI`.

Blazor no accede directamente a MySQL. Toda operación se realiza mediante `HttpClient` contra la API.

## Arquitectura

```text
Usuario
   ↓
Blazor WebAssembly
   ↓
ClienteService
   ↓ HTTP / JSON
Programacion2ClientesAPI
   ↓
Entity Framework Core
   ↓
MySQL
```

## Estructura

```text
Programacion2ClientesBlazor/
├── Layout/
│   ├── MainLayout.razor
│   └── NavMenu.razor
├── Models/
│   ├── Cliente.cs
│   ├── CrearClienteDto.cs
│   ├── ActualizarClienteDto.cs
│   ├── ResultadoOperacion.cs
│   └── ErrorApi.cs
├── Pages/
│   ├── Home.razor
│   └── Clientes.razor
├── Services/
│   └── ClienteService.cs
├── wwwroot/
├── App.razor
├── Program.cs
└── Programacion2ClientesBlazor.csproj
```

## Funcionalidades

- Visualizar clientes.
- Crear clientes.
- Editar clientes.
- Eliminar clientes.
- Actualizar automáticamente el listado tras cada operación.
- Mostrar mensajes devueltos por la API.
- Validar datos mediante `DataAnnotations`.
- Utilizar Bootstrap para tabla, formularios, alertas, botones, spinners y ventanas modales.

## API consumida

Dirección utilizada durante el desarrollo:

```text
http://localhost:5169/
```

Endpoints:

| Método | Endpoint |
|---|---|
| GET | `/api/clientes` |
| GET | `/api/clientes/{id}` |
| POST | `/api/clientes` |
| PUT | `/api/clientes/{id}` |
| DELETE | `/api/clientes/{id}` |

## Ejecutar

Primero debe estar ejecutándose la API.

Después:

```bash
dotnet restore
dotnet build
dotnet run
```

En el entorno utilizado durante el desarrollo:

```text
http://localhost:5122
```

Módulo de clientes:

```text
http://localhost:5122/clientes
```

## Validaciones

La interfaz valida, entre otros:

- CUI obligatorio y de 13 dígitos.
- NIT obligatorio.
- Nombres y apellidos obligatorios.
- Teléfono de 8 dígitos cuando se proporciona.
- Fecha de nacimiento obligatoria.

La API vuelve a validar los datos y controla duplicados de CUI/NIT y fechas no válidas.

## Repositorios

Blazor:

```text
https://github.com/abralc/Programacion2ClientesBlazor
```

API:

```text
https://github.com/abralc/Programacion2ClientesAPI
```

## Autor

**Abraham López**

Proyecto académico de **Programación II**.


## Validaciones de campos

- CUI: exactamente 13 dígitos; el campo bloquea letras y limita la longitud.
- NIT: únicamente dígitos, entre 8 y 15 caracteres.
- Teléfono: exactamente 8 dígitos; el campo bloquea letras y limita la longitud.
- Fecha de nacimiento: no permite fechas futuras.
- Los errores de la API al crear o editar se muestran dentro del modal activo.
