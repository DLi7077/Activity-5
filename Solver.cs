using System.Text.Json.Serialization;

namespace KatsudonLeetcode
{
  public class Problem
  {
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("difficulty")]
    public Difficulty Difficulty { get; set; }

    public override string ToString()
    {
      return $"{Id}. {Title}:\n {Difficulty}\n {Description?.Substring(0, 100)}...\n";
    }
  }

  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum Difficulty
  {
    Easy, Medium, Hard
  }

  public class KatsudonProblemResponse
  {
    [JsonPropertyName("problem")]
    public Problem? Problem { get; set; }
  }
}