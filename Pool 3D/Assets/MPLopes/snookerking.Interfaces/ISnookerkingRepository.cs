using System.Threading;
using System.Threading.Tasks;
using snookerking.Enums;

namespace snookerking.Interfaces
{
    public interface ISnookerkingRepository
    {
        Task Insert(UserCode _code, object _object, CancellationToken cancellationToken);
        Task<object> Get(UserCode _code, string Id, CancellationToken cancellationToken);
        Task Delete(UserCode _code, object _object, CancellationToken cancellationToken);
        Task Update(UserCode _code, object _object, CancellationToken cancellationToken);
    }
}