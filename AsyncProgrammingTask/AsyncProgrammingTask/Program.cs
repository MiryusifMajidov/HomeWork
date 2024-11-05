using System.Diagnostics;
using System.IO;
using AsyncProgrammingTask.Models;
using Newtonsoft.Json;


namespace AsyncProgrammingTask
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            
            string path = @"C:\Users\User\source\repos\AsyncProgrammingTask\AsyncProgrammingTask";

            //Directory.CreateDirectory(path + @"\Models");
            //Directory.CreateDirectory(path + @"\Data");

            //if (!File.Exists(path + @"\Data\jsonData.json"))
            //{
            //    File.Create(path + @"\Data\jsonData.json");
            //}


            
            string url = "https://jsonplaceholder.typicode.com/posts";
            string pathPostFile = @"C:\Users\User\source\repos\AsyncProgrammingTask\AsyncProgrammingTask\Data\jsonData.json";

            await PostData<Post>(url, pathPostFile);

            
           


        }

        public static async Task PostData<T>(string url, string path)
        {
            using HttpClient client = new HttpClient();


            string response = await client.GetStringAsync(url);


            T[] posts = JsonConvert.DeserializeObject<T[]>(response);

            string serializade = JsonConvert.SerializeObject(posts);

            using (StreamWriter sw = new StreamWriter(path))
            {
               
                sw.WriteLine(serializade);
                
            }
            
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
