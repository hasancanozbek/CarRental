
using Core.Entities;

namespace Entities.DTOs
{
    public class CarDto : IDto
    {
        public string Model { get; set; }
        public string BrandName { get; set; }
        public decimal Price { get; set; }
        public string GearType { get; set; }
    }
}
