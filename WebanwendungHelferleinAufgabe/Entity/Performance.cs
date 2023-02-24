using ServiceStack.DataAnnotations;

namespace WHA.Entity;

[Alias("PerformanceType")]
public class Performance : IBaseDbEntity
{
    [Alias("PerformanceTypeID")]
    public long Id { get; set; }
    
    [Alias("PerformanceType")]
    public string Type { get; set; }
    
    [Alias("Price")]
    public decimal Price { get; set; }
}