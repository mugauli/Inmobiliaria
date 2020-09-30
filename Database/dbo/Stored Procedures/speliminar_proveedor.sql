create proc speliminar_proveedor
@idproveedor int
as
delete from proveedor
where idproveedor=@idproveedor
