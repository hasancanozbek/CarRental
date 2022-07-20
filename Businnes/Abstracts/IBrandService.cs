
using Core.Utilities.Results;
using Entities.Concretes;

namespace Business.Abstracts
{
    public interface IBrandService
    {
        DataResult<Brand> Add(Brand brand);
        DataResult<Brand> Update(Brand brand);
        Result Delete(Brand brand);
        DataResult<List<Brand>> GetAll();
        DataResult<Brand> GetById(int id);
    }
}
