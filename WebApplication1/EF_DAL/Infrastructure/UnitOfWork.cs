using EF_DAL.Entities;
using EF_DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace EF_DAL.Infrastructure
{
    public sealed class UnitOfWork<TEntity> : IUnitOfWork<TEntity> where TEntity : class, IEntity
    {
        private readonly EFContext context;

        public UnitOfWork(EFContext context) => this.context = context;

        /// <summary>
        /// Gets DBContext, is used for disposing
        /// </summary>
        public DbContext db => context;

        /// <summary>
        /// Gets repository for TEntity
        /// </summary>
        /// <returns>instance of repository</returns>
        public IRepository<TEntity> GetRepository() => new Repository<TEntity>(context);

        /// <summary>
        /// Saves changes in DB
        /// </summary>
        public void SaveChanges() => context.SaveChanges();

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                db.Dispose();
            }

            disposed = true;
        }
    }
}
