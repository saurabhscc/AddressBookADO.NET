Create or Alter Procedure spGetSizeOfAddressBookByCity
(
	@City varchar(20)
)
As
Begin Try
Select Count(City) as 'NumberOfContacts' from AddressBook Where City=@City Group by City
End Try
Begin Catch
SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH