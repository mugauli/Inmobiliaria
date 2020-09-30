/******************************************************************************/    
/* Copyright Miguel Salazar 2013. All Rights Reserved. */    
/* Procedure: tblParcela_InUp                                                  */    
/* Narrative:                                                                  */    
/* Created by:                                                   */    
/* Created date: 2020-09-06       */    
/* Maintenance History                                                         */    
/*******************************************************************************/
CREATE     PROCEDURE   [dbo].[tblParcela_InUp]
     @idParcela          varchar(10) = NULL
,     @nombre             varchar(50) = NULL
,     @cp                 varchar(13) = NULL
,     @colonia            varchar(10) = NULL
,     @delMunc            varchar(10) = NULL
,     @observaciones      varchar(200) = NULL
AS    
   
--print 'Start process IdParcela=' + convert(varchar(5),@idParcela)
SET NOCOUNT ON 
BEGIN TRY   
	
      IF EXISTS (select 1 from dbo.tblParcela where IdParcela= @idParcela)    
      BEGIN    
	  	SET   NOCOUNT OFF  
            UPDATE      dbo.tblParcela    
			set Nombre   = ISNULL(@nombre,Nombre)
			,Cp   = ISNULL(@cp,Cp)
			,Colonia   = ISNULL(@colonia,Colonia)
			,DelMunc   = ISNULL(@delMunc,DelMunc)
			,Observaciones   = ISNULL(@observaciones,Observaciones)
            WHERE  IdParcela= @idParcela;    
			--print 'Update record on IdParcela=' + convert(varchar(5),@idParcela)
		SET   NOCOUNT ON
      END    
      ELSE    
      BEGIN    
	  	SET   NOCOUNT OFF  
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
            --SET  @idParcela  = @@identity;    
			print 'Insert record with IdParcela=' +  @idParcela 
				SET   NOCOUNT ON  
      END    
	  --print 'Final process IdParcela=' + convert(varchar(5),@idParcela)
      
END TRY    
BEGIN CATCH    
	SET NOCOUNT ON 
      EXECUTE sp_executesql N'XSQLError'    
	SET   NOCOUNT OFF    
END CATCH    

