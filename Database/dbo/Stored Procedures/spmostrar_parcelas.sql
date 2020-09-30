CREATE proc [dbo].[spmostrar_parcelas]
as
select   * from tblParcela
order by IdParcela asc
