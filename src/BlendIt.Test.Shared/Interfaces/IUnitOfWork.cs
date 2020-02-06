using System;
using System.Threading.Tasks;

namespace BlendIt.Test.Shared.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}
