# Módulo Reportes

## Descripción
Generación de reportes en formato PDF y Excel para diferentes aspectos del sistema de compliance.

## Endpoints

### 1. GET /api/Reportes/dashboard
**Generar reporte del dashboard**

**Response (200 OK):**
Archivo PDF con estadísticas generales del sistema.

**Response (500 Internal Server Error):**
```json
{
  "message": "Error al generar el reporte del dashboard"
}
```

### 2. GET /api/Reportes/clientes
**Generar reporte de clientes**

**Response (200 OK):**
Archivo Excel con lista completa de clientes y sus datos asociados.

**Response (500 Internal Server Error):**
```json
{
  "message": "Error al generar el reporte de clientes"
}
```

### 3. GET /api/Reportes/riesgos
**Generar reporte de riesgos**

**Response (200 OK):**
Archivo PDF con análisis de riesgos identificados en el sistema.

**Response (500 Internal Server Error):**
```json
{
  "message": "Error al generar el reporte de riesgos"
}
```

### 4. GET /api/Reportes/debida-diligencia
**Generar reporte de debida diligencia**

**Response (200 OK):**
Archivo PDF con resumen de procesos de debida diligencia.

**Response (500 Internal Server Error):**
```json
{
  "message": "Error al generar el reporte de debida diligencia"
}
```

## Notas
- Los reportes se generan en tiempo real basándose en los datos actuales del sistema.
- Los archivos se devuelven directamente como respuesta binaria.
- No se requieren parámetros adicionales para estos endpoints básicos.
- Para reportes más específicos, se pueden agregar parámetros de consulta en futuras versiones.