CREATE TABLE BPDB.Store (
    [StoreName] NVARCHAR(150),
    [StoreUsername] NVARCHAR(50),
    [StorePW] NVARCHAR(50) UNIQUE,
    [Address] NVARCHAR(150),
    [City] NVARCHAR(150),
    [State] NVARCHAR(25),
    [ZipCode] INT NOT NULL,
    [StoreID] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
)

CREATE TABLE BPDB.Customer (
    [FirstName] NVARCHAR(100),
    [LastName] NVARCHAR(100),
    [EmailAddress] NVARCHAR(150) PRIMARY KEY,
    [CustomerPW] NVARCHAR(50) UNIQUE,
    [Address] NVARCHAR(150),
    [City] NVARCHAR(150),
    [State] NVARCHAR(25),
    [ZipCode] INT NOT NULL,
)

CREATE TABLE BPDB.Admin (
    [AdminName] NVARCHAR(15) PRIMARY KEY,
    [AdminPW] NVARCHAR(15),
)

-- Every Item Purchased Gets Put in this table
CREATE TABLE BPDB.ProductsPurchased (
    [PurchasedProductID] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [ProductID] INT NOT NULL FOREIGN KEY REFERENCES BPDB.Products (ProductID),
    [ProductCount] INT NOT NULL,
    [StoreID] INT NOT NULL FOREIGN KEY REFERENCES BPDB.Store (StoreID),
    [CustomerEmail] NVARCHAR(150) FOREIGN KEY REFERENCES BPDB.Customer (EmailAddress),
    [PurchaseDate] DATETIME2 NOT NULL,
)

CREATE TABLE BPDB.StoreInventory (
    [StoreID] INT NOT NULL FOREIGN KEY REFERENCES BPDB.Store (StoreID),
    [ProductID] INT NOT NULL FOREIGN KEY REFERENCES BPDB.Products (ProductID),
    [ProductName] NVARCHAR(100),
    [ProductCount] INT NOT NULL,
    [SinventoryID] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
)

CREATE TABLE BPDB.Products (
    [ProductID] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    [ProductName] NVARCHAR(100),
    [ProductPrice] DECIMAL(10,2),
)

-- Customers Full Order Placed in this table
CREATE TABLE BPDB.CustomerOrders (
    [CustomerEmail] NVARCHAR(150) FOREIGN KEY REFERENCES BPDB.Customer (EmailAddress),
    [OrderDate] DATETIME NOT NULL,
    [FullProductCount] INT  NOT NULL,
    [TotalPrice] NUMERIC(10,2) NOT NULL,
    [CustomerOrderID] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
)