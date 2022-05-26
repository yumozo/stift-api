using StiftApi.Models;
using System.ComponentModel.DataAnnotations;

namespace StiftApi.Dtos;

public class RecordCreateDto
{
  [Required]
  public string? Title { get; set; }

  public string? Text { get; set; } // Replace with HTML file?
}