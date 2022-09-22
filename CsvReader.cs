using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Countries_Demo_App
{
    public class CsvReader 
    {
        private String _CsvFilePath;
        public CsvReader(String _CsvFilePath)
        {
            this._CsvFilePath = _CsvFilePath;
        }
        public List<Country> ReadFirstNCountry()
        {
            List<Country> result = new List<Country>();

            using ( StreamReader sr = new StreamReader(this._CsvFilePath))
            {
                //لقراءة او سطر ما بدنا اياه

                String line;
                sr.ReadLine();
                while ((line = sr.ReadLine()) != null)
                {
                    result.Add(ReadCountryFromCsvLine(line));
                }

            }

            return result;
        }
        public void removeTheCountryContianComma(List<Country> country)
        {
            for(int i = country.Count-1; i >=0; i--)
            {
                if (country[i].Name.Contains(',')){
                    country.RemoveAt(i);
                }
            }
        }
        public void removeTheCountryContianCommaWaysTow(List<Country> country)
        {
            country.RemoveAll(x => x.Name.Contains(','));
        }
        public Country ReadCountryFromCsvLine(String line)
        {
            //تقسيم كل سطر الي عدة متغيرات عن طريق السبلت
            String[] countres = line.Split(',');
            String name;
            String pop;
            String code;
            String Region;
            switch (countres.Length)
            {
                case 4:
                    pop = countres[0];
                    Region =countres[1];
                    code = countres[2]; 
                    name = countres[3];
                    break;  

                case 5:
                    pop = countres[0];
                    Region = countres[1];
                    code = countres[2];
                    name = countres[3] +","+countres[4];
                    //ازالة الدبل كوتيشن
                    name = name.Replace("\"", null).Trim();
                    break;

                 default:
                    throw new Exception($"Error {line}");
            }
            //اذا لم يحصل التحويل يضع القيمة صفر
            int.TryParse(pop, out int population);
            return new Country(name, code, Region, population);
        }

    }
}
