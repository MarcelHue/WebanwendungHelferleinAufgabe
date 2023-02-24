using ServiceStack.DataAnnotations;

namespace WHA.Entity;

[Alias("Equipment")]
public class Equipment : IBaseDbEntity
{
    [Alias("EquipmentID")]
    public long Id { get; set; }
    
    [Alias("EquipmentType")]
    public string EquipmentType { get; set; }
    
    [Alias("Price")]
    public decimal Price { get; set; }
}