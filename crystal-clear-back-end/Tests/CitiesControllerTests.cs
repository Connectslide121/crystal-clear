using API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Services.DTOs;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class CitiesControllerTests
    {
        [Fact]
        public void GetCities_ReturnsOkResult_WithListOfCities()
        {
            var mockService = new Mock<ICitiesService>();
            mockService.Setup(service => service.GetCities())
                       .Returns(new List<CityDTO> { new CityDTO(), new CityDTO() }); 

            var controller = new CitiesController(mockService.Object);

            var result = controller.GetCities();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<CityDTO>>(okResult.Value);
            Assert.Equal(2, returnValue.Count); 
        }

        [Fact]
        public void GetCities_ReturnsNotFound_WhenNoCitiesExist()
        {
            var mockService = new Mock<ICitiesService>();
            mockService.Setup(service => service.GetCities())
                       .Returns((List<CityDTO>)null);

            var controller = new CitiesController(mockService.Object);

            var result = controller.GetCities();

            Assert.IsType<NotFoundResult>(result);
        }
    }
}
