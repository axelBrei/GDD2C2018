USE [GD2C2018]

BEGIN TRANSACTION
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name='TheBigBangQuery')
EXEC ('CREATE SCHEMA [TheBigBangQuery] AUTHORIZATION [gd]')
COMMIT 

IF object_id('TheBigBangQuery.Premio') IS NOT NULL
	DROP TABLE TheBigBangQuery.Premio;
IF object_id('TheBigBangQuery.FormaDePago') IS NOT NULL
	DROP TABLE TheBigBangQuery.FormaDePago;
IF OBJECT_ID('[TheBigBangQuery].[Ubicaciones_Compra]') IS NOT NULL
	DROP TABLE [TheBigBangQuery].[Ubicaciones_Compra];
IF object_id('TheBigBangQuery.Ubicaciones_publicacion') IS NOT NULL
	DROP TABLE TheBigBangQuery.Ubicaciones_publicacion;
IF object_id('TheBigBangQuery.Compras') IS NOT NULL
	DROP TABLE TheBigBangQuery.Compras;
IF OBJECT_ID('[TheBigBangQuery].[Tarjetas]') IS NOT NULL
	DROP TABLE [TheBigBangQuery].[Tarjetas];
IF object_id('TheBigBangQuery.Cliente') IS NOT NULL
	DROP TABLE TheBigBangQuery.Cliente;
IF object_id('TheBigBangQuery.Tipo_Documento') IS NOT NULL
	DROP TABLE TheBigBangQuery.Tipo_Documento;
IF object_id('TheBigBangQuery.Roles_usuario') IS NOT NULL
	DROP TABLE TheBigBangQuery.Roles_usuario;
IF object_id('TheBigBangQuery.Funcionalidades_rol') IS NOT NULL
	DROP TABLE TheBigBangQuery.Funcionalidades_rol;
IF object_id('TheBigBangQuery.Funcionalidad') IS NOT NULL
	DROP TABLE TheBigBangQuery.Funcionalidad;
IF object_id('TheBigBangQuery.Rol') IS NOT NULL
	DROP TABLE TheBigBangQuery.Rol;
IF object_id('TheBigBangQuery.Item_factura') IS NOT NULL
	DROP TABLE TheBigBangQuery.Item_factura;
IF object_id('TheBigBangQuery.Factura') IS NOT NULL
	DROP TABLE TheBigBangQuery.Factura;
IF object_id('TheBigBangQuery.Ubicacion') IS NOT NULL
	DROP TABLE TheBigBangQuery.Ubicacion;
IF object_id('TheBigBangQuery.TipoUbicacion') IS NOT NULL
	DROP TABLE TheBigBangQuery.TipoUbicacion;
IF object_id('TheBigBangQuery.Publicacion') IS NOT NULL
	DROP TABLE TheBigBangQuery.Publicacion;
IF object_id('TheBigBangQuery.GradoPublicaciones') IS NOT NULL
	DROP TABLE TheBigBangQuery.GradoPublicaciones;
IF object_id('TheBigBangQuery.Espectaculo') IS NOT NULL
	DROP TABLE TheBigBangQuery.Espectaculo;
IF object_id('TheBigBangQuery.Rubro') IS NOT NULL
	DROP TABLE [TheBigBangQuery].Rubro;
IF object_id('TheBigBangQuery.Factura') IS NOT NULL
	DROP TABLE TheBigBangQuery.Factura;
IF object_id('TheBigBangQuery.Empresa') IS NOT NULL
	DROP TABLE TheBigBangQuery.Empresa;
IF object_id('TheBigBangQuery.Usuario') IS NOT NULL
	DROP TABLE TheBigBangQuery.Usuario;

BEGIN TRANSACTION


CREATE TABLE [TheBigBangQuery].[Rol] (
    [rol_cod] NUMERIC(12,0) NOT NULL IDENTITY(0,1),
    [rol_nombre] nvarchar(255),
    [rol_dado_baja] DATETIME,

    CONSTRAINT [PK_Rol] PRIMARY kEY ([rol_cod])
);


CREATE TABLE [TheBigBangQuery].[Funcionalidades_rol] (
    [fpr_id] NUMERIC(12,0) NOT NULL,
    [fpr_rol]  NUMERIC(12,0) NOT NULL

    CONSTRAINT [PK_Func_por_rol] PRIMARY KEY ([fpr_id], [fpr_rol])
);


CREATE TABLE [TheBigBangQuery].[Funcionalidad] (
    [func_id] NUMERIC(12,0) NOT NULL IDENTITY(0,1),
    [func_desc] nvarchar(255)

    CONSTRAINT [PK_FUNC] PRIMARY KEY ([func_id])
);

ALTER TABLE [TheBigBangQuery].[Funcionalidades_rol]
    ADD CONSTRAINT [FK_func_por_rol_f] FOREIGN KEY ([fpr_id]) REFERENCES [TheBigBangQuery].[Funcionalidad](func_id);

ALTER TABLE [TheBigBangQuery].[Funcionalidades_rol]
    ADD CONSTRAINT [FK_func_por_rol_r] FOREIGN KEY ([fpr_rol]) REFERENCES [TheBigBangQuery].[Rol](rol_cod);


CREATE TABLE [TheBigBangQuery].[Roles_usuario] (
    [rolu_rol] NUMERIC(12,0) NOT NULL,
    [rolu_usuario] NUMERIC(12,0),

    CONSTRAINT [PK_ROLU] PRIMARY KEY ([rolu_rol], [rolu_usuario])
);


CREATE TABLE [TheBigBangQuery].[Usuario] (
    [usua_id] NUMERIC(12,0) NOT NULL IDENTITY(0,1),
    [usua_rol] NUMERIC(12,0),
    [usua_usuario] nvarchar(255),
    [usua_password] binary(32),
    [usua_n_intentos] INTEGER DEFAULT 0,
	[usua_habilitado] int DEFAULT 1

    CONSTRAINT [PK_USUA] PRIMARY KEY([usua_id])
);

ALTER TABLE [TheBigBangQuery].[Roles_usuario]
    ADD CONSTRAINT [FK_ROLU_r] FOREIGN KEY ([rolu_rol]) REFERENCES [TheBigBangQuery].[Rol](rol_cod);
    
ALTER TABLE [TheBigBangQuery].[Roles_usuario]
    ADD CONSTRAINT [FK_ROLU_u] FOREIGN KEY ([rolu_usuario]) REFERENCES [TheBigBangQuery].[Usuario](usua_id);


CREATE TABLE [TheBigBangQuery].[Empresa] (
    [empr_id] NUMERIC(12,0) NOT NULL IDENTITY(0,1),
	[empr_cuit] nvarchar(255) NOT NULL,
    [empr_razon_social] nvarchar(255) NOT NULL,
    [empr_usuario] NUMERIC(12,0),
    [empr_mail] nvarchar(50),
    [empr_telefono] nvarchar(255),
    [empr_direccion] nvarchar(50),
    [empr_numero_calle] NUMERIC(18,0),
    [empr_piso] NUMERIC(18,0),
    [empr_dpto] nvarchar(50),
    [empr_localidad] nvarchar(255),
    [empr_codigo_postal] nvarchar(50),
    [empr_ciudad] nvarchar(255),
    [empr_creacion] DATETIME,
    [empr_dado_baja] DATETIME

    CONSTRAINT [PK_Empr] PRIMARY KEY ([empr_id])
);

ALTER TABLE [TheBigBangQuery].[Empresa] 
    ADD CONSTRAINT [FK_EMPR] FOREIGN KEY ([empr_usuario]) REFERENCES [TheBigBangQuery].[Usuario](usua_id);


CREATE TABLE [TheBigBangQuery].[Premio] (
    [prem_id] NUMERIC(18,0) NOT NULL IDENTITY(0,1),
    [prem_puntos_necesarios] NUMERIC(18,0),
    [prem_nombre] NVARCHAR(255),
    [prem_vencimiento] DATETIME

    CONSTRAINT [PK_PREM] PRIMARY KEY (prem_id)
);

CREATE TABLE [TheBigBangQuery].[Tipo_Documento](
	[tipo_id] INTEGER IDENTITY (1,1),
	[tipo_descripcion] [nvarchar](255) NOT NULL,
	CONSTRAINT [PK_TIPO_DOC] PRIMARY KEY ([tipo_id]));

CREATE TABLE [TheBigBangQuery].[Cliente] (
    [clie_id] NUMERIC(18,0) NOT NULL IDENTITY(1,1),
    [clie_dni] NUMERIC(18,0) NOT NULL,
    [clie_usuario] NUMERIC(12,0),
    [clie_nombre] nvarchar(255),
    [clie_apellido] nvarchar(255),
    [clie_tipo_documento] INTEGER,
    [clie_cuil] nvarchar(255),
    [clie_mail] nvarchar(255),
    [clie_telefono] nvarchar(50),
    [clie_direccion] nvarchar(50),
    [clie_numero_calle] NUMERIC(18,0),
    [clie_piso] NUMERIC(18,0),
    [clie_locacalidad] nvarchar(255),
    [clie_codigo_postal] nvarchar(255),
    [clie_f_nacimiento] DATETIME,
    [clie_f_creacion] DATETIME,
    [clie_dado_baja] DATETIME,
    [clie_puntos] NUMERIC(18,0),
	[clie_departamento] nvarchar(255),
    [clie_prox_vencimiento_puntos] DATETIME

    CONSTRAINT [PK_Clie] PRIMARY KEY ([clie_id])
);

ALTER TABLE [TheBigBangQuery].[Cliente] 
    ADD CONSTRAINT [FK_CLI_USER] FOREIGN KEY ([clie_usuario]) REFERENCES [TheBigBangQuery].[Usuario](usua_id);

ALTER TABLE [TheBigBangQuery].[Cliente] 
    ADD CONSTRAINT [FK_CLI_TIPO] FOREIGN KEY ([clie_tipo_documento]) REFERENCES [TheBigBangQuery].[Tipo_Documento](tipo_id);

CREATE TABLE [TheBigBangQuery].[Tarjetas] (
	[tarj_id] NUMERIC(12,0) IDENTITY(1,1) PRIMARY KEY,
	[tarj_cliente] NUMERIC(18,0) FOREIGN KEY REFERENCES [TheBigBangQuery].[Cliente]([clie_id]),
	[tarj_titular] NVARCHAR(255),
	[tarj_numero] NVARCHAR(255),
	[tarj_caducidad] NVARCHAR(25),
	[tarj_cvv] nvarchar(4)
)


CREATE TABLE [TheBigBangQuery].[Rubro] (
    [rub_id] NUMERIC(12,0) NOT NULL IDENTITY(1,1),
    [rub_descripcion] nvarchar(255),
    [rub_dado_de_baja] DATETIME

    CONSTRAINT [PK_RUB] PRIMARY KEY ([rub_id])
);


