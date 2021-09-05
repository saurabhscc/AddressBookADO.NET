Create or Alter Procedure spEditExistingContact
(
	@FirstName varchar(20),
	@Address varchar(100)
)
As
Begin Try
Update AddressBook Set Address=@Address Where FirstName=@FirstName
End Try
Begin Catch
SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH