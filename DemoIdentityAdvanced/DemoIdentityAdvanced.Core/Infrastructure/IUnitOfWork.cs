using System.Threading.Tasks;

namespace DemoIdentityAdvanced.Core.Infrastructure
{
    public interface IUnitOfWork
    {
        int Commit();
        Task<int> CommitAsync();
    }
}
