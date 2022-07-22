
using Core.Utilities.Results;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;

namespace Business.Abstracts
{
    public interface ICarImageService
    {
        Result Add(IFormFile file, CarImage carImage);
        Result Delete(int id);
        Result Update(IFormFile file, CarImage carImage);

        DataResult<List<CarImage>> GetAll();
        DataResult<List<CarImage>> GetAllByCarId(int carId);
        DataResult<CarImage> GetById(int imageId);
    }
}
