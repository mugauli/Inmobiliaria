create proc speliminar_venta
@idventa int
as
delete from venta
where idventa=@idventa
