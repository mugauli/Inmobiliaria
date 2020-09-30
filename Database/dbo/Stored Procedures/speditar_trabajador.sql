create proc speditar_trabajador
@idtrabajador int,
@nombre varchar(20),
@apellidos varchar(40),
@sexo varchar(1),
@fecha_nacimiento date,
@num_documento varchar(8),
@direccion varchar(100),
@telefono varchar(10),
@email varchar(50),
@acceso varchar(20),
@usuario varchar(20),
@password varchar(20)
as
update trabajador set nombre=@nombre,apellidos=@apellidos,
sexo=@sexo,fecha_nac=@fecha_nacimiento,num_documento=@num_documento,
direccion=@direccion,telefono=@telefono,email=@email,
acceso=@acceso,usuario=@usuario,password=@password
where idtrabajador=@idtrabajador
