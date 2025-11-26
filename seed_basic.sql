-- ===========================================
-- Seed Data Script for ComplianceGuard Pro
-- Generated from EF Core Models - Version 2025
-- ===========================================


-- ===========================================
-- 1. ROLES
-- ===========================================
INSERT INTO Roles (Nombre, Descripcion) VALUES
('Administrador', 'Usuario con acceso completo al sistema'),
('Compliance Officer', 'Oficial de cumplimiento responsable de revisiones'),
('Analista', 'Analista de riesgos y evaluaciones'),
('Auditor', 'Auditor interno con acceso de lectura');


-- ===========================================
-- 2. USUARIOS
-- ===========================================
INSERT INTO Usuarios (UsuarioLogin, ClaveHash, EstaActivo, Nombre, RolId, Token) VALUES
('admin', '$2a$11$example.hash.for.admin', 1, 'Administrador del Sistema', 1, NULL),
('compliance1', '$2a$11$example.hash.for.compliance', 1, 'María González', 2, NULL),
('analista1', '$2a$11$example.hash.for.analista', 1, 'Carlos Rodríguez', 3, NULL),
('auditor1', '$2a$11$example.hash.for.auditor', 1, 'Ana López', 4, NULL);


-- ===========================================
-- 3. CLIENTES
-- ===========================================
INSERT INTO Clientes (Nombre, TipoPersona, Siglas, DocumentoIdentidad, FechaCreacion, Rnc, RegistroMercantil, CasaMatriz) VALUES
('Juan Pérez Martínez', 'Persona Natural', NULL, '001-1234567-8', '2020-01-15', NULL, NULL, NULL),
('Tech Solutions S.A.', 'Persona Jurídica', 'TS', '002-9876543-2', '2018-05-20', '131234567', 'RM-2018-001', 'República Dominicana'),
('María Fernanda Díaz', 'Persona Natural', NULL, '003-4567890-1', '2019-03-10', NULL, NULL, NULL),
('Inversiones Globales Ltda.', 'Persona Jurídica', 'IG', '004-1122334-4', '2017-11-30', '131987654', 'RM-2017-045', 'República Dominicana'),
('Roberto Sánchez Torres', 'Persona Natural', NULL, '005-5566778-8', '2021-07-22', NULL, NULL, NULL);


-- ===========================================
-- 4. BENEFICIARIOS FINALES
-- ===========================================
INSERT INTO BeneficiariosFinales (ClienteId, Nombre) VALUES
(1, 'Ana Pérez Martínez'),
(2, 'Carlos Tech Solutions'),
(3, 'Luis Díaz Fernández'),
(4, 'Global Investments LLC'),
(5, 'Patricia Sánchez Torres');


-- ===========================================
-- 5. INTERMEDIARIOS
-- ===========================================
INSERT INTO Intermediarios (ClienteId, Nombre) VALUES
(1, 'Banco Nacional'),
(2, 'Consultora ABC'),
(3, 'Agente Financiero XYZ'),
(4, 'Broker Internacional'),
(5, 'Asesor Legal Corp');


-- ===========================================
-- 6. DIRECCIONES
-- ===========================================
INSERT INTO Direcciones (ClienteId, Calle, Numero, Sector, Municipio, Provincia, Pais, CodigoPostal) VALUES
(1, 'Calle Principal', '123', 'Centro', 'Santo Domingo', 'Distrito Nacional', 'República Dominicana', '10101'),
(2, 'Avenida Empresarial', '456', 'Zona Industrial', 'Santiago', 'Santiago', 'República Dominicana', '51000'),
(3, 'Calle Comercio', '789', 'Centro Histórico', 'La Vega', 'La Vega', 'República Dominicana', '41000'),
(4, 'Boulevard Financiero', '321', 'Zona Franca', 'Santo Domingo', 'Distrito Nacional', 'República Dominicana', '10102'),
(5, 'Avenida Libertad', '654', 'Centro', 'Puerto Plata', 'Puerto Plata', 'República Dominicana', '57000');


