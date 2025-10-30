-- ===========================================
-- Esquema de Cumplimiento Unificado (MySQL) - Versión en Español
-- ===========================================

-- Roles y Usuarios
CREATE TABLE Roles (
    Id BIGINT PRIMARY KEY AUTO_INCREMENT,
    Nombre VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(255)
);

CREATE TABLE Usuarios (
    Id BIGINT PRIMARY KEY AUTO_INCREMENT,
    Nombres VARCHAR(50) NOT NULL,
    Usuario VARCHAR(100) NOT NULL UNIQUE,
    ClaveHash VARCHAR(255) NOT NULL,
    Token VARCHAR(255),
    RolId BIGINT NOT NULL,
    CONSTRAINT FK_Usuarios_Roles FOREIGN KEY (RolId) REFERENCES Roles(Id)
);

-- Clientes
CREATE TABLE Clientes (
    Id BIGINT PRIMARY KEY AUTO_INCREMENT,
    TipoCliente VARCHAR(50) NOT NULL, -- Persona / Empresa
    Nombre VARCHAR(200) NOT NULL,
    DocumentoIdentidad VARCHAR(50),
    RegistroComercial VARCHAR(50),
    RegistroOnapi VARCHAR(50),
    CasaMatriz VARCHAR(50),
    Siglas VARCHAR(10),
    Fecha DATE
);

CREATE TABLE BeneficiariosFinales (
    Id BIGINT PRIMARY KEY AUTO_INCREMENT,
    Nombres VARCHAR(50),
    Apellidos VARCHAR(50),
    Identificacion VARCHAR(50),
    Nacionalidad VARCHAR(50),
    ClienteId BIGINT NOT NULL,
    CONSTRAINT FK_BeneficiariosFinales_Clientes FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
);

CREATE TABLE Intermediarios (
    Id BIGINT PRIMARY KEY AUTO_INCREMENT,
    Nombres VARCHAR(50),
    Apellidos VARCHAR(50),
    Identificacion VARCHAR(50),
    Nacionalidad VARCHAR(50),
    ClienteId BIGINT NOT NULL,
    CONSTRAINT FK_Intermediarios_Clientes FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
);

-- Direcciones y Contactos
CREATE TABLE Direcciones (
    Id BIGINT PRIMARY KEY AUTO_INCREMENT,
    Calle VARCHAR(200),
    Numero VARCHAR(20),
    Sector VARCHAR(100),
    Municipio VARCHAR(100),
    Provincia VARCHAR(100),
    Pais VARCHAR(100),
    CodigoPostal VARCHAR(20),
    ClienteId BIGINT NOT NULL,
    CONSTRAINT FK_Direcciones_Clientes FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
);

CREATE TABLE Contactos (
    Id BIGINT PRIMARY KEY AUTO_INCREMENT,
    Tipo VARCHAR(50), -- Teléfono / Móvil / Correo
    Valor VARCHAR(200),
    ClienteId BIGINT NOT NULL,
    CONSTRAINT FK_Contactos_Clientes FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
);

-- Actividades Económicas y Perfil Financiero
CREATE TABLE ActividadesEconomicas (
    Id BIGINT PRIMARY KEY AUTO_INCREMENT,
    Proveedor VARCHAR(50),
    PrincipalCliente VARCHAR(50),
    CampoLaboral VARCHAR(50),
    Proyecto VARCHAR(50),
    Inscripciones VARCHAR(50),
    OrigenFondos VARCHAR(100),
    ClienteId BIGINT NOT NULL,
    CONSTRAINT FK_ActividadesEconomicas_Clientes FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
);

CREATE TABLE PerfilesFinancieros (
    Id BIGINT PRIMARY KEY AUTO_INCREMENT,
    NivelIngreso DECIMAL(18,2),
    Fuente VARCHAR(200),
    ClienteId BIGINT NOT NULL,
    CONSTRAINT FK_PerfilesFinancieros_Clientes FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
);

-- Operaciones y Transacciones
CREATE TABLE Operaciones (
    Id BIGINT PRIMARY KEY AUTO_INCREMENT,
    Tipo VARCHAR(100),
    Codigo VARCHAR(50),
    ClienteId BIGINT NOT NULL,
    CONSTRAINT FK_Operaciones_Clientes FOREIGN KEY (ClienteId) REFERENCES Operaciones(Id)
);

CREATE TABLE Pagos (
    Id BIGINT PRIMARY KEY AUTO_INCREMENT,
    Tipo VARCHAR(100),
    Codigo VARCHAR(50),
    Moneda VARCHAR(50),
    Monto DECIMAL(18,2),
    OperacionId BIGINT NOT NULL,
    CONSTRAINT FK_Pagos_Operaciones FOREIGN KEY (OperacionId) REFERENCES Operaciones(Id)
);

