using WebanwendungHelferleinAufgabe.Entity;
using WebanwendungHelferleinAufgabe.Repository;

namespace WebanwendungHelferleinAufgabe.Programm;

public class TestClass : ITestClass
{
    private readonly IBaseRepository<Member> _baseRepository;

    public TestClass(IBaseRepository<Member> baseRepository)
    {
        this._baseRepository = baseRepository;
    }

    public void Test()
    {
        var loadSelect = _baseRepository.LoadSelect();
        this._baseRepository.Count();
    }
}