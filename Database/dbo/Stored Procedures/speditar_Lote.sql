/******************************************************************************/    
/* Copyright Miguel Salazar 2013. All Rights Reserved. */    
/* Procedure: [speditar_Lote]                                                  */    
/* Narrative:                                                                  */    
/* Created by:                                                   */    
/* Created date: 2020-09-06       */    
/* Maintenance History                                                         */    
/*******************************************************************************/
CREATE     PROCEDURE   [dbo].[speditar_Lote]
       @idlote             int = NULL
,     @norte              varchar(50) = NULL
,     @sur                varchar(50) = NULL
,     @este               varchar(50) = NULL
,     @oeste              varchar(50) = NULL
,     @medidas            varchar(50) = NULL
,     @ubicacion          varchar(300) = NULL
,     @imagen             image = NULL
,     @idParcela          varchar(10) = NULL
,     @estatus          varchar(10) = NULL
AS    
    
BEGIN TRY   
	 
           UPDATE      dbo.tblLote    
            SET   norte   = ISNULL(@norte,norte)
			,sur   = ISNULL(@sur,sur)
			,este   = ISNULL(@este,este)
			,oeste   = ISNULL(@oeste,oeste)
			,medidas   = ISNULL(@medidas,medidas)
			,ubicacion   = ISNULL(@ubicacion,ubicacion)
			,imagen   = ISNULL(@imagen,imagen)
			,idParcela   = ISNULL(@idParcela,idParcela)
			,estatus = @estatus
            WHERE idlote = @idlote;     
			--print 'Update record on IdParcela=' + convert(varchar(5),@idParcela)
	      
END TRY    
BEGIN CATCH    
	SET NOCOUNT ON 
      EXECUTE sp_executesql N'XSQLError'    
	SET   NOCOUNT OFF    
END CATCH    

