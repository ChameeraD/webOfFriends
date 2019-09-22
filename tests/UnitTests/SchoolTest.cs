using Core.Data;
using Core.Entities;
using Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class SchoolTest : BaseTest
    {
        [Fact]
        public async Task CreateSchool()
        {
            // Arrange 
            var (db, configuration, mockLogger)  = PrepareCommonServiceDependancies<SchoolService>();

            // Act 
            var schoolService = new SchoolService(db, configuration, mockLogger);
            var schoolAdmin = new School
            {
                Email = "admin@abcschool.com",
                Name = "ABC School",
                Address = "96  Balsham Road, HASLAND",
                PhoneNumber = "07926059561"
            };
            var result = await schoolService.AddAsync(schoolAdmin);

            // Assert
            Assert.Equal(schoolAdmin, result);

        }
    }
}
