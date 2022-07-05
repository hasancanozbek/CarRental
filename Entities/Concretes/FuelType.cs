
using Core.Entities;

namespace Entities.Concretes
{
    public class FuelType : IEntity
    {
        public int Id { get; set; }
        public string Fuel { get; set; }



        public List<Car> Cars { get; set; }
    }
}
