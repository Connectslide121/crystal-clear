using Core;
using DatabaseConnection;
using Microsoft.EntityFrameworkCore;
using Services.DTOs;
using Services.Interfaces;
using Services.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CitiesService : ICitiesService
    {
        private readonly AppDbContext _dbContext;
        private CitiesMappers _mappers;

        public CitiesService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _mappers = new CitiesMappers();
        }

        public List<CityDTO> GetCities()
        {
            List<City> cities = _dbContext.Cities
                .Include(c => c.AvailableOptions)
                .ToList();

            return _mappers.MapCitiesToCityDTOs(cities);
        }
    }
}
