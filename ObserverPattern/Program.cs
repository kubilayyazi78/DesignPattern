var samsung = new Product("s23", 1000);
var apple = new Product("max16", 5000);

var kubilayObserver = new KubilayObserver("kubilay 78");
var yaziObserver = new YaziObserver("yazi 78");

var amazon = new Amazon();

amazon.Register(kubilayObserver, samsung);
amazon.Register(yaziObserver, apple);

//amazon.NotifyForProductName("s23");
//amazon.NotifyForProductName("max16");
amazon.NotifyAll();

Console.ReadLine();

class Amazon
{
    private Dictionary<IObserver, Product> observers = new();

    public void Register(IObserver observer, Product product)
    {
        observers.TryAdd(observer, product);
    }
    public void UnRegister(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyAll()
    {
        foreach (var observer in observers)
        {
            observer.Key.Notify(observer.Value);
        }
    }
    public void NotifyForProductName (string productName)
    {
        foreach(var observer in observers)
        {
            if (observer.Value.Name==productName)
            {
                observer.Key.Notify(observer.Value);
            }
        }
    }
}
interface IObserver
{
    string FullName { get; set; }
    void Notify(Product product);
}
class KubilayObserver : IObserver
{
    public string FullName { get; set; }

    public KubilayObserver(string fullName)
    {
        FullName = fullName;
    }

    public void Notify(Product product)
    {
        Console.WriteLine($"{FullName}, product {product.Name}");
    }
}
class YaziObserver : IObserver
{
    public string FullName { get; set; }

    public YaziObserver(string fullName)
    {
        FullName = fullName;
    }
    public void Notify(Product product)
    {
        Console.WriteLine($"{FullName}, product {product.Name}");
    }
}
class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}

