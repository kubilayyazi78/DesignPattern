namespace DecoratorPattern.Computers
{
    public class Computer
    {
        public void Start()
        {
            Console.WriteLine($"{GetType().Name} is starting");
        }
        public void ShutDown()
        {
            Console.WriteLine($"{GetType().Name} is shutting down");
        }
    }

    public class Laptop 
    {
        public void OpenLid()
        {
            Console.WriteLine($"{GetType().Name} is lid is opening");
        }
        public void CloseLid()
        {
            Console.WriteLine($"{GetType().Name} is lid is closing");
        }
    }
    public class LaptopDecorator : Laptop
    {
        public virtual void OpenLid()
        {
            base.OpenLid();
        }
        public virtual void CloseLid()
        {
            base.CloseLid();
        }
    }
    public class DellLaptop: LaptopDecorator
    {
        public override void CloseLid()
        {
            base.CloseLid();
            Console.WriteLine("Dell Laptop is sleeping");
        }
    }

    public class AppleLaptop : LaptopDecorator
    {
        public void OpenLid()
        {
            base.OpenLid();
        }
        public void CloseLid()
        {
            base.CloseLid();
        }
    }

   
}
