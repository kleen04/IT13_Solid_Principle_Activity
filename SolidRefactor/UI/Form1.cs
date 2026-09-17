using SolidRefactor.Domain;
using SolidRefactor.Domain.Discounts;
using SolidRefactor.Invoicing;
using SolidRefactor.Persistence;

namespace SolidRefactor.UI;

public partial class Form1 : Form
{
    private readonly IOrderTotalCalculator _calculator;
    private readonly IDiscountCatalog _discounts;
    private readonly IOrderWriter _orders;
    private readonly IInvoiceSender _invoiceSender;
    private readonly IInvoicePresenter _invoicePresenter;

    private decimal _total;

   
    public Form1() : this(Composition.Default()) { }

    public Form1(OrderScreenDependencies deps)
    {
        ArgumentNullException.ThrowIfNull(deps);

        InitializeComponent();

        _calculator = deps.Calculator;
        _discounts = deps.Discounts;
        _orders = deps.Orders;
        _invoiceSender = deps.InvoiceSender;
        _invoicePresenter = deps.InvoicePresenter;

        cmbDiscountType.Items.Clear();
        foreach (string name in _discounts.Names())
        {
            cmbDiscountType.Items.Add(name);
        }
        cmbDiscountType.SelectedIndex = 0;
    }

    private void btnCalculate_Click(object sender, EventArgs e)
    {
        try
        {
            IDiscountStrategy discount = _discounts.Find(cmbDiscountType.SelectedItem?.ToString() ?? "None");
            _total = _calculator.Calculate(ReadItemsFromGrid(), discount);
            lblTotal.Text = _total.ToString("C");
        }
        catch (Exception ex)
        {
            ShowError("Could not calculate the total", ex);
        }
    }

    private void btnSaveOrder_Click(object sender, EventArgs e)
    {
        try
        {
            _orders.Save(BuildOrder());
            MessageBox.Show("Saved!", "Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            ShowError("Could not save the order", ex);
        }
    }

    private void btnEmailInvoice_Click(object sender, EventArgs e)
    {
        try
        {
            _invoiceSender.Send(BuildOrder());
            MessageBox.Show("Invoice sent.", "Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            ShowError("Could not send the invoice", ex);
        }
    }

    private void btnPrint_Click(object sender, EventArgs e)
    {
        _invoicePresenter.Present(BuildOrder());
    }

    private Order BuildOrder() => new(txtCustomerEmail.Text.Trim(), ReadItemsFromGrid(), _total);

    
    private IReadOnlyList<OrderItem> ReadItemsFromGrid()
    {
        var items = new List<OrderItem>();

        foreach (DataGridViewRow row in dgvItems.Rows)
        {
            if (row.IsNewRow) continue;

            object? priceCell = row.Cells["Price"].Value;
            if (priceCell is null || priceCell == DBNull.Value) continue;

            object? qtyCell = row.Cells["Qty"].Value;
            string product = row.Cells["Product"].Value?.ToString() ?? string.Empty;

            decimal price = Convert.ToDecimal(priceCell);
            int qty = (qtyCell is null || qtyCell == DBNull.Value) ? 0 : Convert.ToInt32(qtyCell);

            items.Add(new OrderItem(product, price, qty));
        }

        return items;
    }

    private static void ShowError(string what, Exception ex) =>
        MessageBox.Show($"{what}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
}
