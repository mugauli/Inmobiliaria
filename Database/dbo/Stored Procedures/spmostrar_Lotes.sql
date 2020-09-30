CREATE proc [dbo].[spmostrar_Lotes]
as
select   a.idParcela ,
		 b.Nombre as NombreParcela ,
		 a.idlote , 
		 a.estatus ,
		 a.norte ,
		 a.sur ,
		 a.este , 
		 a.oeste ,
		 a.medidas ,
		 a.ubicacion ,
		 a.imagen

from tblLote as a
inner join tblParcela as b on a.idParcela=b.IdParcela
order by idlote asc
