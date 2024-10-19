﻿using BeyondNet.Factory.Demo.Bootstrapper;
using BeyondNet.Factory.Demo.Impl;
using BeyondNet.Factory.Demo.Interfaces;
using BeyondNet.Factory.Demo.Models;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using BeyondNet.Factory.Installer.Extensions;
using BeyondNet.Factory.Interfaces;


ServiceProvider? serviceProvider;

var serviceCollection = new ServiceCollection();

var setup = new LogicModelFactoryRecordSetup();

serviceCollection.AddFactory(c =>
{
    c.AddSource<LogicModelFactoryRecordSetup>();
    c.AddSingleton<ILogicModelLoader, LogicModelCATLoader>();
    c.AddSingleton<ILogicModelLoader, LogicModelPADLoader>();
    c.AddSingleton<ILogicModelLoader, LogicModelREVLoader>();
});

serviceProvider = serviceCollection.BuildServiceProvider();

var factory = serviceProvider.GetService<IFactory>();

var strategyBuilder = new StrategyBuilder(factory);

Console.WriteLine("Hello Bro!");

Console.WriteLine("Please, select the personalization type [REV,CAT,PAD]:");

var personalizationTypeSelected = Console.ReadLine();

Enum.TryParse(personalizationTypeSelected, out ePersonalizationType parsedPersonalization);

var strategy = strategyBuilder.Build(new Criteria() { PersonalizationType = parsedPersonalization });

Console.WriteLine($"Strategy Name: {strategy.Name}");
Console.WriteLine($"Strategy Personalization Type: {strategy.PersonalizationType}");
Console.WriteLine($"Strategy Model Logic: {JsonSerializer.Serialize(strategy.ModelLogic)}");

Console.ReadLine();
