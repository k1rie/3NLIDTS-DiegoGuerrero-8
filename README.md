# Actividad 08 - Insertando registros a la Base de Datos (Formulario Vr3) · C# Windows Forms

Programación Avanzada · 3° "N" · LIDTS · UNACH

Formulario de registro (nombre, apellidos, teléfono, edad, estatura y género) que valida cada campo y,
al pulsar **Guardar**, agrega el registro al archivo `Documentos/3NAgoDic26.txt` y lo inserta en la tabla
`BasePA` de MySQL.

## Requisitos
- .NET SDK 10 (Windows)
- MySQL Server en `localhost:3306`
- Paquete NuGet `MySql.Data` (se restaura solo al compilar)

## Ejecutar
1. Crea la base de datos y la tabla con `bd/BasePA.sql` (MySQL Workbench o `mysql -u root -p < bd/BasePA.sql`).
2. Si tu usuario/contraseña o el nombre de la base son otros, cámbialos en `SQLConection` dentro de `Form1.cs`.
3. Abre la solución en Visual Studio y pulsa **F5**, o en la terminal:

```
dotnet run
```
