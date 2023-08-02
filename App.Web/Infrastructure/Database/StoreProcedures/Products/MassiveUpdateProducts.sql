IF NOT EXISTS (SELECT * FROM sys.objects WHERE name = N'MassiveUpdateProducts' AND type = 'P')
BEGIN
	EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[MassiveUpdateProducts] AS'
END

EXEC dbo.sp_executesql @statement = 
N'
-- =============================================
-- Author:		Harold Bartolo
-- Create date: Aug 2, 2023
-- Description:	Update Products
-- =============================================

ALTER   PROCEDURE [dbo].[MassiveUpdateProducts] 
	@productsTable dbo.ProductsTableType READONLY
AS
BEGIN
	UPDATE [dbo].[Products]
	SET
		[Name] = p.[Name],
		[Price] = p.[Price],
		[Stock] = p.[Stock]
	FROM [dbo].[Products] AS p
	INNER JOIN @productsTable as pt ON p.Id = pt.Id
END'

EXEC [dbo].MassiveUpdateProducts @productsTable