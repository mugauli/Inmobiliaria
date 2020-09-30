create proc speliminar_cliente
@idcliente int
as
delete from cliente
where idcliente=@idcliente
