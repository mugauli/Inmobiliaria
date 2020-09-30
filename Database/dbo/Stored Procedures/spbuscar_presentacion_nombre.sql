create proc spbuscar_presentacion_nombre
@textobuscar varchar(50)
as
select * from presentacion
where nombre like @textobuscar + '%' --Alt + 39
