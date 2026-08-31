\# Sistema de Reservas de Salas de Reuniones Corporativas



\*\*Trabajo Práctico Integrador Final — Programación Orientada a Objetos\*\*

Universidad Abierta Interamericana (UAI)



\## Descripción



Aplicación de escritorio desarrollada en C# / WinForms (.NET 8) que permite administrar la disponibilidad de salas de reuniones de una empresa, gestionar distintos tipos de usuarios y registrar, consultar y cancelar reservas evitando solapamientos de horario. No utiliza base de datos: la persistencia se implementa mediante archivos de texto plano delimitados por `|`.



\## Requisitos



\- Visual Studio 2022 o superior, con la carga de trabajo \*\*.NET Desktop Development\*\* instalada.

\- .NET 8 SDK.



\## Puesta en marcha



1\. Clonar o descomprimir el repositorio.

2\. Abrir `SistemaReservasSalas.sln` en Visual Studio.

3\. Compilar y ejecutar (F5).

4\. En la pantalla de inicio de sesión, seleccionar uno de los usuarios precargados (ver tabla a continuación).



Los archivos de datos (`Datos/salas.txt`, `Datos/usuarios.txt`, `Datos/reservas.txt`) se copian automáticamente a la carpeta de salida al compilar y ya incluyen datos de carga inicial para pruebas.



\## Usuarios de prueba



| ID | Rol | Nombre |

|---|---|---|

| A-2026-001 | Administrador | Renata García Marchesi |

| G-2026-002 | Gerente | Claudia Carina Marchesi |

| G-2026-003 | Gerente | José Manuel García |

| E-2026-004 | Empleado | Lucas Fenoglio |

| E-2026-005 | Empleado | Santiago Fenoglio |

| E-2026-006 | Empleado | Pablo Fenoglio |



El rol determina las pantallas disponibles: el \*\*Administrador\*\* accede a la gestión de salas y de usuarios además de las funciones de reserva; \*\*Gerente\*\* y \*\*Empleado\*\* acceden únicamente a reservas y reportes, con límites semanales de reservas diferenciados por rol.



\## Salas cargadas



| ID | Nombre | Ubicación | Capacidad | Equipamiento |

|---|---|---|---|---|

| SALA01 | Sala Directorio | Piso 8 | 12 | Proyector, Videoconferencia, Pizarra |

| SALA02 | Sala Innovación | Piso 5 | 8 | Proyector, Pizarra |

| SALA03 | Sala Rápida | Piso 3 | 4 | Pizarra |

| SALA04 | Sala Auditorio | Piso 1 | 30 | Proyector, Videoconferencia, Sonido |



\## Reservas de prueba



| ID | Sala | Usuario | Fecha | Horario | Motivo | Estado |

|---|---|---|---|---|---|---|

| R001 | SALA01 | G-2024-015 | 2026-07-24 | 14:00–16:00 | Reunión de Directorio | Confirmada |

| R002 | SALA02 | E-2024-003 | 2026-07-24 | 18:00–20:00 | Sincronización de equipo | Pendiente |

| R003 | SALA01 | G-2024-016 | 2026-07-25 | 09:00–10:00 | Revisión de presupuesto | Confirmada |

| R004 | SALA03 | E-2024-004 | 2026-07-24 | 11:00–11:30 | Llamada con cliente | Pendiente |

| R005 | SALA04 | A-2024-001 | 2026-07-26 | 15:00–17:00 | Capacitación general | Confirmada |



\## Estructura del proyecto



| Carpeta | Contenido |

|---|---|

| `Modelos` | `Usuario` (clase abstracta) y sus derivadas `Administrador`, `Gerente`, `Empleado`; `Reserva`; `SalaReunion`. |

| `Enums` | `EstadoReserva` (Pendiente, Confirmada, Cancelada). |

| `Excepciones` | Excepciones propias: `ReservaSolapadaException`, `SalaNoDisponibleException`, `ArchivoDatosCorruptoException`. |

| `Repositorios` | Interfaz `IRepositorio<T>`, clase genérica abstracta `RepositorioArchivo<T>` y sus implementaciones concretas (`RepositorioSalas`, `RepositorioUsuarios`, `RepositorioReservas`). |

| `Servicios` | `ServicioReservas` (lógica de negocio y eventos de dominio) y `ContextoDatos` (clase estática de acceso centralizado a repositorios y servicio). |

| `Formularios` | Login, Principal, Gestión de Salas, Gestión de Usuarios, Grilla de Reservas, Alta de Reserva, Cancelación de Reserva, Reportes. |

| `Datos` | Archivos de texto con la carga inicial de salas, usuarios y reservas. |



\## Funcionalidades principales



\- Alta, baja, modificación y listado de salas de reuniones (solo Administrador).

\- Alta y listado de usuarios, diferenciados por rol.

\- Creación de reservas con validación de solapamiento de horario.

\- Cancelación de reservas, con reglas de autorización según el rol del usuario.

\- Consulta de disponibilidad de una sala en una fecha determinada.

\- Reportes de reservas del día, uso por sala y ranking de salas más solicitadas.



\## Conceptos de POO aplicados



\- \*\*Herencia y polimorfismo\*\*: jerarquía de `Usuario` con los métodos virtuales `ObtenerLimiteReservasSemanales()` y `PuedeCancelar()` sobrescritos en cada rol.

\- \*\*Constructores sobrecargados\*\*: encadenamiento con `: this(...)` en la clase `Reserva`.

\- \*\*Genéricos\*\*: una única clase `RepositorioArchivo<T>` reutilizada para las tres entidades, evitando duplicación de código de lectura/escritura.

\- \*\*Interfaces\*\*: `IRepositorio<T>` como contrato común de la capa de acceso a datos.

\- \*\*Excepciones personalizadas\*\*: jerarquía propia derivada de `Exception`, con manejo mediante try/catch en las operaciones de archivo y de negocio.

\- \*\*Delegados y eventos\*\*: `ReservaEventHandler` desacopla la lógica de negocio de la interfaz gráfica mediante los eventos `ReservaCreada` y `ReservaCancelada`.

\- \*\*LINQ\*\*: consultas de filtrado, ordenamiento y agrupamiento (`Where`, `OrderBy`, `GroupBy`) utilizadas en la detección de solapamientos y en los reportes.

\- \*\*IDisposable\*\*: `RepositorioArchivo<T>` implementa `IDisposable` junto con un destructor para la liberación de recursos.

