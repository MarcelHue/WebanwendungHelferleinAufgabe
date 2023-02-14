using ServiceStack.DataAnnotations;

namespace WebanwendungHelferleinAufgabe.Entity;

[Alias("Member")]
public class Member
{

    [Alias("MemberID")]        
    public int MemberId { get; set; }
    
    [Alias("AddressID")]        
    [References(typeof(Adress))]
    public int AddressId { get; set; }

    [Reference]
    public Adress Adress { get; set; }
    
    [Alias("SalesID")]   
    [References(typeof(Conversions))]
    public int SalesId { get; set; }
    
    [Reference] 
    public Conversions Conversions { get; set; }
    
    [Alias("LastName")]        
    public string LastName { get; set; }
    
    [Alias("FirstName")]        
    public string FirstName { get; set; }
    
    [Alias("TelephoneNumber")]        
    public string Tel { get; set; }
    
    [Alias("EmailAddress")]        
    public string EMail { get; set; }
    
}