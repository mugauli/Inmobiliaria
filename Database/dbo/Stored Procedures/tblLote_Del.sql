
/******************************************************************************/    
/* Copyright Miguel Salazar 2013. All Rights Reserved. */    
/* Procedure: tblLote_Del                                                  */    
/* Narrative:                                                                  */    
/* Created by:                                                   */    
/* Created date: 2020-09-06       */    
/* Maintenance History                                                         */    
/*******************************************************************************/
CREATE     PROCEDURE   [dbo].[tblLote_Del]
   @idlote      int = 0
AS    
SET NOCOUNT ON    
BEGIN TRY    
      DELETE  dbo.tblLote    
      WHERE idlote = @idlote;    
END TRY    
BEGIN CATCH    
      EXECUTE sp_executesql N'XSQLError'    
END CATCH    
SET NOCOUNT OFF    
