using Microsoft.VisualBasic.CompilerServices;
using ServiceStack.DataAnnotations;

namespace WHA.Entity;

[Alias("Member")]
public class Member : IBaseDbEntity
{
    [Alias("MemberID")]        
    public long Id { get; set; }
    
    [Alias("AddressID")]        
    [References(typeof(Adress))]
    public long AddressId { get; set; }

    [Reference]
    public Adress Adress { get; set; }
    
    [Alias("LastName")]        
    public string LastName { get; set; }
    
    [Alias("FirstName")]        
    public string FirstName { get; set; }
    
    [Alias("TelephoneNumber")]        
    public string Tel { get; set; }
    
    [Alias("EmailAddress")]        
    public string EMail { get; set; }
    
    [Alias("TotalRevenue")]
    public decimal TotalRevenue { get; set; }
    
    [Alias("TotalExpenses")]
    public decimal TotalExpenses { get; set; }

    [Ignore]
    public decimal Sum => this.TotalRevenue - this.TotalExpenses;

}