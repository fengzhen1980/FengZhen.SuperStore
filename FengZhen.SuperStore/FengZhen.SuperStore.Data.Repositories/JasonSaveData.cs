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

        public int AddProduct(string id, string name, decimal price, int count)
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

            var product = productList.FirstOrDefault(x => x.ProductId.Equals(id));

            if(product == null)
            {
                product = new Product();
                product.ProductId = id;
                product.ProductName = name;
                product.ProductPrice = price;
                product.ProductCount = count;
                productList.Add(product);

            }
            else
            {
                product.ProductName = name;
                product.ProductPrice = price;
                product.ProductCount += count;
            }

            SaveToJson(productList);
            return (0);
        }

        public Product GetProductById(string id)
        {
            var productList = GetProductsFromJson();

            var product = productList.FirstOrDefault(x => x.ProductId.Equals(id));

            return product;
        }

        public List<Product> GetProducts()
        {
            var products = GetProductsFromJson();
            return products;
        }

        public int RemoveProduct(string id, int count)
        {
            if (count <= 0)
            {
                throw new ArgumentException("Count must larger then 0.");
            }

            var productList = GetProductsFromJson();

            var product = productList.FirstOrDefault(x => x.ProductId.Equals(id));

            if (product == null)
            {
                throw new ArgumentException("ProductId is not exist! Delete failed!");
            }
            else
            {
                product.ProductCount -= count;

                if (product.ProductCount <= 0)
                {
                    productList.Remove(product);
                }
                SaveToJson(productList);
            }
            return (0);
        }

        public int UpdateProductById(string id, string name, decimal price, int count)
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

            var product = productList.FirstOrDefault(x => x.ProductId.Equals(id));

            if (product == null)
            {
                throw new ArgumentException("ProductId is not exist! Update failed!");
            }
            else
            {
                product.ProductName = name;
                product.ProductPrice = price;
                product.ProductCount = count;

                SaveToJson(productList);
            }
            return (0);
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

        private void SaveToJson(List<Product> products)
        {
            File.WriteAllText(ProductJsonFile, JsonConvert.SerializeObject(products));
        }
    }
}
