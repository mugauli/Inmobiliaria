create proc spbuscar_trabajador_apellidos
@textobuscar varchar(50)
as
select * from trabajador
where apellidos like @textobuscar +'%'
order by apellidos asc
