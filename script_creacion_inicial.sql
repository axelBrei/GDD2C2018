USE [GD2C2018]

BEGIN TRANSACTION
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name='TheBigBangQuery')
EXEC ('CREATE SCHEMA [TheBigBangQuery] AUTHORIZATION [gd]')
COMMIT 

IF object_id('TheBigBangQuery.Premio') IS NOT NULL
	DROP TABLE TheBigBangQuery.Premio;
IF object_id('TheBigBangQuery.FormaDePago') IS NOT NULL
	DROP TABLE TheBigBangQuery.FormaDePago;
IF object_id('TheBigBangQuery.Ubicaciones_publicacion') IS NOT NULL
	DROP TABLE TheBigBangQuery.Ubicaciones_publicacion;
IF object_id('TheBigBangQuery.Compras') IS NOT NULL
	DROP TABLE TheBigBangQuery.Compras;
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
    [usua_password] nvarchar(255),
    [usua_n_intentos] INTEGER,

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
    [clie_n_tarjeta] NUMERIC(18,0),
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


CREATE TABLE [TheBigBangQuery].[Rubro] (
    [rub_id] NUMERIC(12,0) NOT NULL IDENTITY(0,1),
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
    [grad_nivel] nvarchar(10) NOT NULL,
    [grad_comision] NUMERIC(10,2),
    [grad_baja] DATETIME

    CONSTRAINT [PK_GRAD] PRIMARY KEY ([grad_nivel])
);



CREATE TABLE [TheBigBangQuery].[Publicacion] (
    [publ_id] NUMERIC(12,0) NOT NULL IDENTITY(0,1),
    [publ_espectaculo] NUMERIC(12,0),
    [publ_grad_nivel] nvarchar(10),
    [publ_fecha_publicacion] DATETIME,
    [publ_fecha_hora_espectaculo] DATETIME,
    [publ_estado] nvarchar(50)

    CONSTRAINT [PK_PUBL] PRIMARY KEY ([publ_id])
);

ALTER TABLE [TheBigBangQuery].[Publicacion]
    ADD CONSTRAINT [PK_ESPEC_ESPE] FOREIGN KEY ([publ_espectaculo]) REFERENCES [TheBigBangQuery].[Espectaculo](espe_id);

ALTER TABLE [TheBigBangQuery].[Publicacion]
    ADD CONSTRAINT [PK_PUBL_GRADO] FOREIGN KEY ([publ_grad_nivel]) REFERENCES [TheBigBangQuery].[GradoPublicaciones](grad_nivel);



CREATE TABLE [TheBigBangQuery].[Ubicacion] (
    [ubi_id] NUMERIC(12,0) NOT NULL IDENTITY(1,1),
    [ubi_fila] VARCHAR(3),
    [ubi_asiento] NUMERIC(18,0),
    [ubi_sin_enumerar] BIT,
    [ubi_tipo_codigo] NUMERIC(18,0),
    [ubi_tipo_descripcion] NVARCHAR(255)

    CONSTRAINT [PK_UBI] PRIMARY KEY ([ubi_id])
);


CREATE TABLE [TheBigBangQuery].[Ubicaciones_publicacion] (
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
    [fact_empresa] NUMERIC(12,0)

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
    [comp_ubicacion] NUMERIC(12,0), 
    [comp_n_factura] NUMERIC(18,0),
    [comp_fecha_y_hora] DATETIME,
    [comp_medio_de_pago] nvarchar(255),
    [comp_cantidad] NUMERIC(12,0)

    CONSTRAINT [PK_COMP] PRIMARY KEY ([comp_id])
);

ALTER TABLE [TheBigBangQuery].[Compras] 
    ADD CONSTRAINT [FK_COMP_CLI] FOREIGN KEY ([comp_cliente]) REFERENCES [TheBigBangQuery].[Cliente](clie_id);

ALTER TABLE [TheBigBangQuery].[Compras] 
    ADD CONSTRAINT [FK_COMP_UBI] FOREIGN KEY (comp_ubicacion) REFERENCES [TheBigBangQuery].[Ubicacion](ubi_id);

ALTER TABLE [TheBigBangQuery].[Compras] 
    ADD CONSTRAINT [FK_COMP_FACT] FOREIGN KEY (comp_n_factura) REFERENCES [TheBigBangQuery].[Factura](fact_numero);

CREATE TABLE [TheBigBangQuery].[FormaDePago] (
	[form_id] INT IDENTITY(1,1),
	[form_nombre] nvarchar(255)

	CONSTRAINT [PK_FORMA_PAGO] PRIMARY KEY ([form_id])
);

COMMIT

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

INSERT INTO [TheBigBangQuery].[Rubro](rub_descripcion) VALUES ('Drama'), ('StandUp'), ('Comedia'), ('Opera'), ('Infantil');

INSERT INTO [TheBigBangQuery].[Funcionalidades_rol]
    SELECT F.func_id, R.rol_cod 
    FROM [TheBigBangQuery].[Rol] R, [TheBigBangQuery].[Funcionalidad] F
    WHERE R.rol_nombre = 'Cliente' AND F.func_desc = 'Comprar'

