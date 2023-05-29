using BallChamps.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DAL
{
    public interface IProductRepository : IDisposable
    {
        Task<List<Product>> GetProducts();
        Task<Product> GetProductById(string productId);
        Task InsertProduct(Product product);
        Task DeleteProduct(string productId);
        Task UpdateProduct(Product product);
        Task UpdateProductImage(string productId);
        Task<bool> ProductNameExist(string productName);
        Task<int> Save();
    }
}
