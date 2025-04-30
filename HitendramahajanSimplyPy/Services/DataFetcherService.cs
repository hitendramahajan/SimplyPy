using RestSharp; 
using System; 
using System.Threading.Tasks; 
namespace HitendramahajanSimplyPy.Services 
{ 
    public class DataFetcherService 
    { 
        public async Task<string> FetchDataFromUrlAsync(string url) 
        { 
            try 
            { 
                Console.WriteLine($"Starting data fetch from URL: {url}"); 
                var client = new RestClient(url); 
                var request = new RestRequest(Method.GET); 
                var response = await client.ExecuteAsync(request); 
                if (!response.IsSuccessful) 
                { 
                    Console.WriteLine($"Failed to fetch data. Status Code: {response.StatusCode}, Error: {response.ErrorMessage}"); 
                    return null; 
                } 
                Console.WriteLine("Data fetch successful."); 
                return response.Content; 
            } 
            catch (Exception ex) 
            { 
                Console.WriteLine($"An error occurred while fetching data: {ex.Message}"); 
                Console.WriteLine(ex.StackTrace); 
                return null; 
            } 
        } 
    } 
} 