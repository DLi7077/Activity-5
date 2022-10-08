using System;
using System.Net.Http.Json;
using System.Text.Json;

namespace KatsudonLeetcode;
public class Program
{

  private static readonly HttpClient client = new HttpClient();

  public static async Task getProblems()
  {
    string baseURL = "https://katsudon-server-v2.herokuapp.com/api/problem/";

    Console.WriteLine(baseURL);

    List<int> problemIDs = new List<int>() { 1, 42, 112, 322, 1029 };
    List<Problem?> problems = new List<Problem?>();

    foreach (var problemID in problemIDs)
    {
      var response = await client.GetAsync($"{baseURL}{problemID}");
      var result = await response.Content.ReadAsStringAsync();
      problems.Add(JsonSerializer.Deserialize<KatsudonProblemResponse>(result)!.Problem);
    }

    problems.ForEach(problem =>
    {
      Console.WriteLine(problem);
    });

  }
  public static async Task Main(string[] args)
  {
    await getProblems();
  }
}