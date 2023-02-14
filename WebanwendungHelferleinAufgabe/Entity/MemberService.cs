using ServiceStack.DataAnnotations;

namespace WebanwendungHelferleinAufgabe.Entity;

[Alias("MemberService")]
public class MemberService
{
    [Alias("MemberSericeID")]
    public int MemberSericeId { get; set; }
    
    [Alias("ServiceGiverID")]    
    [References(typeof(Member))]
    public int ServiceGiverId { get; set; }
    
    [Reference]
    public Member ServiceGiver { get; set; }
    
    [Alias("ServiceUserID")]    
    [References(typeof(Member))]
    public int ServiceUserId { get; set; }

    [Reference]
    public Member ServiceUser { get; set; }
    
    [Alias("LastName")]    
    [References(typeof(Service))]
    public int ServiceId { get; set; }
    
    [Reference] 
    public Service Service { get; set; }
}