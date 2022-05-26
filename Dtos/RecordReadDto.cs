namespace StiftApi.Dtos;

public class RecordReadDto
{
  public int Id { get; set; }
  public string? Title { get; set; }
  public DateTime Date { get; set; }
  public string? Text { get; set; } // Replace with HTML file?
}