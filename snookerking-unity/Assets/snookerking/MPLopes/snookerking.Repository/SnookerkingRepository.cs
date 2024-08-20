using System.Threading;
using System.Threading.Tasks;
using snookerking.Data;
using snookerking.Enums;
using snookerking.Interfaces;

namespace snookerking.Repository
{
    public class SnookerkingRepository : ISnookerkingRepository
    {
        snookerkingData _snookerkingData { get; set; }
        public SnookerkingRepository(snookerkingData dbContext)
            => _snookerkingData = dbContext;

        public async Task Insert(UserCode _code, object _object, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
        public async Task<object> Get(UserCode _code, string Id, CancellationToken cancellationToken)
        {
            return null;
        }

        public async Task Delete(UserCode _code, object _object, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }

        public async Task Update(UserCode _code, object _object, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
    }
}