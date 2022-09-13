
using System.Text.Json.Serialization;
using Core.Entities.Abstracts;

namespace Entities.Concretes
{
    public class RentDetail : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public decimal Price { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int? OriginOfficeId { get; set; }
        public int? ReturnOfficeId { get; set; }


        [JsonIgnore]
        public Customer Customer { get; set; }

        [JsonIgnore]
        public Car Car { get; set; }

        [JsonIgnore] 
        public BranchOffice OriginOffice { get; set; }

        [JsonIgnore]
        public BranchOffice ReturnOffice { get; set; }

    }
}
