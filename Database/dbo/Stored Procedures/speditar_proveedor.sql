create proc speditar_proveedor
@idproveedor int,
@razon_social varchar(150),
@sector_comercial varchar(50),
@tipo_documento varchar(20),
@num_documento varchar(11),
@direccion varchar(100),
@telefono varchar(10),
@email varchar(50),
@url varchar(100)
as
update proveedor set razon_social=@razon_social,sector_comercial=@sector_comercial,
tipo_documento=@tipo_documento,num_documento=@num_documento,
direccion=@direccion,telefono=@telefono,email=@email,
url=@url
where idproveedor=@idproveedor
