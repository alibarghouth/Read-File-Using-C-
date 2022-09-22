
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
            //Remove Contr Conain The Comma 
            reader.removeTheCountryContianCommaWaysTow(countries);
            Console.WriteLine("Enter The Count Of Countries You Need Display");
            bool inputIsInteger = int.TryParse(Console.ReadLine(), out int userInput); 
            if(!inputIsInteger || userInput <= 0)
            {
                Console.WriteLine("Error");
                return;
            }
            // int maxToDisplay = Math.Min(userInput,countries.Count());
            int maxToDisplay = userInput;
            for (int i=0;i<countries.Count;i++)
            {
                if(i>0 && i%maxToDisplay == 0)
                {
                    Console.Write("You Need To Display More");
                    if (Console.ReadLine() != "")
                    {
                        break;
                    }
                }
                Console.WriteLine($"{i+1} : {countries[i].Name} : {countries[i].population}");
            }
            Console.WriteLine("you Need To Display The Countries BackWords If Yes Input The Number If No Click Enter");
            //display Back Words
            bool v = int.TryParse(Console.ReadLine(), out int usersInput);
            if (!v || usersInput <= 0)
            {
                Console.WriteLine("Error");
                return;
            }
            int MaxYouNeedToDisplay = usersInput;

            for(int i = countries.Count-1; i >= 0; i--)
            {
                int userDisplays = countries.Count - 1 - i;
                if(userDisplays>0 && userDisplays%MaxYouNeedToDisplay == 0)
                {
                    Console.WriteLine("You Need To Display More");
                    if (Console.ReadLine() != "")
                    {
                        break;
                    }
                }
                Console.WriteLine($"{userDisplays + 1}  :  {countries[i].Name}  :  {countries[i].population}");
            }
    }
} }