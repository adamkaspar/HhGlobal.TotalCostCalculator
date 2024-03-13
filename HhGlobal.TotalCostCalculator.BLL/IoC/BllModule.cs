using Autofac;

namespace HhGlobal.TotalCostCalculator.BLL.IoC;

public class BllModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);

        builder
            .RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly())
            .AsImplementedInterfaces();
    }
}
