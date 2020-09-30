/******************************************************************************/    
/* Copyright Miguel Salazar 2013. All Rights Reserved. */    
/* Procedure: tblParcela_InUp                                                  */    
/* Narrative:                                                                  */    
/* Created by:                                                   */    
/* Created date: 2020-09-06       */    
/* Maintenance History                                                         */    
/*******************************************************************************/
CREATE     PROCEDURE   [dbo].[speditar_Parcela]
     @idParcela          varchar(10) = NULL
,     @nombre             varchar(50) = NULL
,     @cp                 varchar(13) = NULL
,     @colonia            varchar(10) = NULL
,     @delMunc            varchar(10) = NULL
,     @observaciones      varchar(200) = NULL
AS    
    
BEGIN TRY   
	 
            UPDATE      dbo.tblParcela    
			set Nombre   = ISNULL(@nombre,Nombre)
			,Cp   = ISNULL(@cp,Cp)
			,Colonia   = ISNULL(@colonia,Colonia)
			,DelMunc   = ISNULL(@delMunc,DelMunc)
			,Observaciones   = ISNULL(@observaciones,Observaciones)
            WHERE  IdParcela= @idParcela;    
			--print 'Update record on IdParcela=' + convert(varchar(5),@idParcela)
	      
END TRY    
BEGIN CATCH    
	SET NOCOUNT ON 
      EXECUTE sp_executesql N'XSQLError'    
	SET   NOCOUNT OFF    
END CATCH    

