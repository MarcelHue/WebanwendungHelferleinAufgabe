using ServiceStack.DataAnnotations;

namespace WebanwendungHelferleinAufgabe.Entity;

[Alias("Service")]
public class Service
{
    [Alias("ServiceID")]
    public int ServiceId { get; set; }
    
    [Alias("EquipmentID")]
    [References(typeof(Equipment))]
    public int EquipmentId { get; set; }

    [Reference]
    public Equipment Equipment { get; set; }
    
    [Alias("PerformanceId")]
    [References(typeof(Performance))]
    public int PerformanceId { get; set; }

    [Reference]
    public Performance Performance { get; set; }
    
    [Alias("ServiceStart")]
    public DateTime Start { get; set; }
    
    [Alias("ServiceEnd")]
    public DateTime End { get; set; }
    
    [Alias("ServiceTime")]
    public DateTime Duration { get; set; }
    
}