CREATE TABLE [TheBigBangQuery].[Espectaculo] (
    [espe_id] NUMERIC(12,0) NOT NULL IDENTITY(0,1),
    [espe_empresa] NUMERIC(12,0),
    [espe_rubro] NUMERIC(12,0),
    [espe_descripcion] nvarchar(255),
    [espe_direccion] nvarchar(255),

    CONSTRAINT [PK_ESPE] PRIMARY KEY ([espe_id])
);

ALTER TABLE [TheBigBangQuery].[Espectaculo] 
    ADD CONSTRAINT [FK_ESPEC_RUBR] FOREIGN KEY ([espe_rubro]) REFERENCES [TheBigBangQuery].[Rubro](rub_id);

ALTER TABLE [TheBigBangQuery].[Espectaculo]
    ADD CONSTRAINT [FK_ESPEC_EMPR] FOREIGN KEY ([espe_empresa]) REFERENCES [TheBigBangQuery].[Empresa](empr_id);


CREATE TABLE [TheBigBangQuery].[GradoPublicaciones] (
	[grad_id] NUMERIC(10,0) IDENTITY(1,1),
    [grad_nivel] nvarchar(10) NOT NULL,
    [grad_comision] NUMERIC(10,2),
    [grad_baja] DATETIME

    CONSTRAINT [PK_GRAD] PRIMARY KEY ([grad_id])
);



CREATE TABLE [TheBigBangQuery].[Publicacion] (
    [publ_id] NUMERIC(12,0) NOT NULL IDENTITY(0,1),
    [publ_espectaculo] NUMERIC(12,0),
    [publ_grad_nivel] NUMERIC(10,0),
    [publ_fecha_publicacion] DATETIME,
    [publ_fecha_hora_espectaculo] DATETIME,
    [publ_estado] nvarchar(50)

    CONSTRAINT [PK_PUBL] PRIMARY KEY ([publ_id])
);

ALTER TABLE [TheBigBangQuery].[Publicacion]
    ADD CONSTRAINT [PK_ESPEC_ESPE] FOREIGN KEY ([publ_espectaculo]) REFERENCES [TheBigBangQuery].[Espectaculo](espe_id);

ALTER TABLE [TheBigBangQuery].[Publicacion]
    ADD CONSTRAINT [PK_PUBL_GRADO] FOREIGN KEY ([publ_grad_nivel]) REFERENCES [TheBigBangQuery].[GradoPublicaciones](grad_id);


CREATE TABLE [TheBigBangQuery].[TipoUbicacion] (
	[tipu_id] NUMERIC(18,0) NOT NULL,
	[tipu_descripcion] NVARCHAR(255)

	CONSTRAINT [PK_TIPU] PRIMARY KEY ([tipu_id])
);

CREATE TABLE [TheBigBangQuery].[Ubicacion] (
    [ubi_id] NUMERIC(12,0) NOT NULL IDENTITY(1,1),
    [ubi_fila] VARCHAR(3),
    [ubi_asiento] NUMERIC(18,0),
    [ubi_sin_enumerar] BIT,
    [ubi_tipo_codigo] NUMERIC(18,0)

    CONSTRAINT [PK_UBI] PRIMARY KEY ([ubi_id])
);

ALTER TABLE [TheBigBangQuery].[Ubicacion]
    ADD CONSTRAINT [FK_UBI_TIPO] FOREIGN KEY ([ubi_tipo_codigo]) REFERENCES [TheBigBangQuery].[TipoUbicacion](tipu_id);

-- BIT EN 1 = COMPRADA
CREATE TABLE [TheBigBangQuery].[Ubicaciones_publicacion] (
	[ubpu_id] NUMERIC(12,0) IDENTITY(1,1),
    [ubpu_id_publicacion] NUMERIC(12,0) NOT NULL,
    [ubpu_id_ubicacion] NUMERIC(12,0) NOT NULL,
    [ubpu_precio] NUMERIC(18,0),
    [ubpu_disponible] BIT

    CONSTRAINT [PK_UBPU] PRIMARY KEY ([ubpu_id_publicacion], [ubpu_id_ubicacion])
);

ALTER TABLE [TheBigBangQuery].[Ubicaciones_publicacion]
    ADD CONSTRAINT [FK_UBPU_UBI] FOREIGN KEY ([ubpu_id_ubicacion]) REFERENCES [TheBigBangQuery].[Ubicacion](ubi_id);

ALTER TABLE [TheBigBangQuery].[Ubicaciones_publicacion]
    ADD CONSTRAINT [FK_UBPU_PUBL] FOREIGN KEY ([ubpu_id_publicacion]) REFERENCES [TheBigBangQuery].[Publicacion](publ_id);


CREATE TABLE [TheBigBangQuery].[Item_Factura] (
    [item_id] NUMERIC(18,0) IDENTITY(1,1),
    [item_n_factura] NUMERIC(18,0) ,
    [item_publicacion] NUMERIC(12,0),
    [item_ubicacion] NUMERIC(12,0),
    [item_monto] NUMERIC(18,2),
    [item_cantidad] NUMERIC(18,0),
    [item_descripcion] NVARCHAR(60)

    CONSTRAINT [PK_ITEM] PRIMARY KEY ([item_id])
);


CREATE TABLE [TheBigBangQuery].[Factura] (
    [fact_numero] NUMERIC(18,0) IDENTITY(1,1),
    [fact_forma_de_pago] NVARCHAR(255),
    [fact_total] NUMERIC(18,2),
    [fact_fecha] DATETIME,
    [fact_empresa] NUMERIC(12,0),
	[fact_comision_hecha] BIT

    CONSTRAINT [PK_FACT] PRIMARY KEY (fact_numero)
);

ALTER TABLE [TheBigBangQuery].[Item_Factura]
    ADD CONSTRAINT [FK_ITEM_FACT] FOREIGN KEY ([item_n_factura]) REFERENCES [TheBigBangQuery].[Factura](fact_numero);

ALTER TABLE [TheBigBangQuery].[Item_Factura]
    ADD CONSTRAINT [FK_ITEM_UBI] FOREIGN KEY ([item_ubicacion]) REFERENCES [TheBigBangQuery].[Ubicacion](ubi_id);

ALTER TABLE [TheBigBangQuery].[Item_Factura]
    ADD CONSTRAINT [FK_ITEM_PUBLI] FOREIGN KEY ([item_publicacion]) REFERENCES [TheBigBangQuery].[Publicacion](publ_id);


CREATE TABLE [TheBigBangQuery].[Compras] (
    [comp_id] NUMERIC(12,0) NOT NULL IDENTITY(0,1),
    [comp_cliente] NUMERIC(18,0), 
    [comp_n_factura] NUMERIC(18,0),
    [comp_fecha_y_hora] DATETIME,
    [comp_medio_de_pago] nvarchar(255),
    [comp_cantidad] NUMERIC(12,0),
	[comp_total] NUMERIC(18,2),
	[comp_publicacion] NUMERIC(12,0)

    CONSTRAINT [PK_COMP] PRIMARY KEY ([comp_id])
);

ALTER TABLE [TheBigBangQuery].[Compras] 
    ADD CONSTRAINT [FK_COMP_CLI] FOREIGN KEY ([comp_cliente]) REFERENCES [TheBigBangQuery].[Cliente](clie_id);

ALTER TABLE [TheBigBangQuery].[Compras] 
	ADD CONSTRAINT [FK_COMP_PUB] FOREIGN KEY ([comp_publicacion]) REFERENCES [TheBigBangQuery].[Publicacion](publ_id);

ALTER TABLE [TheBigBangQuery].[Compras] 
    ADD CONSTRAINT [FK_COMP_FACT] FOREIGN KEY (comp_n_factura) REFERENCES [TheBigBangQuery].[Factura](fact_numero);

CREATE TABLE [TheBigBangQuery].[FormaDePago] (
	[form_id] INT IDENTITY(1,1),
	[form_nombre] nvarchar(255)

	CONSTRAINT [PK_FORMA_PAGO] PRIMARY KEY ([form_id])
);

CREATE TABLE [TheBigBangQuery].[Ubicaciones_Compra](
	[ubco_id] NUMERIC(12,0) IDENTITY(1,1),
	[ubco_compra] NUMERIC(12,0),
	[ubco_ubicacion] NUMERIC(12,0)

	CONSTRAINT [PK_UBCO] PRIMARY KEY ([ubco_id])
);

ALTER TABLE [TheBigBangQuery].[Ubicaciones_Compra]
	ADD CONSTRAINT [FK_UBCO_COM] FOREIGN KEY (ubco_compra) REFERENCES [TheBigBangQuery].[Compras](comp_id);
ALTER TABLE [TheBigBangQuery].[Ubicaciones_Compra]
	ADD CONSTRAINT [FK_UBCO_UB] FOREIGN KEY (ubco_ubicacion) REFERENCES [TheBigBangQuery].[Ubicacion](ubi_id);



COMMIT


IF OBJECT_ID('[TheBigBangQuery].[getHashPassword]') IS NOT NULL
	DROP FUNCTION [TheBigBangQuery].[getHashPassword];
GO

CREATE FUNCTION [TheBigBangQuery].[getHashPassword] (@contraseña nvarchar(255))
RETURNS binary(32) AS BEGIN
	RETURN HASHBYTES('SHA2_256', @contraseña);
END


GO

BEGIN TRANSACTION
-- Inserto los Roles por Default del enunciado
INSERT INTO [TheBigBangQuery].[Rol](rol_nombre) VALUES ('Empresa');
INSERT INTO [TheBigBangQuery].[Rol](rol_nombre) VALUES ('Administrativo');
INSERT INTO [TheBigBangQuery].[Rol](rol_nombre) VALUES ('Cliente');

-- Inserto los tipos de documentos 
INSERT INTO [TheBigBangQuery].[Tipo_Documento] (tipo_descripcion) VALUES ('DNI');
INSERT INTO [TheBigBangQuery].[Tipo_Documento] (tipo_descripcion) VALUES ('CI');
INSERT INTO [TheBigBangQuery].[Tipo_Documento] (tipo_descripcion) VALUES ('LE');
INSERT INTO [TheBigBangQuery].[Tipo_Documento] (tipo_descripcion) VALUES ('LC');

