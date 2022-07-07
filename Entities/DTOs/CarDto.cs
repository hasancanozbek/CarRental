
using Core.Entities;

namespace Entities.DTOs
{
    public class CarDto : IDto
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public string GearType { get; set; }
        public string FuelType { get; set; }
        public string Colour { get; set; }
    }
}
