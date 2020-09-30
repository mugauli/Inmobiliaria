create proc spinsertar_presentacion
@idpresentacion int output,
@nombre varchar(50),
@descripcion varchar(256)
as
insert into presentacion (nombre,descripcion)
values (@nombre,@descripcion)
