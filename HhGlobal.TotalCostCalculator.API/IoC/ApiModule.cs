﻿using Autofac;

namespace HhGlobal.TotalCostCalculator.API.IoC;

public class ApiModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var assembly = System.Reflection.Assembly.GetExecutingAssembly();

        builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces();
    }
}
