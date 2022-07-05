using Core.Entities;

namespace Entities.Concretes
{
    public class Colour : IEntity
    {
        public int Id { get; set; }
        public string ColourName { get; set; }



        public List<Car> Cars { get; set; }
    }
}
