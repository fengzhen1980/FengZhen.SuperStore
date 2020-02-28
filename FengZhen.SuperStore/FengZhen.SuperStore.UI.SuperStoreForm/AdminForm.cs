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
            }
            else
            {
                MessageBox.Show("Update fail.");
            }
        }

        private void buttonGetAll_Click(object sender, EventArgs e)
        {
            List<Product> productList = _productService.GetAllProducts();


            //DataGridViewRow productRow = new DataGridViewRow();
            dataGridViewProduct.DataSource = productList;
        }
    }
}
