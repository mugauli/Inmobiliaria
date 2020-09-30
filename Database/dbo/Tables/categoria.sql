CREATE TABLE [dbo].[categoria] (
    [idcategoria] INT           IDENTITY (1, 1) NOT NULL,
    [nombre]      VARCHAR (50)  NOT NULL,
    [descripcion] VARCHAR (256) NULL,
    CONSTRAINT [PK_categoria] PRIMARY KEY CLUSTERED ([idcategoria] ASC)
);

