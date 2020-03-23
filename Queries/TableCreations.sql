CREATE TABLE BPDB.Store (
    [StoreName] NVARCHAR(150),
    [StoreID] INT NOT NULL PRIMARY KEY IDENTITY,
)

CREATE TABLE BPDB.StoreLocation (
    [Address] NVARCHAR(150),
    [City] NVARCHAR(150),
    [State] NVARCHAR(25),
    [ZipCode] INT NOT NULL,
    [StoreID] INT NOT NULL FOREIGN KEY REFERENCES BPDB.Store (StoreID),
    [LocationID] INT NOT NULL PRIMARY KEY IDENTITY,
)

CREATE TABLE BPDB.Customer (
    [FirstName] NVARCHAR(100),
    [LastName] NVARCHAR(100),
    [EmailAddress] NVARCHAR(150) PRIMARY KEY,
    [Address] NVARCHAR(150),
    [City] NVARCHAR(150),
    [State] NVARCHAR(25),
    [ZipCode] INT NOT NULL,
)

CREATE TABLE BPDB.Item (
    [ItemName] NVARCHAR(100),
    [ItemID] INT NOT NULL PRIMARY KEY IDENTITY,
)

CREATE TABLE BPDB.Invoice (
    [EmailAddress] NVARCHAR(150) FOREIGN KEY REFERENCES BPDB.Customer (EmailAddress),
    [StoreID] INT NOT NULL FOREIGN KEY REFERENCES BPDB.Store (StoreID),
    [ItemID] INT NOT NULL FOREIGN KEY  REFERENCES BPDB.Item (ItemID),
    [ItemCount] INT NOT NULL,
    [InvoiceID] INT NOT NULL PRIMARY KEY IDENTITY,
)

CREATE TABLE BPDB.Inventory (
    [ItemID] INT NOT NULL FOREIGN KEY REFERENCES BPDB.Item (ItemID),
    [StoreID] INT NOT NULL FOREIGN KEY REFERENCES BPDB.Store (StoreID),
    [ItemCount] INT NOT NULL,
    [InventoryID] INT NOT NULL PRIMARY KEY IDENTITY,
)

CREATE TABLE BPDB.CustomerOrder (
    [CustomerEmail] NVARCHAR(150) FOREIGN KEY REFERENCES BPDB.Customer (EmailAddress),
    [CustomerLine] INT NOT NULL FOREIGN KEY REFERENCES BPDB.Invoice (InvoiceID),
    [InvoiceDate] DATETIME NOT NULL,
    [Total] NUMERIC(10,2) NOT NULL,
    [CustomerOrderID] INT NOT NULL PRIMARY KEY IDENTITY,
)