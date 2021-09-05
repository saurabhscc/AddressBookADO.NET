Create or Alter Procedure spRetrievePersonBelongsToCityOrState
(
	@City varchar(20),
	@State varchar(20)
)
As
Begin Try
Select * From AddressBook Where City=@City or State=@State
End Try
Begin Catch
SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH 