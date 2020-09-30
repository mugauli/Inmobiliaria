create proc spmostrar_cliente
as
select top 100 * from cliente
order by apellidos asc
