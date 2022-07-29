
using System.Text.Json.Serialization;
using Core.Entities.Abstracts;

namespace Entities.Concretes
{
    public class GearType : IEntity
    {
        public int Id { get; set; }
        public string Gear { get; set; }
        public bool IsDeleted { get; set; }


        [JsonIgnore]
        public List<Car>? Cars { get; set; }
    }
}
