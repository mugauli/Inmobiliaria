create proc spmostrar_presentacion
as
select top 100 * from presentacion
order by idpresentacion desc
