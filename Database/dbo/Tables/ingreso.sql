CREATE TABLE [dbo].[ingreso] (
    [idingreso]        INT            IDENTITY (1, 1) NOT NULL,
    [idtrabajador]     INT            NOT NULL,
    [idproveedor]      INT            NOT NULL,
    [fecha]            DATE           NOT NULL,
    [tipo_comprobante] VARCHAR (20)   NOT NULL,
    [serie]            VARCHAR (4)    NOT NULL,
    [correlativo]      VARCHAR (7)    NOT NULL,
    [igv]              DECIMAL (4, 2) NOT NULL,
    [estado]           VARCHAR (7)    NOT NULL,
    CONSTRAINT [PK_ingreso] PRIMARY KEY CLUSTERED ([idingreso] ASC),
    CONSTRAINT [FK_ingreso_proveedor] FOREIGN KEY ([idproveedor]) REFERENCES [dbo].[proveedor] ([idproveedor]),
    CONSTRAINT [FK_ingreso_trabajador] FOREIGN KEY ([idtrabajador]) REFERENCES [dbo].[trabajador] ([idtrabajador])
);

