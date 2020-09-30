CREATE TABLE [dbo].[presentacion] (
    [idpresentacion] INT           IDENTITY (1, 1) NOT NULL,
    [nombre]         VARCHAR (50)  NOT NULL,
    [descripcion]    VARCHAR (256) NULL,
    CONSTRAINT [PK_presentacion] PRIMARY KEY CLUSTERED ([idpresentacion] ASC)
);

