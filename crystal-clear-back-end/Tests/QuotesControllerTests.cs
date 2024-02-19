using Core;
using DatabaseConnection;
using Microsoft.EntityFrameworkCore;
using Services.DTOs;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class QuotesControllerTests
    {
        private readonly QuotesService _quotesService;
        private readonly AppDbContext _dbContext;

        public QuotesControllerTests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "CrystalClear")
                .Options;

            _dbContext = new AppDbContext(options);

            _quotesService = new QuotesService(_dbContext);
        }

        private void SeedDatabase()
        {
            _dbContext.Cities.AddRange(new[]
            {
            new City { Id = 1, PricePerSquareMeter = 65, Name = "ExampleCity" }
        });
            _dbContext.Options.AddRange(new[]
            {
            new Option { Id = 1, Price = 100, Name = "ExampleOption1" },
            new Option { Id = 2, Price = 600, Name = "ExampleOption2" }
        });

            _dbContext.SaveChanges();
        }

        [Fact]
        public async Task CreateQuote_WithValidParameters_ReturnsQuoteDTO()
        {
            SeedDatabase();

            var city = new CityDTO { PricePerSquareMeter = 10, Id = 1 };
            var options = new List<OptionDTO>
        {
            new OptionDTO { Price = 5, Id = 1 },
            new OptionDTO { Price = 15, Id = 2 }
        };
            int squareMeters = 50;
            int expectedTotalPrice = city.PricePerSquareMeter * squareMeters + options[0].Price + options[1].Price;

            var result = await _quotesService.CreateQuote(city, options, squareMeters);

            Assert.NotNull(result);
            Assert.Equal(expectedTotalPrice, result.TotalPrice);
        }

        [Fact]
        public async Task CreateQuote_WithNoOptions_ReturnsQuoteDTOWithBasePriceOnly()
        {

            var city = new CityDTO { PricePerSquareMeter = 10, Id = 1 };
            var options = new List<OptionDTO>();
            int squareMeters = 50;
            int expectedTotalPrice = city.PricePerSquareMeter * squareMeters;

            var result = await _quotesService.CreateQuote(city, options, squareMeters);

            Assert.NotNull(result);
            Assert.Equal(expectedTotalPrice, result.TotalPrice);
        }

        public void Dispose()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }
    }
}
