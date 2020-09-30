create proc spmostrar_detalle_ingreso
@textobuscar int
as
select d.idarticulo,a.nombre as Articulo,d.precio_compra,
d.precio_venta,d.stock_inicial,d.fecha_produccion,
d.fecha_vencimiento,(d.stock_inicial*d.precio_compra) as Subtotal
from detalle_ingreso d inner join articulo a
on d.idarticulo=a.idarticulo
where d.idingreso=@textobuscar
