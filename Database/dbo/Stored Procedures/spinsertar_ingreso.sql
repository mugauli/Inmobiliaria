create proc spinsertar_ingreso
@idingreso int=null output,
@idtrabajador int,
@idproveedor int,
@fecha date,
@tipo_comprobante varchar(20),
@serie varchar(4),
@correlativo varchar(7),
@igv decimal(4,2),
@estado varchar(7)
as
insert into ingreso (idtrabajador,idproveedor,fecha,tipo_comprobante,
serie,correlativo,igv,estado)
values (@idtrabajador,@idproveedor,@fecha,@tipo_comprobante,
@serie,@correlativo,@igv,@estado)
--Obtener el código autogenerado
SET @idingreso=@@IDENTITY
