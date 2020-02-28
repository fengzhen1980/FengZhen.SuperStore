using FengZhen.SuperStore.Data.Entities;
using FengZhen.SuperStore.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FengZhen.SuperStore.UI.SuperStoreForm
{
    public partial class AdminForm : Form
    {
        private readonly ProductService _productService = new ProductService();

        public AdminForm()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string id = idInput.Text.Trim();
            string name = nameInput.Text.Trim();
            decimal price = decimal.Parse(priceInput.Text.Trim());
            int count = int.Parse(countInput.Text.Trim());

            int result = _productService.AddProduct(id, name, price, count);
            if(result==0)
            {
                MessageBox.Show("Add successful.");
                ClearAllInput();
            }
            else
            {
                MessageBox.Show("Add fail.");
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string id = idInput.Text.Trim();
            string name = nameInput.Text.Trim();
            decimal price = decimal.Parse(priceInput.Text.Trim());
            int count = int.Parse(countInput.Text.Trim());

            int result = _productService.UpdateProductById(id, name, price, count);
            if (result == 0)
            {
                MessageBox.Show("Update successful.");
                ClearAllInput();
            }
            else
            {
                MessageBox.Show("Update fail.");
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string id = idInput.Text.Trim();
            string name = nameInput.Text.Trim();
            decimal price = decimal.Parse(priceInput.Text.Trim());
            int count = int.Parse(countInput.Text.Trim());

            int result = _productService.RemoveProductById(id, count);
            if (result == 0)
            {
                MessageBox.Show("Update successful.");
                ClearAllInput();
            }
            else
            {
                MessageBox.Show("Update fail.");
            }
        }

        private void buttonGetAll_Click(object sender, EventArgs e)
        {
            List<Product> productList = _productService.GetAllProducts();
            dataGridViewProduct.DataSource = productList;
            ClearAllInput();
        }

        private void DataGridViewListCellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            List<Product> productList = (List<Product>)dataGridViewProduct.DataSource;
            string id = productList[e.RowIndex].ProductId;
            string name = productList[e.RowIndex].ProductName;
            string price = productList[e.RowIndex].ProductPrice.ToString();
            string count = productList[e.RowIndex].ProductCount.ToString();

            idInput.Text = id;
            nameInput.Text = name;
            priceInput.Text = price;
            countInput.Text = count;
        }

        private void ClearAllInput()
        {
            idInput.Text = null;
            nameInput.Text = null;
            priceInput.Text = null;
            countInput.Text = null;
        }

        private void Select_Click(object sender, EventArgs e)
        {
            string id = idInput.Text.Trim();
            string name = nameInput.Text.Trim();
            decimal price;
            if (priceInput.Text=="")
            {
                price = 0;
            }
            else
            {
                price = decimal.Parse(priceInput.Text.Trim());
            }
            int count;
            if (countInput.Text == "")
            {
                count = 0;
            }
            else
            {
                count = int.Parse(countInput.Text.Trim());
            }

            Product product = _productService.GetProductById(id);
            List<Product> productList = new List<Product>();
            productList.Add(product);

            dataGridViewProduct.DataSource = productList;
            ClearAllInput();

        }
    }
}
