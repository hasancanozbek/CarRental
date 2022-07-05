using Core.Entities;

namespace Entities.Concretes
{
    public class GearType : IEntity
    {
        public int Id { get; set; }
        public string Gear { get; set; }



        public List<Car> Cars { get; set; }
    }
}
