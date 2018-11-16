USE [GD2C2018]

GO

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name='TheBigBangQuery')

BEGIN

EXEC ('CREATE SCHEMA [TheBigBangQuery] AUTHORIZATION [gdEspectaculos2018]')

END

GO

BEGIN TRANSACTION

CREATE TABLE [TheBigBangQuery].[ROLES] (
    rol_cod NUMERIC(12,0) NOT NULL IDENTITY(0,1),
    rol_nombre nvarchar(255),
    rol_dado_baja DATETIME,

    CONSTRAINT [PK_ROLES] PRIMARY kEY ([rol_cod])
);

CREATE TABLE [TheBigBangQuery].[Funcionalidades_rol] (
    fpr_id NUMERIC(12,0) NOT NULL,
    fpr_rol  NUMERIC(12,0) NOT NULL

    CONSTRAINT [PK_FPR] PRIMARY KEY([fpr_id], [fpr_rol])
);

CREATE TABLE [TheBigBangQuery].[Funcionalidad] (
    func_id NUMERIC(12,0) NOT NULL IDENTITY(0,1),
    func_desc nvarchar(255)

    CONSTRAINT [PK_FUNC] PRIMARY KEY ([func_id])
);

ALTER TABLE [TheBigBangQuery].[Funcionalidades_rol]
    ADD CONSTRAINT [FK_func_por_rol_f] FOREIGN KEY ([fpr_id]) REFERENCES [TheBigBangQuery].[Funcionalidad](func_id);

ALTER TABLE [TheBigBangQuery].[Funcionalidades_rol]
    ADD CONSTRAINT [FK_func_por_rol_r] FOREIGN KEY ([fpr_rol]) REFERENCES [TheBigBangQuery].[Rol](rol_cod);

CREATE TABLE [TheBigBangQuery].[Roles_usuario] (
    rolu_rol NUMERIC(12,0) NOT NULL,
    rolu_usuario NUMERIC(12,0),

    CONSTRAINT [PK_ROLUS] PRIMARY KEY ([rolu_rol], [rolu_usuario])
);

CREATE TABLE [TheBigBangQuery].[Usuario] (
    usua_id NUMERIC(12,0) NOT NULL IDENTITY(0,1),
    usua_rol NUMERIC(12,0),
    usua_usuario nvarchar(255),
    usua_password nvarchar(255),
    usua_n_intentos INTEGER,

    CONSTRAINT [PK_USUA] PRIMARY KEY([usua_id])
);

ALTER TABLE [TheBigBangQuery].[Roles_usuario]
    ADD CONSTRAINT [FK_ROLU_r] FOREIGN KEY ([rolu_rol]) REFERENCES [TheBigBangQuery].[Rol](rol_cod);
    
ALTER TABLE [TheBigBangQuery].[Roles_usuario]
    ADD CONSTRAINT [FK_ROLU_u] FOREIGN KEY ([rolu_usuario]) REFERENCES [TheBigBangQuery].[Usuario](usua_id);


CREATE TABLE [TheBigBangQuery].[Empresa] (
    empr_id NUMERIC(12,0) NOT NULL IDENTITY(0,1),
	empr_cuil nvarchar(255) NOT NULL,
    empr_razon_social nvarchar(255) NOT NULL,
    empr_usuario NUMERIC(12,0),
    empr_mail nvarchar(50),
    empr_telefono nvarchar(255),
    empr_direccion nvarchar(50),
    empr_numero_calle NUMERIC(18,0),
    empr_piso NUMERIC(18,0),
    empr_dpto nvarchar(50),
    empr_localidad nvarchar(255),
    empr_codigo_postal nvarchar(50),
    empr_ciudad nvarchar(255),
    empr_creacion DATETIME,
    empr_dado_baja DATETIME

    CONSTRAINT [PK_Empr] PRIMARY KEY ([empr_id])
);

ALTER TABLE [TheBigBangQuery].[Empresa] 
    ADD CONSTRAINT [FK_EMPR] FOREIGN KEY ([empr_usuario]) REFERENCES [TheBigBangQuery].[Usuario](usua_id);

CREATE TABLE [TheBigBangQuery].[Premio] (
    prem_id NUMERIC(18,0) NOT NULL IDENTITY(0,1),
    prem_puntos_necesarios NUMERIC(18,0),
    prem_nombre NVARCHAR(255),
    prem_vencimiento DATETIME

    CONSTRAINT [PK_PREM] PRIMARY KEY (prem_id)
);


