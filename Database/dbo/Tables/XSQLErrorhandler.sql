CREATE TABLE [dbo].[XSQLErrorhandler] (
    [dateError]      DATETIME        NOT NULL,
    [errornumber]    INT             NULL,
    [errorseverity]  INT             NULL,
    [errorstate]     INT             NULL,
    [errorprocedure] NVARCHAR (128)  NULL,
    [errorline]      INT             NULL,
    [errormessage]   NVARCHAR (4000) NULL
);

