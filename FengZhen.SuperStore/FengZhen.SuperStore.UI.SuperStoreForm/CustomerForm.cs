using FengZhen.SuperStore.Data.Entities;
using FengZhen.SuperStore.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FengZhen.SuperStore.UI.SuperStoreForm
{
    public partial class CustomerForm : Form
    {
        private readonly ProductService _productService = new ProductService();
        private readonly ShoppingService shoppingService = new ShoppingService();
        private ShoppingCar cart = new ShoppingCar();
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void buttonGetAll_Click(object sender, EventArgs e)
        {
            //List<Product> productList = _productService.GetAllProducts();
            //dataGridViewProduct.DataSource = productList;

            //DataGridViewTextBoxColumn buyCountColumn = new DataGridViewTextBoxColumn();
            //buyCountColumn.Name = "buyCountColumn";
            //buyCountColumn.DataPropertyName = "buyCountColumn";
            //buyCountColumn.HeaderText = "Buy Count";
            //dataGridViewProduct.Columns.Add(buyCountColumn);

            //foreach (DataGridViewRow row in dataGridViewProduct.Rows)
            //{
            //    row.Cells[4].Value = 0;
            //}
            GetAllProduct(sender, e);
        }

        private void buttonAddToCart_Click(object sender, EventArgs e)
        {
            string id = "";
            int buyCount = 0;

            foreach (DataGridViewRow row in dataGridViewProduct.Rows)
            {

                if (row.Cells[4].Value != null && IsInt(row.Cells[4].Value.ToString()))
                {
                    buyCount = int.Parse(row.Cells[4].Value.ToString());
                    id = row.Cells[0].Value.ToString();
                }
                else
                {
                    buyCount = 0;
                }
                
                if(buyCount != 0)
                {
                    shoppingService.AddShoppingItem(cart, id, buyCount);
                }
            }
            GetAllProduct(sender, e);
        }


        private void GetAllProduct(object sender, EventArgs e)
        {
            List<Product> productList = _productService.GetAllProducts();
            dataGridViewProduct.Columns.Clear();
            dataGridViewProduct.DataSource = productList;
            if (dataGridViewProduct.ColumnCount != 5)
            {
                DataGridViewTextBoxColumn buyCountColumn = new DataGridViewTextBoxColumn();
                buyCountColumn.Name = "buyCountColumn";
                buyCountColumn.DataPropertyName = "buyCountColumn";
                buyCountColumn.HeaderText = "Buy Count";
                dataGridViewProduct.Columns.Add(buyCountColumn);
            }

            foreach (DataGridViewRow row in dataGridViewProduct.Rows)
            {
                //row.Cells[4].Value = 0;
            }
        }

        private bool IsInt(string value)
        {
            return Regex.IsMatch(value, @"^[1-9]d*$");
        }

        private void buttonShowCart_Click(object sender, EventArgs e)
        {
            ShoppingCartForm shoppingCartForm = new ShoppingCartForm();
            shoppingCartForm.cart = cart;
            shoppingCartForm.Show();
        }
    }
}
