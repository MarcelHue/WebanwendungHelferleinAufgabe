using ServiceStack.DataAnnotations;

namespace WebanwendungHelferleinAufgabe.Entity;

[Alias("Conversions")]
public class Conversions
{
    [Alias("ConversionsID")]
    public int ConversionId { get; set; }

    [Alias("MembersID")] 
    public int MembersId { get; set; }

    [Alias("TotalRevenue")]
    public decimal TotalRevenue { get; set; }
    
    [Alias("TotalExpenses")]
    public decimal TotalExpenses { get; set; }
    
    [Alias("Sum")]
    public decimal Sum { get; set; }
}