-- ===========================================
-- 7. CONTACTOS
-- ===========================================
INSERT INTO Contactos (ClienteId, Tipo, Valor) VALUES
(1, 'Teléfono', '+1-809-555-0123'),
(1, 'Correo', 'juan.perez@email.com'),
(2, 'Teléfono', '+1-809-555-0456'),
(2, 'Correo', 'contacto@techsolutions.com'),
(3, 'Teléfono', '+1-809-555-0789'),
(3, 'Correo', 'maria.diaz@consultora.com'),
(4, 'Teléfono', '+1-809-555-0321'),
(4, 'Correo', 'info@inversionesglobales.com'),
(5, 'Teléfono', '+1-809-555-0654'),
(5, 'Correo', 'roberto.sanchez@robertosanchez.com');


-- ===========================================
-- 8. ACTIVIDADES ECONOMICAS
-- ===========================================
INSERT INTO ActividadesEconomicas (ClienteId, Proveedor, PrincipalCliente, CampoLaboral, Proyecto, Inscripciones, OrigenFondos) VALUES
(1, 'Proveedor A', 'Cliente Principal 1', 'Consultoría', 'Proyecto Gestión Empresarial', 'Registro Profesional', 'Honorarios profesionales'),
(2, 'Proveedor Tech', 'Cliente Principal 2', 'Tecnología', 'Proyecto Desarrollo Software', 'Registro Comercial', 'Contratos corporativos'),
(3, 'Proveedor Servicios', 'Cliente Principal 3', 'Consultoría', 'Proyecto Asesoría Financiera', 'Licencia Profesional', 'Servicios profesionales'),
(4, 'Proveedor Inversión', 'Cliente Principal 4', 'Finanzas', 'Proyecto Gestión de Portafolios', 'Registro Financiero', 'Retornos de inversión'),
(5, 'Proveedor Comercial', 'Cliente Principal 5', 'Comercio', 'Proyecto Importación', 'Registro de Importador', 'Ventas comerciales');


-- ===========================================
-- 9. PERFILES FINANCIEROS
-- ===========================================
INSERT INTO PerfilesFinancieros (ClienteId, NivelIngreso, Fuente) VALUES
(1, 50000.00, 'Salario profesional'),
(2, 250000.00, 'Ingresos corporativos'),
(3, 100000.00, 'Honorarios profesionales'),
(4, 500000.00, 'Retornos de inversión'),
(5, 75000.00, 'Ingresos comerciales');


-- ===========================================
-- 10. OPERACIONES
-- ===========================================
INSERT INTO Operaciones (ClienteId, Tipo, Codigo) VALUES
(1, 'Transferencia', 'OP-001-2025'),
(2, 'Depósito', 'OP-002-2025'),
(3, 'Retiro', 'OP-003-2025'),
(4, 'Inversión', 'OP-004-2025'),
(5, 'Pago', 'OP-005-2025');


-- ===========================================
-- 11. PAGOS
-- ===========================================
INSERT INTO Pagos (OperacionId, Tipo, Codigo, Moneda, Monto) VALUES
(1, 'Transferencia bancaria', 'PAY-001', 'DOP', 50000.00),
(2, 'Depósito en efectivo', 'PAY-002', 'USD', 10000.00),
(3, 'Cheque', 'PAY-003', 'DOP', 25000.00),
(4, 'Transferencia internacional', 'PAY-004', 'EUR', 15000.00),
(5, 'Pago electrónico', 'PAY-005', 'DOP', 75000.00);