INSERT INTO [TheBigBangQuery].[Funcionalidad] (func_desc) VALUES ('Login Y Seguridad');
INSERT INTO [TheBigBangQuery].[Funcionalidad] (func_desc) VALUES ('ABM Rol');
INSERT INTO [TheBigBangQuery].[Funcionalidad] (func_desc) VALUES ('Registro de Usuarios');
INSERT INTO [TheBigBangQuery].[Funcionalidad] (func_desc) VALUES ('ABM de Clientes');
INSERT INTO [TheBigBangQuery].[Funcionalidad] (func_desc) VALUES ('ABM de Empresa de espectaculos');
INSERT INTO [TheBigBangQuery].[Funcionalidad] (func_desc) VALUES ('ABM de Categorias');
INSERT INTO [TheBigBangQuery].[Funcionalidad] (func_desc) VALUES ('ABM de grado de Publicacion');
INSERT INTO [TheBigBangQuery].[Funcionalidad] (func_desc) VALUES ('Generar Publicacion');
INSERT INTO [TheBigBangQuery].[Funcionalidad] (func_desc) VALUES ('Editar Publicacion');
INSERT INTO [TheBigBangQuery].[Funcionalidad] (func_desc) VALUES ('Comprar');
INSERT INTO [TheBigBangQuery].[Funcionalidad] (func_desc) VALUES ('Historial del Cliente');
INSERT INTO [TheBigBangQuery].[Funcionalidad] (func_desc) VALUES ('Canje y administracion de puntos');
INSERT INTO [TheBigBangQuery].[Funcionalidad] (func_desc) VALUES ('Generar pago de comisiones');
INSERT INTO [TheBigBangQuery].[Funcionalidad] (func_desc) VALUES ('Listado Estadistico');



INSERT INTO [TheBigBangQuery].[Rubro](rub_descripcion) VALUES ('-'), ('Drama'), ('StandUp'), ('Comedia'), ('Opera'), ('Infantil'), ('Musical');

INSERT INTO [TheBigBangQuery].[Funcionalidades_rol](fpr_id, fpr_rol)
    SELECT F.func_id, R.rol_cod 
    FROM [TheBigBangQuery].[Rol] R, [TheBigBangQuery].[Funcionalidad] F
    WHERE R.rol_nombre = 'Cliente' AND (F.func_desc = 'Comprar'
		OR F.func_desc = 'Historial del Cliente'
		OR F.func_desc = 'Canje y administracion de puntos'
	)

INSERT INTO [TheBigBangQuery].[Funcionalidades_rol](fpr_id, fpr_rol)
    SELECT F.func_id, R.rol_cod 
    FROM [TheBigBangQuery].[Rol] R, [TheBigBangQuery].[Funcionalidad] F
    WHERE R.rol_nombre = 'Empresa' AND (
        F.func_desc = 'Generar Publicacion'  OR
            F.func_desc = 'Editar Publicacion'
    )

INSERT INTO [TheBigBangQuery].[Funcionalidades_rol](fpr_id, fpr_rol)
    SELECT F.func_id, R.rol_cod 
    FROM [TheBigBangQuery].[Rol] R, [TheBigBangQuery].[Funcionalidad] F
    WHERE R.rol_nombre = 'Administrativo' AND (
        F.func_desc = 'ABM Rol' OR
        F.func_desc = 'Registro de Usuarios' OR
        F.func_desc = 'ABM de Clientes' OR
        F.func_desc = 'ABM de Empresa de espectaculos' OR
        F.func_desc = 'ABM de Categorias' OR
        F.func_desc = 'ABM de grado de Publicacion' OR
        F.func_desc = 'Generar Publicacion' OR
        F.func_desc = 'Editar Publicacion' OR
        F.func_desc = 'Comprar' OR
        F.func_desc = 'Historial del Cliente' OR
        F.func_desc = 'Canje y administracion de puntos' OR
        F.func_desc = 'Generar pago de comisiones' OR
        F.func_desc = 'Listado Estadistico'
    )

	-- INSERTO EL USUARIO ADMIN
INSERT INTO [TheBigBangQuery].[Usuario] (usua_usuario, usua_password, usua_rol) VALUES (
	'admin', [TheBigBangQuery].[getHashPassword]('admin') ,1
);
INSERT INTO [TheBigBangQuery].[Roles_usuario](rolu_usuario, rolu_rol) VALUES(0,1);

    -- inserto premios en Tabla de Premios
    INSERT INTO [TheBigBangQuery].[Premio] VALUES (1000,'Bebida a Eleccion', '20200101 12:00:00 PM');
    INSERT INTO [TheBigBangQuery].[Premio] VALUES (3000, 'Entradas a eleccion para proximo espectaculo', '20200101 12:00:00 PM');
    INSERT INTO [TheBigBangQuery].[Premio] VALUES (1500, 'Mochila BigBangQuery','20181220 12:00:00 AM');

    -- CREO FACTURA QUE CONTEMPLA TODAS LAS COMISIONES POR VENTAS ANTERIORES
     INSERT INTO [TheBigBangQuery].Factura VALUES ('efectivo',0,GETDATE(),00001,1)

	 -- AGREGO LOS GRADOS DE PUBLICACION CON SU RESPECTIVA COMISION
	 INSERT INTO [TheBigBangQuery].[GradoPublicaciones](grad_nivel,grad_comision) VALUES ('ALTO', 15);
	 INSERT INTO [TheBigBangQuery].[GradoPublicaciones](grad_nivel,grad_comision) VALUES ('MEDIO', 10);
	 INSERT INTO [TheBigBangQuery].[GradoPublicaciones](grad_nivel,grad_comision) VALUES ('BAJO', 5);

	 -- INSERTO EMPRESA DEFAULT PARA CUANDO UN ADMIN CARGA UNA PUBLICACION
		INSERT INTO [TheBigBangQuery].[Empresa](empr_usuario, empr_cuit, empr_razon_social) VALUES (0, '3623613623', 'RazonSocial123');

COMMIT

