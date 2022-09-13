
using System.Text.Json.Serialization;
using Core.Entities.Abstracts;

namespace Entities.Concretes
{
    public class BranchOffice : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }



        [JsonIgnore]
        public List<RentDetail>? RentedFromOffice { get; set; }

        [JsonIgnore]
        public List<RentDetail>? ReturnedToOffice { get; set; }
    }
}
