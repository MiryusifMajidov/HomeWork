using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexer
{
    public class StringList
    {
        string[] cities;
        string Output;
        public StringList(string[] inputCities)
        {
            cities = inputCities;
        }
        public string this[string cityName]
        {

            
            get
            {
                cityName = cityName.ToLower();
               
                for (int i = 0; i < cities.Length; i++)
                {
                    if (cities[i].ToLower() == cityName)
                    {
                        Output = cities[i] + "Seheri tapildi ve indexsi ;"+i;
                        return Output;
                    }
                }
               
                return "axtardiginiz seher tapilmadi";
            }
        }
    }

}
