
using Countries_Demo_App;
using System.Security.Cryptography;

namespace CountriesDemoApp{
class Program
{
    static void Main(string[] args)
    {
           
            String File = "C:\\Users\\user\\source\\repos\\Countries Demo App\\Country.Csv ";
            CsvReader reader = new CsvReader(File);
            List<Country> countries = reader.ReadFirstNCountry();

            foreach (Country country in countries)
            {
                Console.WriteLine($"{country.Name} : {country.population}");
            }
    }
} }