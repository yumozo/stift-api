using System.ComponentModel.DataAnnotations;

namespace StiftApi.Models
{
  public class Record : IRecord
  {
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string? Title { get; set; }
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public string? Text { get; set; } // Replace with HTML?

    // [Required]
    // [StringLength(50, MinimumLength = 3)]
    // public string Author { get; set; } 
  }
}