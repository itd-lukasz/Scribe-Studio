CREATE TABLE [dbo].[Order]
(
    [ord_id] UNIQUEIDENTIFIER DEFAULT(NEWID()) PRIMARY KEY,
    [ord_date] DATETIME2(7),
    [ord_symbol] NVARCHAR(20),
    [ord_status] NVARCHAR(20),
    [ord_price] DECIMAL(15,10),
    [ord_value] DECIMAL(15,10)
)