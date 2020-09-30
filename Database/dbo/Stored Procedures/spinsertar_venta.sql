create proc spinsertar_venta
@idventa int=null output,
@idcliente int,
@idtrabajador int,
@fecha date,
@tipo_comprobante varchar(20),
@serie varchar(4),
@correlativo varchar(7),
@igv decimal(4,2)
as
insert into venta (idcliente,idtrabajador,fecha,tipo_comprobante,
serie,correlativo,igv)
values (@idcliente,@idtrabajador,@fecha,@tipo_comprobante,
@serie,@correlativo,@igv)
--Obtenemos el código autogenerado
set @idventa=@@IDENTITY
