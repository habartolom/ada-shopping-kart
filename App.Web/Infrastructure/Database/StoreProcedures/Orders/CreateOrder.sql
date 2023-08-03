IF NOT EXISTS (SELECT * FROM sys.objects WHERE name = N'CreateOrder' AND type = 'P')
BEGIN
	EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[CreateOrder] AS'
END

EXEC dbo.sp_executesql @statement = 
N'
-- =============================================
-- Author:		Harold Bartolo
-- Create date: Aug 2, 2023
-- Description:	Create Order
-- =============================================

ALTER PROCEDURE [dbo].[CreateOrder] 
	@orderId UNIQUEIDENTIFIER,
    @orderDate DATETIME,
    @userId UNIQUEIDENTIFIER,
    @requestedProductsTable dbo.RequestedProductsTableType READONLY

AS
BEGIN
	
	CREATE TABLE #TempRequestedInvalidProducts (
		Id UNIQUEIDENTIFIER
	)

	CREATE TABLE #TempProductsWithoutStock (
		Id UNIQUEIDENTIFIER,
		Name VARCHAR(MAX),
		Price FLOAT,
		Stock INT
	)

	CREATE TABLE #TempOrderedProducts (
		Id UNIQUEIDENTIFIER,
		Quantity INT,
		Price FLOAT,
		Total FLOAT,
		OrderId UNIQUEIDENTIFIER,
		ProductId UNIQUEIDENTIFIER
	)

	DECLARE @invalidProducts INT = 0
	DECLARE @productsWithoutStock INT = 0
	
	INSERT INTO #TempRequestedInvalidProducts
	SELECT P.[Id] FROM @requestedProductsTable AS RP LEFT JOIN Products AS P ON RP.[Id] = P.[Id] WHERE P.Id IS NULL
	SET @invalidProducts = @@ROWCOUNT

	INSERT INTO #TempProductsWithoutStock
	SELECT P.[Id], P.[Name], P.[Price], P.[Stock]
	FROM @requestedProductsTable AS RP
	INNER JOIN [dbo].[Products] AS P ON RP.[Id] = P.[Id]
	WHERE P.[Stock] - RP.[Quantity] < 0
	SET @productsWithoutStock = @@ROWCOUNT

	INSERT INTO #TempOrderedProducts
	SELECT NEWID(), RP.[Quantity], P.[Price], RP.[Quantity] * P.[Price], @orderId, P.[Id] 
	FROM @requestedProductsTable AS RP
	INNER JOIN [dbo].[Products] AS P ON RP.[Id] = P.[Id]

	IF(@invalidProducts = 0 AND @productsWithoutStock = 0)
	BEGIN
		DECLARE @total FLOAT
		DECLARE @quantity INT
		SELECT @total = SUM(Total), @quantity = SUM(Quantity) FROM #TempOrderedProducts

		INSERT INTO [dbo].[Orders]
		SELECT @orderId, @orderDate, @total, @quantity, @userId
	
		INSERT INTO [dbo].[OrderProducts]
		SELECT * FROM #TempOrderedProducts

		UPDATE P
		SET P.Stock = P.Stock - OP.Quantity
		FROM [dbo].[Products] AS P
		INNER JOIN #TempOrderedProducts AS OP ON P.[Id] = OP.[ProductId];
	END

	IF OBJECT_ID(''tempdb..#TempRequestedInvalidProducts'') IS NOT NULL BEGIN
		DROP TABLE [dbo].[#TempRequestedInvalidProducts]
	END

	IF OBJECT_ID(''tempdb..#TempProductsWithoutStock'') IS NOT NULL BEGIN
		DROP TABLE [dbo].[#TempProductsWithoutStock]
	END

	IF OBJECT_ID(''tempdb..#TempOrderedProducts'') IS NOT NULL BEGIN
		DROP TABLE [dbo].[#TempOrderedProducts]
	END

END'

EXEC [dbo].[CreateOrder] @orderId, @orderDate, @userId, @requestedProductsTable