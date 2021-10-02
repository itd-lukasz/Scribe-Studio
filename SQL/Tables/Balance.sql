CREATE TABLE dbo.Balance(
    [blc_id]    UNIQUEIDENTIFIER DEFAULT(NEWID()) NOT NULL PRIMARY KEY,
    [blc_date]  DATETIME2(7) NOT NULL,
    [blc_asset] NVARCHAR(100) NOT NULL,
    [blc_free]  DECIMAL(15,10) NOT NULL,
    [blc_locked] DECIMAL(15,10) NOT NULL,
    [blc_price] DECIMAL(15,10) NOT NULL,
    [blc_value] DECIMAL(15,10) NOT NULL
)