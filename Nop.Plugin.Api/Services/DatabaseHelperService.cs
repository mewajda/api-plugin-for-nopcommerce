using Nop.Core;
using Nop.Data;
using System.Collections.Generic;
using System.Transactions;

namespace Nop.Plugin.Api.Services
{
    public class DatabaseHelperService : IDatabaseHelperService
    {
        private readonly IDbContext _dbContext;

        public DatabaseHelperService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void BulkInsert<T>(IList<T> items) where T : BaseEntity, new()
        {
            using (var scope = new TransactionScope())
            {
                try
                {
                    _dbContext.AutoDetectChangesEnabled = false;

                    for (int i = 0; i < items.Count; i++)
                        items[i] = AddToContext(items[i]);

                    _dbContext.SaveChanges();
                }
                finally
                {
                    _dbContext.AutoDetectChangesEnabled = true;
                }

                scope.Complete();
            }
        }

        private TEntity AddToContext<TEntity>(TEntity entity) where TEntity : BaseEntity, new()
        {
            _dbContext.Set<TEntity>().Add(entity);

            return entity;
        }
    }
}
