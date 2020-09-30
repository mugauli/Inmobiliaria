create proc spinsertar_detalle_venta
@iddetalle_venta int output,
@idventa int,
@iddetalle_ingreso int,
@cantidad int,
@precio_venta money,
@descuento money
as
insert into detalle_venta (idventa,iddetalle_ingreso,cantidad,
precio_venta,descuento)
values (@idventa,@iddetalle_ingreso,@cantidad,
@precio_venta,@descuento)
