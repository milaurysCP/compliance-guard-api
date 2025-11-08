-- ===========================================
-- Esquema de Cumplimiento Unificado (SQL Server) - Versión en Español
-- ===========================================

-- Roles y Usuarios
CREATE TABLE Roles (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255)
);

CREATE TABLE Usuarios (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    UsuarioLogin NVARCHAR(100) NOT NULL UNIQUE,
    Nombre NVARCHAR(200),
    ClaveHash NVARCHAR(255) NOT NULL,
    Token NVARCHAR(255),
    RolId BIGINT NOT NULL,
    EstaActivo BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_Usuarios_Roles FOREIGN KEY (RolId) REFERENCES Roles(Id)
);

-- Clientes
CREATE TABLE Clientes (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    TipoCliente NVARCHAR(50) NOT NULL, -- Persona / Empresa
    Nombre NVARCHAR(200) NOT NULL,
    Url NVARCHAR(255),
    DocumentoIdentidad NVARCHAR(50),
    RegistroComercial NVARCHAR(100),
    FechaNacimiento DATETIME,
    EstaActivo BIT NOT NULL DEFAULT 1,
    Estado NVARCHAR(50) DEFAULT 'Activo',
    FechaRegistro DATETIME DEFAULT GETDATE()
);

CREATE TABLE BeneficiariosFinales (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(200),
    ClienteId BIGINT NOT NULL,
    CONSTRAINT FK_BeneficiariosFinales_Clientes FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
);

CREATE TABLE Intermediarios (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(200),
    ClienteId BIGINT NOT NULL,
    CONSTRAINT FK_Intermediarios_Clientes FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
);

-- Direcciones y Contactos
CREATE TABLE Direcciones (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    Calle NVARCHAR(200),
    Numero NVARCHAR(20),
    Sector NVARCHAR(100),
    Municipio NVARCHAR(100),
    Provincia NVARCHAR(100),
    Pais NVARCHAR(100),
    CodigoPostal NVARCHAR(20),
    ClienteId BIGINT NOT NULL,
    CONSTRAINT FK_Direcciones_Clientes FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
);

CREATE TABLE Contactos (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    Tipo NVARCHAR(50), -- Teléfono / Móvil / Correo
    Valor NVARCHAR(200),
    ClienteId BIGINT NOT NULL,
    CONSTRAINT FK_Contactos_Clientes FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
);

-- Actividades Económicas y Perfil Financiero
CREATE TABLE ActividadesEconomicas (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    Proveedor NVARCHAR(50),
    PrincipalCliente NVARCHAR(50),
    CampoLaboral NVARCHAR(50),
    Proyecto NVARCHAR(50),
    Inscripciones NVARCHAR(50),
    OrigenFondos NVARCHAR(100),
    ClienteId BIGINT NOT NULL,
    CONSTRAINT FK_ActividadesEconomicas_Clientes FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
);

CREATE TABLE PerfilesFinancieros (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    NivelIngreso DECIMAL(18,2),
    Fuente NVARCHAR(200),
    ClienteId BIGINT NOT NULL,
    CONSTRAINT FK_PerfilesFinancieros_Clientes FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
);

-- Operaciones y Transacciones
CREATE TABLE Operaciones (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    Tipo NVARCHAR(100),
    Codigo NVARCHAR(50),
    ClienteId BIGINT NOT NULL,
    CONSTRAINT FK_Operaciones_Clientes FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
);

CREATE TABLE Pagos (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    Tipo NVARCHAR(100),
    Codigo NVARCHAR(50),
    Moneda NVARCHAR(50),
    Monto DECIMAL(18,2),
    OperacionId BIGINT NOT NULL,
    CONSTRAINT FK_Pagos_Operaciones FOREIGN KEY (OperacionId) REFERENCES Operaciones(Id)
);

CREATE TABLE Transacciones (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    Tipo NVARCHAR(100),
    InstitucionFinanciera NVARCHAR(200),
    Descripcion NVARCHAR(255),
    PropositoProducto NVARCHAR(200),
    FormaDeposito NVARCHAR(100),
    FormaExpectativa NVARCHAR(100),
    ClienteId BIGINT NOT NULL,
    CONSTRAINT FK_Transacciones_Clientes FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
);

-- Cumplimiento: Referencias, PEP, Responsables
CREATE TABLE Referencias (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    Recomendacion NVARCHAR(200),
    Descripcion NVARCHAR(255),
    ClienteId BIGINT NOT NULL,
    CONSTRAINT FK_Referencias_Clientes FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
);

CREATE TABLE PersonasExpuestasPoliticamente (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(200),
    Cargo NVARCHAR(100),
    Ordenanza NVARCHAR(100),
    Institucion NVARCHAR(200),
    ClienteId BIGINT NOT NULL,
    CONSTRAINT FK_PEP_Clientes FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
);

