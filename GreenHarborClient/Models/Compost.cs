using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GreenHarborClient.Models
{
  public class Compost
  {
    public int CompostId { get; set; }
    // [Required]
    public string Zip { get; set; }
    public string City { get; set; }
    public string Location { get; set; }
    // [Required]
    public string ContactName { get; set; }
    [DataType(DataType.PhoneNumber)]
    public string ContactPhone { get; set; }
    [DataType(DataType.EmailAddress)]
    public string ContactEmail { get; set; }
    public string Contents { get; set; }

    public static List<Compost> GetComposts()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Compost> composts = JsonConvert.DeserializeObject<List<Compost>>(jsonResponse.ToString());

      return composts;
    }

    public static List<Compost> GetCompostsByZip(string zip)
    {
      var apiCallTask = ApiHelper.GetByZip(zip);
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Compost> composts = JsonConvert.DeserializeObject<List<Compost>>(jsonResponse.ToString());
      return composts;
    }
    
    public static List<Compost> GetCompostsByCity(string city)
    {
      var apiCallTask = ApiHelper.GetByCity(city);
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Compost> composts = JsonConvert.DeserializeObject<List<Compost>>(jsonResponse.ToString());
      return composts;
    }

    public static List<Compost> GetCompostsByContents(string contents)
    {
      var apiCallTask = ApiHelper.GetByContents(contents);
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Compost> composts = JsonConvert.DeserializeObject<List<Compost>>(jsonResponse.ToString());
      return composts;
    }

    public static Compost GetDetails(int id)
    {
      Task<string> apiCallTask = ApiHelper.Get(id);
      string result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Compost compost = JsonConvert.DeserializeObject<Compost>(jsonResponse.ToString());

      return compost;
    }

    public static void Post(Compost compost)
    {
      string jsonCompost = JsonConvert.SerializeObject(compost);
      ApiHelper.Post(jsonCompost);
    }

    public static void Put(Compost compost)
    {
      string jsonCompost = JsonConvert.SerializeObject(compost);
      ApiHelper.Put(compost.CompostId, jsonCompost);
    }

    public static void Delete(int id)
    {
      ApiHelper.Delete(id);
    }
  }
}