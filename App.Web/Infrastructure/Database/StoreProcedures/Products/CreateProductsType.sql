IF NOT EXISTS (SELECT * FROM sys.objects WHERE name = N'CreateProductsType' AND type = 'P')
BEGIN
	EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[CreateProductsType] AS'
END

EXEC dbo.sp_executesql @statement = 
N'
-- =============================================
-- Author:		Harold Bartolo
-- Create date: Aug 2, 2023
-- Description:	Create Products Type
-- =============================================

ALTER PROCEDURE [dbo].[CreateProductsType] 
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM sys.types WHERE name = N''ProductsTableType'' AND is_table_type = 1)
    BEGIN
        CREATE TYPE dbo.ProductsTableType AS TABLE
        (
            Id UNIQUEIDENTIFIER,
            Name NVARCHAR(MAX),
            Price FLOAT,
            Stock INT
        );
    END
END'

EXEC [dbo].CreateProductsType