using System.ComponentModel.DataAnnotations;

namespace StiftApi.Models;

public class User : IUser
{
  [Key]
  [Required]
  public int Id { get; set; }

  [Required]
  [StringLength(25)]
  public string? Name { get; set; }

  [Required]
  [EmailAddress]
  [StringLength(50)]
  public string? Email { get; set; }
  
  [Required]
  public string? Password { get; set; }
  
  public List<Record>? Records { get; set; }
}