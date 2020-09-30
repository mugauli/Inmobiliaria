/******************************************************************************/    
/* Copyright Miguel Salazar 2013. All Rights Reserved. */    
/* Procedure: tblParcela_InUp                                                  */    
/* Narrative:                                                                  */    
/* Created by:                                                   */    
/* Created date: 2020-09-06       */    
/* Maintenance History                                                         */    
/*******************************************************************************/
CREATE     PROCEDURE   [dbo].[spinsertar_Parcela]
     @idParcela          varchar(10) = NULL
,     @nombre             varchar(50) = NULL
,     @cp                 varchar(13) = NULL
,     @colonia            varchar(10) = NULL
,     @delMunc            varchar(10) = NULL
,     @observaciones      varchar(200) = NULL
AS      
--print 'Start process IdParcela=' + convert(varchar(5),@idParcela)
BEGIN TRY    
            INSERT      INTO  dbo.tblParcela(    
             IdParcela
			,Nombre
			,Cp
			,Colonia
			,DelMunc
			,Observaciones
			)    
            VALUES      (    
			  ISNULL(@idParcela,'')
			, ISNULL(@nombre,'')
			, ISNULL(@cp,'')
			, ISNULL(@colonia,'')
			, ISNULL(@delMunc,'')
			, ISNULL(@observaciones,'')
			);     
END TRY    
BEGIN CATCH    

	SET NOCOUNT ON  
      EXECUTE sp_executesql N'XSQLError'    
	SET NOCOUNT OFF
END CATCH    
		 
