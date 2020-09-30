CREATE TABLE [dbo].[detalle_ingreso] (
    [iddetalle_ingreso] INT   IDENTITY (1, 1) NOT NULL,
    [idingreso]         INT   NOT NULL,
    [idarticulo]        INT   NOT NULL,
    [precio_compra]     MONEY NOT NULL,
    [precio_venta]      MONEY NOT NULL,
    [stock_inicial]     INT   NOT NULL,
    [stock_actual]      INT   NOT NULL,
    [fecha_produccion]  DATE  NOT NULL,
    [fecha_vencimiento] DATE  NOT NULL,
    CONSTRAINT [PK_detalle_ingreso] PRIMARY KEY CLUSTERED ([iddetalle_ingreso] ASC),
    CONSTRAINT [FK_detalle_ingreso_articulo] FOREIGN KEY ([idarticulo]) REFERENCES [dbo].[articulo] ([idarticulo]),
    CONSTRAINT [FK_detalle_ingreso_ingreso] FOREIGN KEY ([idingreso]) REFERENCES [dbo].[ingreso] ([idingreso]) ON DELETE CASCADE ON UPDATE CASCADE
);

