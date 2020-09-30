create proc spmostrar_proveedor
as
select top 100 * from proveedor
order by razon_social asc
