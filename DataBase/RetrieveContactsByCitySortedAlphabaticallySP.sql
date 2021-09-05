Create or Alter Procedure spRetrieveContactsByCitySortedAlphabatically
(
	@City varchar(20)
)
As
Begin Try
Select * From AddressBook Where City=@City Order by FirstName ASC
End Try
Begin Catch
SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH 