create proc speliminar_articulo
@idarticulo int
as
delete from articulo
where idarticulo=@idarticulo
