USE AdventureWorks2019;
Go
CREATE PROCEDURE TablesConnection AS
BEGIN
	SELECT Person.Person.FirstName FROM Person.BusinessEntity
	,Person.BusinessEntityAddress
	,Person.Password
	,Person.EmailAddress
	,Person.Person

	WHERE Person.BusinessEntity.BusinessEntityID=1
	AND  Person.BusinessEntity.BusinessEntityID=Person.BusinessEntityAddress.BusinessEntityID
	AND Person.BusinessEntity.BusinessEntityID=Person.Password.BusinessEntityID
	AND Person.BusinessEntity.BusinessEntityID=Person.EmailAddress.BusinessEntityID
	AND Person.BusinessEntity.BusinessEntityID=Person.Person.BusinessEntityID

END;

EXECUTE TablesConnection