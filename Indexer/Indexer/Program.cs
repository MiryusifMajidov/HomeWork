namespace Indexer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] cities = { "Baki", "Ganja", "Sumqayit", "Shaki" };

            
            StringList stringList = new StringList(cities);

            string index = stringList["BAKİüüü"];
            Console.WriteLine(index);
        }
    }
}
