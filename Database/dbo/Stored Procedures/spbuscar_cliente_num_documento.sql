create proc spbuscar_cliente_num_documento
@textobuscar varchar(50)
as
select * from cliente
where num_documento like @textobuscar + '%'
