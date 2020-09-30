create proc spanular_ingreso
@idingreso int
as
update ingreso set estado='ANULADO'
where idingreso=@idingreso
