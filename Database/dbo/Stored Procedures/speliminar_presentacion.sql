create proc speliminar_presentacion
@idpresentacion int
as
delete from presentacion
where idpresentacion=@idpresentacion
