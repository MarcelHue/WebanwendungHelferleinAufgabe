using ServiceStack.DataAnnotations;

namespace WebanwendungHelferleinAufgabe.Entity;

[Alias("Equipment")]
public class Equipment
{
    [Alias("EquipmentID")]
    public int EquipmentId { get; set; }
    
    [Alias("EquipmentType")]
    public string EquipmentType { get; set; }
    
    [Alias("Price")]
    public decimal Price { get; set; }
}