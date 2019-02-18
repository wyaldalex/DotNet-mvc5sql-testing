using CarDBSql.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDBSql.Connection;

namespace CarDBSql.Querys
{
    public class CarQuerys
    {

        public  List<Brand> getAllBrands()
        {
            var brandsList = new List<Brand>();
            try
            { 
                using (SqlConnection connection = DBConnection.getConnection())
                {
                    string sql = "SELECT * FROM Brand";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Brand brand = new Brand();
                                brand.BrandId = reader.GetInt32(0);
                                brand.BrandName = reader.GetString(1);
                                brandsList.Add(brand);
                            }
                        }
                    }

                    return brandsList;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public List<Model> getAllModels()
        {
            var modelList = new List<Model>();
            try
            {
                using (SqlConnection connection = DBConnection.getConnection())
                {
                    string sql = "SELECT Model.ModelId, Model.Name, Model.Price, Brand.Name  AS Brand, Brand.BrandId FROM Model, Brand WHERE Model.BrandId = Brand.BrandId";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Model model = new Model();
                                model.ModelId = reader.GetInt32(0);
                                model.ModelName = reader.GetString(1);
                                model.Price =  reader.GetDouble(2); //(reader.GetFloat(2)
                                model.BrandName = reader.GetString(3);
                                model.BrandId = reader.GetInt32(4);
                                modelList.Add(model);
                            }
                        }
                    }

                    return modelList;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }


        public void insertBrand(string brandName)
        {
            try
            {
                using (SqlConnection connection = DBConnection.getConnection())
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("INSERT INTO Brand (Name) VALUES (@name)");
                    string sql = sb.ToString();
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", brandName);
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " row(s) inserted");

                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }


        public void insertModel(Model model)
        {
            try
            {
                using (SqlConnection connection = DBConnection.getConnection())
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("INSERT INTO Model (BrandId, Name, Price) VALUES (@brandId ,@name, @price)");
                    string sql = sb.ToString();
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@brandId", model.BrandId);
                        command.Parameters.AddWithValue("@name", model.ModelName);
                        command.Parameters.AddWithValue("@price", model.Price);
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " row(s) inserted");

                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

    }
}
