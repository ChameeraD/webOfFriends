using Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests
{
    public class BaseTest
    {
        protected (ApplicationDbContext, IConfigurationRoot, ILogger<T>) PrepareCommonServiceDependancies<T>()
        {
            // Prepare db context
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase($"WebOfFriendsDB-{new Guid()}")
                .Options;

            var db = new ApplicationDbContext(options);

            // Prepare configurations
            IConfigurationRoot configuration = new ConfigurationBuilder()
                        .AddInMemoryCollection(MakeConfig())
                        .Build();

            // Prepare logger
            var mockLogger = new Mock<ILogger<T>>().Object;

            // Return
            return (db, configuration, mockLogger);

        }

        private static List<KeyValuePair<string, string>> MakeConfig()
        {
            var config = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("ASPNETCORE_ENVIRONMENT", "Development")
            };

            return config;
        }
    }
}
