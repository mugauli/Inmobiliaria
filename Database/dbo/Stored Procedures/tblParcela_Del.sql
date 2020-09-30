/******************************************************************************/    
/* Copyright Miguel Salazar 2013. All Rights Reserved. */    
/* Procedure: tblParcela_Del                                                  */    
/* Narrative:                                                                  */    
/* Created by:                                                   */    
/* Created date: 2020-09-06       */    
/* Maintenance History                                                         */    
/*******************************************************************************/
CREATE     PROCEDURE   [dbo].[tblParcela_Del]
@idParcela          int  
AS    
SET NOCOUNT ON    
BEGIN TRY    
      DELETE      dbo.tblParcela    
      WHERE tblParcela.IdParcela=@idParcela;    
END TRY    
BEGIN CATCH    
      EXECUTE sp_executesql N'XSQLError'    
END CATCH    
SET NOCOUNT OFF    
