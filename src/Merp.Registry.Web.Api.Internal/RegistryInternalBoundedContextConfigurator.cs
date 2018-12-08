﻿using MementoFX.Persistence;
using Merp.Registry.CommandStack.Events;
using Merp.Registry.CommandStack.Sagas;
using Merp.Registry.CommandStack.Services;
using Merp.Registry.QueryStack.Denormalizers;
using Merp.Registry.Web.Api.Internal.WorkerServices;
using Merp.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rebus.ServiceProvider;

namespace Merp.Registry.Web.Api.Internal
{
    public class RegistryInternalBoundedContextConfigurator : BoundedContextConfigurator
    {
        public RegistryInternalBoundedContextConfigurator(IConfiguration configuration, IServiceCollection services) : base(configuration, services)
        {

        }

        protected override void ConfigureEventStore()
        {
            var mongoDbConnectionString = Configuration.GetConnectionString("Merp-Registry-EventStore");
            var mongoDbDatabaseName = MongoDB.Driver.MongoUrl.Create(mongoDbConnectionString).DatabaseName;
            var mongoClient = new MongoDB.Driver.MongoClient(mongoDbConnectionString);
            Services.AddSingleton(mongoClient.GetDatabase(mongoDbDatabaseName));
            Services.AddTransient<IEventStore, MementoFX.Persistence.MongoDB.MongoDbEventStore>();
            Services.AddTransient<IRepository, MementoFX.Persistence.Repository>();
        }

        protected override void RegisterAclServices()
        {
            //Acl Services
            Services.AddScoped<Acl.RegistryResolutionServices.Resolver>();
        }

        protected override void RegisterDenormalizers()
        {
            //Denormalizers
            Services.AutoRegisterHandlersFromAssemblyOf<CompanyDenormalizer>();
        }

        protected override void RegisterHandlers()
        {
            //Handlers
        }

        protected override void RegisterSagas()
        {
            //Sagas
            Services.AutoRegisterHandlersFromAssemblyOf<CompanySaga>();
        }

        protected override void RegisterServices()
        {
            //Services
            Services.AddScoped<IDefaultCountryResolver, DefaultCountryResolver>();
        }

        protected override void RegisterTypes()
        {
            //Types
            var readModelConnectionString = Configuration.GetConnectionString("Merp-Registry-ReadModel");
            Services.AddDbContext<Merp.Registry.QueryStack.RegistryDbContext>(options => options.UseSqlServer(readModelConnectionString));
            Services.AddScoped<Merp.Registry.QueryStack.IDatabase, Merp.Registry.QueryStack.Database>();
        }

        protected override void RegisterWorkerServices()
        {
            //Worker Services
            Services.AddScoped<CountriesControllerWorkerServices>();
            Services.AddScoped<PartyControllerWorkerServices>();
            Services.AddScoped<PersonControllerWorkerServices>();
            Services.AddScoped<CompanyControllerWorkerServices>();
        }

        protected override void SubscribeEvents()
        {
            //Events
            Bus.Subscribe<CompanyRegisteredEvent>();
            Bus.Subscribe<PersonRegisteredEvent>();
        }
    }
}
