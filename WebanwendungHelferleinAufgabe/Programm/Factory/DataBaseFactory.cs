using System.Data;
using Bogus;
using ServiceStack.OrmLite;
using WHA.Entity;
using WHA.Extensions;

namespace WHA.Programm.Factory;

public class IdbFactory : IDBFactory
{
    private readonly IDbConnection dbConnection;

    public IdbFactory(IDbConnection dbConnection)
    {
        this.dbConnection = dbConnection;
    }

    public void InitDB()
    {
        this.CleanRepository();
        this.FillRepoWithMoqData(150);
    }

    private void CleanRepository()
    {
        this.dbConnection.DeleteAll<Member>();
        this.dbConnection.DeleteAll<Adress>();
        this.dbConnection.DeleteAll<MemberService>();
        this.dbConnection.DeleteAll<Service>();
        this.dbConnection.DeleteAll<Equipment>();
        this.dbConnection.DeleteAll<Performance>();
    }

    private void FillRepoWithMoqData(int ammount)
    {
        ammount.Times(() => this.dbConnection.Insert(GenAddress()));
        ammount.Times(() => this.dbConnection.Insert(this.GenMember()));
        ammount.Times(() => this.dbConnection.Insert(GenEquipment()));
        ammount.Times(() => this.dbConnection.Insert(GenPerformance()));
        ammount.Times(() => this.dbConnection.Insert(this.GenService()));
        ammount.Times(() => this.dbConnection.Insert(this.GenMemberService()));
    }

    private static Adress GenAddress()
    {
        var faker = new Faker("de");
        return new Adress
        {
            Plz = faker.Address.ZipCode(),
            City = faker.Address.City(),
            Street = faker.Address.StreetName(),
            StreetNumber = faker.Random.Int(0,1337).ToString(),
            Country = faker.Address.Country(),
        };
    }

    private static Equipment GenEquipment()
    {
        var faker = new Faker("de");
        return new Equipment
        {
            EquipmentType = faker.Commerce.Product(),
            Price = faker.Finance.Amount(),
        };
    }
    
    private Member GenMember()
    {
        var faker = new Faker("de");
        var adress = this.dbConnection.LoadSelect<Adress>().GetRandom();
        
        return new Member
        {
            AddressId = adress.Id,
            LastName = faker.Name.LastName(),
            FirstName = faker.Name.FirstName(),
            Tel = faker.Phone.PhoneNumber(),
            EMail = faker.Internet.Email(),
            TotalRevenue = faker.Finance.Amount(),
            TotalExpenses = faker.Finance.Amount(),
        };
    }
    
    private MemberService GenMemberService()
    {
        var ServiceGiver = this.dbConnection.LoadSelect<Member>().GetRandom();
        var ServiceUser = this.dbConnection.LoadSelect<Member>().GetRandom();
        var service = this.dbConnection.LoadSelect<Service>().GetRandom();
        return new MemberService
        {
            ServiceGiverId = ServiceGiver.Id,
            ServiceUserId = ServiceUser.Id,
            ServiceId = service.Id,
        };
    }
    
    private static Performance GenPerformance()
    {
        var faker = new Faker("de");
        return new Performance
        {
            Type = faker.Commerce.ProductDescription(),
            Price = faker.Finance.Amount(),
        };
    }
    
    private Service GenService()
    {
        var faker = new Faker("de");
        var Equipment = this.dbConnection.LoadSelect<Equipment>().GetRandom();
        var Performance = this.dbConnection.LoadSelect<Performance>().GetRandom();

        return new Service
        {
            EquipmentId = Equipment.Id,
            Equipment = Equipment,
            PerformanceId = Performance.Id,
            Performance = Performance,
            StartDate = faker.Date.Past(),
            EndDate = faker.Date.Soon(),
        };
    }


}