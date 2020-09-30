create proc spbuscar_cliente_apellidos
@textobuscar varchar(50)
as
select * from cliente
where apellidos like @textobuscar + '%'
