Create or Alter Procedure spDeleteContact
(
	@FirstName varchar(20)
)
As
Begin Try
Delete from AddressBook Where FirstName=@FirstName
End Try
Begin Catch
SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH 