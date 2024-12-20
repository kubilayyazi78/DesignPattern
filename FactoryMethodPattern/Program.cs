PizzaStore karabuk = new KarabukPizzaStore();
PizzaStore istanbul = new IstanbulPizzaStore();

IPizza cheesePizza = karabuk.OrderPizza("cheese");

interface IPizza
{
    void Prepare();
    void Bake();
    void Cut();
}

class CheesePizza : IPizza
{
    public void Bake()
    {
        Console.WriteLine("CheesePizza Bake");
    }

    public void Cut()
    {
        Console.WriteLine("CheesePizza Cut");
    }

    public void Prepare()
    {
        Console.WriteLine("CheesePizza Prepare");
    }
}

class VeggiPizza : IPizza
{
    public void Bake()
    {
        Console.WriteLine("VeggiPizza Bake");
    }

    public void Cut()
    {
        Console.WriteLine("VeggiPizza Cut");
    }

    public void Prepare()
    {
        Console.WriteLine("VeggiPizza Prepare");
    }
}

abstract class PizzaStore
{
    protected abstract IPizza CreatePizza(string type);
    public IPizza OrderPizza(string type)
    {
        IPizza pizza = CreatePizza(type);
        pizza.Prepare();
        pizza.Bake();
        pizza.Cut();

        return pizza;
    }

}

class KarabukPizzaStore : PizzaStore
{
    protected override IPizza CreatePizza(string type)
    {
        return type switch
        {
            "cheese" => new CheesePizza(),
            "veggi" => new VeggiPizza(),
            _ => throw new ArgumentException("Invalid", nameof(type))
        };
    }
}

class IstanbulPizzaStore : PizzaStore
{
    protected override IPizza CreatePizza(string type)
    {
        return type switch
        {
            "cheese" => new CheesePizza(),
            "veggi" => new VeggiPizza(),
            _ => throw new ArgumentException("Invalid", nameof(type))
        };
    }
}