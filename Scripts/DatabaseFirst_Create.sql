IF DB_ID(N'CafeteriaDB') IS NULL
    CREATE DATABASE CafeteriaDB;
GO

USE CafeteriaDB;
GO

IF OBJECT_ID(N'dbo.Categories', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Categories
    (
        Id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Categories PRIMARY KEY,
        Name nvarchar(100) NOT NULL,
        Description nvarchar(255) NULL
    );
END;
GO

IF OBJECT_ID(N'dbo.Suppliers', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Suppliers
    (
        Id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Suppliers PRIMARY KEY,
        Name nvarchar(100) NOT NULL,
        Email nvarchar(150) NOT NULL,
        Phone nvarchar(20) NOT NULL,
        CONSTRAINT UQ_Suppliers_Email UNIQUE (Email)
    );
END;
GO

IF OBJECT_ID(N'dbo.Products', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Products
    (
        Id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Products PRIMARY KEY,
        Name nvarchar(100) NOT NULL,
        Price decimal(10,2) NOT NULL,
        Quantity int NOT NULL,
        CategoryId int NOT NULL,
        SupplierId int NOT NULL,
        CONSTRAINT FK_Products_Categories FOREIGN KEY (CategoryId)
            REFERENCES dbo.Categories(Id),
        CONSTRAINT FK_Products_Suppliers FOREIGN KEY (SupplierId)
            REFERENCES dbo.Suppliers(Id)
    );
END;
GO

IF OBJECT_ID(N'dbo.PurchaseOrders', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.PurchaseOrders
    (
        Id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_PurchaseOrders PRIMARY KEY,
        OrderDate datetime NOT NULL CONSTRAINT DF_PurchaseOrders_OrderDate DEFAULT (GETDATE()),
        Status nvarchar(30) NOT NULL CONSTRAINT DF_PurchaseOrders_Status DEFAULT (N'Pending'),
        SupplierId int NOT NULL,
        CONSTRAINT FK_PurchaseOrders_Suppliers FOREIGN KEY (SupplierId)
            REFERENCES dbo.Suppliers(Id)
    );
END;
GO

IF OBJECT_ID(N'dbo.PurchaseOrderItems', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.PurchaseOrderItems
    (
        Id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_PurchaseOrderItems PRIMARY KEY,
        PurchaseOrderId int NOT NULL,
        ProductId int NOT NULL,
        Quantity int NOT NULL,
        UnitPrice decimal(10,2) NOT NULL,
        CONSTRAINT FK_PurchaseOrderItems_PurchaseOrders FOREIGN KEY (PurchaseOrderId)
            REFERENCES dbo.PurchaseOrders(Id),
        CONSTRAINT FK_PurchaseOrderItems_Products FOREIGN KEY (ProductId)
            REFERENCES dbo.Products(Id)
    );
END;
GO
