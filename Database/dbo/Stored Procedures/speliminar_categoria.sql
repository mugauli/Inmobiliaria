--Procedimiento Eliminar
create proc speliminar_categoria
@idcategoria int
as
delete from categoria
where idcategoria=@idcategoria
