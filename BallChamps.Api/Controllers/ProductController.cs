using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BallChamps.Domain;
using DataLayer;
using DataLayer.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BallChampsApi.Controllers
{
    /// <summary>
    /// Product Controller
    /// </summary>
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private IProductRepository productRepository;

        /// <summary>
        /// Product Controller
        /// </summary>
        /// <param name="productContext"></param>
        public ProductController(ProductContext productContext)
        {
            this.productRepository = new ProductRepository(productContext);
        }

        /// <summary>
        /// Get Products
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetProducts")]
        public async Task<List<Product>> GetProducts()
        {
            return await productRepository.GetProducts();
        }

        /// <summary>
        /// Get ProductById
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        //[Authorize]
        [HttpGet("GetProductById")]
        public async Task<Product> GetProductById(string productId)
        {
            try
            {
                return await productRepository.GetProductById(productId);
            }
            catch
            {
                return null;
            }

        }

        /// <summary>
        /// Create Product
        /// </summary>
        /// <param name="product"></param>
        //[Authorize]
        [HttpPost("CreateProduct")]
        public void CreateProduct([FromBody] Product product)
        {

            try
            {
                productRepository.InsertProduct(product);
            }
            catch (Exception ex)
            {
                var x = ex;
            }
        }

        /// <summary>
        /// Update Product
        /// </summary>
        /// <param name="product"></param>
        //[Authorize]
        [HttpPost("UpdateProduct")]
        public void UpdateProduct([FromBody] Product product)
        {
            productRepository.UpdateProduct(product);

        }


        /// <summary>
        /// Check if Product Name Exist
        /// </summary>
        /// <param name="productName"></param>
        [HttpGet("ProductNameExist")]

        public async Task<bool> ProductNameExist(string productName)
        {
            bool result = false;

            try
            {
                return result = await productRepository.ProductNameExist(productName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return result;
        }

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <param name="productId"></param>
        [HttpDelete("DeleteProduct")]
        //[Authorize]
        public async Task<HttpResponseMessage> DeleteProduct(string productId)
        {
            HttpResponseMessage returnMessage = new HttpResponseMessage();
            try
            {


                await productRepository.DeleteProduct(productId);

                returnMessage.RequestMessage = new HttpRequestMessage(HttpMethod.Post, "");

                return await Task.FromResult(returnMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return await Task.FromResult(returnMessage);
        }
    }
}
