# Compliance Guard Pro - Colección de Postman

Esta colección contiene todos los endpoints de la API de Compliance Guard Pro organizados por módulos.

## 📋 Requisitos Previos

1. **API en funcionamiento**: Asegúrate de que la API esté ejecutándose en `https://localhost:5001` (o actualiza la variable `baseUrl` si es diferente)
2. **Postman instalado**: Descarga e instala Postman desde https://www.postman.com/

## 🚀 Configuración

### 1. Importar la colección
1. Abre Postman
2. Haz clic en "Import" en la esquina superior izquierda
3. Selecciona "File" y elige `ComplianceGuardPro_Postman_Collection.json`
4. La colección aparecerá en el panel izquierdo

### 2. Configurar variables
La colección incluye dos variables de entorno:

- **`baseUrl`**: URL base de la API (por defecto: `https://localhost:5001`)
- **`token`**: Token JWT para autenticación (se llena automáticamente después del login)

### 3. Actualizar baseUrl (opcional)
Si tu API corre en un puerto diferente:
1. Ve a "Environments" en Postman
2. Crea un nuevo environment o edita el existente
3. Actualiza la variable `baseUrl` con tu URL real

## 📖 Uso de la Colección

### 🔐 Autenticación
1. Ve al folder "01. Autenticación"
2. Ejecuta la request "Login" con credenciales válidas
3. El token se guardará automáticamente en la variable `{{token}}`
4. Todas las demás requests usarán este token automáticamente

### 📂 Estructura de la Colección

La colección está organizada por módulos en orden lógico:

1. **01. Autenticación** - Login y registro de usuarios
2. **02. Roles** - Gestión de roles del sistema
3. **03. Usuarios** - Gestión de usuarios (requiere roles)
4. **04. Clientes** - Gestión de clientes
5. **05. Direcciones** - Direcciones de clientes
6. **06. Contactos** - Contactos de clientes
7. **07. Beneficiarios Finales** - Beneficiarios finales
8. **08. Intermediarios** - Intermediarios
9. **09. Actividades Económicas** - Actividades económicas
10. **10. Perfiles Financieros** - Perfiles financieros
11. **11. Operaciones** - Operaciones
12. **12. Pagos** - Pagos asociados a operaciones
13. **13. Transacciones** - Transacciones
14. **14. Riesgos** - Gestión de riesgos
15. **15. Evaluaciones** - Evaluaciones de riesgos
16. **16. Mensajes Chat** - Mensajería interna
17. **17. Configuración** - Configuración del sistema
18. **18. Debida Diligencia** - Procesos de debida diligencia
19. **19. Persona Expuesta Políticamente** - Personas expuestas políticamente
20. **20. Referencia** - Referencias de clientes
21. **21. Reportes** - Generación de reportes
22. **22. Responsable** - Responsables de compliance

### 🔄 Flujo de Uso Recomendado

1. **Login** → Obtén el token de autenticación
2. **Gestionar Roles** → Crea los roles necesarios primero (antes de crear usuarios)
3. **Crear Usuario** → Registra usuarios con roles asignados
4. **Crear Cliente** → Registra un cliente
5. **Agregar Direcciones/Contactos** → Completa la información del cliente
6. **Crear Operaciones/Pagos** → Registra operaciones financieras
7. **Gestionar Riesgos** → Evalúa y mitiga riesgos
8. **Generar Reportes** → Obtén reportes del sistema

## 📝 Notas Importantes

- **Autenticación requerida**: La mayoría de los endpoints requieren el header `Authorization: Bearer {{token}}`
- **IDs de ejemplo**: Los requests incluyen IDs de ejemplo (1, 2, 3...). Reemplázalos con IDs reales de tu base de datos
- **Datos de prueba**: Los bodies de las requests POST/PUT incluyen datos de ejemplo. Modifícalos según tus necesidades
- **Dependencias**: Algunos módulos dependen de otros (ej: Direcciones requieren un Cliente existente)

## 🐛 Solución de Problemas

### Error 401 Unauthorized
- Verifica que hayas ejecutado el login primero
- Confirma que el token se guardó en la variable `{{token}}`

### Error 404 Not Found
- Verifica que la `baseUrl` sea correcta
- Asegúrate de que la API esté ejecutándose

### Error 400 Bad Request
- Revisa el body de la request (formato JSON incorrecto)
- Verifica que los IDs de referencia existan (clienteId, operacionId, etc.)

## 📞 Soporte

Si encuentras problemas con la colección o la API, revisa:
1. Los logs de la aplicación
2. La documentación en la carpeta `docs/`
3. El archivo `ESTRUCTURA-Y-ENDPOINTS.MD`

---

**Versión**: 1.0
**Fecha**: Noviembre 2025
**API Version**: .NET 9.0