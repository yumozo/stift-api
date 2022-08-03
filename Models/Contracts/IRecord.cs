namespace StiftApi.Models;

public interface IRecord
{
  public int Id { get; set; }
  public string? Title { get; set; }
  public DateTime Date { get; set; }
  public string? Text { get; set; }
}