CREATE TABLE Transacciones (
    Id BIGINT PRIMARY KEY AUTO_INCREMENT,
    Tipo VARCHAR(100),
    InstitucionFinanciera VARCHAR(200),
    Descripcion VARCHAR(255),
    PropositoProducto VARCHAR(200),
    FormaDeposito VARCHAR(100),
    FormaExpectativa NVARCHAR(100),
    ClienteId BIGINT NOT NULL,
    CONSTRAINT FK_Transacciones_Clientes FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
);

-- Cumplimiento: Referencias, PEP, Responsables
CREATE TABLE Referencias (
    Id BIGINT PRIMARY KEY AUTO_INCREMENT,
    Recomendacion VARCHAR(200),
    Descripcion VARCHAR(255),
    ClienteId BIGINT NOT NULL,
    CONSTRAINT FK_Referencias_Clientes FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
);

CREATE TABLE PersonasExpuestasPoliticamente (
    Id BIGINT PRIMARY KEY AUTO_INCREMENT,
    Nombre VARCHAR(200),
    Cargo VARCHAR(100),
    Ordenanza VARCHAR(100),
    Institucion VARCHAR(200),
    ClienteId BIGINT NOT NULL,
    CONSTRAINT FK_PEP_Clientes FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
);

CREATE TABLE Responsables (
    Id BIGINT PRIMARY KEY AUTO_INCREMENT,
    Nombre VARCHAR(100),
    Apellido VARCHAR(100),
    Direccion VARCHAR(200),
    Telefono VARCHAR(50),
    Cargo VARCHAR(100),
    Correo VARCHAR(150),
    DocumentoIdentificacion VARCHAR(100),
    ClienteId BIGINT NOT NULL,
    CONSTRAINT FK_Responsables_Clientes FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
);

-- Políticas, Riesgos y Cumplimiento
CREATE TABLE DebidaDiligencia (
    Id BIGINT PRIMARY KEY AUTO_INCREMENT,
    Nombre VARCHAR(200),
    Descripcion VARCHAR(255),
    FechaCreacion DATETIME DEFAULT CURRENT_TIMESTAMP,
    ClienteId BIGINT NOT NULL,
    CONSTRAINT FK_DebidaDiligencia_Clientes FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
);

CREATE TABLE Riesgos (
    Id BIGINT PRIMARY KEY AUTO_INCREMENT,
    Nombre VARCHAR(200),
    Identificador VARCHAR(50),
    Tipo VARCHAR(50),
    Categoria VARCHAR(50),
    Estado VARCHAR(50),
    DescripcionRiesgo VARCHAR(255),
    Objetivo VARCHAR(50),
    Fase VARCHAR(50),
    Causa VARCHAR(200),
    Efecto VARCHAR(200),
    Disparador VARCHAR(100),
    DisparadorDescripcion VARCHAR(100),
    FechaCreacion DATE,
    DebidaDiligenciaId BIGINT NOT NULL,
    CONSTRAINT FK_Riesgo_DebidaDiligencia FOREIGN KEY (DebidaDiligenciaId) REFERENCES DebidaDiligencia(Id)
);

CREATE TABLE Mitigacion (
    Id BIGINT PRIMARY KEY AUTO_INCREMENT,
    RiesgoId BIGINT NOT NULL,
    Accion VARCHAR(255) NOT NULL,
    Responsable VARCHAR(150) NOT NULL,
    Estado VARCHAR(50) DEFAULT 'Pendiente',
    FechaInicio DATE,
    FechaCierre DATE,
    Observaciones VARCHAR(500),
    Eficacia DECIMAL(5,2),
    CONSTRAINT FK_Mitigacion_Riesgos FOREIGN KEY (RiesgoId) REFERENCES Riesgos(Id)
);

CREATE TABLE Evaluaciones (
    Id BIGINT PRIMARY KEY AUTO_INCREMENT,
    RiesgoId BIGINT NOT NULL,
    ClienteId BIGINT NOT NULL,
    Puntaje INT,
    FechaEvaluacion DATE,
    UsuarioEvaluador VARCHAR(100),
    Observaciones VARCHAR(500),
    CONSTRAINT FK_Evaluaciones_Riesgos FOREIGN KEY (RiesgoId) REFERENCES Riesgos(Id),
    CONSTRAINT FK_Evaluaciones_Clientes FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
);

CREATE TABLE MensajesChat (
    Id BIGINT PRIMARY KEY AUTO_INCREMENT,
    UsuarioId BIGINT NOT NULL,
    Mensaje VARCHAR(500),
    FechaEnvio DATE,
    CONSTRAINT FK_MensajesChat_Usuarios FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id)
);