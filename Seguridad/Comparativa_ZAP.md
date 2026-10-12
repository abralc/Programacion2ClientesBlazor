# Comparativa de resultados OWASP ZAP

Proyecto analizado: **Programacion2ClientesBlazor**

URL utilizada para el análisis:

```text
http://localhost:5122/clientes
```

## Resultado inicial

El primer análisis encontró tres tipos de alertas:

| Alerta encontrada | Riesgo | Corrección realizada | Resultado final |
|---|---|---|---|
| Cabecera Content Security Policy (CSP) no configurada | Medio | Se configuró `Content-Security-Policy` en el host ASP.NET Core de Blazor, limitando las fuentes permitidas e incorporando `frame-ancestors 'none'`. | Pendiente segundo análisis |
| Falta de cabecera Anti-Clickjacking | Medio | Se agregaron `X-Frame-Options: DENY` y `frame-ancestors 'none'` para impedir que la aplicación sea embebida en frames externos. | Pendiente segundo análisis |
| Falta encabezado X-Content-Type-Options | Bajo | Se agregó `X-Content-Type-Options: nosniff` a todas las respuestas HTTP servidas por el host. | Pendiente segundo análisis |

## Cabeceras adicionales incorporadas

También se agregaron:

- `Referrer-Policy: strict-origin-when-cross-origin`
- `Permissions-Policy: camera=(), microphone=(), geolocation=()`
- Se deshabilitó el encabezado identificador `Server: Kestrel`.

## Segundo análisis

Después de aplicar las correcciones:

1. Ejecutar la API en `http://localhost:5169`.
2. Ejecutar el host Blazor con:

```powershell
dotnet run --project Server/Programacion2ClientesBlazor.Server.csproj
```

3. Comprobar que la aplicación funcione en:

```text
http://localhost:5122/clientes
```

4. Ejecutar OWASP ZAP bajo condiciones similares al primer análisis.
5. Guardar el nuevo informe como:

```text
Seguridad/Informe_ZAP_Despues.html
```

6. Actualizar la columna **Resultado final** con el resultado real del segundo análisis.
