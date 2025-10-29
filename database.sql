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
    Usuario NVARCHAR(100) NOT NULL UNIQUE,
    ClaveHash NVARCHAR(255) NOT NULL,
    Token NVARCHAR(255),
    RolId BIGINT NOT NULL,
    CONSTRAINT FK_Usuarios_Roles FOREIGN KEY (RolId) REFERENCES Roles(Id)
);

-- Clientes
CREATE TABLE Clientes (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    TipoCliente NVARCHAR(50) NOT NULL, -- Persona / Empresa
    Nombre NVARCHAR(200) NOT NULL,
    Telefono NVARCHAR(50),
    Correo NVARCHAR(150),
    Url NVARCHAR(255),
    DocumentoIdentidad NVARCHAR(50),
    RegistroComercial NVARCHAR(100),
    FechaNacimiento DATE
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
    Tipo NVARCHAR(100),
    Descripcion NVARCHAR(255),
    ClienteId BIGINT NOT NULL,
    CONSTRAINT FK_ActividadesEconomicas_Clientes FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
);

CREATE TABLE PerfilesFinancieros (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    NivelIngreso NVARCHAR(100),
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
CREATE TABLE Politicas (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(200),
    Descripcion NVARCHAR(255),
    FechaCreacion DATETIME DEFAULT GETDATE()
);

CREATE TABLE Riesgos (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(200),
    Descripcion NVARCHAR(255),
    Mitigacion NVARCHAR(255),
    FechaCreacion DATETIME DEFAULT GETDATE()
);

CREATE TABLE Evaluaciones (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    RiesgoId BIGINT NOT NULL,
    ClienteId BIGINT NOT NULL,
    Puntaje INT,
    FechaEvaluacion DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Evaluaciones_Riesgos FOREIGN KEY (RiesgoId) REFERENCES Riesgos(Id),
    CONSTRAINT FK_Evaluaciones_Clientes FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
);

-- Entrenamiento y Registros
CREATE TABLE Capacitaciones (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    Titulo NVARCHAR(200),
    Descripcion NVARCHAR(255),
    FechaCreacion DATETIME DEFAULT GETDATE()
);

CREATE TABLE ProgresoCapacitacion (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    CapacitacionId BIGINT NOT NULL,
    UsuarioId BIGINT NOT NULL,
    Estado NVARCHAR(50),
    FechaCompletado DATETIME,
    CONSTRAINT FK_ProgresoCapacitacion_Capacitaciones FOREIGN KEY (CapacitacionId) REFERENCES Capacitaciones(Id),
    CONSTRAINT FK_ProgresoCapacitacion_Usuarios FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id)
);

CREATE TABLE MensajesChat (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    UsuarioId BIGINT NOT NULL,
    Mensaje NVARCHAR(500),
    FechaEnvio DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_MensajesChat_Usuarios FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id)
);
