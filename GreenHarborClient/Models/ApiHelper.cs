using System.Threading.Tasks;
using RestSharp;

namespace GreenHarborClient.Models
{
  public class ApiHelper
  {
    public static async Task<string> GetAll()
    {
      RestClient client = new RestClient("https://localhost:7000/");
      RestRequest request = new RestRequest($"api/composts", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

    public static async Task<string> Get(int id)
    {
      RestClient client = new RestClient("https://localhost:7000/");
      // may need to change
      RestRequest request = new RestRequest($"api/composts/{id}", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

    public static async Task<string> GetByZip(string zip)
    {
      RestClient client = new RestClient("https://localhost:7000/");
      RestRequest request = new RestRequest($"api/composts?zip={zip}", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

    public static async Task<string> GetByCity(string city)
    {
      RestClient client = new RestClient("https://localhost:7000/");
      RestRequest request = new RestRequest($"api/composts?zip={city}", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

    public static async Task<string> GetByContents(string contents)
    {
      RestClient client = new RestClient("https://localhost:7000/");
      RestRequest request = new RestRequest($"api/composts?contents={contents}", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

    public static async void Post(string newCompost)
    {
      RestClient client = new RestClient("https://localhost:7000/");
      // may need to change
      RestRequest request = new RestRequest($"api/composts", Method.Post);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newCompost);
      await client.PostAsync(request);
    }

    public static async void Put(int id, string newCompost)
    {
      RestClient client = new RestClient("https://localhost:7000/");
      // may need to change
      RestRequest request = new RestRequest($"api/composts/{id}", Method.Put);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newCompost);
      await client.PutAsync(request);
    }

    public static async void Delete(int id)
    {
      RestClient client = new RestClient("https://localhost:7000/");
      RestRequest request = new RestRequest($"api/composts/{id}", Method.Delete);
      request.AddHeader("Content-Type", "application/json");
      await client.DeleteAsync(request);
    }
  }
}