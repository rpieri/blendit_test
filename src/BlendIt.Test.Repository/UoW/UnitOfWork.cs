using BlendIt.Test.Repository.Contexts;
using BlendIt.Test.Shared.Interfaces;
using System.Threading.Tasks;

namespace BlendIt.Test.Repository.UoW
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly EntityContext context;

        public UnitOfWork(EntityContext context)
        {
            this.context = context;
        }
        public async Task<bool> Commit() => await context.SaveChangesAsync() > 0;

        public void Dispose() => context.Dispose();
    }
}
