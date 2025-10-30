ESTRUCTURA GENERAL DE ENDPOINTS
La raíz del API será:
localhost:puerto/api/
Cada controlador representará una entidad principal o módulo del sistema, agrupando los endpoints REST bajo un prefijo claro.
Ejemplo: /api/Clientes, /api/Usuarios, /api/Riesgos, etc.

MÓDULOS Y ENDPOINTS DETALLADOS

1. Autenticación y Usuarios (UsuariosController)
Ventanas: Register, Login, Configuracion
Método	Endpoint	Descripción
POST	/api/usuarios/register	Registrar un nuevo usuario (con rol asignado).
POST	/api/usuarios/login	Iniciar sesión (valida usuario y clave, devuelve token JWT).
GET	/api/usuarios/perfil	Obtener perfil del usuario autenticado.
PUT	/api/usuarios/{id}	Actualizar información del usuario (nombre, rol, etc.).
GET	/api/usuarios	Listar todos los usuarios (solo rol Administrador).
DELETE	/api/usuarios/{id}	Eliminar un usuario.
Tablas relacionadas: Usuarios, Roles
2. Clientes (ClientesController)
Ventanas: ClienteList, RegistroClientes, DebidaDiligencia
Método	Endpoint	Descripción
GET	/api/clientes	Listar todos los clientes.
GET	/api/clientes/{id}	Obtener un cliente por ID (con sus relaciones).
POST	/api/clientes	Crear un nuevo cliente.
PUT	/api/clientes/{id}	Actualizar datos del cliente.
DELETE	/api/clientes/{id}	Eliminar un cliente.
GET	/api/clientes/{id}/detalle	Obtener cliente con relaciones: direcciones, contactos, beneficiarios, intermediarios, etc.
Tablas relacionadas:
Clientes, Direcciones, Contactos, BeneficiariosFinales, Intermediarios, ActividadesEconomicas, PerfilesFinancieros, Operaciones, Transacciones, Referencias, PersonasExpuestasPoliticamente, Responsables

3. Direcciones (DireccionesController)
Usado dentro de RegistroClientes
Método	Endpoint	Descripción
GET	/api/direcciones/cliente/{clienteId}	Obtener direcciones de un cliente.
POST	/api/direcciones	Agregar dirección a un cliente.
PUT	/api/direcciones/{id}	Actualizar dirección.
DELETE	/api/direcciones/{id}	Eliminar dirección.

4. Contactos (ContactosController)
Usado dentro de RegistroClientes
Método	Endpoint	Descripción
GET	/api/contactos/cliente/{clienteId}	Obtener contactos de un cliente.
POST	/api/contactos	Crear contacto.
PUT	/api/contactos/{id}	Actualizar contacto.
DELETE	/api/contactos/{id}	Eliminar contacto.

5. Beneficiarios e Intermediarios
Usado dentro de RegistroClientes
BeneficiariosFinalesController
Método	Endpoint	Descripción
GET	/api/beneficiarios/cliente/{clienteId}	Listar beneficiarios del cliente.
POST	/api/beneficiarios	Crear beneficiario.
PUT	/api/beneficiarios/{id}	Editar beneficiario.
DELETE	/api/beneficiarios/{id}	Eliminar beneficiario.
IntermediariosController
Método	Endpoint	Descripción
GET	/api/intermediarios/cliente/{clienteId}	Listar intermediarios del cliente.
POST	/api/intermediarios	Crear intermediario.
PUT	/api/intermediarios/{id}	Editar intermediario.
DELETE	/api/intermediarios/{id}	Eliminar intermediario.

6. Actividades Económicas y Perfil Financiero
Ventana: RegistroClientes
Controlador	Endpoint base	Descripción
ActividadesEconomicasController	/api/actividades	CRUD de actividades económicas por cliente.
PerfilesFinancierosController	/api/perfilesfinancieros	CRUD del perfil financiero del cliente.
Ejemplo:
•	GET /api/actividades/cliente/{clienteId}
•	GET /api/perfilesfinancieros/cliente/{clienteId}

