CREATE proc [dbo].[spmostrar_venta]
as
select top 100 v.idventa,
(t.apellidos+' '+t.nombre) as Trabajador,
(c.apellidos+' '+c.nombre) as Cliente,
v.fecha,v.tipo_comprobante,v.serie,v.correlativo,
sum((d.cantidad*d.precio_venta)-d.descuento) as Total,v.igv as Impuesto
from detalle_venta d inner join venta v
on d.idventa=v.idventa
inner join cliente c
on v.idcliente=c.idcliente
inner join trabajador t
on v.idtrabajador=t.idtrabajador
group by v.idventa,
(t.apellidos+' '+t.nombre),
(c.apellidos+' '+c.nombre),
v.fecha,v.tipo_comprobante,v.serie,v.correlativo,v.igv
order by v.idventa desc