BEGIN TRANSACTION

	-- INSERTO LOS RUBROS
	INSERT INTO [TheBigBangQuery].[Rubro] ([rub_descripcion])
		SELECT DISTINCT Espectaculo_Rubro_Descripcion
		FROM [gd_esquema].[Maestra]

	-- INSERTO LAS FORMAS DE PAGO
	INSERT INTO [TheBigBangQuery].[FormaDePago] 
		SELECT DISTINCT Forma_Pago_Desc
		FROM [gd_esquema].[Maestra]
	
	-- INSERTO LAS EMPRESAS
	INSERT INTO [TheBigBangQuery].[Empresa] (
		empr_razon_social,
		empr_cuit,
		empr_creacion,
		empr_mail,
		empr_direccion,
		empr_numero_calle,
		empr_piso,
		empr_dpto,
		empr_codigo_postal)
	SELECT DISTINCT Espec_Empresa_Razon_Social, Espec_Empresa_Cuit, Espec_Empresa_Fecha_Creacion, Espec_Empresa_Mail, Espec_Empresa_Dom_Calle, Espec_Empresa_Nro_Calle, Espec_Empresa_Piso,Espec_Empresa_Depto,Espec_Empresa_Cod_Postal
	FROM [gd_esquema].[Maestra]
	WHERE Espec_Empresa_Cuit IS NOT NULL

	-- INSERTO LOS CLIENTES
	INSERT INTO [TheBigBangQuery].[Cliente] (
		[clie_dni],
		[clie_apellido],
		[clie_nombre],
		[clie_f_nacimiento],
		[clie_mail],
		[clie_direccion],
		[clie_numero_calle],
		[clie_piso],
		[clie_departamento],
		[clie_codigo_postal],
		[clie_tipo_documento],
		[clie_f_creacion],
		[clie_puntos]
	)
	SELECT M.Cli_Dni,Cli_Apeliido, M.Cli_Nombre,M.Cli_Fecha_Nac, M.Cli_Mail,Cli_Dom_Calle, M.Cli_Nro_Calle,M.Cli_Piso,M.Cli_Depto,M.Cli_Cod_Postal,D.tipo_id, GETDATE(), 0
	FROM [gd_esquema].[Maestra] M, [TheBigBangQuery].[Tipo_Documento] D
	WHERE Cli_Dni IS NOT NULL AND D.tipo_descripcion = 'DNI'
	GROUP BY M.Cli_Dni,Cli_Apeliido, M.Cli_Nombre,M.Cli_Fecha_Nac, M.Cli_Mail,Cli_Dom_Calle, M.Cli_Nro_Calle,M.Cli_Piso,M.Cli_Depto,M.Cli_Cod_Postal,D.tipo_id

	-- INSERTO ESPECTACULOS
	SET IDENTITY_INSERT [TheBigBangQuery].[Espectaculo] ON;

	INSERT INTO [TheBigBangQuery].[Espectaculo] (
		espe_id,
		espe_descripcion,
		espe_rubro,
		espe_empresa)
	SELECT DISTINCT m.Espectaculo_Cod, m.Espectaculo_Descripcion,  CASE WHEN m.Espectaculo_Rubro_Descripcion = '' THEN 1 
																		WHEN m.Espectaculo_Rubro_Descripcion = NULL THEN 1
																		ELSE r.rub_id END, e.empr_id
	FROM [gd_esquema].[Maestra] m 
		LEFT JOIN [TheBigBangQuery].[Empresa] e ON (
			e.empr_cuit = m.Espec_Empresa_Cuit AND 
			e.empr_razon_social = m.Espec_Empresa_Razon_Social AND 
			e.empr_creacion = m.Espec_Empresa_Fecha_Creacion AND
			e.empr_mail = m.Espec_Empresa_Mail AND
			e.empr_direccion = m.Espec_Empresa_Dom_Calle AND 
			e.empr_numero_calle = m.Espec_Empresa_Nro_Calle AND 
			e.empr_piso = m.Espec_Empresa_Piso AND
			e.empr_dpto = m.Espec_Empresa_Depto AND
			e.empr_codigo_postal = m.Espec_Empresa_Cod_Postal
		)
		LEFT JOIN [TheBigBangQuery].[Rubro] r ON (r.rub_descripcion = m.Espectaculo_Rubro_Descripcion)
	WHERE m.Espectaculo_Cod IS NOT NULL AND m.Espectaculo_Rubro_Descripcion IS NOT NULL

	SET IDENTITY_INSERT [TheBigBangQuery].[Espectaculo] OFF;

	
	-- INSERTO PUBLICACIONES CON GRADO DEFAULT (MEDIO)
	INSERT INTO [TheBigBangQuery].[Publicacion](
		publ_espectaculo,
		publ_estado,
		publ_fecha_hora_espectaculo,
		publ_fecha_publicacion,
		publ_grad_nivel)
	SELECT DISTINCT e.espe_id, m.Espectaculo_Estado, m.Espectaculo_Fecha, m.Espectaculo_Fecha_Venc, 2
	FROM [gd_esquema].[Maestra] m LEFT JOIN [TheBigBangQuery].[Espectaculo] e ON (
		m.Espectaculo_Cod = e.espe_id AND
		m.Espectaculo_Descripcion = e.espe_descripcion
	) 
	WHERE m.Espectaculo_Cod IS NOT NULL AND m.Espectaculo_Descripcion IS NOT NULL AND m.Espectaculo_Rubro_Descripcion IS NOT NULL

	-- INSERTO LOS TIPOS 
	INSERT INTO [TheBigBangQuery].[TipoUbicacion]
	SELECT Ubicacion_Tipo_Codigo, Ubicacion_Tipo_Descripcion
	FROM [gd_esquema].[Maestra]
	WHERE Ubicacion_Tipo_Codigo IS NOT NULL AND Ubicacion_Tipo_Descripcion IS NOT NULL
	GROUP BY Ubicacion_Tipo_Codigo, Ubicacion_Tipo_Descripcion


	-- INSERTO LAS UBICACIONES
	INSERT INTO [TheBigBangQuery].[Ubicacion](
		[ubi_asiento],
		[ubi_fila],
		[ubi_sin_enumerar],
		[ubi_tipo_codigo])
	SELECT DISTINCT m.Ubicacion_Asiento, m.Ubicacion_Fila, m.Ubicacion_Sin_numerar, m.Ubicacion_Tipo_Codigo
	FROM [gd_esquema].[Maestra] m
	WHERE m.Ubicacion_Asiento IS NOT NULL AND 
		m.Ubicacion_Fila IS NOT NULL AND 
		m.Ubicacion_Sin_numerar IS NOT NULL AND
		m.Ubicacion_Tipo_Codigo IS NOT NULL AND 
		m.Ubicacion_Tipo_Descripcion IS NOT NULL

	-- INSERTO LAS UBICACIONES POR PUBLICACION
	INSERT INTO [TheBigBangQuery].[Ubicaciones_publicacion](
		[ubpu_id_publicacion],
		[ubpu_id_ubicacion],
		[ubpu_precio],
		[ubpu_disponible])
	SELECT DISTINCT p.publ_id, u.ubi_id, m.Ubicacion_Precio, 0
	FROM [gd_esquema].[Maestra] m LEFT JOIN [TheBigBangQuery].[Ubicacion] u ON (
		m.Ubicacion_Asiento = u.ubi_asiento AND 
		m.Ubicacion_Fila = u.ubi_fila AND 
		m.Ubicacion_Sin_numerar = u.ubi_sin_enumerar AND 
		m.Ubicacion_Tipo_Codigo = u.ubi_tipo_codigo
	) LEFT JOIN [TheBigBangQuery].[Publicacion] p ON (
		p.publ_espectaculo = m.Espectaculo_Cod AND 
		p.publ_estado = m.Espectaculo_Estado AND 
		p.publ_fecha_hora_espectaculo = m.Espectaculo_Fecha AND 
		p.publ_fecha_publicacion = m.Espectaculo_Fecha_Venc)

	-- INSERTO LAS FACTURAS
	SET IDENTITY_INSERT [TheBigBangQuery].[Factura] ON;

	INSERT INTO [TheBigBangQuery].[Factura](
		[fact_numero],
		fact_fecha,
		fact_forma_de_pago,
		fact_total,
		fact_empresa, 
		fact_comision_hecha)
	SELECT DISTINCT Factura_Nro, Factura_Fecha, f.form_nombre, Factura_Total, e.empr_id, 0
	FROM [gd_esquema].[Maestra] m LEFT JOIN [TheBigBangQuery].[Empresa] e ON (
			e.empr_razon_social = m.Espec_Empresa_Razon_Social AND 
			e.empr_cuit = m.Espec_Empresa_Cuit AND 
			e.empr_creacion = m.Espec_Empresa_Fecha_Creacion AND 
			e.empr_mail = m.Espec_Empresa_Mail AND 
			e.empr_direccion = m.Espec_Empresa_Dom_Calle AND 
			e.empr_numero_calle = m.Espec_Empresa_Nro_Calle AND 
			e.empr_piso = m.Espec_Empresa_Piso AND 
			e.empr_dpto = m.Cli_Depto AND 
			e.empr_codigo_postal = m.Espec_Empresa_Cod_Postal
		) LEFT JOIN [TheBigBangQuery].[FormaDePago] f ON (m.Forma_Pago_Desc = f.form_nombre)
	WHERE m.Factura_Nro IS NOT NULL AND e.empr_id IS NOT NULL

	SET IDENTITY_INSERT [TheBigBangQuery].[Factura] OFF;

	-- INSERTO LAS COMPRAS
	INSERT INTO [TheBigBangQuery].[Compras](
		[comp_cliente],
		[comp_n_factura],
		[comp_fecha_y_hora],
		[comp_cantidad],
		[comp_medio_de_pago],
		[comp_total],
		[comp_publicacion])
	SELECT c.clie_id, f.fact_numero,m.Compra_Fecha, m.Compra_Cantidad, 'Efectivo', f.fact_total, p.publ_id
	FROM [gd_esquema].[Maestra] m LEFT JOIN [TheBigBangQuery].[Cliente] c ON (
		c.clie_dni = m.Cli_Dni AND 
		c.clie_apellido = m.Cli_Apeliido AND
		c.clie_nombre = m.Cli_Nombre AND 
		c.clie_f_nacimiento = m.Cli_Fecha_Nac AND 
		c.clie_mail = m.Cli_Mail AND
		c.clie_direccion = m.Cli_Dom_Calle AND
		c.clie_numero_calle = m.Cli_Nro_Calle AND 
		c.clie_piso = m.Cli_Piso AND 
		c.clie_departamento = m.Cli_Depto AND 
		c.clie_codigo_postal = m.Cli_Cod_Postal
	) LEFT JOIN [TheBigBangQuery].[Factura] f ON (
		f.fact_numero = m.Factura_Nro AND 
		f.fact_fecha = m.Factura_Fecha AND 
		f.fact_total = m.Factura_Total
	) LEFT JOIN [TheBigBangQuery].[Publicacion] p ON (
		p.publ_espectaculo = m.Espectaculo_Cod
	) 
	WHERE c.clie_id IS NOT NULL  AND f.fact_numero IS NOT NULL AND p.publ_id IS NOT NULL

	-- INSERTO LAS UBICACIONES DE CADA COMPRA
	INSERT INTO [TheBigBangQuery].[Ubicaciones_Compra](
		[ubco_compra],[ubco_ubicacion]
	)
	SELECT DISTINCT c.clie_id, u.ubi_id
	FROM [gd_esquema].[Maestra] m 
	LEFT JOIN [TheBigBangQuery].[Cliente] c ON (
		c.clie_dni = m.Cli_Dni AND 
		c.clie_apellido = m.Cli_Apeliido AND
		c.clie_nombre = m.Cli_Nombre AND 
		c.clie_f_nacimiento = m.Cli_Fecha_Nac AND 
		c.clie_mail = m.Cli_Mail AND
		c.clie_direccion = m.Cli_Dom_Calle AND
		c.clie_numero_calle = m.Cli_Nro_Calle AND 
		c.clie_piso = m.Cli_Piso AND 
		c.clie_departamento = m.Cli_Depto AND 
		c.clie_codigo_postal = m.Cli_Cod_Postal
	) 
	LEFT JOIN [TheBigBangQuery].[Compras] co ON (co.comp_cliente = c.clie_id)
	LEFT JOIN [TheBigBangQuery].[Ubicacion] u ON (
		m.Ubicacion_Asiento = u.ubi_asiento AND 
		m.Ubicacion_Fila = u.ubi_fila AND 
		m.Ubicacion_Sin_numerar = u.ubi_sin_enumerar AND
		m.Ubicacion_Tipo_Codigo = u.ubi_tipo_codigo
	)
	WHERE m.Compra_Cantidad IS NOT NULL AND m.Compra_Fecha IS NOT NULL


	INSERT INTO [TheBigBangQuery].[Item_Factura](
		[item_monto],
		[item_cantidad],
		[item_descripcion],
		[item_n_factura],
		[item_publicacion],
		[item_ubicacion])
	SELECT m.Item_Factura_Monto, m.Item_Factura_Cantidad, m.Item_Factura_Descripcion , f.fact_numero, p.publ_id, u.ubi_id
	FROM [gd_esquema].[Maestra] m LEFT JOIN [TheBigBangQuery].[Factura] f ON (
		f.fact_numero = m.Factura_Nro AND 
		f.fact_fecha = m.Factura_Fecha AND 
		f.fact_total = m.Factura_Total
	) LEFT JOIN [TheBigBangQuery].[Publicacion] p ON (
		p.publ_estado = m.Espectaculo_Estado AND 
		p.publ_fecha_hora_espectaculo = m.Espectaculo_Fecha AND
		p.publ_fecha_publicacion = m.Espectaculo_Fecha_Venc 
	) LEFT JOIN [TheBigBangQuery].[Ubicacion] u ON (
		u.ubi_fila = m.Ubicacion_Fila AND 
		u.ubi_asiento = m.Ubicacion_Asiento AND 
		u.ubi_sin_enumerar = m.Ubicacion_Sin_numerar AND
		u.ubi_tipo_codigo = m.Ubicacion_Tipo_Codigo 
	)
	WHERE m.Item_Factura_Cantidad IS NOT NULL AND 
		m.Item_Factura_Descripcion IS NOT NULL AND 
		m.Item_Factura_Monto IS NOT NULL AND 
		f.fact_numero IS NOT NULL AND 
		p.publ_id IS NOT NULL AND 
		u.ubi_id IS NOT NULL

COMMIT

GO

IF OBJECT_ID('[TheBigBangQuery].[UsuarioHabilitado]') IS NOT NULL
	DROP FUNCTION [TheBigBangQuery].[UsuarioHabilitado];
GO

CREATE FUNCTION [TheBigBangQuery].[UsuarioHabilitado](@usuario nvarchar(255)) 
RETURNS INT AS BEGIN
	IF(SELECT usua_id
	   FROM [TheBigBangQuery].[Usuario]
	   WHERE usua_usuario = @usuario AND usua_habilitado = 1
	   ) IS NOT NULL
	BEGIN
		-- USUARIO HABILITADO
		RETURN 1;
	END 
	-- USUARIO INHABILITADO
	RETURN 0;
END

GO

IF OBJECT_ID('TheBigBangQuery.ExisteUsuario') IS NOT NULL
	DROP FUNCTION [TheBigBangQuery].[ExisteUsuario];

GO

CREATE FUNCTION [TheBigBangQuery].[ExisteUsuario]( @usuario nvarchar(255))
RETURNS INT AS BEGIN
	IF @usuario IN (SELECT usua_usuario FROM [TheBigBangQuery].[Usuario])
	BEGIN
		RETURN 1;
	END

	RETURN 0;
END

GO

