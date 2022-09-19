
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
            Country ali = new Country("africa" , "af","g", 523454);
            int populaton = countries.FindIndex(x => x.population < 523454);  
            //لعمل insert لدولة بشرط ان تكون مرتبة مع البيانات
           
            countries.Insert(populaton,ali);
            foreach (Country country in countries)
            {
                Console.WriteLine($"{country.Name} : {country.population}");
            }
    }
} }