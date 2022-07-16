
using Core.Utilities.Results;
using Entities.Concretes;

namespace Businnes.Abstracts
{
    public interface IColourService
    {
        DataResult<Colour> Add(Colour color);
        DataResult<Colour> Update(Colour color);
        Result Delete(Colour color);
        DataResult<Colour> GetById(int id);
        DataResult<List<Colour>> GetAll();
    }
}
