using Autofac;
using WHA.AutoFac;
using WHA.Programm.Interface;

namespace WHA;

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