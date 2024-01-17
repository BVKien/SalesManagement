using DataAccess.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Tran Khanh Hien 
namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly eStoreContext context;

        public ProductRepository(eStoreContext dbContext)
        {
            context = dbContext;
        }

        public void AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            Product existingProduct = context.Products.Find(product.ProductId);

            if (existingProduct != null)
            {
                existingProduct.CategoryId = product.CategoryId;
                existingProduct.ProductName = product.ProductName;
                existingProduct.Weight = product.Weight;
                existingProduct.UnitPrice = product.UnitPrice;
                existingProduct.UnitInStock = product.UnitInStock;
                context.Entry(existingProduct).State = EntityState.Modified;
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Product not found", nameof(product));
            }
        }

        public void DeleteProduct(int productId)
        {
            Product productToDelete = context.Products.Find(productId);

            if (productToDelete != null)
            {
                context.Products.Remove(productToDelete);
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Product not found", nameof(productId));
            }
        }
        public IEnumerable<Product> SearchProduct(Product searchProduct)
        {

            var query = from p in context.Products
                        where (searchProduct.CategoryId == 0 || p.CategoryId == searchProduct.CategoryId)
                        && (string.IsNullOrEmpty(searchProduct.ProductName) || p.ProductName.Contains(searchProduct.ProductName))
                        && (!searchProduct.Weight.HasValue || p.Weight == searchProduct.Weight)
                        && (searchProduct.UnitPrice == 0 || p.UnitPrice == searchProduct.UnitPrice)
                        && (searchProduct.UnitInStock == 0 || p.UnitInStock == searchProduct.UnitInStock)
                        select p;
            return query.ToList();
        }

        // Bui Van Kien 
        // Get all products 
        public IEnumerable<Product> GetAllProducts()
        {
            var distinctProducts = context.Products.GroupBy(p => p.ProductName).Select(g => g.First());
            return distinctProducts.ToList();
        }
    }
}
