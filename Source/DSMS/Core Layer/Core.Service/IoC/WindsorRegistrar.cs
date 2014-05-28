﻿using System;
using Castle.MicroKernel.Registration;

namespace Core.Service.IoC
{
    public class WindsorRegistrar
    {
        public static void RegisterSingleton(Type interfaceType, Type implementationType)
        {
            IoC.Container.Register(Component.For(interfaceType).ImplementedBy(implementationType).LifeStyle.Singleton);
        }

        public static void Register(Type interfaceType, Type implementationType)
        {
            IoC.Container.Register(
                Component.For(interfaceType).ImplementedBy(implementationType).LifeStyle.PerWebRequest);
        }

        public static void RegisterSpecialType(Type interfaceType, Type implementationType, string name, string keyName,
            string keyValue)
        {
            IoC.Container.Register(
                Component.For(interfaceType)
                    .ImplementedBy(implementationType)
                    .LifeStyle.PerWebRequest
                    .Named(name)
                    .DependsOn(
                        Parameter.ForKey(keyName).Eq(keyValue))
                );
        }


        public static void RegisterAllFromAssemblies(string a)
        {
            IoC.Container.Register(
                Classes.FromAssemblyNamed(a)
                    .Pick()
                    .WithService.AllInterfaces()
                    .Configure(o => o.LifestylePerWebRequest()));
        }
    }
}