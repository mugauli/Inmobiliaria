create proc spinsertar_proveedor
@idproveedor int output,
@razon_social varchar(150),
@sector_comercial varchar(50),
@tipo_documento varchar(20),
@num_documento varchar(11),
@direccion varchar(100),
@telefono varchar(10),
@email varchar(50),
@url varchar(100)
as
insert into proveedor (razon_social,sector_comercial,tipo_documento,
num_documento,direccion,telefono,email,url)
values (@razon_social,@sector_comercial,@tipo_documento,
@num_documento,@direccion,@telefono,@email,@url)
