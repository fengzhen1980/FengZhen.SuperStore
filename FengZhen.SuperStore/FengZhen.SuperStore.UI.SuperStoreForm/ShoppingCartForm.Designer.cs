namespace FengZhen.SuperStore.UI.SuperStoreForm
{
    partial class ShoppingCartForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewShoppingCart = new System.Windows.Forms.DataGridView();
            this.labelTotalPrice = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCheckOut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShoppingCart)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewShoppingCart
            // 
            this.dataGridViewShoppingCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewShoppingCart.Location = new System.Drawing.Point(36, 38);
            this.dataGridViewShoppingCart.Name = "dataGridViewShoppingCart";
            this.dataGridViewShoppingCart.RowHeadersWidth = 51;
            this.dataGridViewShoppingCart.RowTemplate.Height = 24;
            this.dataGridViewShoppingCart.Size = new System.Drawing.Size(730, 327);
            this.dataGridViewShoppingCart.TabIndex = 0;
            // 
            // labelTotalPrice
            // 
            this.labelTotalPrice.AutoSize = true;
            this.labelTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalPrice.Location = new System.Drawing.Point(683, 378);
            this.labelTotalPrice.Name = "labelTotalPrice";
            this.labelTotalPrice.Size = new System.Drawing.Size(0, 29);
            this.labelTotalPrice.TabIndex = 1;
            this.labelTotalPrice.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(538, 378);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "TotalPrice:";
            // 
            // buttonCheckOut
            // 
            this.buttonCheckOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCheckOut.Location = new System.Drawing.Point(36, 378);
            this.buttonCheckOut.Name = "buttonCheckOut";
            this.buttonCheckOut.Size = new System.Drawing.Size(146, 42);
            this.buttonCheckOut.TabIndex = 3;
            this.buttonCheckOut.Text = "Check Out";
            this.buttonCheckOut.UseVisualStyleBackColor = true;
            this.buttonCheckOut.Click += new System.EventHandler(this.buttonCheckOut_Click);
            // 
            // ShoppingCartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonCheckOut);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelTotalPrice);
            this.Controls.Add(this.dataGridViewShoppingCart);
            this.Name = "ShoppingCartForm";
            this.Text = "ShoppingCartForm";
            this.Load += new System.EventHandler(this.ShoppingCartForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShoppingCart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewShoppingCart;
        private System.Windows.Forms.Label labelTotalPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCheckOut;
    }
}