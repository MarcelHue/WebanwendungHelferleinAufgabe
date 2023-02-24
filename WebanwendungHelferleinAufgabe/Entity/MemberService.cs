using ServiceStack.DataAnnotations;

namespace WHA.Entity;

[Alias("MemberService")]
public class MemberService : IBaseDbEntity
{
    [Alias("MemberServiceID")]
    public long Id { get; set; }
    
    [Alias("ServiceGiverID")]    
    [References(typeof(Member))]
    public long ServiceGiverId { get; set; }
    
    [Reference]
    public Member ServiceGiver { get; set; }
    
    [Alias("ServiceUserID")]    
    [References(typeof(Member))]
    public long ServiceUserId { get; set; }

    [Reference]
    public Member ServiceUser { get; set; }
    
    [Alias("ServiceID")]    
    [References(typeof(Service))]
    public long ServiceId { get; set; }
    
    [Reference] 
    public Service Service { get; set; }
}