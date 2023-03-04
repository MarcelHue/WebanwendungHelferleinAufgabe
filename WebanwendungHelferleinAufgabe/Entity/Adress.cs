using ServiceStack.DataAnnotations;

namespace WHA.Entity;

[Alias("Address")]
public class Adress : IBaseDbEntity
{
    [Alias("AddressID")]
    public long Id { get; set; }
    
    [Alias("PLZ")]
    public string Plz { get; set; }
    
    [Alias("City")]
    public string City { get; set; }
    
    [Alias("Street")]
    public string Street { get; set; }
    
    [Alias("StreetNumber")]
    public string StreetNumber { get; set; }
    
    [Alias("Country")]
    public string Country { get; set; }
}