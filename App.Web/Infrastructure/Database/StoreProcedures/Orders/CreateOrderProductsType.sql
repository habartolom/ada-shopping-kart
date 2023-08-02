IF NOT EXISTS (SELECT * FROM sys.objects WHERE name = N'CreateOrderProductsType' AND type = 'P')
BEGIN
	EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[CreateOrderProductsType] AS'
END

EXEC dbo.sp_executesql @statement = 
N'
-- =============================================
-- Author:		Harold Bartolo
-- Create date: Aug 2, 2023
-- Description:	Create Order Products Type
-- =============================================

ALTER PROCEDURE [dbo].[CreateOrderProductsType] 
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM sys.types WHERE name = N''OrderProductsTableType'' AND is_table_type = 1)
    BEGIN
        CREATE TYPE dbo.OrderProductsTableType AS TABLE
        (
            Id UNIQUEIDENTIFIER,
            Quantity INT,
            Price FLOAT,
            Total FLOAT,
            OrderId UNIQUEIDENTIFIER,
            ProductId UNIQUEIDENTIFIER
        );
    END
END'

EXEC [dbo].CreateOrderProductsType