using ServiceStack.DataAnnotations;

namespace WebanwendungHelferleinAufgabe.Entity;

[Alias("Address")]
public class Adress
{
    [Alias("AddressID")]
    public int AddressId { get; set; }
    
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