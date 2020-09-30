CREATE proc [dbo].[spbuscar_categoria]
@textobuscar varchar(50)
as
select * from categoria
where nombre like @textobuscar + '%' --Alt +39