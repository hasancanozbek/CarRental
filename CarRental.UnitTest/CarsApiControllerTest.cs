using Business.Abstracts;
using Core.Utilities.Results;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebAPI.Controllers;
using Xunit;
using Xunit.Sdk;

namespace CarRental.UnitTest
{
    public class CarsApiControllerTest
    {
        private readonly Mock<ICarService> mockService;
        private readonly CarsController controller;

        private List<CarDto> carDtoList;
        private List<CarFeatureDto> carFeatureDtostList;
        public CarsApiControllerTest()
        {
            mockService = new Mock<ICarService>();
            controller = new CarsController(mockService.Object);
            carDtoList = new List<CarDto>
            {
                new CarDto{Id=1, BrandName="Audi", Colour="Siyah", FuelType="Benzin", GearType="Otomatik", Model="A8", Price=6500},
                new CarDto{Id=2, BrandName="Mercedes", Colour="Beyaz", FuelType="Benzin", GearType="Otomatik", Model="AMG G63", Price=8000},
                new CarDto{Id=3, BrandName="Hyundai", Colour="Beyaz", FuelType="Benzin", GearType="Otomatik", Model="i20", Price=1200},
                new CarDto{Id=4, BrandName="Renault", Colour="Gri", FuelType="Dizel", GearType="Manuel", Model="Fluence", Price=1000},
                new CarDto{Id=5, BrandName="Opel", Colour="Kırmızı", FuelType="Dizel", GearType="Manuel", Model="Corsa", Price=1100},
                new CarDto{Id=6, BrandName="Mercedes", Colour="Siyah", FuelType="Benzin", GearType="Otomatik", Model="C", Price=2300},
            };
            carFeatureDtostList = new List<CarFeatureDto>
            {
                new CarFeatureDto{Id=1, BrandId=1, ColourId=2, Description=null, FuelTypeId=1, GearTypeId=1, Model="A8", ModelYear=2021, Price=6500},
                new CarFeatureDto{Id=2, BrandId=2, ColourId=3, Description=null, FuelTypeId=1, GearTypeId=1, Model="AMG G63", ModelYear=2022, Price=8000},
                new CarFeatureDto{Id=3, BrandId=3, ColourId=3, Description=null, FuelTypeId=1, GearTypeId=1, Model="i20", ModelYear=2018, Price=1200},
                new CarFeatureDto{Id=4, BrandId=4, ColourId=1, Description=null, FuelTypeId=2, GearTypeId=2, Model="Fluence", ModelYear=2012, Price=1000},
                new CarFeatureDto{Id=5, BrandId=5, ColourId=4, Description=null, FuelTypeId=2, GearTypeId=2, Model="Corsa", ModelYear=2015, Price=1100},
                new CarFeatureDto{Id=6, BrandId=2, ColourId=2, Description=null, FuelTypeId=1, GearTypeId=1, Model="C", ModelYear=2018, Price=2300},
            };
        }

        [Fact]
        public void GetAll_Execute_ReturnOkWithCarDto()
        {
            mockService.Setup(x => x.GetAll()).Returns(new SuccessDataResult<List<CarDto>>(carDtoList));
            var actionResult = controller.GetAll();
            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            var returnCars = Assert.IsAssignableFrom<SuccessDataResult<List<CarDto>>>(okResult.Value);
            Assert.Equal<int>(6, returnCars.Data.Count);
        }

        [Theory]
        [InlineData(0)]
        public void GetById_InvalidId_ReturnBadRequest(int carId)
        {
            mockService.Setup(x => x.GetById(carId)).Throws(new Exception());
            Assert.Throws<Exception>(() => controller.GetById(carId));
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void GetById_Execute_ReturnOkWithCarDto(int carId)
        {
            var car = carDtoList.First(c => c.Id == carId);
            mockService.Setup(x => x.GetById(carId)).Returns(new SuccessDataResult<CarDto>(car));
            var actionResult = controller.GetById(carId);
            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            Assert.IsAssignableFrom<SuccessDataResult<CarDto>>(okResult.Value);
        }

        [Theory]
        [InlineData(1000,1500)]
        public void GetByPrice_Execute_ReturnOkWithCarFeatureDto(int min, int max)
        {
            var cars = carFeatureDtostList.FindAll(c => c.Price >= min && c.Price <= max);
            mockService.Setup(x => x.GetByPrice(min, max)).Returns(new SuccessDataResult<List<CarFeatureDto>>(cars));
            var actionResult = controller.GetByPrice(min, max);
            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            var returnCar = Assert.IsAssignableFrom<SuccessDataResult<List<CarFeatureDto>>>(okResult.Value);
            Assert.Equal<int>(3,returnCar.Data.Count);
        }

        [Theory]
        [InlineData(1)]
        public void GetAllByGearType_Execute_ReturnOkWithCarFeatureDto(int gearId)
        {
            var cars = carFeatureDtostList.FindAll(c => c.GearTypeId == gearId);
            mockService.Setup(x => x.GetAllByGearType(gearId)).Returns(new SuccessDataResult<List<CarFeatureDto>>(cars));
            var actionResult = controller.GetAllByGearType(gearId);
            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            var returnCars = Assert.IsAssignableFrom<SuccessDataResult<List<CarFeatureDto>>>(okResult.Value);
            Assert.Equal(4, returnCars.Data.Count);
        }
    }
}
