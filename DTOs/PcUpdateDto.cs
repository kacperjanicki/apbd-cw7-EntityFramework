using System.ComponentModel.DataAnnotations;

namespace apbd_cw7_EntityFramework.DTOs;

public class PcUpdateDto
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    [Required]
    public float Weight { get; set; }

    [Required]
    public int Warranty { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    public int Stock { get; set; }
}
