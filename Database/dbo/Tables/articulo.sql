CREATE TABLE [dbo].[articulo] (
    [idarticulo]     INT            IDENTITY (1, 1) NOT NULL,
    [codigo]         VARCHAR (50)   NOT NULL,
    [nombre]         VARCHAR (50)   NOT NULL,
    [descripcion]    VARCHAR (1024) NULL,
    [imagen]         IMAGE          NULL,
    [idcategoria]    INT            NOT NULL,
    [idpresentacion] INT            NOT NULL,
    CONSTRAINT [PK_articulo] PRIMARY KEY CLUSTERED ([idarticulo] ASC),
    CONSTRAINT [FK_articulo_categoria] FOREIGN KEY ([idcategoria]) REFERENCES [dbo].[categoria] ([idcategoria]),
    CONSTRAINT [FK_articulo_presentacion] FOREIGN KEY ([idpresentacion]) REFERENCES [dbo].[presentacion] ([idpresentacion])
);