7. Operaciones, Pagos y Transacciones
Ventana: RegistroClientes o DebidaDiligencia
Controlador	Endpoint base	Descripción
OperacionesController	/api/operaciones	CRUD de operaciones del cliente.
PagosController	/api/pagos	CRUD de pagos asociados a una operación.
TransaccionesController	/api/transacciones	CRUD de transacciones del cliente.

8. Cumplimiento y Debida Diligencia (DebidaDiligenciaController)
Ventanas: DebidaDiligencia, ScoreRiesgo, Reporte
Método	Endpoint	Descripción
GET	/api/debidadiligencia	Listar procesos de debida diligencia.
GET	/api/debidadiligencia/{id}	Obtener detalle de una debida diligencia (con riesgos y mitigaciones).
POST	/api/debidadiligencia	Crear un nuevo proceso de debida diligencia.
PUT	/api/debidadiligencia/{id}	Actualizar debida diligencia.
DELETE	/api/debidadiligencia/{id}	Eliminar debida diligencia.

9. Riesgos y Mitigaciones
Ventanas: ScoreRiesgo, Reporte
RiesgosController
Método	Endpoint	Descripción
GET	/api/riesgos	Listar todos los riesgos.
GET	/api/riesgos/{id}	Obtener riesgo por ID (con mitigaciones).
GET	/api/riesgos/debidadiligencia/{debidaDiligenciaId}	Listar riesgos asociados a una debida diligencia.
POST	/api/riesgos	Crear riesgo.
PUT	/api/riesgos/{id}	Editar riesgo.
DELETE	/api/riesgos/{id}	Eliminar riesgo.
MitigacionController
Método	Endpoint	Descripción
GET	/api/mitigacion/riesgo/{riesgoId}	Listar acciones de mitigación de un riesgo.
POST	/api/mitigacion	Crear acción de mitigación.
PUT	/api/mitigacion/{id}	Actualizar estado u observaciones.
DELETE	/api/mitigacion/{id}	Eliminar acción de mitigación.

10. Evaluaciones (EvaluacionesController)
Ventana: ScoreRiesgo
Método	Endpoint	Descripción
GET	/api/evaluaciones/cliente/{clienteId}	Obtener evaluaciones por cliente.
POST	/api/evaluaciones	Registrar nueva evaluación de riesgo.
PUT	/api/evaluaciones/{id}	Actualizar puntaje u observaciones.
DELETE	/api/evaluaciones/{id}	Eliminar evaluación.

11. Mensajería Interna (MensajesChatController)
Ventana: Dashboard
Método	Endpoint	Descripción
GET	/api/mensajes	Listar mensajes recientes.
POST	/api/mensajes	Enviar nuevo mensaje.
GET	/api/mensajes/usuario/{usuarioId}	Obtener mensajes por usuario.

12. Configuración (ConfiguracionController)
Ventana: Configuracion
Método	Endpoint	Descripción
GET	/api/configuracion/roles	Listar roles disponibles.
POST	/api/configuracion/roles	Crear nuevo rol.
PUT	/api/configuracion/roles/{id}	Actualizar rol.
DELETE	/api/configuracion/roles/{id}	Eliminar rol.

13. Reportes (ReporteController)
Ventana: Reporte
Método	Endpoint	Descripción
GET	/api/reportes/dashboard	Datos resumidos para el dashboard (totales, estadísticas).
GET	/api/reportes/clientes	Generar reporte PDF/Excel de clientes.
GET	/api/reportes/riesgos	Generar reporte PDF/Excel de riesgos y mitigaciones.
GET	/api/reportes/debidadiligencia/{id}	Generar informe completo de una debida diligencia.

ESTRUCTURA DE CONTROLADORES (ASP.NET Core)
Los controladores se organizan así:
Controllers/
├── UsuariosController.cs
├── ClientesController.cs
├── DireccionesController.cs
├── ContactosController.cs
├── BeneficiariosFinalesController.cs
├── IntermediariosController.cs
├── ActividadesEconomicasController.cs
├── PerfilesFinancierosController.cs
├── OperacionesController.cs
├── PagosController.cs
├── TransaccionesController.cs
├── DebidaDiligenciaController.cs
├── RiesgosController.cs
├── MitigacionController.cs
├── EvaluacionesController.cs
├── MensajesChatController.cs
├── ConfiguracionController.cs
└── ReporteController.cs

