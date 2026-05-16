namespace apbd_cw7_EntityFramework.DTOs;

public class PcComponentDto
{
    public string ComponentCode { get; set; } = null!;
    public string ComponentName { get; set; } = null!;
    public string? Description { get; set; }
    public int Amount { get; set; }
    public string ManufacturerName { get; set; } = null!;
    public string ComponentTypeName { get; set; } = null!;
}
