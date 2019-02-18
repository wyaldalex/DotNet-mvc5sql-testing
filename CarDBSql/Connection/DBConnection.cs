using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDBSql.Connection
{
   public class DBConnection
    {
        public static SqlConnection getConnection()
        {
            //Create Table Script for fast testing
            //Local DB test  Data Source=(localdb)\mssqllocaldb;Initial Catalog=master;Integrated Security=True
            //TestDB
            /*
             * CREATE DATABASE [AireSpringCar];
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
             */
            try
            {
                // Build connection string
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "(localdb)\\mssqllocaldb";   
                builder.InitialCatalog = "AireSpringCar";
                builder.IntegratedSecurity = true;
                // Connect to SQL
                Console.Write("Connecting to SQL Server ... ");

                return new SqlConnection(builder.ConnectionString);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
} 


       
    }
}
