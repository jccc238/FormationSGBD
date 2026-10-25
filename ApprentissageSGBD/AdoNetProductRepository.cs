using ApprentissageSGBD;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

public class AdoNetProductRepository : IProductRepository
{
    private SqlConnection _connection;

    public AdoNetProductRepository(string? connectionString)
    {
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentException("Connection string cannot be null or empty.", nameof(connectionString));
        }
        _connection = new SqlConnection(connectionString);
    }

    // --- Implémentation du contrat IProductRepository ---

    int IProductRepository.AddProduct(Product product)
    {
        throw new NotImplementedException();
    }

    bool IProductRepository.DeleteProduct(int productId)
    {
        throw new NotImplementedException();
    }

    IEnumerable<Product> IProductRepository.GetAllProducts()
    {
        var products = new List<Product>();

        _connection.Open();

        using (var command = _connection.CreateCommand())
        {
            command.CommandText = "SELECT Id, Name, Price FROM Products";
            command.CommandType = CommandType.Text;

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var product = new Product
                    {
                        Id = reader.GetInt32("Id"),
                        Name = reader.GetString("Name"),
                        Price = reader.GetDecimal("Price")
                    };
                    products.Add(product);
                }
            }
        }

        _connection.Close();

        return products;
    }

    Product? IProductRepository.GetProductById(int productId)
    {
        throw new NotImplementedException();
    }

    bool IProductRepository.UpdateProduct(Product product)
    {
        throw new NotImplementedException();
    }

    
}