using FengZhen.SuperStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengZhen.SuperStore.Data.Repositories
{
    public interface IProductRepositories
    {
        void AddProduct(string id, string name, decimal price, int count);
        void RemoveProduct(string id, int count);
        void UpdateProductById(string id, string name, decimal price, int count);
        Product GetProductById(string id);
        List<Product> GetProducts();
    }
}
