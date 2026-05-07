# RestaurantProject – Sistema Web de Reservas para Restaurante

## Descripción del Proyecto

**RestaurantProject** es una aplicación web desarrollada en **ASP.NET Core** bajo el patrón de arquitectura **MVC (Model – View – Controller)**. El sistema permite registrar, visualizar y administrar reservas de mesa para un restaurante mediante una interfaz web intuitiva y funcional.

La aplicación captura información relevante de cada reservación:

- Nombre del cliente
- Fecha de reservación
- Hora
- Número de comensales

La información es almacenada en una base de datos **SQL Server** utilizando conexión mediante **ADO.NET** y Entity Framework Core.

Además, el proyecto integra prácticas modernas de **DevOps**, incluyendo contenerización, orquestación y automatización de despliegues mediante Docker, Kubernetes y GitHub Actions.

> Este proyecto forma parte del Proyecto Integrador de la Metodología DevOps y representa la implementación final funcional del sistema.

---

# Objetivo del Proyecto

Desarrollar una aplicación web que permita digitalizar y optimizar el proceso de gestión de reservas en un restaurante, sustituyendo métodos manuales como llamadas telefónicas o mensajes, mejorando la organización, monitoreo y administración de la información.

---

# Arquitectura del Sistema

El sistema está desarrollado bajo el patrón **MVC (Model – View – Controller)**, permitiendo una clara separación de responsabilidades y facilitando el mantenimiento del proyecto.

## Model

Representa la entidad `Reserva` y define la estructura de los datos almacenados en la base de datos.

### Campos actuales

- `Id`
- `Nombre`
- `Dia`
- `Hora`
- `Comensales`

---

## View

Interfaz web desarrollada con Razor (`.cshtml`) que permite:

- Registrar reservas
- Visualizar reservas almacenadas
- Monitorear reservaciones
- Seleccionar y eliminar registros
- Mostrar confirmaciones al usuario

---

## Controller

Gestiona la lógica de negocio de la aplicación:

- Recibe datos desde formularios
- Ejecuta consultas SQL
- Inserta registros
- Consulta información
- Elimina reservas seleccionadas
- Devuelve respuestas dinámicas al usuario

---

# Comunicación con la Base de Datos

La conexión a la base de datos se realiza mediante:

- `SqlConnection`
- `SqlCommand`
- Entity Framework Core
- Consultas parametrizadas

La cadena de conexión se encuentra definida en el archivo:

```json
appsettings.json
La inserción de datos se realiza mediante consultas parametrizadas para prevenir vulnerabilidades como SQL Injection.

---

# Base de Datos

## Motor utilizado

- SQL Server

## Tabla principal

- `Reserva`

| Campo | Tipo |
|---|---|
| Id | int |
| Nombre | nvarchar(255) |
| Dia | date |
| Hora | time |
| Comensales | int |

---

# Funcionalidades Implementadas

## Funcionalidades principales

- [x] Registro de reservas mediante formulario web
- [x] Almacenamiento en SQL Server
- [x] Listado dinámico de reservas
- [x] Eliminación múltiple de reservaciones
- [x] Interfaz administrativa para monitoreo
- [x] Arquitectura MVC
- [x] Manejo de errores con try-catch
- [x] Validación mediante consultas parametrizadas

---

# Panel Administrativo

El sistema incluye una interfaz administrativa diseñada para facilitar la gestión de reservaciones por parte de gerentes o meseros del restaurante.

La interfaz permite:

- Visualizar reservas registradas
- Monitorear información de clientes
- Seleccionar múltiples reservaciones
- Eliminar registros de forma rápida y sencilla

---

# Implementación DevOps

El proyecto integra herramientas y prácticas modernas de DevOps para automatizar el ciclo de vida de la aplicación.

## Tecnologías DevOps implementadas

- Docker
- Docker Compose
- Kubernetes
- Helm
- GitHub Actions
- CI/CD

---

# Docker

La aplicación fue contenerizada mediante Docker utilizando un archivo `Dockerfile`.

## Funcionalidades implementadas

- Construcción automática de imágenes
- Ejecución en contenedores
- Portabilidad entre entornos
- Aislamiento de dependencias

## Construcción de imagen

```bash
docker build -t restaurant-app .
```

## Ejecución del contenedor

```bash
docker run -d -p 8080:80 --name restaurant-container restaurant-app
```

---

# Docker Compose

Docker Compose fue utilizado para ejecutar múltiples servicios de manera coordinada.

## Servicios integrados

- Aplicación ASP.NET Core
- SQL Server

## Ejecución

```bash
docker compose up --build -d
```

---

# Kubernetes

Kubernetes fue utilizado para administrar el despliegue y orquestación de contenedores.

## Recursos implementados

- Deployment
- Service
- Pods
- NodePort

## Despliegue

```bash
kubectl apply -f deployment.yaml
kubectl apply -f service.yaml
```

---

# Helm

Helm fue utilizado para empaquetar y administrar los recursos Kubernetes.

## Funcionalidades implementadas

- Gestión de configuraciones
- Parametrización de despliegues
- Administración simplificada

## Instalación del chart

```bash
helm install restaurant-release .
```

---

# Integración Continua y Despliegue Continuo (CI/CD)

El proyecto implementa un pipeline automatizado mediante GitHub Actions.

## Funcionalidades del pipeline

- Build automático
- Construcción de imagen Docker
- Publicación automática en Docker Hub

El pipeline se ejecuta automáticamente al realizar un `push` a la rama principal del repositorio.

---

# Tecnologías Utilizadas

| Tecnología | Uso |
|---|---|
| ASP.NET Core MVC | Framework principal |
| SQL Server | Base de datos |
| ADO.NET | Acceso a datos |
| Entity Framework Core | Contexto de datos |
| Docker | Contenerización |
| Docker Compose | Orquestación local |
| Kubernetes | Orquestación de contenedores |
| Helm | Gestión de despliegues |
| GitHub Actions | CI/CD |
| GitHub | Control de versiones |
| HTML / CSS | Interfaz de usuario |
| Visual Studio | Entorno de desarrollo |

---

# Estructura del Proyecto

```text
RestaurantProject/
│
├── Controllers/
├── Data/
├── Models/
├── Views/
├── wwwroot/
├── .github/workflows/
├── deployment.yaml
├── service.yaml
├── docker-compose.yml
├── Dockerfile
├── appsettings.json
├── Program.cs
└── README.md
```

---

# Cómo Ejecutar el Proyecto

## 1. Clonar el repositorio

```bash
git clone https://github.com/KGCC-hub/RestaurantProject.git
```

---

## 2. Acceder al proyecto

```bash
cd RestaurantProject
```

---

## 3. Ejecutar con Docker Compose

```bash
docker compose up --build -d
```

---

## 4. Abrir la aplicación

```text
http://localhost:8080
```

---

# Evidencias del Proyecto

El proyecto incluye evidencias relacionadas con:

- Aplicación funcionando
- SQL Server
- Docker
- Docker Compose
- Kubernetes
- Helm
- GitHub Actions
- Docker Hub

---

# Estado del Proyecto

![Estado](https://img.shields.io/badge/Estado-Finalizado-brightgreen)
![DevOps](https://img.shields.io/badge/DevOps-Implementado-blue)
![ASP.NET](https://img.shields.io/badge/ASP.NET-Core%208-purple)
![Docker](https://img.shields.io/badge/Docker-Implementado-2496ED)

El proyecto se encuentra finalizado funcionalmente y demuestra la integración completa de prácticas DevOps modernas aplicadas al desarrollo y despliegue de aplicaciones web.
