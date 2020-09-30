


/*******************************************************************************/
/* Procedure: XSQLError                                                  */
/* Narrative: Error Handler, storage all errors in database                    */
/* Created by: Miguel Salazar                                                  */
/* Created date: Jan 22, 2013                                                  */
/* Maintenance History                                                         */
/*******************************************************************************/
CREATE PROCEDURE [dbo].[XSQLError]
AS
SET NOCOUNT ON
INSERT INTO dbo.XSQLErrorhandler( 
	dateError
,	errornumber
,	errorseverity
,	errorstate
,	errorprocedure
,	errorline
,	errormessage)
VALUES ( 
	GETDATE() 
,	error_number()
,	error_severity()
,	error_state()
,	error_procedure()
,	error_line()
,	error_message());

--SELECT 
--	GETDATE() as dateError
--,	error_number() as errornumber
--,	error_severity() as errorseverity
--,	error_state() as errorstate
--,	error_procedure() as errorprocedure
--,	error_line() as errorline
--,	error_message() as errormessage ;
--SET NOCOUNT OFF