-- ===========================================
-- 12. TRANSACCIONES
-- ===========================================
INSERT INTO Transacciones (ClienteId, Tipo, InstitucionFinanciera, Descripcion, PropositoProducto, FormaDeposito, FormaExpectativa) VALUES
(1, 'Depósito', 'Banco Popular', 'Depósito mensual', 'Ahorro personal', 'Transferencia', 'Cuenta corriente'),
(2, 'Transferencia', 'Banco BHD', 'Pago de servicios', 'Operaciones comerciales', 'Cheque', 'Cuenta empresarial'),
(3, 'Retiro', 'Banco Scotiabank', 'Retiro de fondos', 'Gastos personales', 'Efectivo', 'Cuenta de ahorros'),
(4, 'Inversión', 'Banco de Reservas', 'Inversión en bonos', 'Portafolio de inversión', 'Transferencia', 'Cuenta de inversión'),
(5, 'Pago', 'Banco Caribe', 'Pago de proveedores', 'Operaciones comerciales', 'Transferencia', 'Cuenta corriente');


-- ===========================================
-- 13. REFERENCIAS
-- ===========================================
INSERT INTO Referencias (ClienteId, Recomendacion, Descripcion) VALUES
(1, 'Cliente confiable', 'Ha mantenido buena relación comercial por 5 años'),
(2, 'Empresa sólida', 'Buena reputación en el mercado tecnológico'),
(3, 'Profesional competente', 'Excelente servicio en asesoría financiera'),
(4, 'Inversionista experimentado', 'Historial positivo en inversiones'),
(5, 'Comerciante responsable', 'Cumple con todos los compromisos comerciales');


-- ===========================================
-- 14. PERSONAS EXPUESTAS POLITICAMENTE
-- ===========================================
INSERT INTO PersonasExpuestasPoliticamente (ClienteId, Nombre, Cargo, Ordenanza, Institucion) VALUES
(1, 'Juan Pérez', 'Diputado', 'Ordenanza 123', 'Cámara de Diputados'),
(3, 'María Díaz', 'Ministra', 'Ordenanza 456', 'Ministerio de Hacienda'),
(5, 'Roberto Sánchez', 'Alcalde', 'Ordenanza 789', 'Municipalidad de Puerto Plata');


-- ===========================================
-- 15. RESPONSABLES
-- ===========================================
INSERT INTO Responsables (ClienteId, Nombre, Apellido, Direccion, Telefono, Cargo, Correo, DocumentoIdentificacion) VALUES
(1, 'Juan', 'Pérez', 'Calle Principal 123, Santo Domingo', '+1-809-555-0123', 'Gerente General', 'juan.perez@email.com', '001-1234567-8'),
(2, 'Carlos', 'Rodríguez', 'Avenida Empresarial 456, Santiago', '+1-809-555-0456', 'CEO', 'carlos@techsolutions.com', '002-9876543-2'),
(3, 'María', 'Díaz', 'Calle Comercio 789, La Vega', '+1-809-555-0789', 'Directora Ejecutiva', 'maria@consultora.com', '003-4567890-1'),
(4, 'Luis', 'Martínez', 'Boulevard Financiero 321, Santo Domingo', '+1-809-555-0321', 'Director Financiero', 'luis@inversionesglobales.com', '004-1122334-4'),
(5, 'Patricia', 'Sánchez', 'Avenida Libertad 654, Puerto Plata', '+1-809-555-0654', 'Gerente Comercial', 'patricia@robertosanchez.com', '005-5566778-8');


-- ===========================================
-- 16. DEBIDA DILIGENCIA
-- ===========================================
INSERT INTO DebidaDiligencias (ClienteId, Titulo, Descripcion, Estado, FechaInicio, FechaFin, Observaciones, Conclusion, ResponsableId) VALUES
(1, 'Debida Diligencia Inicial', 'Evaluación completa del cliente Juan Pérez', 'Completada', '2025-01-01', '2025-01-15', 'Cliente aprobado sin observaciones', 'Cliente aprobado', NULL),
(2, 'Debida Diligencia Empresarial', 'Revisión de Tech Solutions S.A.', 'En Progreso', '2025-01-10', NULL, 'Pendiente documentación adicional', NULL, NULL),
(3, 'Debida Diligencia Profesional', 'Evaluación de María Díaz', 'Completada', '2025-01-05', '2025-01-20', 'Cliente aprobado con monitoreo', 'Cliente aprobado', NULL),
(4, 'Debida Diligencia Inversiones', 'Análisis de Inversiones Globales', 'Pendiente', '2025-01-15', NULL, 'Esperando información financiera', NULL, NULL),
(5, 'Debida Diligencia Comercial', 'Revisión de Roberto Sánchez', 'Completada', '2025-01-08', '2025-01-25', 'Cliente aprobado', 'Cliente aprobado', NULL);


