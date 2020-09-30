CREATE proc [dbo].[spbuscar_ingreso_fecha]
@textobuscar varchar(50),
@textobuscar2 varchar(50)
as
SELECT ingreso.idingreso,
(trabajador.apellidos +' '+ trabajador.nombre) as Trabajador, 
proveedor.razon_social	as proveedor,
ingreso.fecha, ingreso.tipo_comprobante, 
ingreso.serie, ingreso.correlativo,
ingreso.estado, sum(detalle_ingreso.precio_compra*
detalle_ingreso.stock_inicial) as Total,ingreso.igv as Impuesto
FROM detalle_ingreso INNER JOIN ingreso 
ON detalle_ingreso.idingreso = ingreso.idingreso 
INNER JOIN proveedor 
ON ingreso.idproveedor = proveedor.idproveedor 
INNER JOIN dbo.trabajador 
ON ingreso.idtrabajador = trabajador.idtrabajador
group by
ingreso.idingreso,
trabajador.apellidos +' '+ trabajador.nombre, 
proveedor.razon_social,
ingreso.fecha, ingreso.tipo_comprobante, 
ingreso.serie, ingreso.correlativo,
ingreso.estado,ingreso.igv
having ingreso.fecha>=@textobuscar and ingreso.fecha<=@textobuscar2