IF OBJECT_ID('TheBigBangQuery.ValidarUsuarioDisponible') IS NOT NULL 
	DROP TRIGGER [TheBigBangQuery].[ValidarUsuarioDisponible];

GO

CREATE TRIGGER [TheBigBangQuery].[ValidarUsuarioDisponible] ON [TheBigBangQuery].[Usuario] INSTEAD OF INSERT AS BEGIN
	DECLARE cu CURSOR FOR (
		SELECT usua_usuario, usua_password, usua_rol, usua_n_intentos
		FROM [inserted]
	);
	DECLARE @usuario nvarchar(255);
	DECLARE @contraseña binary(32);
	DECLARE @rol NUMERIC(12,0);
	DECLARE @intentos INT;
	OPEN cu;
	FETCH cu INTO @usuario, @contraseña ,@rol, @intentos;
	WHILE @@FETCH_STATUS = 0
	BEGIN 
		IF(@usuario NOT IN (SELECT usua_usuario FROM [TheBigBangQuery].[Usuario]))
		BEGIN
			INSERT INTO [TheBigBangQuery].[Usuario](usua_usuario, usua_password, usua_rol, usua_n_intentos) VALUES (
				@usuario,
				@contraseña,
				@rol,
				@intentos)
		END ELSE BEGIN
			RAISERROR('Ya Existe el usuario en la base de datos, no se pueden ingresar dos usuarios iguales.',16,1);
			ROLLBACK TRANSACTION;
		END
		FETCH cu INTO @usuario, @contraseña ,@rol, @intentos;
	END
	CLOSE cu;
	DEALLOCATE cu;
END 

GO

IF OBJECT_ID('[TheBigBangQuery].[IncrementarIntento]') IS NOT NULL
	DROP PROCEDURE [TheBigBangQuery].[IncrementarIntento];
GO
CREATE PROCEDURE [TheBigBangQuery].[IncrementarIntento]( @usuario nvarchar(255)) AS
BEGIN
	DECLARE @intentos INT, @habilitado INT, @id NUMERIC(12,0);
	SELECT @intentos =  usua_n_intentos, @habilitado = usua_habilitado, @id = usua_id
	FROM [TheBigBangQuery].[Usuario]
	WHERE usua_usuario = @usuario

	IF @usuario IN (SELECT usua_usuario FROM [TheBigBangQuery].[Usuario])
	BEGIN
		IF @habilitado = 0 OR @intentos + 1 = 3
		BEGIN
			-- USUARIO DESHABILITADO
			UPDATE [TheBigBangQuery].[Usuario]
			SET usua_n_intentos = 3, usua_habilitado = 0
			WHERE usua_id = @id
		END ELSE BEGIN
			-- USUARIO HABILITADO
			UPDATE [TheBigBangQuery].[Usuario]
			SET usua_n_intentos = @intentos + 1
			WHERE usua_id = @id
		END
	END
END

GO 

IF OBJECT_ID('[TheBigBangQuery].[InsertarNuevoClienteConUsuario]') IS NOT NULL
	DROP PROCEDURE [TheBigBangQuery].[InsertarNuevoClienteConUsuario];
GO
CREATE PROCEDURE [TheBigBangQuery].[InsertarNuevoClienteConUsuario] (
	@usuario nvarchar(255),
	@contraseña nvarchar(255),
	@nombre nvarchar(255),
	@apellido nvarchar(255),
	@tipoDoc nvarchar(255),
	@documento nvarchar(255),
	@cuil nvarchar(255),
	@mail nvarchar(255),
	@telefono nvarchar(255),
	@calle nvarchar(255),
	@altura nvarchar(255),
	@piso nvarchar(255),
	@depto nvarchar(255),
	@localidad nvarchar(255),
	@codigoPostal nvarchar(255),
	@fechaNacimiento DATETIME,
	@fechaCreacion DATETIME
) AS BEGIN
	
	BEGIN TRY

		BEGIN TRANSACTION

		IF (SELECT COUNT(*)
				FROM [TheBigBangQuery].[Cliente] c
				WHERE c.clie_dni = CONVERT(NUMERIC,@documento) AND c.clie_tipo_documento = @tipoDoc) < 1 
		BEGIN

		INSERT INTO [TheBigBangQuery].[Usuario](usua_usuario, usua_rol, usua_n_intentos, usua_password) VALUES 
		(@usuario, 2, 0, [TheBigBangQuery].[getHashPassword](@contraseña) );

		INSERT INTO [TheBigBangQuery].[Roles_usuario](rolu_rol, rolu_usuario) 
		SELECT usua_rol, usua_id
		FROM [TheBigBangQuery].[Usuario]
		WHERE usua_usuario = @usuario AND usua_password = [TheBigBangQuery].[getHashPassword](@contraseña)

		INSERT INTO [TheBigBangQuery].[Cliente](
			[clie_usuario],
			[clie_nombre],
			[clie_apellido],
			[clie_tipo_documento],
			[clie_dni],
			[clie_cuil],
			[clie_mail],
			[clie_telefono],
			[clie_direccion],
			[clie_numero_calle],
			[clie_piso],
			[clie_departamento],
			[clie_locacalidad],
			[clie_codigo_postal],
			[clie_f_nacimiento],
			[clie_f_creacion],
			[clie_puntos]) VALUES (
				(
						SELECT TOP 1 usua_id
						FROM [TheBigBangQuery].[Usuario]
						WHERE usua_usuario = @usuario AND usua_password = [TheBigBangQuery].[getHashPassword](@contraseña)
				),
				@nombre, 
				@apellido, 
				(SELECT TOP 1 tipo_id FROM [TheBigBangQuery].[Tipo_Documento] WHERE tipo_descripcion = @tipoDoc),
				@documento,
				@cuil,
				@mail,
				@telefono,
				@calle,
				CONVERT(numeric, @altura),
				CONVERT(numeric, @piso),
				@depto,
				@localidad,
				@codigoPostal,
				@fechaNacimiento,
				@fechaCreacion,
				0
			);
			END ELSE BEGIN
				RAISERROR('Ya existe el cliente',16,1);
				ROLLBACK TRANSACTION;
			END

			COMMIT 
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0 
		BEGIN
			RAISERROR('No se pudo insertar el cliente',16,1);
			PRINT ERROR_MESSAGE();
			ROLLBACK TRANSACTION;
		END
	END CATCH
	
END
GO 

IF OBJECT_ID('[TheBigBangQuery].[InsertarEmpresaConUsuario]') IS NOT NULL
	DROP PROCEDURE [TheBigBangQuery].[InsertarEmpresaConUsuario];
GO
CREATE PROCEDURE [TheBigBangQuery].[InsertarEmpresaConUsuario](
	@usuario nvarchar(255),
	@contraseña nvarchar(255),
	@razonSocial nvarchar(255),
	@cuit nvarchar(255),
	@mail nvarchar(50),
	@telefono nvarchar(255),
	@calle nvarchar(50),
	@altura nvarchar(255),
	@piso nvarchar(255),
	@depto nvarchar(50),
	@localidad nvarchar(255),
	@codigoPostal nvarchar(50),
	@ciudad nvarchar(255),
	@fechaCreacion nvarchar(255)) 
AS BEGIN
	
	
	BEGIN TRY

		BEGIN TRANSACTION
		
		INSERT INTO [TheBigBangQuery].[Usuario](usua_usuario, usua_rol, usua_n_intentos, usua_password) VALUES 
		(@usuario, 0, 0, [TheBigBangQuery].[getHashPassword](@contraseña));
		
		INSERT INTO [TheBigBangQuery].[Roles_usuario] (rolu_usuario, rolu_rol) 
		SELECT usua_id, usua_rol
		FROM [TheBigBangQuery].[Usuario]	
		WHERE usua_usuario = @usuario AND usua_password = [TheBigBangQuery].[getHashPassword](@contraseña)


		INSERT INTO [TheBigBangQuery].[Empresa](
		empr_usuario,
		empr_razon_social,
		empr_cuit,
		empr_mail,
		empr_telefono,
		empr_direccion,
		empr_numero_calle,
		empr_piso,
		empr_dpto,
		empr_localidad,
		empr_codigo_postal,
		empr_ciudad,
		empr_creacion
		) VALUES (
			(
				SELECT TOP 1  usua_id
				FROM [TheBigBangQuery].[Usuario]
				WHERE usua_usuario = @usuario AND usua_password = [TheBigBangQuery].[getHashPassword](@contraseña) 
			),
			@razonSocial,
			@cuit,
			@mail,
			@telefono,
			@calle,
			CONVERT(numeric, @altura),
			CONVERT(numeric, @piso),
			@depto,
			@localidad,
			@codigoPostal,
			@ciudad,
			CONVERT(datetime, @fechaCreacion, 20)
		);

		COMMIT

	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0 
		BEGIN
			RAISERROR('No se pudo insertar la empresa',16,1);
			PRINT ERROR_MESSAGE();
			ROLLBACK TRANSACTION;
		END
	END CATCH
END

GO 

IF OBJECT_ID('[TheBigBangQuery].[ActualizarCliente]') IS NOT NULL
	DROP PROCEDURE [TheBigBangQuery].[ActualizarCliente];
GO
CREATE PROCEDURE [TheBigBangQuery].[ActualizarCliente](
	@id nvarchar(255),
	@nombre nvarchar(255),
	@apellido nvarchar(255),
	@tipoDocumento nvarchar(50),
	@numeroDocumento nvarchar(255),
	@cuil nvarchar(255),
	@mail nvarchar(255),
	@telefono nvarchar(255),
	@calle nvarchar(255),
	@altura nvarchar(255),
	@piso nvarchar(255),
	@depto nvarchar(50),
	@localidad nvarchar(255),
	@codigoPostal nvarchar(255),
	@fechaDeNacimiento nvarchar(255),
	@fechaCreacion nvarchar(255)
) AS BEGIN
	
	IF (SELECT COUNT(*)
		FROM TheBigBangQuery.Cliente JOIN TheBigBangQuery.Tipo_Documento ON (clie_tipo_documento = tipo_id)
		WHERE clie_dni = CONVERT(numeric(18,0),@numeroDocumento) AND tipo_descripcion = @tipoDocumento
	) > 1 
	BEGIN
		RAISERROR('Error al actualizar cliente, ya existe un cliente con el mismo documento', 16,1);
	END ELSE BEGIN

		UPDATE [TheBigBangQuery].[Cliente]
		SET clie_nombre = @nombre ,
			clie_apellido = @apellido,
			clie_tipo_documento = (SELECT tipo_id FROM [TheBigBangQuery].[Tipo_Documento] WHERE tipo_descripcion = @tipoDocumento),
			clie_dni = CONVERT(numeric(18,0),@numeroDocumento),
			clie_cuil = @cuil,
			clie_mail = @mail,
			clie_telefono = @telefono,
			clie_direccion = @calle,
			clie_numero_calle = CONVERT(numeric(18,0),@altura),
			clie_piso = CONVERT(numeric(18,0),@piso),
			clie_departamento = @depto,
			clie_locacalidad = @localidad,
			clie_codigo_postal = @codigoPostal,
			clie_f_nacimiento = CONVERT(datetime, @fechaDeNacimiento),
			clie_f_creacion = CONVERT(datetime, @fechaCreacion)
		WHERE clie_id = CONVERT(numeric(18,0), @id)

	END
