CREATE TABLE [dbo].[trabajador] (
    [idtrabajador]  INT           IDENTITY (1, 1) NOT NULL,
    [nombre]        VARCHAR (20)  NOT NULL,
    [apellidos]     VARCHAR (40)  NOT NULL,
    [sexo]          VARCHAR (1)   NOT NULL,
    [fecha_nac]     DATE          NOT NULL,
    [num_documento] VARCHAR (8)   NOT NULL,
    [direccion]     VARCHAR (100) NULL,
    [telefono]      VARCHAR (10)  NULL,
    [email]         VARCHAR (50)  NULL,
    [acceso]        VARCHAR (20)  NOT NULL,
    [usuario]       VARCHAR (20)  NOT NULL,
    [password]      VARCHAR (20)  NOT NULL,
    CONSTRAINT [PK_trabajador] PRIMARY KEY CLUSTERED ([idtrabajador] ASC)
);

