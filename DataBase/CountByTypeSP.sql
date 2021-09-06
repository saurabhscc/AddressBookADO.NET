Create or Alter Procedure spCountByType
(
	@AddressBookType varchar(50)
)
As
Begin try
Select Count(AddressBookType)As 'NumberOfContacts' From AddressBook Where AddressBookType=@AddressBookType
End try
Begin catch
SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH 