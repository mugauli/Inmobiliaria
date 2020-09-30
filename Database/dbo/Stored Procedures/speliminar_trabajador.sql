create proc speliminar_trabajador
@idtrabajador int
as
delete from trabajador
where idtrabajador=@idtrabajador