INSERT INTO [TheBigBangQuery].[Funcionalidades_rol]
    SELECT F.func_id, R.rol_cod 
    FROM [TheBigBangQuery].[Rol] R, [TheBigBangQuery].[Funcionalidad] F
    WHERE R.rol_nombre = 'Empresa' AND (
        F.func_desc = 'Generar Publicacion'  OR
            F.func_desc = 'Editar Publicacion'
    )

INSERT INTO [TheBigBangQuery].[Funcionalidades_rol]
    SELECT F.func_id, R.rol_cod 
    FROM [TheBigBangQuery].[Rol] R, [TheBigBangQuery].[Funcionalidad] F
    WHERE R.rol_nombre = 'Administrativo' AND (
        F.func_desc = 'Login Y Seguridad' OR
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

    -- inserto premios en Tabla de Premios
    INSERT INTO [TheBigBangQuery].[Premio] VALUES (1000,'Bebida a Eleccion', '20200101 12:00:00 PM');
    INSERT INTO [TheBigBangQuery].[Premio] VALUES (10000, 'Entradas a eleccion para proximo espectaculo', '20200101 12:00:00 PM');
    INSERT INTO [TheBigBangQuery].[Premio] VALUES (1500, 'Mochila BigBangQuery','20181220 12:00:00 AM');

    -- CREO FACTURA QUE CONTEMPLA TODAS LAS COMISIONES POR VENTAS ANTERIORES
     INSERT INTO [TheBigBangQuery].Factura VALUES ('efectivo',0,GETDATE(),00001)

	 -- AGREGO LOS GRADOS DE PUBLICACION CON SU RESPECTIVA COMISION
	 INSERT INTO [TheBigBangQuery].[GradoPublicaciones](grad_nivel,grad_comision) VALUES ('ALTO', 15), ('MEDIO', 10), ('BAJO', 5);

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
	SELECT DISTINCT m.Espectaculo_Cod, m.Espectaculo_Descripcion, r.rub_id, e.empr_id
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
	SELECT DISTINCT e.espe_id, m.Espectaculo_Estado, m.Espectaculo_Fecha, m.Espectaculo_Fecha_Venc, 'MEDIO'
	FROM [gd_esquema].[Maestra] m LEFT JOIN [TheBigBangQuery].[Espectaculo] e ON (
		m.Espectaculo_Cod = e.espe_id AND
		m.Espectaculo_Descripcion = e.espe_descripcion
	) 
	WHERE m.Espectaculo_Cod IS NOT NULL AND m.Espectaculo_Descripcion IS NOT NULL AND m.Espectaculo_Rubro_Descripcion IS NOT NULL

	-- INSERTO LAS UBICACIONES
	INSERT INTO [TheBigBangQuery].[Ubicacion](
		[ubi_asiento],
		[ubi_fila],
		[ubi_sin_enumerar],
		[ubi_tipo_codigo],
		[ubi_tipo_descripcion])
	SELECT DISTINCT m.Ubicacion_Asiento, m.Ubicacion_Fila, m.Ubicacion_Sin_numerar, m.Ubicacion_Tipo_Codigo, m.Ubicacion_Tipo_Descripcion
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
		m.Ubicacion_Tipo_Codigo = u.ubi_tipo_codigo AND
		m.Ubicacion_Tipo_Descripcion = u.ubi_tipo_descripcion
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
		fact_empresa)
	SELECT DISTINCT Factura_Nro, Factura_Fecha, f.form_nombre, Factura_Total, e.empr_id
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
		[comp_ubicacion],
		[comp_n_factura],
		[comp_fecha_y_hora],
		[comp_cantidad])
	SELECT c.clie_id,  u.ubi_id, f.fact_numero,m.Compra_Fecha, m.Compra_Cantidad
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
	) LEFT JOIN [TheBigBangQuery].[Ubicacion] u ON (
		u.ubi_fila = m.Ubicacion_Fila AND 
		u.ubi_asiento = m.Ubicacion_Asiento AND 
		u.ubi_sin_enumerar = m.Ubicacion_Sin_numerar AND
		u.ubi_tipo_codigo = m.Ubicacion_Tipo_Codigo AND 
		u.ubi_tipo_descripcion = m.Ubicacion_Tipo_Descripcion
	) LEFT JOIN [TheBigBangQuery].[Factura] f ON (
		f.fact_numero = m.Factura_Nro AND 
		f.fact_fecha = m.Factura_Fecha AND 
		f.fact_total = m.Factura_Total
	)
	WHERE c.clie_id IS NOT NULL AND u.ubi_id IS NOT NULL AND f.fact_numero IS NOT NULL

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
		u.ubi_tipo_codigo = m.Ubicacion_Tipo_Codigo AND 
		u.ubi_tipo_descripcion = m.Ubicacion_Tipo_Descripcion
	)
	WHERE m.Item_Factura_Cantidad IS NOT NULL AND 
		m.Item_Factura_Descripcion IS NOT NULL AND 
		m.Item_Factura_Monto IS NOT NULL AND 
		f.fact_numero IS NOT NULL AND 
		p.publ_id IS NOT NULL AND 
		u.ubi_id IS NOT NULL

COMMIT 

