IF NOT EXISTS (
    SELECT name 
    FROM sys.databases 
    WHERE name = N'App-Hexagonal'
)
BEGIN
    CREATE DATABASE [App-Hexagonal];
END
GO
