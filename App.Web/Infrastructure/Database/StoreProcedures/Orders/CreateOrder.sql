IF NOT EXISTS (SELECT * FROM sys.objects WHERE name = N'CreateOrder' AND type = 'P')
BEGIN
	EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[CreateOrder] AS'
END

EXEC dbo.sp_executesql @statement = 
N'
-- =============================================
-- Author:		Harold Bartolo
-- Create date: Aug 2, 2023
-- Description:	Insert Order
-- =============================================

ALTER   PROCEDURE [dbo].[CreateOrder] 
	@id UNIQUEIDENTIFIER,
    @userId UNIQUEIDENTIFIER,
    @date DATETIME,
    @items INT,
    @total FLOAT

AS
BEGIN
	
	SET NOCOUNT ON;

	INSERT INTO [dbo].[Orders] ([Id], [UserId], [Date], [Items], [Total])
		VALUES (@id, @userId, @date, @items, @total)

END'

EXEC [dbo].[CreateOrder] @id, @userId, @date, @items, @total