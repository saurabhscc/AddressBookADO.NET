Create or Alter Procedure spAlterTable
(
	@FieldName varchar(50)
)
As
Begin try
ALTER TABLE AddressBook ADD tmpCol VARCHAR(100) NULL
EXEC sp_RENAME 'AddressBook.tmpCol' , @FieldName, 'COLUMN'
End try
Begin catch
SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH