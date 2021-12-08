using EF_DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace EF_DAL.Interfaces
{
    public interface IUnitOfWork<TEntity> : IDisposable where TEntity : class, IEntity
    {
        DbContext db { get; }

        IRepository<TEntity> GetRepository();

        void SaveChanges();
    }
}
