using System.Threading.Tasks;
using TheCastle.Kernel.Entities;

namespace TheCastle.Core.Interfaces
{
    public interface ICastleService : IGenericService<Castle>
    {
        Task<Castle> GetOneWithDetails(int? id);
    }
}
