using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IProductRepository
    {
        // Tran Khanh Hien 
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int productId);
        IEnumerable<Product> SearchProduct(Product searchProduct);

        // Bui Van Kien 
        IEnumerable<Product> GetAllProducts();
    }
}
