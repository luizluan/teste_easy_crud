using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace CRUD_EASY.EntityFramework.Repositories
{
    public abstract class CRUD_EASYRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<CRUD_EASYDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected CRUD_EASYRepositoryBase(IDbContextProvider<CRUD_EASYDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class CRUD_EASYRepositoryBase<TEntity> : CRUD_EASYRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected CRUD_EASYRepositoryBase(IDbContextProvider<CRUD_EASYDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
