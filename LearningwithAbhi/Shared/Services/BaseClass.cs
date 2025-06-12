
using System.Text.Json;
using System.Threading.Tasks;

namespace LearningwithAbhi.Shared.Services
{

    public class BaseClass
    {
        // Base class implementation



        public static List<T> GetJsonObject<T>(string path)
        {
            // Read the JSON file
            string json = File.ReadAllText(path);
            List<T> list;

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            try
            {
                // Deserialize the JSON into a list of objects
                list = JsonSerializer.Deserialize<List<T>>(json, options);
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                list = new List<T>();
                return list;
            } 
            
        }
        

    }

}