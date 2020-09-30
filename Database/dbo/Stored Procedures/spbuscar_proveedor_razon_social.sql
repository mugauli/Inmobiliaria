create proc spbuscar_proveedor_razon_social
@textobuscar varchar(50)
as
select * from proveedor
where razon_social like @textobuscar + '%'