-- ===========================================
-- 17. RIESGOS
-- ===========================================
INSERT INTO Riesgos (DebidaDiligenciaId, Nombre, Identificador, Tipo, Categoria, Estado, DescripcionRiesgo, Objetivo, Fase, Causa, Efecto, Disparador, DisparadorDescripcion, FechaCreacion) VALUES
(1, 'Riesgo de Lavado de Activos', 'RSK-001', 'Operacional', 'Alto', 'Mitigado', 'Posible riesgo de lavado de activos detectado', 'Prevención', 'Identificación', 'Transacciones sospechosas', 'Pérdida reputacional', 'Monto elevado', 'Transacción superior a límite', '2025-01-02'),
(2, 'Riesgo Operacional Tecnológico', 'RSK-002', 'Tecnológico', 'Medio', 'En Evaluación', 'Riesgo en operaciones tecnológicas', 'Control', 'Evaluación', 'Sistemas obsoletos', 'Interrupción del servicio', 'Fallo del sistema', 'Problemas de infraestructura', '2025-01-12'),
(3, 'Riesgo Reputacional', 'RSK-003', 'Reputacional', 'Bajo', 'Mitigado', 'Riesgo por exposición política', 'Monitoreo', 'Seguimiento', 'Exposición pública', 'Daño a imagen', 'Publicación negativa', 'Medios de comunicación', '2025-01-07'),
(4, 'Riesgo Financiero', 'RSK-004', 'Financiero', 'Alto', 'Pendiente', 'Riesgo en inversiones especulativas', 'Evaluación', 'Análisis', 'Volatilidad del mercado', 'Pérdidas financieras', 'Cambio de mercado', 'Fluctuaciones económicas', '2025-01-17'),
(5, 'Riesgo Regulatorio', 'RSK-005', 'Cumplimiento', 'Medio', 'Mitigado', 'Riesgo de incumplimiento normativo', 'Cumplimiento', 'Control', 'Cambios normativos', 'Sanciones regulatorias', 'Nueva regulación', 'Actualización normativa', '2025-01-10');


-- ===========================================
-- 18. MITIGACIONES
-- ===========================================
INSERT INTO Mitigaciones (RiesgoId, Accion, Responsable, Estado, FechaInicio, FechaCierre, Observaciones, Eficacia) VALUES
(1, 'Implementar monitoreo transaccional', 'María González', 'Completada', '2025-01-03', '2025-01-10', 'Monitoreo implementado exitosamente', 85.00),
(2, 'Actualizar protocolos de seguridad', 'Carlos Rodríguez', 'En Progreso', '2025-01-13', NULL, 'En proceso de implementación', NULL),
(3, 'Establecer límites de exposición', 'Ana López', 'Completada', '2025-01-08', '2025-01-15', 'Límites establecidos correctamente', 90.00),
(4, 'Revisar estrategia de inversión', 'María González', 'Pendiente', '2025-01-18', NULL, 'Esperando aprobación del comité', NULL),
(5, 'Actualizar procedimientos operativos', 'Carlos Rodríguez', 'Completada', '2025-01-11', '2025-01-20', 'Procedimientos actualizados', 80.00);


-- ===========================================
-- 19. EVALUACIONES
-- ===========================================
INSERT INTO Evaluaciones (RiesgoId, ClienteId, Puntaje, FechaEvaluacion, UsuarioEvaluador, Observaciones) VALUES
(1, 1, 75, '2025-01-15', 'compliance1', 'Evaluación satisfactoria'),
(2, 2, 60, '2025-01-20', 'analista1', 'Requiere atención adicional'),
(3, 3, 85, '2025-01-22', 'compliance1', 'Bajo riesgo identificado'),
(4, 4, 70, '2025-01-25', 'analista1', 'Riesgo manejable'),
(5, 5, 90, '2025-01-27', 'compliance1', 'Muy bajo riesgo');


