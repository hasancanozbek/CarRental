
using Business.Abstracts;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;

namespace Business.Concretes
{
    public class CarImageManager : ICarImageService
    {
        private readonly ICarImageRepository carImageRepository;

        public CarImageManager(ICarImageRepository carImageRepository)
        {
            this.carImageRepository = carImageRepository;
        }

        public Result Add(IFormFile file, CarImage carImage)
        {
            throw new NotImplementedException();
        }

        public Result Delete(int id)
        {
            throw new NotImplementedException();
        }

        public DataResult<List<CarImage>> GetAll()
        {
            throw new NotImplementedException();
        }

        public DataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            throw new NotImplementedException();
        }

        public DataResult<CarImage> GetById(int imageId)
        {
            throw new NotImplementedException();
        }

        public Result Update(IFormFile file, CarImage carImage)
        {
            throw new NotImplementedException();
        }
    }
}
