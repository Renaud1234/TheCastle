using System.Threading.Tasks;
using TheCastle.Kernel.Entities;

namespace TheCastle.Core.Interfaces
{
    public interface IArmyService : IGenericService<Army>
    {
        Task<Army> GetOneWithDetails(int? id);
    }
}
