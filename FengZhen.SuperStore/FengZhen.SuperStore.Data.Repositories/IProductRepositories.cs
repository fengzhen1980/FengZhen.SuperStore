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
        int AddProduct(string id, string name, decimal price, int count);
        int RemoveProduct(string id, int count);
        int UpdateProductById(string id, string name, decimal price, int count);
        Product GetProductById(string id);
        List<Product> GetProducts();
    }
}
