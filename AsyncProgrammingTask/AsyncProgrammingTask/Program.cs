using System.Diagnostics;

namespace AsyncProgrammingTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();
            List<string> urls = new List<string>
            {
                "https://www.instagram.com/_majidov12/",
                "https://www.instagram.com/",
                "https://github.com/"
            };

            AsyncMethod(urls);
            long firstData = sw.ElapsedMilliseconds;
            sw.Restart();
            Console.WriteLine("=======================================================================");

            NonAsyncMethod(urls).Wait();
            Console.WriteLine(sw.ElapsedMilliseconds);
            Console.WriteLine(firstData);


        }

        public static async Task NonAsyncMethod(List<string> urls)
        {
            HttpClient client = new HttpClient();

            List<Task<string>> tasks = new List<Task<string>>();

            foreach (var item in urls)
            {
                tasks.Add(client.GetStringAsync(item));
            }

            await Task.WhenAll(tasks);
        }



        public static async void AsyncMethod(List<string> urls) 
        { 
            HttpClient client = new HttpClient();
            foreach (var item in urls)
            {
                client.GetStringAsync(item).Result.ToString();
            }
        }
    }
}
