CREATE TABLE [dbo].[venta] (
    [idventa]          INT            IDENTITY (1, 1) NOT NULL,
    [idcliente]        INT            NOT NULL,
    [idtrabajador]     INT            NOT NULL,
    [fecha]            DATE           NOT NULL,
    [tipo_comprobante] VARCHAR (20)   NOT NULL,
    [serie]            VARCHAR (4)    NOT NULL,
    [correlativo]      VARCHAR (7)    NOT NULL,
    [igv]              DECIMAL (4, 2) NOT NULL,
    CONSTRAINT [PK_venta] PRIMARY KEY CLUSTERED ([idventa] ASC),
    CONSTRAINT [FK_venta_cliente] FOREIGN KEY ([idcliente]) REFERENCES [dbo].[cliente] ([idcliente]),
    CONSTRAINT [FK_venta_trabajador] FOREIGN KEY ([idtrabajador]) REFERENCES [dbo].[trabajador] ([idtrabajador])
);

