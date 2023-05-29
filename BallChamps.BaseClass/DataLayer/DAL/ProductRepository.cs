using BallChamps.Domain;
using Common;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.DAL
{
    public class ProductRepository : IProductRepository, IDisposable
    {
        private ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            this._context = context;
            
        }

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task DeleteProduct(string productId)
        {
            if (productId != null)
            {

                Product product = (from u in _context.Product
                                    where u.ProductId == productId
                                    select u).FirstOrDefault();

                _context.Product.Remove(product);
                Save();
            }
            else
            {

            }
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Product By Id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<Product> GetProductById(string productId)
        {

            Product product = (from u in _context.Product
                         where u.ProductId == productId
                         select u).FirstOrDefault();

            return product;
        }

        /// <summary>
        /// Get Products
        /// </summary>
        /// <returns></returns>
        public async Task<List<Product>> GetProducts()
        {
            return await _context.Product.ToListAsync();
        }

        /// <summary>
        /// Insert Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task InsertProduct(Product product)
        {
           string id =  Guid.NewGuid().ToString();
            string uniqueNumber = Functions.GenerateSixDigit();

            product.ProductId = id;
            product.ProductNumber = uniqueNumber;
            product.ObjType = "Product";
            product.ImagePath = "https://ballchampsstorage.blob.core.windows.net/productimage/" + uniqueNumber + ".png";
            
            _context.Product.Add(product);
        }

        /// <summary>
        /// Save
        /// </summary>
        /// <returns></returns>
        public Task<int> Save()
        {
            return _context.SaveChangesAsync();
        }

        /// <summary>
        /// Update Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task UpdateProduct(Product product)
        {
            _context.Entry(product).Property(x => x.ProductId).IsModified = false;
            _context.Entry(product).Property(x => x.ProductNumber).IsModified = false;
            _context.Entry(product).State = EntityState.Modified;
            Save();
        }

        /// <summary>
        /// Update Product Image
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task UpdateProductImage(string productId)
        {
            throw new NotImplementedException();
        }

        #region Validation

        /// <summary>
        /// Product NameExist
        /// </summary>
        /// <param name="productName"></param>
        /// <returns></returns>
        public async Task<bool> ProductNameExist(string productName)
        {

            var result = await (from u in _context.Product
                                where u.Name == productName
                                select u).AnyAsync();

            return result;
        }

        #endregion
    }
}