CREATE TABLE [TheBigBangQuery].[Cliente] (
    clie_id NUMERIC(18,0) NOT NULL IDENTITY(1,1),
    clie_dni NUMERIC(18,0) NOT NULL,
    clie_usuario NUMERIC(12,0),
    clie_nombre nvarchar(255),
    clie_apellido nvarchar(255),
    clie_tipo_documento nvarchar(255),
    clie_cuil nvarchar(255),
    clie_mail nvarchar(255),
    clie_telefono nvarchar(50),
    clie_direccion nvarchar(50),
    clie_numero_calle NUMERIC(18,0),
    clie_piso NUMERIC(18,0),
    clie_locacalidad nvarchar(255),
    clie_codigo_postal nvarchar(255),
    clie_f_nacimiento DATETIME,
    clie_f_creacion DATETIME,
    clie_n_tarjeta NUMERIC(18,0),
    clie_dado_baja DATETIME,
    clie_puntos NUMERIC(18,0),
    clie_prox_vencimiento_puntos DATETIME

    CONSTRAINT [PK_Clie] PRIMARY KEY ([clie_dni])
);

ALTER TABLE [TheBigBangQuery].[Cliente] 
    ADD CONSTRAINT [FK_CLI_USER] FOREIGN KEY ([clie_usuario]) REFERENCES [TheBigBangQuery].[Usuario](usua_id);

ALTER TABLE [TheBigBangQuery].[Cliente] 
    ADD CONSTRAINT [FK_CLI_PREM] FOREIGN KEY ([clie_puntos]) REFERENCES [TheBigBangQuery].[Premio](prem_id);


CREATE TABLE [TheBigBangQuery].[Rubro] (
    rub_id NUMERIC(12,0) NOT NULL IDENTITY(0,1),
    rub_descripcion nvarchar(255),
    rub_dado_de_baja DATETIME

    CONSTRAINT [PK_RUB] PRIMARY KEY ([rub_id])
);

CREATE TABLE [TheBigBangQuery].[Espectaculo] (
    espe_id NUMERIC(12,0) NOT NULL IDENTITY(0,1),
    espe_empresa NUMERIC(12,0),
    espe_rubro NUMERIC(12,0),
    espe_descripcion nvarchar(255),
    espe_direccion nvarchar(255),

    CONSTRAINT [PK_ESPE] PRIMARY KEY ([espe_id])
);

ALTER TABLE [TheBigBangQuery].[Espectaculo] 
    ADD CONSTRAINT [FK_ESPEC_RUBR] FOREIGN KEY ([espe_rubro]) REFERENCES [TheBigBangQuery].[Rubro](rub_id);

ALTER TABLE [TheBigBangQuery].[Espectaculo]
    ADD CONSTRAINT [FK_ESPE_EMPR] FOREIGN KEY ([espe_empresa]) REFERENCES [TheBigBangQuery].[Empresa](empr_id);

CREATE TABLE [TheBigBangQuery].[GradoPublicaciones] (
    grad_nivel nvarchar(10) NOT NULL,
    grad_comision NUMERIC(10,2),
    grad_baja DATETIME

    CONSTRAINT [PK_GRAD] PRIMARY KEY ([grad_nivel])
);

CREATE TABLE [TheBigBangQuery].[Publicacion] (
    publ_id NUMERIC(12,0) NOT NULL IDENTITY(0,1),
    publ_espectaculo NUMERIC(12,0),
    publ_grad_nivel nvarchar(10),
    publ_fecha_publicacion DATETIME,
    publ_fecha_hora_espectaculo DATETIME,
    publ_estado nvarchar(50)

    CONSTRAINT [PK_PUBL] PRIMARY KEY ([publ_id])
);

ALTER TABLE [TheBigBangQuery].[Publicacion]
    ADD CONSTRAINT [PK_ESPEC_ESPE] FOREIGN KEY ([publ_espectaculo]) REFERENCES [TheBigBangQuery].[Espectaculo](espe_id);

ALTER TABLE [TheBigBangQuery].[Publicacion]
    ADD CONSTRAINT [PK_PUBL_GRADO] FOREIGN KEY ([publ_grad_nivel]) REFERENCES [TheBigBangQuery].[GradoPublicaciones](grad_nivel);