END

GO

IF OBJECT_ID('[TheBigBangQuery].[ActualizarEmpresa]') IS NOT NULL
	DROP PROCEDURE [TheBigBangQuery].[ActualizarEmpresa];
GO
CREATE PROCEDURE [TheBigBangQuery].[ActualizarEmpresa] (
	@id nvarchar(255),
	@cuit nvarchar(255),
	@razonSocial nvarchar(255),
	@mail nvarchar(255),
	@telefono nvarchar(255),
	@direccion nvarchar(255),
	@altura nvarchar(255),
	@piso nvarchar(50),
	@depto nvarchar(50),
	@localidad nvarchar(255),
	@codigoPostal nvarchar(255),
	@ciudad nvarchar(255)) 
AS BEGIN

	IF (
		SELECT COUNT(*)
		FROM [TheBigBangQuery].[Empresa]
		WHERE empr_razon_social = @razonSocial AND empr_cuit = @cuit
	) > 1
	BEGIN
		RAISERROR('Error al actualizar cliente, ya existe una empresa con el mismo cuit', 16,1);
	END ELSE BEGIN
		UPDATE [TheBigBangQuery].[Empresa]
		SET empr_cuit = @cuit,
			empr_razon_social = @razonSocial,
			empr_mail = @mail,
			empr_telefono = @telefono,
			empr_direccion = @direccion,
			empr_numero_calle = CONVERT(numeric(18,0),@altura),
			empr_piso = CONVERT(numeric(18,0),@piso),
			empr_dpto = @depto,
			empr_localidad = @localidad,
			empr_codigo_postal = @codigoPostal,
			empr_ciudad = @ciudad
			WHERE empr_id = CONVERT(numeric(18,0), @id)
	END
END
GO

IF OBJECT_ID('[TheBigBangQuery].[getUltimoIdPublicaciones]') IS NOT NULL
	DROP FUNCTION [TheBigBangQuery].[getUltimoIdPublicaciones];
GO
CREATE FUNCTION [TheBigBangQuery].[getUltimoIdPublicaciones] ()
RETURNS NUMERIC(12,0) AS BEGIN
	RETURN (
		SELECT TOP 1 publ_id
		FROM TheBigBangQuery.Publicacion
		ORDER BY 1 DESC
	);
END

GO
IF OBJECT_ID('[TheBigBangQuery].[InsertarEspectaculo]') IS NOT NULL
	DROP PROCEDURE [TheBigBangQuery].[InsertarEspectaculo];
GO
CREATE PROCEDURE [TheBigBangQuery].[InsertarEspectaculo](
	@empresa nvarchar(255),
	@rubro NUMERIC(12,0),
	@descripcion nvarchar(255),
	@direccion nvarchar(255),
	@newId numeric(12,0) OUTPUT)
AS BEGIN

INSERT INTO [TheBigBangQuery].[Espectaculo] (
	[espe_empresa],
	[espe_rubro],
	[espe_descripcion],
	[espe_direccion]
) VALUES (
	CASE WHEN @empresa = 'NULL' THEN NULL
		 WHEN @empresa IS NULL THEN NULL
		ELSE CONVERT(numeric, @empresa) END,
	CONVERT(numeric,@rubro),
	@descripcion,
	@direccion
)

SELECT @newId = SCOPE_IDENTITY()

END
GO

IF OBJECT_ID('[TheBigBangQuery].[InsertarPublicacion]') IS NOT NULL
	DROP PROCEDURE [TheBigBangQuery].[InsertarPublicacion]
GO
CREATE PROCEDURE [TheBigBangQuery].[InsertarPublicacion] (
	@idEspec nvarchar(255),
	@gradoPublicacion nvarchar(255),
	@fechaPublicacion DATETIME,
	@fechaEvento DATETIME,
	@estado nvarchar(50),
	@newId numeric(12,0) OUTPUT) 
AS BEGIN
	
	IF (SELECT COUNT(*)
		FROM TheBigBangQuery.Publicacion p1
		WHERE p1.publ_fecha_publicacion = @fechaPublicacion
			AND p1.publ_espectaculo = @idEspec
			AND p1.publ_fecha_hora_espectaculo = @fechaEvento) < 1
	BEGIN

	INSERT INTO [TheBigBangQuery].[Publicacion] (
		[publ_espectaculo],
		[publ_grad_nivel],
		[publ_fecha_publicacion],
		[publ_fecha_hora_espectaculo],
		[publ_estado]
	) VALUES (
		CONVERT(NUMERIC(12,0),@idEspec),
		CONVERT(NUMERIC(10,0),@gradoPublicacion),
		@fechaPublicacion,
		@fechaEvento,
		@estado
	)

	SELECT @newId = SCOPE_IDENTITY()

	END ELSE 
		RAISERROR('Error al insertar publicacion, la misma esta duplicada',16,1);
END
GO

IF OBJECT_ID('[TheBigBangQuery].[InsertarUbicacion]') IS NOT NULL
	DROP PROCEDURE [TheBigBangQuery].[InsertarUbicacion];
GO
CREATE PROCEDURE [TheBigBangQuery].[InsertarUbicacion] (
	@fila nvarchar(3),
	@asiento nvarchar(255),
	@sinEnumerar nvarchar(3),
	@tipoUbi nvarchar(255),
	@newId numeric(12,0) OUTPUT)
AS BEGIN
	INSERT INTO [TheBigBangQuery].[Ubicacion] (
		[ubi_fila],
		[ubi_asiento],
		[ubi_sin_enumerar],
		[ubi_tipo_codigo]
	) VALUES (
		@fila,
		CONVERT(NUMERIC(18,0), @asiento),
		CONVERT(bit, @sinEnumerar),
		CONVERT(NUMERIC(18,0),@tipoUbi)
	);

	SELECT @newId = SCOPE_IDENTITY();
END
GO

IF OBJECT_ID('[TheBigBangQuery].[InsertarUbicacionPorPublicacion]') IS NOT NULL
	DROP PROCEDURE [TheBigBangQuery].[InsertarUbicacionPorPublicacion]
GO
CREATE PROCEDURE [TheBigBangQuery].[InsertarUbicacionPorPublicacion] (
	@ubicacion nvarchar(255),
	@publicacion nvarchar(255),
	@precio nvarchar(255),
	@disponible bit)
AS BEGIN
	BEGIN TRANSACTION;
	BEGIN TRY
		INSERT INTO [TheBigBangQuery].[Ubicaciones_publicacion] (
			[ubpu_id_ubicacion],
			[ubpu_id_publicacion],
			[ubpu_precio],
			[ubpu_disponible]
		) VALUES (
			CONVERT(NUMERIC(12,0),@ubicacion),
			CONVERT(NUMERIC(12,0),@publicacion),
			CONVERT(NUMERIC(18,0),@precio),
			CONVERT(bit,@disponible)
		)
		COMMIT;
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION;
		RAISERROR('Error al insertar ubicacione en la publicacion',16,1);
	END CATCH
END
GO

IF OBJECT_ID('[TheBigBangQuery].[ActualizarPublicacion]') IS NOT NULL
	DROP PROCEDURE [TheBigBangQuery].[ActualizarPublicacion]
GO
CREATE PROCEDURE [TheBigBangQuery].[ActualizarPublicacion](
	@publId nvarchar(255),
	@espeId nvarchar(255),
	@rubroEspe nvarchar(255),
	@descipcion nvarchar(255),
	@direccion nvarchar(255),
	@idGradoPublicacion nvarchar(255),
	@fechaPublicacion DATETIME,
	@fechaEvento DATETIME,
	@estado nvarchar(255))
AS BEGIN
	
	BEGIN TRANSACTION
	IF (
		SELECT COUNT(*)
		FROM TheBigBangQuery.Publicacion
		WHERE publ_fecha_hora_espectaculo = @fechaEvento
			AND publ_id = CONVERT(NUMERIC,@publId)
	) <= 1 
	BEGIN
		BEGIN TRY
			-- SE PUEDE ACTUALIZAR
			UPDATE [TheBigBangQuery].[Espectaculo]
			SET [espe_rubro] = CONVERT(NUMERIC,@rubroEspe),
				[espe_descripcion] = @descipcion,
				[espe_direccion] = @direccion
			WHERE [espe_id] = CONVERT(NUMERIC, @publId)

			UPDATE [TheBigBangQuery].[Publicacion]
			SET [publ_grad_nivel] = CONVERT(NUMERIC,@idGradoPublicacion),
				[publ_fecha_publicacion] = @fechaPublicacion,
				[publ_fecha_hora_espectaculo] = @fechaEvento,
				[publ_estado] = @estado
			WHERE [publ_id] = CONVERT(NUMERIC, @publId)

		END TRY
		BEGIN CATCH
			RAISERROR( 'No se ha podido actualizar la publicacion' ,16,1);
			ROLLBACK TRANSACTION;
		END CATCH

		COMMIT;

	END ELSE BEGIN
		-- NO SE PUEDE ACTUALIZAR
		RAISERROR( 'Ya existe una publicacion para este espectaculo con la misma fecha' ,16,1);
		ROLLBACK TRANSACTION;
	END

END
GO

IF OBJECT_ID('[TheBigBangQuery].[getIdPubluUbi]') IS NOT NULL
	DROP FUNCTION [TheBigBangQuery].[getIdPubluUbi];
GO
CREATE FUNCTION [TheBigBangQuery].[getIdPubluUbi] (@ubiId nvarchar(255), @publiId nvarchar(255))
RETURNS NUMERIC(12,0) AS BEGIN
	RETURN (
		SELECT TOP 1 ubpu_id
		FROM [TheBigBangQuery].[Ubicaciones_publicacion]
		WHERE ubpu_id_publicacion = CONVERT(NUMERIC(12,0),@publiId)
			AND ubpu_id_ubicacion = CONVERT(NUMERIC(12,0),@ubiId)
	)
END

GO 


IF OBJECT_ID('[TheBigBangQuery].[getPublicacionesPorPagina]') IS NOT NULL
	DROP FUNCTION [TheBigBangQuery].[getPublicacionesPorPagina];
