using ServiceStack.DataAnnotations;

namespace WebanwendungHelferleinAufgabe.Entity;

[Alias("PerformanceType")]
public class Performance
{
    [Alias("PerformanceTypeID")]
    public int PerformanceId { get; set; }
    
    [Alias("PerformanceType")]
    public string Type { get; set; }
    
    [Alias("Price")]
    public decimal Price { get; set; }
}