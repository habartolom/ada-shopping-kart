IF NOT EXISTS (SELECT * FROM sys.objects WHERE name = N'BulkInsertOrderProducts' AND type = 'P')
BEGIN
	EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[BulkInsertOrderProducts] AS'
END

EXEC dbo.sp_executesql @statement = 
N'
-- =============================================
-- Author:		Harold Bartolo
-- Create date: Aug 2, 2023
-- Description:	Products Ordered Bulk Insert 
-- =============================================

ALTER   PROCEDURE [dbo].[BulkInsertOrderProducts] 
	@orderProductsTable dbo.OrderProductsTableType READONLY
AS
BEGIN
	
	SET NOCOUNT ON;

	INSERT INTO [dbo].[OrderProducts] ([Id], [Price], [Quantity], [OrderId], [ProductId], [Total])
		SELECT [Id], [Price], [Quantity], [OrderId], [ProductId], [Total]
		FROM @orderProductsTable;
END'

EXEC [dbo].BulkInsertOrderProducts @orderProductsTable