CREATE TABLE [TheBigBangQuery].[Ubicacion] (
    ubi_id NUMERIC(12,0) NOT NULL IDENTITY(1,1),
    ubi_fila VARCHAR(3),
    ubi_asiento NUMERIC(18,0),
    ubi_sin_enumerar BIT,
    ubi_tipo_codigo NUMERIC(18,0),
    ubi_tipo_descripcion NVARCHAR(255)

    CONSTRAINT [PK_UBI] PRIMARY KEY ([ubi_id])
);

CREATE TABLE [TheBigBangQuery].[Ubicaciones_publicacion] (
    ubpu_id_publicacion NUMERIC(12,0) NOT NULL,
    ubpu_id_ubicacion NUMERIC(12,0) NOT NULL,
    ubpu_precio NUMERIC(18,0),
    ubpu_disponible BIT

    CONSTRAINT [PK_UBPU] PRIMARY KEY ([ubpu_id_publicacion], [ubpu_id_ubicacion])
);

ALTER TABLE [TheBigBangQuery].[Ubicaciones_publicacion]
    ADD CONSTRAINT [FK_UBPU_UBI] FOREIGN KEY ([ubpu_id_ubicacion]) REFERENCES [TheBigBangQuery].[Ubicacion](ubi_id);

ALTER TABLE [TheBigBangQuery].[Ubicaciones_publicacion]
    ADD CONSTRAINT [FK_UBPU_PUBL] FOREIGN KEY ([ubpu_id_publicacion]) REFERENCES [TheBigBangQuery].[Publicacion](publ_id);


CREATE TABLE [TheBigBangQuery].[Item_Factura] (
    item_id NUMERIC(18,0) NOT NULL IDENTITY(1,1),
    item_n_factura NUMERIC(18,0) NOT NULL,
    item_publicacion NUMERIC(12,0),
    item_ubicacion NUMERIC(12,0),
    item_monto NUMERIC(18,2),
    item_cantidad NUMERIC(18,0),
    item_descripcion NVARCHAR(60)

    CONSTRAINT [PK_ITEM] PRIMARY KEY ([item_id], [item_n_factura])
);

CREATE TABLE [TheBigBangQuery].[Factura] (
    fact_numero NUMERIC(18,0) NOT NULL IDENTITY(1,1),
    fact_forma_de_pago NVARCHAR(255),
    fact_total NUMERIC(18,2),
    fact_fecha DATETIME,
    fact_empresa NUMERIC(12,0)

    CONSTRAINT [PK_FACT] PRIMARY KEY (fact_numero)
);

ALTER TABLE [TheBigBangQuery].[Item_Factura]
    ADD CONSTRAINT [FK_ITEM_FACT] FOREIGN KEY ([item_n_factura]) REFERENCES [TheBigBangQuery].[Factura](fact_numero);

ALTER TABLE [TheBigBangQuery].[Item_Factura]
    ADD CONSTRAINT [FK_ITEM_UBI] FOREIGN KEY ([item_ubicacion]) REFERENCES [TheBigBangQuery].[Ubicacion](ubi_id);

ALTER TABLE [TheBigBangQuery].[Item_Factura]
    ADD CONSTRAINT [FK_ITEM_PUBLI] FOREIGN KEY ([item_publicacion]) REFERENCES [TheBigBangQuery].[Publicacion](publ_id);


CREATE TABLE [TheBigBangQuery].[Compras] (
    comp_id NUMERIC(12,0) NOT NULL IDENTITY(0,1),
    comp_cliente NUMERIC(12,0),
    comp_ubicacion NUMERIC(12,0), 
    comp_n_factura NUMERIC(18,0),
    comp_fecha_y_hora DATETIME,
    comp_medio_de_pago nvarchar(255),
    comp_cantidad NUMERIC(12,0)

    CONSTRAINT [PK_COMP] PRIMARY KEY ([comp_id])
);

ALTER TABLE [TheBigBangQuery].[Compras] 
    ADD CONSTRAINT [FK_COMP_CLI] FOREIGN KEY (comp_cliente) REFERENCES [TheBigBangQuery].[Cliente](clie_id);

ALTER TABLE [TheBigBangQuery].[Compras] 
    ADD CONSTRAINT [FK_COMP_UBI] FOREIGN KEY (comp_ubicacion) REFERENCES [TheBigBangQuery].[Ubicacion](ubi_id);

ALTER TABLE [TheBigBangQuery].[Compras] 
    ADD CONSTRAINT [FK_COMP_UBI] FOREIGN KEY (comp_n_factura) REFERENCES [TheBigBangQuery].[Factura](fact_numero);

COMMIT