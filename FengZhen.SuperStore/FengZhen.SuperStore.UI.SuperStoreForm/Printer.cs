using FengZhen.SuperStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengZhen.SuperStore.UI.SuperStoreForm
{
    public class Printer
    {
        public void PrintReceipt(Receipt receipt)
        {
            FileStream fs = new FileStream($"D:\\receipt\\{receipt.ReceiptId}.txt", FileMode.CreateNew);
            byte[] data = System.Text.Encoding.Default.GetBytes("========\r\n");
            fs.Write(data, 0, data.Length);
            data = System.Text.Encoding.Default.GetBytes("Receipt\r\n");
            fs.Write(data, 0, data.Length);
            data = System.Text.Encoding.Default.GetBytes($"Receipt Id : {receipt.ReceiptId}\r\n");
            fs.Write(data, 0, data.Length);
            data = System.Text.Encoding.Default.GetBytes("--------\r\n");
            fs.Write(data, 0, data.Length);
            foreach (var item in receipt.ReceiptItems)
            {
                data = System.Text.Encoding.Default.GetBytes(item.ToString());
                fs.Write(data, 0, data.Length);
            }
            data = System.Text.Encoding.Default.GetBytes("--------\r\n");
            fs.Write(data, 0, data.Length);
            data = System.Text.Encoding.Default.GetBytes($"Total Items: {receipt.TotalItems}\r\n");
            fs.Write(data, 0, data.Length);
            data = System.Text.Encoding.Default.GetBytes($"Total Price: {receipt.TotalPrice}\r\n");
            fs.Write(data, 0, data.Length);
            data = System.Text.Encoding.Default.GetBytes("Thank you.\r\n");
            fs.Write(data, 0, data.Length);
            data = System.Text.Encoding.Default.GetBytes("========\r\n");
            fs.Write(data, 0, data.Length);
            fs.Flush();
            fs.Close();
        }
    }
}
