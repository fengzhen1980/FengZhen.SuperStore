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
    public partial class ShoppingCartForm : Form
    {
        ShoppingService shoppingService = new ShoppingService();
        Printer printer = new Printer();
        public ShoppingCar cart;
        public ShoppingCartForm()
        {
            InitializeComponent();
        }

        private void ShoppingCartForm_Load(object sender, EventArgs e)
        {
            decimal totalPrice = 0;

            foreach(ShoppingItem item in cart.ItemListInCar)
            {
                item.ItemSumPrice = item.ItemPrice * item.ItemCount;
                totalPrice += item.ItemSumPrice;
            }
            dataGridViewShoppingCart.DataSource = cart.ItemListInCar;
            labelTotalPrice.Text = totalPrice.ToString();
        }

        private void buttonCheckOut_Click(object sender, EventArgs e)
        {
            var receipt = shoppingService.Checkout(cart);
            printer.PrintReceipt(receipt);
            MessageBox.Show("Receipt output successful.");

            this.Close();
        }
    }
}
