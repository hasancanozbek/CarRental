using Core.Entities;
using System.Text.Json.Serialization;

namespace Entities.Concretes
{
    public class Colour : IEntity
    {
        public int Id { get; set; }
        public string ColourName { get; set; }
        public bool IsDeleted { get; set; }


        [JsonIgnore]
        public List<Car>? Cars { get; set; }
    }
}
