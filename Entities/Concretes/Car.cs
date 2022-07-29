
using Core.Entities.Abstracts;

namespace Entities.Concretes
{
    public class Car : IEntity
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int GearTypeId { get; set; }
        public int FuelTypeId { get; set; }
        public int ColourId { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public bool? Active { get; set; }
        public bool? Deleted { get; set; }



        public virtual Brand Brand { get; set; }
        public virtual GearType GearType { get; set; }
        public virtual FuelType FuelType { get; set; }
        public virtual Colour Colour { get; set; }

        public virtual List<RentDetail>? RentDetails { get; set; }
    }
}
