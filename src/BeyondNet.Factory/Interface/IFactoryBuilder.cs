﻿namespace BeyondNet.Factory.Interfaces
{
    public interface IFactoryBuilder
    {
        IFactoryBuilder AddSingleton<TService, TImplementation>() 
            where TService : class
            where TImplementation : class, TService;

        IFactoryBuilder AddTransient<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService;

        IFactoryBuilder AddSource<TImplementation>()
            where TImplementation : class, IFactorySetupSource;
    }
}