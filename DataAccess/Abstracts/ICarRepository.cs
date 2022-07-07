
using Core.DataAccess;
using Entities.Concretes;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Abstracts
{
    public interface ICarRepository : IEntityRepository<Car>
    {
        public void Update(CarUpdateDto car);
        public void Delete(int id);
        public List<CarDto> GetAllCars(Expression<Func<CarDto, bool>> filter = null);
        public CarDto GetCar(Expression<Func<CarDto, bool>> filter);
    }
}
