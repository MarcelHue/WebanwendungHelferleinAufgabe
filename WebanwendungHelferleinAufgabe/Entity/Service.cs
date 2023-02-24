using ServiceStack.DataAnnotations;

namespace WHA.Entity;

[Alias("Service")]
public class Service : IBaseDbEntity
{
    [Alias("ServiceID")]
    public long Id { get; set; }
    
    [Alias("EquipmentID")]
    [References(typeof(Equipment))]
    public long EquipmentId { get; set; }

    [Reference]
    public Equipment Equipment { get; set; }
    
    [Alias("PerformanceTypeID")]
    [References(typeof(Performance))]
    public long PerformanceId { get; set; }

    [Reference]
    public Performance Performance { get; set; }
    
    [Alias("ServiceStart")]
    public DateTime StartDate { get; set; }
    
    [Alias("ServiceEnd")]
    public DateTime EndDate { get; set; }
    
    [Ignore]
    public TimeSpan Duration => this.EndDate - this.StartDate;
}