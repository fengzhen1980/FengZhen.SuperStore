using FengZhen.SuperStore.Data.Entities;
using FengZhen.SuperStore.Data.Repositories;
using System;
using System.Collections.Generic;

namespace FengZhen.SuperStore.Services
{
    public class ProductService
    {
        private IProductRepositories _productRepositorie = new JasonSaveData();

        public int AddProduct(
            string id,
            string name,
            decimal price,
            int count)
        {
            _productRepositorie.AddProduct(id, name, price, count);
            return (0);
        }

        public int AddProduct(
            string id,
            int count)
        {
            var product = _productRepositorie.GetProductById(id);
            _productRepositorie.AddProduct(id, product.ProductName, product.ProductPrice, count);
            return (0);
        }

        public int UpdateProductById(
            string id,
            string name,
            decimal price,
            int count)
        {
            try
            {
                _productRepositorie.UpdateProductById(id, name, price, count);
                return (0);
            }
            catch(ArgumentException e)
            {
                return (1);
            }
            
        }

        public Product GetProductById(string id)
        {
            return _productRepositorie.GetProductById(id);
        }

        public int RemoveProductById(string id, int count)
        {
            _productRepositorie.RemoveProduct(id, count);
            return (0);
        }

        public List<Product> GetAllProducts()
        {
            return _productRepositorie.GetProducts();
        }
    }

}
