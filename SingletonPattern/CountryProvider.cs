using SingletonPattern.Models;

namespace SingletonPattern
{
    public class CountryProvider
    {
        private static CountryProvider instance = null;
        public static CountryProvider Instance => instance ?? (instance = new CountryProvider());
        private new List<Country> Countries { get; set; }
        private CountryProvider()
        {
            Task.Delay(1000).GetAwaiter().GetResult();
            Countries = new List<Country>()
            {
                new Country(){ Name="Türkiye"},
                new Country(){ Name="ABD"}
            };
        }
        public int CountryCount() => Countries.Count;
        public async Task<List<Country>> GetCountries() => Countries;
    }
}
