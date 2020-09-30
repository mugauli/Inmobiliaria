create proc spbuscar_trabajador_num_documento
@textobuscar varchar(50)
as
select * from trabajador
where num_documento like @textobuscar +'%'
order by apellidos asc
