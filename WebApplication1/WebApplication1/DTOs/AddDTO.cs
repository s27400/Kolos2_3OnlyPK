using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs;

public class AddDTO
{
    [Required]
    [MaxLength(30)]
    public string Imie { get; set; }
    [Required]
    [MaxLength(40)]
    public string Nazwisko { get; set; }
    [MaxLength(50)]
    public string? Pseudonim { get; set; }
    [Required]
    [MaxLength(30)]
    public string NazwaUtworu { get; set; }
    [Required]
    public float CzasTrwania { get; set; }
}