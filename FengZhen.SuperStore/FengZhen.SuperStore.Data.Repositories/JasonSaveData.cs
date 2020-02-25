using FengZhen.SuperStore.Data.Entities;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengZhen.SuperStore.Data.Repositories
{
    public class JasonSaveData : IProductRepositories
    {
        private const string ProductJsonFile = "ProductData.json";

        public void AddProduct(string id, string name, decimal price, int count)
        {
            if (price <= 0)
            {
                throw new ArgumentException("Price must larger then 0.");
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or white space.");
            }

            if (count <= 0)
            {
                throw new ArgumentException("Count must larger then 0.");
            }

            var productList = GetProductsFromJson();
        }

        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProducts()
        {
            throw new NotImplementedException();
        }

        public void RemoveProduct(int id, int count)
        {
            throw new NotImplementedException();
        }

        public void UpdateProductById(string id, string name, decimal price, int count)
        {
            throw new NotImplementedException();
        }

        private List<Product> GetProductsFromJson()
        {
            var products = new List<Product>();

            try
            {
                products = JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText(ProductJsonFile));
            }
            catch
            {
            }

            return products;
        }
    }
}
