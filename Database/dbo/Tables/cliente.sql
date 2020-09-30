CREATE TABLE [dbo].[cliente] (
    [idcliente]        INT           IDENTITY (1, 1) NOT NULL,
    [nombre]           VARCHAR (50)  NOT NULL,
    [apellidos]        VARCHAR (40)  NULL,
    [sexo]             VARCHAR (1)   NULL,
    [fecha_nacimiento] DATE          NULL,
    [tipo_documento]   VARCHAR (20)  NOT NULL,
    [num_documento]    VARCHAR (11)  NOT NULL,
    [direccion]        VARCHAR (100) NULL,
    [telefono]         VARCHAR (10)  NULL,
    [email]            VARCHAR (50)  NULL,
    CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED ([idcliente] ASC)
);