CREATE TABLE Responsables (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100),
    Apellido NVARCHAR(100),
    Direccion NVARCHAR(200),
    Telefono NVARCHAR(50),
    Cargo NVARCHAR(100),
    Correo NVARCHAR(150),
    DocumentoIdentificacion NVARCHAR(100),
    ClienteId BIGINT NOT NULL,
    CONSTRAINT FK_Responsables_Clientes FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
);

-- Políticas, Riesgos y Cumplimiento
CREATE TABLE DebidaDiligencias (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    ClienteId BIGINT NOT NULL,
    Titulo NVARCHAR(200) NOT NULL,
    Descripcion NVARCHAR(1000),
    Estado NVARCHAR(50),
    FechaInicio DATETIME NOT NULL,
    FechaFin DATETIME,
    Observaciones NVARCHAR(1000),
    Conclusion NVARCHAR(1000),
    ResponsableId BIGINT,
    CONSTRAINT FK_DebidaDiligencias_Clientes FOREIGN KEY (ClienteId) REFERENCES Clientes(Id),
    CONSTRAINT FK_DebidaDiligencias_Responsables FOREIGN KEY (ResponsableId) REFERENCES Responsables(Id) ON DELETE NO ACTION
);

CREATE TABLE Riesgos (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(200),
    Identificador NVARCHAR(50),
    Tipo NVARCHAR(50),
    Categoria NVARCHAR(50),
    Estado NVARCHAR(50),
    DescripcionRiesgo NVARCHAR(255),
    Objetivo NVARCHAR(50),
    Fase NVARCHAR(50),
    Causa NVARCHAR(200),
    Efecto NVARCHAR(200),
    Disparador NVARCHAR(100),
    DisparadorDescripcion NVARCHAR(100),
    FechaCreacion DATETIME,
    DebidaDiligenciaId BIGINT NOT NULL,
    CONSTRAINT FK_Riesgos_DebidaDiligencias FOREIGN KEY (DebidaDiligenciaId) REFERENCES DebidaDiligencias(Id)
);

CREATE TABLE Mitigaciones (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    RiesgoId BIGINT NOT NULL,
    Accion NVARCHAR(255) NOT NULL,            
    Responsable NVARCHAR(150) NOT NULL,      
    Estado NVARCHAR(50) DEFAULT 'Pendiente', 
    FechaInicio DATETIME,
    FechaCierre DATETIME,
    Observaciones NVARCHAR(500),
    Eficacia DECIMAL(5,2),
    CONSTRAINT FK_Mitigaciones_Riesgos FOREIGN KEY (RiesgoId) REFERENCES Riesgos(Id)
);

CREATE TABLE Evaluaciones (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    RiesgoId BIGINT NOT NULL,
    ClienteId BIGINT NOT NULL,
    Puntaje INT,
    FechaEvaluacion DATETIME NOT NULL,
    UsuarioEvaluador NVARCHAR(100),
    Observaciones NVARCHAR(500),
    CONSTRAINT FK_Evaluaciones_Riesgos FOREIGN KEY (RiesgoId) REFERENCES Riesgos(Id) ON DELETE NO ACTION,
    CONSTRAINT FK_Evaluaciones_Clientes FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
);

CREATE TABLE MensajesChat (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    UsuarioId BIGINT NOT NULL,
    Mensaje NVARCHAR(500),
    FechaEnvio DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_MensajesChat_Usuarios FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id)
);

-- Políticas
CREATE TABLE Politicas (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(200) NOT NULL,
    Descripcion NVARCHAR(500),
    FechaCreacion DATETIME DEFAULT GETDATE()
);

-- Capacitaciones
CREATE TABLE Capacitaciones (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    Titulo NVARCHAR(200) NOT NULL,
    Descripcion NVARCHAR(1000),
    DuracionHoras INT NOT NULL,
    FechaInicio DATETIME NOT NULL,
    FechaFin DATETIME NOT NULL,
    Instructor NVARCHAR(200),
    Estado NVARCHAR(50),
    FechaCreacion DATETIME DEFAULT GETDATE()
);

-- Documentos
CREATE TABLE Documentos (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    DebidaDiligenciaId BIGINT NOT NULL,
    Nombre NVARCHAR(200) NOT NULL,
    Tipo NVARCHAR(100),
    RutaArchivo NVARCHAR(500),
    Descripcion NVARCHAR(1000),
    Verificado BIT NOT NULL DEFAULT 0,
    FechaSubida DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Documentos_DebidaDiligencias FOREIGN KEY (DebidaDiligenciaId) REFERENCES DebidaDiligencias(Id)
);
