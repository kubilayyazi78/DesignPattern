// See https://aka.ms/new-console-template for more information
using SingletonPattern;

Console.WriteLine("Hello, World!");

//var countryProvider = new CountryProvider();

var countries = await CountryProvider.Instance.GetCountries();

foreach (var country in countries)
{
    Console.WriteLine(country.Name);
}

await CountryProvider.Instance.GetCountries();

var x =  CountryProvider.Instance.CountryCount();