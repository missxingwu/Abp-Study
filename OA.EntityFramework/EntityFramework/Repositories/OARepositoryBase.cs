using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace OA.EntityFramework.Repositories
{
    public abstract class OARepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<OADbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected OARepositoryBase(IDbContextProvider<OADbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class OARepositoryBase<TEntity> : OARepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected OARepositoryBase(IDbContextProvider<OADbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
