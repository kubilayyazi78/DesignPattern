// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Runtime.ExceptionServices;
using System.Xml;

Console.WriteLine("Hello, World!");
// yeni sipariş işleniyor yolda teslim edildi

var order =new Order();

order.PrintOrderState();

order.NextState();

order.PrintOrderState();

Console.ReadLine();

interface IOrderState
{
    void Next(Order order);
    void Previous(Order order);
    void PrintStatus();
}
record DeliveredState : IOrderState
{
    public void Next(Order order)
    {
        Console.WriteLine("Order is finished");
    }

    public void Previous(Order order)
    {
        order.State = new OnTheWayState();
    }

    public void PrintStatus()
    {
        Console.WriteLine("Order is delivered");
    }
}
record OnTheWayState : IOrderState
{
    public void Next(Order order)
    {
        order.State = new DeliveredState();
    }

    public void Previous(Order order)
    {
        order.State = new ProcessingState();
    }

    public void PrintStatus()
    {
        Console.WriteLine("Order is on the way");
    }
}
record ProcessingState : IOrderState
{
    public void Next(Order order)
    {
        order.State = new OnTheWayState();
    }

    public void Previous(Order order)
    {
        order.State = new NewOrderState();
    }

    public void PrintStatus()
    {
        Console.WriteLine("Order is being proccessed");
    }
}
record NewOrderState : IOrderState
{
    public void Next(Order order)
    {
        order.State = new ProcessingState();
    }

    public void Previous(Order order)
    {
        Console.WriteLine("this is the initial state");
    }

    public void PrintStatus()
    {
        Console.WriteLine("Order is placed");
    }
}

class Order
{
    public IOrderState State { get; set; }

    public Order()
    {
        State =new NewOrderState();
    }
    public void NextState()
    {
        State.Next(this);
    }
    public void PreviousState()
    {
        State.Previous(this);
    }
    public void PrintOrderState()
    {
        State.PrintStatus();
    }
}