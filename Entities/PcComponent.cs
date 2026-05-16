namespace apbd_cw7_EntityFramework.Entities;

public class PcComponent
{
    public int PcId { get; set; }
    public string ComponentCode { get; set; } = null!;
    public int Amount { get; set; }

    public virtual Pc Pc { get; set; } = null!;
    public virtual Component Component { get; set; } = null!;
}
