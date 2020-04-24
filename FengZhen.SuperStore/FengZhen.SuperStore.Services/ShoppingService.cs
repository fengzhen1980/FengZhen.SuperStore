using FengZhen.SuperStore.Data.Entities;
using FengZhen.SuperStore.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengZhen.SuperStore.Services
{
    public class ShoppingService
    {
        private IProductRepositories _productRepositorie = new JasonSaveData();

        private readonly ProductService _productService = new ProductService();

        public void AddShoppingItem(
            ShoppingCar shoppingCart,
            string productId,
            int count)
        {
            if (shoppingCart == null)
            {
                throw new ArgumentNullException();
            }

            var product = _productRepositorie.GetProductById(productId);

            if (product.ProductCount < count)
            {
                throw new InvalidOperationException($"Product {product.ProductId} count is not enough.");
            }

            var shoppingItem = shoppingCart.ItemListInCar
                .FirstOrDefault(x => x.ProductId.Equals(productId));
            if (shoppingItem == null)
            {
                shoppingItem = new ShoppingItem
                {
                    ProductId = productId,
                    ProductName = product.ProductName,
                    ItemPrice = product.ProductPrice,
                    ItemCount = count
                };
                shoppingCart.ItemListInCar.Add(shoppingItem);
            }
            else
            {
                shoppingItem.ItemCount += count;
            }
            _productRepositorie.RemoveProduct(productId, count);
        }

        public void RemoveShoppingItem(
            ShoppingCar shoppingCart,
            string productId,
            int count)
        {
            if (shoppingCart == null)
            {
                throw new ArgumentNullException();
            }

            var shoppingItem = shoppingCart.ItemListInCar
                .FirstOrDefault(x => x.ProductId.Equals(productId));
            if (shoppingItem != null)
            {
                int countToAddBack = Math.Min(shoppingItem.ItemCount, count);

                shoppingItem.ItemCount -= count;

                if (shoppingItem.ItemCount <= 0)
                {
                    shoppingCart.ItemListInCar.Remove(shoppingItem);
                }

                try
                {
                    int result = _productService.AddProduct(productId, countToAddBack);
                }
                catch(ArgumentException e)
                {
                    throw (e);
                }
            }
        }

        public List<ShoppingItem> CheckShoppingCart(ShoppingCar shoppingCart)
        {
            foreach (var item in shoppingCart.ItemListInCar)
            {
                Console.WriteLine(item);
            }

            return shoppingCart.ItemListInCar;
        }

        public Receipt Checkout(ShoppingCar shoppingCart)
        {
            var result = new Receipt();

            foreach (var item in shoppingCart.ItemListInCar)
            {
                result.ReceiptItems.Add(new ReceiptItem
                {
                    ReceiptItemId = item.ProductId,
                    ReceiptItemName = item.ProductName,
                    ReceiptPriceOne = item.ItemPrice,
                    ReceiptCount = item.ItemCount,
                    ReceiptItemsPrice = item.ItemSumPrice
                });
            }

            result.TotalItems = result.ReceiptItems.Count;
            result.TotalPrice = result.ReceiptItems.Sum(x => x.ReceiptItemsPrice);
            result.ReceiptId = DateTime.Now.ToString("yyyyMMddHHmmss");
            return result;
        }
    }
}
