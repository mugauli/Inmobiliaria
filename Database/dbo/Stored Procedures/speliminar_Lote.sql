/******************************************************************************/    
/* Copyright Miguel Salazar 2013. All Rights Reserved. */    
/* Procedure: [speliminar_Lote]                                                  */    
/* Narrative:                                                                  */    
/* Created by:                                                   */    
/* Created date: 2020-09-06       */    
/* Maintenance History                                                         */    
/*******************************************************************************/
CReate     PROCEDURE   [dbo].[speliminar_Lote]
@idLote         int  
AS    
  
BEGIN TRY    
      Delete      dbo.tblParcela    
      WHERE tblParcela.IdParcela=@idLote;    
END TRY    
BEGIN CATCH    
	SET NOCOUNT ON  
      EXECUTE sp_executesql N'XSQLError'    
	  
	SET NOCOUNT OFF 
END CATCH       
