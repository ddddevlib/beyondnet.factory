﻿using BeyondNet.Factory.Impl;
using BeyondNet.Factory.Installer.Impl;
using BeyondNet.Factory.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BeyondNet.Factory.Installer.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFactory(this IServiceCollection servicecollection, Action<IFactoryBuilder> action = null)
        {
            servicecollection.AddServiceLocator();

            servicecollection.TryAddSingleton<IFactory, Factory.Impl.Factory>();

            servicecollection.TryAddSingleton<IFactoryCreator, FactoryCreator>();

            servicecollection.TryAddSingleton<IFactorySetupProvider, FactorySetupProvider>();

            if (action != null)
            {
                action(new FactoryBuilder(servicecollection));
            }

            return servicecollection;
        }

        public static IServiceCollection AddServiceLocator(this IServiceCollection servicecollection)
        {
            servicecollection.TryAddSingleton<Factory.Impl.ServiceLocator>();

            servicecollection.TryAddSingleton<IServiceLocator>(x => x.GetRequiredService<Factory.Impl.ServiceLocator>());

            servicecollection.TryAddSingleton<IScopedServiceLocator>(x => x.GetRequiredService<Impl.ServiceLocator>());

            return servicecollection;
        }
    }
}
