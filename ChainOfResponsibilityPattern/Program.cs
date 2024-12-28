// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//StockControl Payment Invoice Shipping

var order = new Order();

var stockControl=new StockControl();

var paymentControl=new PaymentControl();
stockControl.SetNext (paymentControl);

var invoiceControl=new InvoiceControl();
paymentControl.SetNext (invoiceControl);

var shippingControl=new ShippingControl();
invoiceControl.SetNext (shippingControl);

stockControl.Handle(order);


public class StockControl : IOrderHandler
{
    private IOrderHandler next;
    public void SetNext(IOrderHandler next)
    {
        this.next = next;
    }
    public bool Handle(Order order)
    {
        bool stockAvailable = true;
        if (next is not null && stockAvailable)
        {
            return next.Handle(order);
        }
        return false;
    }
}

public class PaymentControl : IOrderHandler
{
    private IOrderHandler next;
    public void SetNext(IOrderHandler next)
    {
        this.next = next;
    }
    public bool Handle(Order order)
    {
        bool paymentSuccess = true;
        if (next is not null && paymentSuccess)
        {
            return next.Handle(order);
        }
        return false;
    }
}

public class InvoiceControl : IOrderHandler
{
    private IOrderHandler next;
    public void SetNext(IOrderHandler next)
    {
        this.next = next;
    }
    public bool Handle(Order order)
    {
        bool invoiceCreated = true;
        if (next is not null && invoiceCreated)
        {
            return next.Handle(order);
        }
        return false;
    }
}

public class ShippingControl : IOrderHandler
{
    private IOrderHandler next;
    public void SetNext(IOrderHandler next)
    {
        this.next = next;
    }
    public bool Handle(Order order)
    {
        bool shippingSuccess = true;
        if (next is not null && shippingSuccess)
        {
            return next.Handle(order);
        }
        return false;
    }
}

public interface IOrderHandler
{
    void SetNext(IOrderHandler next);
    bool Handle(Order order);
}

public class Order
{
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}