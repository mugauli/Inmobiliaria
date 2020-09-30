create proc [dbo].[spbuscar_parcela_nombre]
@textobuscar varchar(50)
as
SELECT * from tblParcela
where nombre like rtrim(ltrim(@textobuscar)) + '%'
order by  IdParcela desc
