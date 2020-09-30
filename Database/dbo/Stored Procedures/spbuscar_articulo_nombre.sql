CREATE proc [dbo].[spbuscar_articulo_nombre]
@textobuscar varchar(50)
as
SELECT dbo.articulo.idarticulo, dbo.articulo.codigo, dbo.articulo.nombre,
dbo.articulo.descripcion, dbo.articulo.imagen, dbo.articulo.idcategoria,
dbo.categoria.nombre AS Categoria, dbo.articulo.idpresentacion, 
dbo.presentacion.nombre AS Presentacion
FROM dbo.articulo INNER JOIN dbo.categoria 
ON dbo.articulo.idcategoria = dbo.categoria.idcategoria 
INNER JOIN dbo.presentacion 
ON dbo.articulo.idpresentacion = dbo.presentacion.idpresentacion
where dbo.articulo.nombre like @textobuscar + '%'
order by dbo.articulo.idarticulo desc
