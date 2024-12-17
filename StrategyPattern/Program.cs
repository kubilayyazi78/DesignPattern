var paymentOptions = new PaymentOptions()
{
    CardNumber = "111",
    CardHolderName = "ky",
    ExpirationDate = "11.11",
    Cvv = "123",
    Amount = 1000
};

var paymentService = new PaymentService();
do
{
    Console.WriteLine("ödeme yapılacak banka secin");
    var bank = Console.ReadLine();

    IPaymentService bankPaymentService = null;

    switch (bank)
    {
        case "1":
            bankPaymentService = new AkbankBankPaymentService();
            break;
        case "2":
            bankPaymentService = new DenizBankPaymentService();
            break;
        case "3":
            bankPaymentService = new GarantiBankPaymentService();
            break;
        default:
            Console.WriteLine("geçersiz");
            break;
    }

    paymentService.SetPaymentService(bankPaymentService);
    paymentService.PayViaStrategy(paymentOptions);
}
while (Console.ReadKey().Key != ConsoleKey.Escape);

class PaymentService
{
    private IPaymentService _paymentService;

    public PaymentService(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }
    public PaymentService()
    {

    }
    public void SetPaymentService(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }
    public bool PayViaStrategy(PaymentOptions options)
    {
        return _paymentService.Pay(options);

    }
}
public class GarantiBankPaymentService : IPaymentService
{
    public bool Pay(PaymentOptions options)
    {
        Console.WriteLine("Garanti ile ödeme");

        return true;
    }
}
public class AkbankBankPaymentService : IPaymentService
{
    public bool Pay(PaymentOptions options)
    {
        Console.WriteLine("Akbank ile ödeme");

        return true;
    }
}
public class DenizBankPaymentService : IPaymentService
{
    public bool Pay(PaymentOptions options)
    {
        Console.WriteLine("Deniz ile ödeme");

        return true;
    }
}
interface IPaymentService
{
    bool Pay(PaymentOptions options);
}
public class PaymentOptions
{
    public string CardNumber { get; set; }
    public string CardHolderName { get; set; }
    public string ExpirationDate { get; set; }
    public string Cvv { get; set; }
    public decimal Amount { get; set; }
}