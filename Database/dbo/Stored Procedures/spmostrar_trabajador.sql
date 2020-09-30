create proc spmostrar_trabajador
as
select top 100 * from trabajador
order by apellidos asc