-- ===========================================
-- 20. MENSAJES CHAT
-- ===========================================
INSERT INTO MensajesChat (UsuarioId, Mensaje, FechaEnvio) VALUES
(1, 'Sistema inicializado correctamente', '2025-01-01'),
(2, 'Nueva evaluación de riesgo completada', '2025-01-15'),
(3, 'Análisis de cliente finalizado', '2025-01-20'),
(4, 'Auditoría interna programada', '2025-01-25'),
(1, 'Mantenimiento del sistema completado', '2025-01-30');


-- ===========================================
-- 21. POLITICAS
-- ===========================================
INSERT INTO Politicas (Nombre, Descripcion, FechaCreacion) VALUES
('Política de Prevención de Lavado de Activos', 'Establece las medidas para prevenir el lavado de activos', '2025-01-01'),
('Política de Conocimiento del Cliente', 'Define los procedimientos para conocer a los clientes', '2025-01-05'),
('Política de Reporte de Operaciones Sospechosas', 'Regula el reporte de actividades sospechosas', '2025-01-10'),
('Política de Capacitación', 'Establece los programas de capacitación obligatorios', '2025-01-15'),
('Política de Monitoreo Continuo', 'Define el monitoreo continuo de clientes y transacciones', '2025-01-20');


-- ===========================================
-- 22. CAPACITACIONES
-- ===========================================
INSERT INTO Capacitaciones (Titulo, Descripcion, DuracionHoras, Estado, FechaCreacion, FechaInicio, FechaFin, Instructor) VALUES
('Prevención de Lavado de Activos', 'Curso básico sobre PLD y FT', 8, 'Activa', '2025-01-01', '2025-02-01', '2025-02-08', 'Dr. María González'),
('Conocimiento del Cliente', 'Técnicas para identificar y verificar clientes', 6, 'Activa', '2025-01-05', '2025-02-10', '2025-02-15', 'Lic. Carlos Rodríguez'),
('Reporte de Operaciones Sospechosas', 'Cómo identificar y reportar actividades sospechosas', 4, 'Activa', '2025-01-10', '2025-02-20', '2025-02-24', 'Dra. Ana López'),
('Cumplimiento Regulatorio', 'Actualizaciones en normativa de cumplimiento', 12, 'Planificada', '2025-01-15', '2025-03-01', '2025-03-15', 'Dr. Roberto Sánchez'),
('Ética Profesional', 'Principios éticos en el sector financiero', 3, 'Activa', '2025-01-20', '2025-02-25', '2025-02-27', 'Lic. Patricia Díaz');




-- ===========================================
-- 24. DOCUMENTOS
-- ===========================================
INSERT INTO Documentos (DebidaDiligenciaId, Nombre, Descripcion, Tipo, RutaArchivo, FechaSubida, Verificado) VALUES
(1, 'Cedula_Juan_Perez.pdf', 'Copia de cédula de identidad', 'Identificación', '/documents/clientes/cedula_juan_perez.pdf', '2025-01-02', 1),
(2, 'Registro_TechSolutions.pdf', 'Registro comercial de la empresa', 'Legal', '/documents/empresas/registro_techsolutions.pdf', '2025-01-12', 1),
(3, 'Licencia_Maria_Diaz.pdf', 'Licencia profesional', 'Profesional', '/documents/profesionales/licencia_maria_diaz.pdf', '2025-01-07', 1),
(4, 'Estados_Financieros_Globales.pdf', 'Estados financieros auditados', 'Financiero', '/documents/financieros/estados_globales.pdf', '2025-01-18', 0),
(5, 'Contrato_Roberto_Sanchez.pdf', 'Contrato comercial', 'Comercial', '/documents/comerciales/contrato_roberto_sanchez.pdf', '2025-01-11', 1);


PRINT 'Seed data inserted successfully!';
