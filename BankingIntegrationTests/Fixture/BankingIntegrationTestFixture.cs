using Freemarket.Test.Utilities.BankingCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using Freemarket.Test.Utilities.Config;
using Ardalis.GuardClauses;
using Freemarket.Test.Utilities.Blob;
using Freemarket.Test.Utilities.ServiceBus;
using BoDi;
using Azure.Messaging.ServiceBus;
using Freemarket.Test.Utilities.Drivers;
using Microsoft.Extensions.Configuration;

namespace BankingIntegrationTests.Fixture
{
    public class BankingIntegrationTestFixture : IAsyncLifetime
    {
        public AcceptanceTestConfig Config;
        public readonly BankingHelpers Banking;
        public readonly BlobStorageUtility BlobStorageUtility;
        public readonly ServiceBusUtility ServiceBusUtility;
        public Driver BrowserDriver;
        private readonly IObjectContainer _container;
        private readonly IConfiguration _config;

        private readonly JsonSerializerOptions _serialiserOptions = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            NumberHandling = JsonNumberHandling.AllowReadingFromString,
            Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) },
        };

        public BankingIntegrationTestFixture()
        {
            Banking = new("TestBankIntergrations");
            Config = BankingConfiguration.GetConfig<AcceptanceTestConfig>();
            _config = ConfigurationSetUp.GetConfig();
            
            Guard.Against.Null(Config, nameof(Config),
                "Config must not be null");
            Guard.Against.Null(Config.AzureServiceBus, nameof(Config.AzureServiceBus),
                "AzureServiceBus must not be null");
            Guard.Against.Null(Config.AzureServiceBus?.ConnectionString, nameof(Config.AzureServiceBus.ConnectionString),
                "AzureServiceBus.ConnectionString must not be null");
            Guard.Against.Null(Config.AzureServiceBus?.ConnectionString, nameof(Config.AzureServiceBus.Prefix),
                "AzureServiceBus.Prefix must not be null");
            Guard.Against.Null(Config.CosmosDB.Endpoint, nameof(Config.CosmosDB.Endpoint),
                "CosmosDB.Endpoint must not be null");
            Guard.Against.Null(Config.CosmosDB.Key, nameof(Config.CosmosDB.Key),
                "CosmosDB.Key must not be null");
            Guard.Against.Null(Config.BlobStorage?.ConnectionString, nameof(Config.BlobStorage.ConnectionString),
                "BlobStorage.ConnectionString must not be null");

            BlobStorageUtility = new BlobStorageUtility(Config.BlobStorage!.ConnectionString);

            ServiceBusUtility = Banking.ServiceBusUtility;
        }

        public async Task InitializeAsync()
        {
            try
            {
                await Banking.EnsureTopicsAndSubscriptions();
            }
            catch (ServiceBusException)
            {
            }
            _container.RegisterInstanceAs(_config);
            BrowserDriver = new Driver(_config);
            _container.RegisterInstanceAs(BrowserDriver);
            
        }

        public async Task DisposeAsync()
        {
            if (BrowserDriver != null)
            {
                BrowserDriver.Dispose();
            }
        }


    }
}
