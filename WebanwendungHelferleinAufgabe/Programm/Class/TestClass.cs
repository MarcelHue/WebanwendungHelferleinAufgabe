using WHA.Entity;
using WHA.Programm.Factory;
using WHA.Programm.Interface;
using WHA.Repository;

namespace WHA.Programm.Class;

public class TestClass : ITestClass
{

    private readonly IDBFactory dbFactory;

    public TestClass(IDBFactory dbFactory)
    {
        this.dbFactory = dbFactory;
    }
    public void Test()
    {
        this.dbFactory.InitDB();
    }
}