CREATE proc [dbo].[spmostrar_ingreso]
as
select top 100 i.idingreso,(t.apellidos+' '+t.nombre) as Trabajador,
p.razon_social as Proveedor,i.fecha,i.tipo_comprobante,
i.serie,i.correlativo,i.estado,
sum(d.precio_compra*d.stock_inicial) as Total,i.igv as Impuesto
from detalle_ingreso d inner join ingreso i
on d.idingreso=i.idingreso
inner join proveedor p
on i.idproveedor=p.idproveedor
inner join trabajador t
on i.idtrabajador=t.idtrabajador
group by
i.idingreso,t.apellidos+' '+t.nombre,
p.razon_social,i.fecha,i.tipo_comprobante,
i.serie,i.correlativo,i.estado,i.igv
order by i.idingreso desc
