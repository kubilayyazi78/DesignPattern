// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


var tran = new TransferTransaction() { Amount = 10, FromIBAN = "1", ToIBAN = "2" };

var adapter = new JsonBankApiAdapter();
var result = adapter.ExecuteTransaction(tran);
Console.WriteLine(result);

Console.ReadLine();

interface IBankApi
{
    public bool ExecuteTransaction(TransferTransaction transferTransaction);
}

class JsonBankApiAdapter : IBankApi
{
    private readonly JsonBankApi jsonBankApi;
    public JsonBankApiAdapter()
    {
        jsonBankApi = new();
    }
    public bool ExecuteTransaction(TransferTransaction transferTransaction)
    {
        return jsonBankApi.ExecuteTransaction(transferTransaction);
    }
}

class XmlBankApiAdapter : IBankApi
{
    private readonly XmlBankApi xmlBankApi;
    public XmlBankApiAdapter()
    {
        xmlBankApi = new();
    }
    public bool ExecuteTransaction(TransferTransaction transferTransaction)
    {
        return xmlBankApi.ExecuteTransaction(transferTransaction);
    }
}

class JsonBankApi : IBankApi
{
    public bool ExecuteTransaction(TransferTransaction transferTransaction)
    {
        var json = $$""""
         {
         ""FromIBAN"" : "" {{transferTransaction.FromIBAN}}"",
         ""ToIBAN""   : "" {{transferTransaction.ToIBAN}}"",
         ""Amount""   : "" {{transferTransaction.Amount:C2}}""
         }
         """";

        Console.WriteLine($"{GetType().Name} worked");

        return true;
    }
}

class XmlBankApi : IBankApi
{
    public bool ExecuteTransaction(TransferTransaction transferTransaction)
    {
        var xml = $"""
            <TransferTransaction>
             <FromIBAN>{transferTransaction.FromIBAN}</FromIBAN>
            <ToIBAN>{transferTransaction.ToIBAN}</ToIBAN>
            <Amount>{transferTransaction.Amount:C2}</Amount>
            """;
        Console.WriteLine($"{GetType().Name} worked");

        return true;
    }
}

class TransferTransaction
{
    public string FromIBAN { get; set; }
    public string ToIBAN { get; set; }
    public decimal Amount { get; set; }

}