GO
IF TYPE_ID('[TheBigBangQuery].[InfoBasicaPublicacion]') IS NOT NULL
	DROP TYPE [TheBigBangQuery].[InfoBasicaPublicacion];
GO
CREATE TYPE [TheBigBangQuery].[InfoBasicaPublicacion] AS TABLE (
	publ_id NUMERIC(12,0),
	publ_espectaculo NUMERIC(12,0),
	publ_grad_nivel NUMERIC(12,0),
	publ_fecha_publicacion DATETIME,
	publ_fecha_hora_espectaculo DATETIME,
	publ_estado NVARCHAR(50),
	espe_descripcion nvarchar(255),
	espe_direccion nvarchar(255),
	grad_nivel nvarchar(255)
)
GO
CREATE FUNCTION [TheBigBangQuery].[getPublicacionesPorPagina] (
	@numeroPagina int,
	@tablaAPAginar [TheBigBangQuery].[InfoBasicaPublicacion] READONLY
)
RETURNS @temp  TABLE (
	publ_id NUMERIC(12,0),
	publ_espectaculo NUMERIC(12,0),
	publ_grad_nivel NUMERIC(12,0),
	publ_fecha_publicacion DATETIME,
	publ_fecha_hora_espectaculo DATETIME,
	publ_estado NVARCHAR(50),
	espe_descripcion nvarchar(255),
	espe_direccion nvarchar(255),
	grad_nivel nvarchar(255)
) AS BEGIN

	DECLARE @ordenada TABLE (
		fila bigInt,
		publ_id NUMERIC(12,0),
		publ_espectaculo NUMERIC(12,0),
		publ_grad_nivel NUMERIC(12,0),
		publ_fecha_publicacion DATETIME,
		publ_fecha_hora_espectaculo DATETIME,
		publ_estado NVARCHAR(50),
		espe_descripcion nvarchar(255),
		espe_direccion nvarchar(255),
		rub_descripcion nvarchar(255)
	);

	SET @numeroPagina = @numeroPagina - 1;

	INSERT INTO @ordenada 
	SELECT ROW_NUMBER() OVER( ORDER BY publ_grad_nivel ASC) AS RowNum, *
	FROM @tablaAPAginar
	WHERE LOWER(publ_estado) != 'finalizada' AND LOWER(publ_estado) != 'borrador'


	-- PAGINAS DE 40 ELEMENTOS 

	INSERT INTO @temp
	SELECT publ_id, 
		publ_espectaculo, 
		publ_grad_nivel, 
		publ_fecha_publicacion, 
		publ_fecha_hora_espectaculo,
		publ_estado, 
		espe_descripcion, 
		espe_direccion , 
		rub_descripcion
	FROM @ordenada
	WHERE fila >= 40 * @numeroPagina AND fila < (40 * @numeroPagina) + 41

	RETURN;
	
END

GO 

IF OBJECT_ID('[TheBigBangQuery].[getPaginaPublicacionesPorFiltroDescripcion]') IS NOT NULL
	DROP FUNCTION [TheBigBangQuery].[getPaginaPublicacionesPorFiltroDescripcion];
GO
CREATE FUNCTION [TheBigBangQuery].[getPaginaPublicacionesPorFiltroDescripcion](@pagina int, @desc varchar(255))
RETURNS @temp  TABLE (
	publ_id NUMERIC(12,0),
	publ_espectaculo NUMERIC(12,0),
	publ_grad_nivel NUMERIC(12,0),
	publ_fecha_publicacion DATETIME,
	publ_fecha_hora_espectaculo DATETIME,
	publ_estado NVARCHAR(50),
	espe_descripcion nvarchar(255),
	espe_direccion nvarchar(255),
	grad_nivel nvarchar(255)
) AS BEGIN
	DECLARE @t [TheBigBangQuery].[InfoBasicaPublicacion];

	INSERT INTO @t
	SELECT publ_id, 
		publ_espectaculo, 
		publ_grad_nivel, 
		publ_fecha_publicacion, 
		publ_fecha_hora_espectaculo,
		publ_estado, 
		e.espe_descripcion, 
		e.espe_direccion , 
		r.rub_descripcion
	FROM [TheBigBangQuery].[Publicacion] JOIN [TheBigBangQuery].[Espectaculo] e ON (e.espe_id = publ_espectaculo) 
		JOIN [TheBigBangQuery].[Rubro] r ON (e.espe_rubro = r.rub_id)
	WHERE LOWER(e.espe_descripcion) LIKE '%'+LOWER(@desc)+'%'

	INSERT INTO @temp 
	SELECT *
	FROM [TheBigBangQuery].[getPublicacionesPorPagina](@pagina, @t)

	RETURN;
END
GO

IF OBJECT_ID('[TheBigBangQuery].[getPaginaPublicacionesPorFiltroFecha]') IS NOT NULL
	DROP FUNCTION [TheBigBangQuery].[getPaginaPublicacionesPorFiltroFecha];
GO
CREATE FUNCTION [TheBigBangQuery].[getPaginaPublicacionesPorFiltroFecha](
	@pagina int,
	@fechaInicio DATETIME,
	@fechaFin DATETIME)
RETURNS @temp  TABLE (
	publ_id NUMERIC(12,0),
	publ_espectaculo NUMERIC(12,0),
	publ_grad_nivel NUMERIC(12,0),
	publ_fecha_publicacion DATETIME,
	publ_fecha_hora_espectaculo DATETIME,
	publ_estado NVARCHAR(50),
	espe_descripcion nvarchar(255),
	espe_direccion nvarchar(255),
	grad_nivel nvarchar(255)
) AS BEGIN
	DECLARE @t [TheBigBangQuery].[InfoBasicaPublicacion];

	INSERT INTO @t
	SELECT publ_id, 
		publ_espectaculo, 
		publ_grad_nivel, 
		publ_fecha_publicacion, 
		publ_fecha_hora_espectaculo,
		publ_estado, 
		e.espe_descripcion, 
		e.espe_direccion , 
		r.rub_descripcion
	FROM [TheBigBangQuery].[Publicacion] JOIN [TheBigBangQuery].[Espectaculo] e ON (e.espe_id = publ_espectaculo) 
		JOIN [TheBigBangQuery].[Rubro] r ON (e.espe_rubro = r.rub_id)
	WHERE publ_fecha_hora_espectaculo >= @fechaInicio AND publ_fecha_hora_espectaculo <= @fechaFin

	INSERT INTO @temp 
	SELECT *
	FROM [TheBigBangQuery].[getPublicacionesPorPagina](@pagina, @t)

	RETURN;
END
GO



IF OBJECT_ID('[TheBigBangQuery].[getPaginaPublicacionesPorFiltroRubros]') IS NOT NULL 
	DROP FUNCTION [TheBigBangQuery].[getPaginaPublicacionesPorFiltroRubros];
GO

IF OBJECT_ID('[TheBigBangQuery].[getUltimaLineaFiltroRubro]') IS NOT NULL
	DROP FUNCTION [TheBigBangQuery].[getUltimaLineaFiltroRubro];
GO

IF TYPE_ID('[TheBigBangQuery].[RubrosList]') IS NOT NULL
	DROP TYPE [TheBigBangQuery].[RubrosList];
GO

CREATE TYPE [TheBigBangQuery].[RubrosList] AS TABLE (
	[rub_id] NUMERIC(12,0)
)
GO

CREATE FUNCTION [TheBigBangQuery].[getUltimaLineaFiltroRubro](@rubros [theBigBangQuery].[RubrosList] READONLY)
RETURNS INT AS BEGIN

	RETURN (
		SELECT CASE WHEN COUNT(*) % 40 > 0 THEN (COUNT(*)/40) + 1
			ELSE COUNT(*)/40 END 
		FROM [TheBigBangQuery].[Publicacion] JOIN [TheBigBangQuery].[Espectaculo] e ON (e.espe_id = publ_espectaculo) 
			JOIN [TheBigBangQuery].[Rubro] r ON (e.espe_rubro = r.rub_id)
		WHERE e.espe_rubro IN (SELECT *
								FROM @rubros)
	)
END
GO


CREATE FUNCTION [TheBigBangQuery].[getPaginaPublicacionesPorFiltroRubros]
(
	@pagina int,
	@rubros [TheBigBangQuery].[RubrosList] READONLY
)
RETURNS @temp  TABLE (
	publ_id NUMERIC(12,0),
	publ_espectaculo NUMERIC(12,0),
	publ_grad_nivel NUMERIC(12,0),
	publ_fecha_publicacion DATETIME,
	publ_fecha_hora_espectaculo DATETIME,
	publ_estado NVARCHAR(50),
	espe_descripcion nvarchar(255),
	espe_direccion nvarchar(255),
	grad_nivel nvarchar(255)
) AS BEGIN
	DECLARE @t [TheBigBangQuery].[InfoBasicaPublicacion];

	INSERT INTO @t
	SELECT publ_id, 
		publ_espectaculo, 
		publ_grad_nivel, 
		publ_fecha_publicacion, 
		publ_fecha_hora_espectaculo,
		publ_estado, 
		e.espe_descripcion, 
		e.espe_direccion , 
		r.rub_descripcion
	FROM [TheBigBangQuery].[Publicacion] JOIN [TheBigBangQuery].[Espectaculo] e ON (e.espe_id = publ_espectaculo) 
		JOIN [TheBigBangQuery].[Rubro] r ON (e.espe_rubro = r.rub_id)
	WHERE e.espe_rubro IN (SELECT *
							FROM @rubros)


	INSERT INTO @temp 
	SELECT *
	FROM [TheBigBangQuery].[getPublicacionesPorPagina](@pagina, @t)

	RETURN;
END
GO
IF OBJECT_ID('[TheBigBangQuery].[getUltimaLineaFiltroDesc]') IS NOT NULL
	DROP FUNCTION [TheBigBangQuery].[getUltimaLineaFiltroDesc];
GO
CREATE FUNCTION [TheBigBangQuery].[getUltimaLineaFiltroDesc](@desc nvarchar(255))
RETURNS INT AS BEGIN
	DECLARE @temp TABLE ([cant] int, [grad] NUMERIC(12,0));

	
	RETURN (
		SELECT CASE WHEN COUNT(*) % 40 > 0 THEN (COUNT(*)/40) + 1
			ELSE COUNT(*)/40 END   
		FROM [TheBigBangQuery].[Publicacion]
			JOIN [TheBigBangQuery].[Espectaculo] e ON (e.espe_id = publ_espectaculo) 
		WHERE LOWER(e.espe_descripcion) LIKE '%'+LOWER(@desc)+'%'
	)
END
GO


IF OBJECT_ID('[TheBigBangQuery].[getUltimaPagFiltroFecha]') IS NOT NULL
	DROP FUNCTION [TheBigBangQuery].[getUltimaPagFiltroFecha];
