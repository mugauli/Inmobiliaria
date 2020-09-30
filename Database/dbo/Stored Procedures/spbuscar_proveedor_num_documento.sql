create proc spbuscar_proveedor_num_documento
@textobuscar varchar(20)
as
SELECT * FROM proveedor
where num_documento like @textobuscar + '%'
