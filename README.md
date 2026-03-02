# RestaurantProject – Sistema Web de Reservas para Restaurante

## Descripción del Proyecto

**RestaurantProject** es una aplicación web desarrollada en **ASP.NET Core** bajo el patrón de arquitectura **MVC (Model – View – Controller)**. El sistema permite registrar reservas de mesa para un restaurante mediante una interfaz web que captura el nombre del cliente, la fecha, la hora y el número de comensales.

La información es almacenada en una base de datos **SQL Server** local utilizando conexión directa mediante **ADO.NET**.

> Este proyecto forma parte del **Proyecto Integrador de la Metodología DevOps** y documenta el avance funcional correspondiente a la fase actual de desarrollo.

---

## Objetivo del Proyecto

Desarrollar una aplicación web que permita digitalizar el proceso de registro de reservas en un restaurante, sustituyendo los métodos manuales como llamadas telefónicas o mensajes, mejorando la organización y el control de la información.

---

## Arquitectura del Sistema

El sistema está desarrollado bajo el patrón **MVC (Model – View – Controller)**, lo que permite una clara separación de responsabilidades:

### Model
Representa la entidad `Reserva` y define la estructura de los datos almacenados en la base de datos.

**Campos actuales:**
- `NameCostumer`
- `Date`
- `Time`
- `NumberOfPeople`

### View
Interfaz web desarrollada con **Razor (.cshtml)** que permite:
- Capturar datos de reserva
- Mostrar confirmación de registro

### Controller
Gestiona la lógica de la aplicación:
- Recibe los datos del formulario
- Ejecuta la consulta SQL
- Inserta los datos en la base de datos
- Devuelve la respuesta al usuario

---

## Comunicación con la Base de Datos

La conexión a la base de datos se realiza mediante **ADO.NET** utilizando:
- `SqlConnection`
- `SqlCommand`
- Consultas parametrizadas

La cadena de conexión se encuentra definida en el archivo `appsettings.json`.

La inserción de datos se realiza mediante la siguiente consulta:
```sql
INSERT INTO Reserva (Nombre, Dia, Hora, Comensales)
VALUES (@NameCostumer, @Date, @Time, @NumberOfPeople)
```

> El uso de parámetros permite prevenir vulnerabilidades como **SQL Injection** y garantiza mayor seguridad en el manejo de datos.

---

## Base de Datos

**Motor utilizado:** SQL Server (instancia local)

**Tabla actual:** `Reserva`

| Campo | Descripción |
|-------|-------------|
| `Id` | Identificador único (identidad) |
| `Nombre` | Nombre del cliente |
| `Dia` | Fecha de la reserva |
| `Hora` | Hora de la reserva |
| `Comensales` | Número de personas |

**En futuros avances se ampliará el diseño para incluir:**
- Mesas
- Estados de reserva
- Validaciones de disponibilidad
- Control de traslapes
- Gestión administrativa

---

## Tecnologías Utilizadas

| Tecnología | Uso |
|------------|-----|
| ASP.NET Core MVC | Framework principal |
| SQL Server | Base de datos |
| ADO.NET | Acceso a datos |
| HTML / CSS | Interfaz de usuario |
| Visual Studio | Entorno de desarrollo |

---

## Funcionalidades Implementadas (Avance Actual)

- [x] Registro de reservas mediante formulario web
- [x] Inserción de datos en base de datos SQL Server
- [x] Confirmación posterior al registro
- [x] Separación estructural mediante patrón MVC

## Funcionalidades Pendientes

- [ ] Listado de reservas registradas
- [ ] Validación de disponibilidad y traslapes
- [ ] Manejo de estados de reserva
- [ ] Implementación completa del diseño de base de datos propuesto
- [ ] Gestión administrativa

---

## Estructura del Proyecto
```
RestaurantProject/
│
├── Controllers/
├── Models/
├── Views/
├── wwwroot/
├── appsettings.json
├── Program.cs
└── README.md
```

---

## Cómo Ejecutar el Proyecto

1. **Clonar el repositorio:**
```bash
   git clone https://github.com/KGCC-hub/RestaurantProject.git
```

2. **Abrir el proyecto** en Visual Studio.

3. **Configurar la cadena de conexión** en `appsettings.json` para apuntar a tu instancia local de SQL Server.

4. **Verificar** que la base de datos y la tabla `Reserva` estén creadas.

5. **Ejecutar** la aplicación.

---

## Estado del Proyecto

![Estado](https://img.shields.io/badge/Estado-En%20Desarrollo-yellow)
![Versión](https://img.shields.io/badge/Versión-v0.1-blue)

El sistema se encuentra en **fase de desarrollo**. Actualmente permite registrar reservas básicas y almacenarlas en una base de datos local. Se continuará ampliando la lógica de negocio y el diseño de la base de datos en las siguientes fases del proyecto.
