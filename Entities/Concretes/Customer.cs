
using Core.Entities.Abstracts;
using Core.Entities.Concretes;
using System.Text.Json.Serialization;

namespace Entities.Concretes
{
    public class Customer : User, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalId { get; set; }
        public string Address { get; set; }


        [JsonIgnore]
        public List<RentDetail>? RentDetails { get; set; }
    }
}
