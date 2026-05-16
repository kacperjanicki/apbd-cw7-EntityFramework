namespace apbd_cw7_EntityFramework.Entities;

public class Component
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    public int ComponentManufacturerId { get; set; }
    public int ComponentTypeId { get; set; }

    public virtual ComponentManufacturer Manufacturer { get; set; } = null!;
    public virtual ComponentType ComponentType { get; set; } = null!;
    public virtual ICollection<PcComponent> PcComponents { get; set; } = new List<PcComponent>();
}
