using Autofac;
using WebanwendungHelferleinAufgabe.AutoFac;
using WebanwendungHelferleinAufgabe.Entity;
using WebanwendungHelferleinAufgabe.Programm;
using WebanwendungHelferleinAufgabe.Repository;

namespace WebanwendungHelferleinAufgabe;

static class MainClass
{
    [STAThread]
    static void Main()
    {
        //Init Container For Dependency Injections
        ApplicationConfiguration.Initialize();
        var container = Container.Configure();

        var testClass = container.Resolve <ITestClass>();
        
        testClass.Test();

        //Start Main Window
        Application.Run(container.Resolve<MainWindow>());
        
        
    }
}