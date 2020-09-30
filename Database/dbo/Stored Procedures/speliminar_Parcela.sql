/******************************************************************************/    
/* Copyright Miguel Salazar 2013. All Rights Reserved. */    
/* Procedure: tblParcela_Del                                                  */    
/* Narrative:                                                                  */    
/* Created by:                                                   */    
/* Created date: 2020-09-06       */    
/* Maintenance History                                                         */    
/*******************************************************************************/
CREATE     PROCEDURE   [dbo].[speliminar_Parcela]
@idParcela          int  
AS    
  
BEGIN TRY    
      Delete      dbo.tblParcela    
      WHERE tblParcela.IdParcela=@idParcela;    
END TRY    
BEGIN CATCH    
	SET NOCOUNT ON  
      EXECUTE sp_executesql N'XSQLError'    
	  
	SET NOCOUNT OFF 
END CATCH       
