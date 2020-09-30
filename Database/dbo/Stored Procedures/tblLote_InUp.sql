/******************************************************************************/    
/* Copyright Miguel Salazar 2013. All Rights Reserved. */    
/* Procedure: tblLote_InUp                                                  */    
/* Narrative:                                                                  */    
/* Created by:                                                   */    
/* Created date: 2020-09-06       */    
/* Maintenance History                                                         */    
/*******************************************************************************/
CREATE     PROCEDURE   [dbo].[tblLote_InUp]
     @idlote             int = NULL
,     @norte              varchar(50) = NULL
,     @sur                varchar(50) = NULL
,     @este               varchar(50) = NULL
,     @oeste              varchar(50) = NULL
,     @medidas            varchar(50) = NULL
,     @ubicacion          varchar(300) = NULL
,     @imagen             image = NULL
,     @idParcela          varchar(10) = NULL
AS    
SET NOCOUNT ON    
BEGIN TRY    
      IF EXISTS (select 1 from dbo.tblLote where idlote = @idlote)    
      BEGIN    
            UPDATE      dbo.tblLote    
            SET   norte   = ISNULL(@norte,norte)
			,sur   = ISNULL(@sur,sur)
			,este   = ISNULL(@este,este)
			,oeste   = ISNULL(@oeste,oeste)
			,medidas   = ISNULL(@medidas,medidas)
			,ubicacion   = ISNULL(@ubicacion,ubicacion)
			,imagen   = ISNULL(@imagen,imagen)
			,idParcela   = ISNULL(@idParcela,idParcela)
     
            WHERE idlote = @idlote;    
      END    
      ELSE    
      BEGIN    
            INSERT      INTO  dbo.tblLote(    
            norte
			,sur
			,este
			,oeste
			,medidas
			,ubicacion
			,imagen
			,idParcela
			)    
            VALUES      (    
				ISNULL(@norte,'')
			, ISNULL(@sur,'')
			, ISNULL(@este,'')
			, ISNULL(@oeste,'')
			, ISNULL(@medidas,'')
			, ISNULL(@ubicacion,'')
			, @imagen
			, ISNULL(@idParcela,0)
			);    
            SET   @idlote = @@identity;    
      END    
      SELECT * FROM dbo.tblLote WHERE idlote = @idlote;     
END TRY    
BEGIN CATCH    
      EXECUTE sp_executesql N'XSQLError'    
END CATCH    
SET   NOCOUNT OFF    
