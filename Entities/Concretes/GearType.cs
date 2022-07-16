using Core.Entities;
using System.Text.Json.Serialization;

namespace Entities.Concretes
{
    public class GearType : IEntity
    {
        public int Id { get; set; }
        public string Gear { get; set; }


        [JsonIgnore]
        public List<Car>? Cars { get; set; }
    }
}
