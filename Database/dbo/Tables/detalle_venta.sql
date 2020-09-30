CREATE TABLE [dbo].[detalle_venta] (
    [iddetalle_venta]   INT   IDENTITY (1, 1) NOT NULL,
    [idventa]           INT   NOT NULL,
    [iddetalle_ingreso] INT   NOT NULL,
    [cantidad]          INT   NOT NULL,
    [precio_venta]      MONEY NOT NULL,
    [descuento]         MONEY NOT NULL,
    CONSTRAINT [PK_detalle_venta] PRIMARY KEY CLUSTERED ([iddetalle_venta] ASC),
    CONSTRAINT [FK_detalle_venta_detalle_ingreso] FOREIGN KEY ([iddetalle_ingreso]) REFERENCES [dbo].[detalle_ingreso] ([iddetalle_ingreso]),
    CONSTRAINT [FK_detalle_venta_venta] FOREIGN KEY ([idventa]) REFERENCES [dbo].[venta] ([idventa]) ON DELETE CASCADE ON UPDATE CASCADE
);


GO
create trigger trrestablecer_stock
on [detalle_venta]
for delete
as
update di set di.stock_actual=di.stock_actual+dv.cantidad
from detalle_ingreso as di inner join
deleted as dv on di.iddetalle_ingreso=dv.iddetalle_ingreso
