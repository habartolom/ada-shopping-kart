IF NOT EXISTS (SELECT * FROM sys.objects WHERE name = N'CreateRequestedProductsType' AND type = 'P')
BEGIN
	EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[CreateRequestedProductsType] AS'
END

EXEC dbo.sp_executesql @statement = 
N'
-- =============================================
-- Author:		Harold Bartolo
-- Create date: Aug 2, 2023
-- Description:	Create Requested Products Type
-- =============================================

ALTER PROCEDURE [dbo].[CreateRequestedProductsType] 
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM sys.types WHERE name = N''RequestedProductsTableType'' AND is_table_type = 1)
    BEGIN
        CREATE TYPE dbo.RequestedProductsTableType AS TABLE
        (
            Id UNIQUEIDENTIFIER,
            Quantity INT
        );
    END
END'

EXEC [dbo].CreateRequestedProductsType