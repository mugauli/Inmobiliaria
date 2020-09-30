/******************************************************************************/    
/* Copyright Miguel Salazar 2013. All Rights Reserved. */    
/* Procedure: [spinsertar_Lote]                                                  */    
/* Narrative:                                                                  */    
/* Created by:                                                   */    
/* Created date: 2020-09-06       */    
/* Maintenance History                                                         */    
/*******************************************************************************/
CREATE     PROCEDURE   [dbo].[spinsertar_Lote]
      @norte              varchar(50) = NULL
,     @sur                varchar(50) = NULL
,     @este               varchar(50) = NULL
,     @oeste              varchar(50) = NULL
,     @medidas            varchar(50) = NULL
,     @ubicacion          varchar(300) = NULL
,     @imagen             image = NULL
,     @idParcela          varchar(10) = NULL
,     @estatus            varchar(50) = NULL
AS      

BEGIN TRY    
DECLARE @IdLote as integer 

select  @IdLote=ISnull(Max(IdLote)+1,1) from tblLote where idParcela = @idParcela
             INSERT      INTO  dbo.tblLote(  
  idlote
  ,[norte]
  ,[sur]
  ,[este]
  ,[oeste]
  ,[medidas]
  ,[ubicacion]
  ,[imagen]
  ,[idParcela]
  ,[estatus]
)    
            VALUES      (    @IdLote,
  ISNULL(@norte,'')
, ISNULL(@sur,'')
, ISNULL(@este,'')
, ISNULL(@oeste,'')
, ISNULL(@medidas,'')
, ISNULL(@ubicacion,'')
, @imagen
, ISNULL(@idParcela,'') 
, @estatus
);    
           -- SET   @idlote = @@identity;    
END TRY    
BEGIN CATCH    

SET NOCOUNT ON  
      EXECUTE sp_executesql N'XSQLError'    
SET NOCOUNT OFF
END CATCH    