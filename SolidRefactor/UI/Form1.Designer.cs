#nullable disable

namespace SolidRefactor.UI;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.lblEmail = new System.Windows.Forms.Label();
        this.txtCustomerEmail = new System.Windows.Forms.TextBox();
        this.dgvItems = new System.Windows.Forms.DataGridView();
        this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.cmbDiscountType = new System.Windows.Forms.ComboBox();
        this.btnCalculate = new System.Windows.Forms.Button();
        this.btnSaveOrder = new System.Windows.Forms.Button();
        this.btnEmailInvoice = new System.Windows.Forms.Button();
        this.btnPrint = new System.Windows.Forms.Button();
        this.lblTotal = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
        this.SuspendLayout();
        // 
        // lblEmail
        // 
        this.lblEmail.AutoSize = true;
        this.lblEmail.Location = new System.Drawing.Point(12, 15);
        this.lblEmail.Name = "lblEmail";
        this.lblEmail.Size = new System.Drawing.Size(107, 15);
        this.lblEmail.TabIndex = 0;
        this.lblEmail.Text = "Customer e-mail:";
        // 
        // txtCustomerEmail
        // 
        this.txtCustomerEmail.Location = new System.Drawing.Point(125, 12);
        this.txtCustomerEmail.Name = "txtCustomerEmail";
        this.txtCustomerEmail.Size = new System.Drawing.Size(320, 23);
        this.txtCustomerEmail.TabIndex = 1;
        // 
        // dgvItems
        // 
        this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Product,
            this.Price,
            this.Qty});
        this.dgvItems.Location = new System.Drawing.Point(12, 50);
        this.dgvItems.Name = "dgvItems";
        this.dgvItems.RowTemplate.Height = 25;
        this.dgvItems.Size = new System.Drawing.Size(433, 220);
        this.dgvItems.TabIndex = 2;
        // 
        // Product
        // 
        this.Product.HeaderText = "Product";
        this.Product.Name = "Product";
        this.Product.Width = 200;
        // 
        // Price
        // 
        this.Price.HeaderText = "Price";
        this.Price.Name = "Price";
        this.Price.Width = 110;
        // 
        // Qty
        // 
        this.Qty.HeaderText = "Qty";
        this.Qty.Name = "Qty";
        this.Qty.Width = 80;
        // 
        // cmbDiscountType
        // 
        this.cmbDiscountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbDiscountType.Location = new System.Drawing.Point(12, 285);
        this.cmbDiscountType.Name = "cmbDiscountType";
        this.cmbDiscountType.Size = new System.Drawing.Size(180, 23);
        this.cmbDiscountType.TabIndex = 3;
        // 
        // btnCalculate
        // 
        this.btnCalculate.Location = new System.Drawing.Point(210, 284);
        this.btnCalculate.Name = "btnCalculate";
        this.btnCalculate.Size = new System.Drawing.Size(110, 26);
        this.btnCalculate.TabIndex = 4;
        this.btnCalculate.Text = "Calculate";
        this.btnCalculate.UseVisualStyleBackColor = true;
        this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
        // 
        // lblTotal
        // 
        this.lblTotal.AutoSize = true;
        this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.lblTotal.Location = new System.Drawing.Point(340, 285);
        this.lblTotal.Name = "lblTotal";
        this.lblTotal.Size = new System.Drawing.Size(48, 21);
        this.lblTotal.TabIndex = 5;
        this.lblTotal.Text = "0.00";
        // 
        // btnSaveOrder
        // 
        this.btnSaveOrder.Location = new System.Drawing.Point(12, 325);
        this.btnSaveOrder.Name = "btnSaveOrder";
        this.btnSaveOrder.Size = new System.Drawing.Size(130, 30);
        this.btnSaveOrder.TabIndex = 6;
        this.btnSaveOrder.Text = "Save Order";
        this.btnSaveOrder.UseVisualStyleBackColor = true;
        this.btnSaveOrder.Click += new System.EventHandler(this.btnSaveOrder_Click);
        // 
        // btnEmailInvoice
        // 
        this.btnEmailInvoice.Location = new System.Drawing.Point(155, 325);
        this.btnEmailInvoice.Name = "btnEmailInvoice";
        this.btnEmailInvoice.Size = new System.Drawing.Size(130, 30);
        this.btnEmailInvoice.TabIndex = 7;
        this.btnEmailInvoice.Text = "E-mail Invoice";
        this.btnEmailInvoice.UseVisualStyleBackColor = true;
        this.btnEmailInvoice.Click += new System.EventHandler(this.btnEmailInvoice_Click);
        // 
        // btnPrint
        // 
        this.btnPrint.Location = new System.Drawing.Point(300, 325);
        this.btnPrint.Name = "btnPrint";
        this.btnPrint.Size = new System.Drawing.Size(130, 30);
        this.btnPrint.TabIndex = 8;
        this.btnPrint.Text = "Print";
        this.btnPrint.UseVisualStyleBackColor = true;
        this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
        // 
        // Form1
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(460, 375);
        this.Controls.Add(this.btnPrint);
        this.Controls.Add(this.btnEmailInvoice);
        this.Controls.Add(this.btnSaveOrder);
        this.Controls.Add(this.lblTotal);
        this.Controls.Add(this.btnCalculate);
        this.Controls.Add(this.cmbDiscountType);
        this.Controls.Add(this.dgvItems);
        this.Controls.Add(this.txtCustomerEmail);
        this.Controls.Add(this.lblEmail);
        this.Name = "Form1";
        this.Text = "Order Screen";
        ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.Label lblEmail;
    private System.Windows.Forms.TextBox txtCustomerEmail;
    private System.Windows.Forms.DataGridView dgvItems;
    private System.Windows.Forms.DataGridViewTextBoxColumn Product;
    private System.Windows.Forms.DataGridViewTextBoxColumn Price;
    private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
    private System.Windows.Forms.ComboBox cmbDiscountType;
    private System.Windows.Forms.Button btnCalculate;
    private System.Windows.Forms.Button btnSaveOrder;
    private System.Windows.Forms.Button btnEmailInvoice;
    private System.Windows.Forms.Button btnPrint;
    private System.Windows.Forms.Label lblTotal;
}
