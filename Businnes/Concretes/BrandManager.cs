
using Businnes.Abstracts;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Businnes.Concretes
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandRepository brandRepository;

        public BrandManager(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        public DataResult<Brand> Add(Brand brand)
        {
            brandRepository.Add(brand);
            return new SuccessDataResult<Brand>(brand,"Brand added to database.");
        }

        public Result Delete(Brand brand)
        {
            brandRepository.Delete(brand);
            return new SuccessResult("Brand removed from database.");
        }

        public DataResult<List<Brand>> GetAll()
        {
            var brands = brandRepository.GetAll();
            return new SuccessDataResult<List<Brand>>(brands, "All brands listed.");
        }

        public DataResult<Brand> GetById(int id)
        {
            var brand = brandRepository.Get(b => b.Id == id);
            return new SuccessDataResult<Brand>(brand, "The desired brand is listed according to the id.");
        }

        public DataResult<Brand> Update(Brand brand)
        {
            brandRepository.Update(brand);
            return new SuccessDataResult<Brand>(brand, "Brand information updated.");
        }
    }
}
