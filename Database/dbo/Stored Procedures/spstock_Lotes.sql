CREATE proc [dbo].[spstock_Lotes]
as
select top 100 * from tblLote
where estatus = 'Disponible'
order by idlote asc
