CREATE DATABASE [AireSpringCar];
GO

USE [AireSpringCar];
GO

CREATE TABLE [Brand] (
    [BrandId] int NOT NULL IDENTITY,
    [Name] nvarchar(200) NOT NULL,
    CONSTRAINT [PK_Brand] PRIMARY KEY ([BrandId])
);
GO

CREATE TABLE [Model] (
    [ModelId] int NOT NULL IDENTITY,
    [BrandId] int NOT NULL,
    [Name] nvarchar(200),
    [Price] float,
    CONSTRAINT [PK_Model] PRIMARY KEY ([ModelId]),
    CONSTRAINT [FK_Model_Brand_BrandId] FOREIGN KEY ([BrandId]) REFERENCES [Brand] ([BrandId]) ON DELETE CASCADE
);
GO

INSERT INTO [Brand] (Name) VALUES
('Toyota'),
('Ford'),
('Nissan')
GO

INSERT INTO [Model] (BrandId,Name,Price) VALUES
(1,'Yaris',12000),
(1,'Hilux',30000),
(2,'Focus',13000),
(2,'Explorer',24000),
(3,'Versa',7000),
(3,'Patrol',34000)
GO