create proc spinsertar_detalle_ingreso
@iddetalle_ingreso int output,
@idingreso int,
@idarticulo int,
@precio_compra money,
@precio_venta money,
@stock_inicial int,
@stock_actual int,
@fecha_produccion date,
@fecha_vencimiento date
as
insert into detalle_ingreso (idingreso,idarticulo,precio_compra,
precio_venta,stock_inicial,stock_actual,fecha_produccion,
fecha_vencimiento)
values (@idingreso,@idarticulo,@precio_compra,
@precio_venta,@stock_inicial,@stock_actual,@fecha_produccion,
@fecha_vencimiento)