GO
CREATE FUNCTION [TheBigBangQuery].[getUltimaPagFiltroFecha](@fechaI DATETIME, @fechaF DATETIME)
RETURNS INT AS BEGIN
	RETURN (
		SELECT CASE WHEN COUNT(*) % 40 > 0 THEN (COUNT(*)/40) + 1
			ELSE COUNT(*)/40 END 
		FROM [TheBigBangQuery].[Publicacion] JOIN [TheBigBangQuery].[Espectaculo] e ON (e.espe_id = publ_espectaculo) 
			JOIN [TheBigBangQuery].[Rubro] r ON (e.espe_rubro = r.rub_id)
		WHERE publ_fecha_hora_espectaculo >= @fechaI AND publ_fecha_hora_espectaculo <= @fechaF
	)
END
GO
-- TRIGGER PARA ACTUALIZAR FACTURA CUANDO SE INSERTA UN ITEM
IF OBJECT_ID('[TheBigBangQuery].[ActualizarfacturaTrigger]') IS NOT NULL	
	DROP TRIGGER [TheBigBangQuery].[ActualizarfacturaTrigger];
GO
CREATE TRIGGER [TheBigBangQuery].[ActualizarfacturaTrigger] ON [TheBigBangQuery].[Item_Factura] AFTER INSERT 
AS BEGIN
	-- CURSOR PARA SUMAR CADA ITEM A SU CORRESPONDIENTE FACTURA
	DECLARE @monto NUMERIC(18,2);
	DECLARE @factNum NUMERIC(12,0);
	DECLARE c CURSOR FOR (
		SELECT item_monto, item_n_factura
		FROM inserted
	);
	OPEN c;
	FETCH c INTO @monto, @factNum;
	WHILE @@FETCH_STATUS = 0
	BEGIN
		UPDATE [TheBigBangQuery].[Factura]
		SET [fact_total] = [fact_total] + @monto
		WHERE fact_numero = @factNum

		FETCH c INTO @monto, @factNum;
	END

	CLOSE c;
	DEALLOCATE c;

END

GO

IF OBJECT_ID('[TheBigBangQuery].[InsertarCompra]') IS NOT NULL
	DROP PROCEDURE [TheBigBangQuery].[InsertarCompra];
GO
IF TYPE_ID('[TheBigBangQuery].[UbicacionesList]') IS NOT NULL 
	DROP TYPE [TheBigBangQuery].[UbicacionesList];
GO
CREATE TYPE [TheBigBangQuery].[UbicacionesList] AS TABLE (
	[ubli_ubicacion] NUMERIC(12,0)
)
GO
CREATE PROCEDURE [TheBigBangQuery].[InsertarCompra] (
	@publicacion NUMERIC(12,0),
	@cliente NUMERIC(12,0),
	@fechaCompra DATETIME,
	@medioPago NVARCHAR(255),
	@cantidad NUMERIC(12,0),
	@total NUMERIC(18,2),
	@ubicaciones [TheBigBangQuery].[UbicacionesList] READONLY
) AS BEGIN
	
	INSERT INTO [TheBigBangQuery].[Compras] (
		[comp_cliente],
		[comp_fecha_y_hora],
		[comp_medio_de_pago],
		[comp_cantidad],
		[comp_total],
		[comp_publicacion]
	) VALUES (
		@cliente,
		@fechaCompra,
		@medioPago,
		@cantidad,
		@total,
		@publicacion
	);

	INSERT INTO [TheBigBangQuery].[Ubicaciones_Compra] (ubco_ubicacion, ubco_compra)
	SELECT ubli_ubicacion, SCOPE_IDENTITY()
	FROM @ubicaciones

	UPDATE [TheBigBangQuery].[Ubicaciones_publicacion]
	SET [ubpu_disponible] = 1
	WHERE [ubpu_id_publicacion] = @publicacion AND 
		[ubpu_id_ubicacion] IN (SELECT ubli_ubicacion FROM @ubicaciones)
END
GO

IF OBJECT_ID('[TheBigBangQuery].[ActualizarPuntosDelCliente]') IS NOT NULL
	DROP PROCEDURE [TheBigBangQuery].[ActualizarPuntosDelCliente];
GO
CREATE PROCEDURE [TheBigBangQuery].[ActualizarPuntosDelCliente] (
	@idCliente NUMERIC (18,0),
	@montoCompra NUMERIC(18,2),
	@fechaCompra DATETIME)
AS BEGIN

	UPDATE [TheBigBangQuery].[Cliente]
	SET [clie_puntos] = @montoCompra * 0.05, [clie_prox_vencimiento_puntos] = DATEADD(MM,2,@fechaCompra)
	WHERE @idCliente = [clie_id]

END

GO
IF OBJECT_ID('[TheBigBangQuery].[InsertarItemFactura]') IS NOT NULL
	DROP PROCEDURE [TheBigBangQuery].[InsertarItemFactura];
GO
CREATE PROCEDURE [TheBigBangQuery].[InsertarItemFactura] (
		@numFact NUMERIC(12,0),
		@idUbi NUMERIC(12,0),
		@idPubli NUMERIC(12,0),
		@monto NUMERIC(18,2),
		@cantidad NUMERIC(12,0),
		@desc VARCHAR(255))
AS BEGIN 
	INSERT INTO [TheBigBangQuery].[Item_Factura](
		[item_n_factura],
		[item_ubicacion],
		[item_publicacion],
		[item_monto],
		[item_cantidad],
		[item_descripcion]
	) VALUES (
		@numFact,
		@idUbi,
		@idPubli,
		@monto,
		@cantidad,
		@desc
	)
END

GO
IF OBJECT_ID('[TheBigBangQuery].[getComprasPorPagina]') IS NOT NULL
	DROP FUNCTION [TheBigBangQuery].[getComprasPorPagina];
GO
CREATE FUNCTION [TheBigBangQuery].[getComprasPorPagina] (@pagina INT, @clieId NUMERIC(18,0))
RETURNS @return TABLE (
	[coml_id] NUMERIC(12,0),
	[coml_fecha_y_hora] DATETIME,
	[coml_medio_pago] NVARCHAR(255),
	[coml_cantidad] NUMERIC(12,0),
	[coml_total] NUMERIC(18,2),
	[com_public_id] NUMERIC(12,0),
	[comp_desc_espec] NVARCHAR(255)
) AS BEGIN 

	DECLARE @ordenada TABLE (
		fila BIGINT,
		[coml_id] NUMERIC(12,0),
		[coml_fecha_y_hora] DATETIME,
		[coml_medio_pago] NVARCHAR(255),
		[coml_cantidad] NUMERIC(12,0),
		[coml_total] NUMERIC(18,2),
		[com_public_id] NUMERIC(12,0),
		[comp_desc_espec] NVARCHAR(255)
	)
	
	SET @pagina = @pagina - 1;

	INSERT INTO @ordenada
	SELECT ROW_NUMBER() OVER (ORDER BY comp_fecha_y_hora DESC) AS ROW, 
		c.comp_id, c.comp_fecha_y_hora, 
		c.comp_medio_de_pago, c.comp_cantidad,
		c.comp_total,
		p.publ_id,
		e.espe_descripcion
	FROM [TheBigBangQuery].[Compras] c JOIN [TheBigBangQuery].[Publicacion] p ON (c.comp_publicacion = p.publ_id)
		JOIN [TheBigBangQuery].[Espectaculo] e ON (e.espe_id = p.publ_espectaculo)
	WHERE c.comp_cliente = @clieId

	INSERT INTO @return
	SELECT [coml_id] , [coml_fecha_y_hora] ,[coml_medio_pago] ,
		[coml_cantidad], [coml_total], [com_public_id], [comp_desc_espec]
	FROM @ordenada
	WHERE fila > (30 * @pagina) AND fila < ( (30 * @pagina) + 31 )

	RETURN
END
GO
IF OBJECT_ID('[TheBigBangQuery].[getLastPaginaCompras]') IS NOT NULL
	DROP FUNCTION [TheBigBangQuery].[getLastPaginaCompras];
GO
CREATE FUNCTION [TheBigBangQuery].[getLastPaginaCompras](@clieId NUMERIC(12,0))
RETURNS INT AS BEGIN
	RETURN (
		SELECT CASE WHEN COUNT(*) % 30 > 0 THEN (COUNT(*)/30) + 1
				ELSE COUNT(*)/40 END 
		FROM [TheBigBangQuery].[Compras]
		WHERE @clieId = [comp_cliente]
	);
END
GO

IF OBJECT_ID('[TheBigBangQuery].[getPremiosDelPuntaje]') IS NOT NULL
	DROP FUNCTION [TheBigBangQuery].[getPremiosDelPuntaje];
GO
CREATE FUNCTION [TheBigBangQuery].[getPremiosDelPuntaje]()
RETURNS @res TABLE (
	punt_id NUMERIC(18,0),
	punt_puntos NUMERIC(18,0),
	punt_nombre NVARCHAR(255),
	punt_vencimiento DATETIME
) AS BEGIN
	INSERT INTO @res
	SELECT *
	FROM [TheBigBangQuery].[Premio]
	
	RETURN;
END
GO

IF OBJECT_ID('[TheBigBangQuery].[insertarNuevoPremio]') IS NOT NULL
	DROP PROCEDURE [TheBigBangQuery].[insertarNuevoPremio];
GO
CREATE PROCEDURE [TheBigBangQuery].[insertarNuevoPremio](
	@puntos NUMERIC(18,0),
	@nombre NVARCHAR(255),
	@vencimiento DATETIME
) AS BEGIN
	
	INSERT INTO [TheBigBangQuery].[Premio] (
		[prem_puntos_necesarios],
		[prem_nombre],
		[prem_vencimiento]
	) VALUES (
		@puntos,
		@nombre,
		@vencimiento
	)

END

GO
IF OBJECT_ID('[TheBigBangQuery].[canjearPuntos]') IS NOT NULL
	DROP PROCEDURE [TheBigBangQuery].[canjearPuntos]
GO
CREATE PROCEDURE [TheBigBangQuery].[canjearPuntos](
	@puntosCanjeados NUMERIC(18,0),
	@idCliente NUMERIC(18,0)
) AS BEGIN
	IF (
		SELECT clie_puntos
		FROM [TheBigBangQuery].[Cliente]
		WHERE clie_id = @idCliente
	) < @puntosCanjeados
	BEGIN
		RAISERROR('No tenes puntos suficientes para canjear por dicho premio',16,1);
	END ELSE BEGIN
		UPDATE TheBigBangQuery.Cliente
		SET clie_puntos = clie_puntos - @puntosCanjeados
		WHERE clie_id = @idCliente
	END
		
END