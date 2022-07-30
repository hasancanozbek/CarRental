
using Business.Abstracts;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;

namespace Business.Concretes
{
    public class CarImageManager : ICarImageService
    {
        private readonly ICarImageRepository carImageRepository;
        private readonly IFileHelper fileHelper;
        private readonly string root = "www\\Uploads\\CarImages\\";

        public CarImageManager(ICarImageRepository carImageRepository, IFileHelper fileHelper)
        {
            this.carImageRepository = carImageRepository;
            this.fileHelper = fileHelper;
        }

        public Result Add(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run( CheckImageLimit(carImage.CarId), CheckDefaultImageExist(carImage.CarId) );
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = fileHelper.Upload(file, root);
            carImage.UploadDate = DateTime.Now;
            carImageRepository.Add(carImage);
            return new SuccessResult("The photo uploaded successfully.");
        }

        public Result AddDefaultImage(int carId)
        {
            CarImage image = new CarImage()
            {
                CarId = carId,
                ImagePath = "default_car_image",
                UploadDate = DateTime.Now
            };
            carImageRepository.Add(image);
            return new SuccessResult();
        }

        public Result Delete(int id)
        {
            var carImage = carImageRepository.Get(image => image.Id == id);
            fileHelper.Delete(root+carImage.ImagePath);
            carImageRepository.Delete(id);
            return new SuccessResult("The photo deleted successfully.");
        }

        public DataResult<List<CarImage>> GetAll()
        {
            var carImages = carImageRepository.GetAll();
            return new SuccessDataResult<List<CarImage>>(carImages, "Images of all cars are listed.");
        }

        public DataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            var images = carImageRepository.GetAll(c => c.CarId == carId);
            return new SuccessDataResult<List<CarImage>>(images, "All images of the specified car are listed.");
        }

        public DataResult<CarImage> GetById(int imageId)
        {
            var carImage = carImageRepository.Get(image => image.Id == imageId);
            return new SuccessDataResult<CarImage>(carImage, "Desired image is listed by id.");
        }

        public Result Update(IFormFile file, CarImage carImage)
        {
            fileHelper.Update(file, root + carImage.ImagePath, root);
            carImageRepository.Update(carImage);
            return new SuccessResult("Image updated.");
        }



        private Result CheckImageLimit(int carId)
        {
            var result = GetAllByCarId(carId);
            if (result.Data.Count > 5)
            {
                return new ErrorResult("There can be a maximum of 5 image for each car.");
            }

            return new SuccessResult();
        }

        private Result CheckDefaultImageExist(int carId)
        {
            var image = carImageRepository.Get(image => image.ImagePath == "default_car_image");
            if (image != null)
            {
                carImageRepository.Delete(image);
            }
            return new SuccessResult();
        }
    }
}
