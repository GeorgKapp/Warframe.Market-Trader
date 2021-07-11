﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Warframe.Market_DbContextScope;
using Warframe.Market_Infrastructure;
using Warframe.Market_Infrastructure_Repositories.Repositories.EntityModelRepositories.Interfaces.RepositoryInterfaces;
using Warframe.Market_Infrastructure_Repositories.Repositories.Exceptions;

namespace Warframe.Market_Infrastructure_Repositories.Repositories.EntityModelRepositories.Implementation
{
    public class EntityOrderRepository : IEntityOrderRepository
    {
        private readonly IAmbientDbContextLocator _ambientDbContextLocator;
        private DbContext DbContext => _ambientDbContextLocator.GetAmbientDbContextOrThrow<EntityContext>();

        public EntityOrderRepository(IAmbientDbContextLocator ambientDbContextLocator)
        {
            _ambientDbContextLocator = ambientDbContextLocator ?? throw new ArgumentNullException(nameof(ambientDbContextLocator));
        }

        public void Create(ref Order entity)
        {
            DbContext.Entry(entity).State = EntityState.Added;
            DbContext.SaveChanges();
        }

        public void Delete(int entityID)
        {
            var entity = DbContext.Set<Order>()
                .Where(predicate => predicate.ID == entityID)
                .SingleOrDefault()
                ?? throw new EntityNotFoundException(nameof(Order), entityID);

            DbContext.Entry(entity).State = EntityState.Deleted;
            DbContext.SaveChanges();
        }

        public bool Exists(int entityID)
        {
            return DbContext.Set<Order>().Any(e => e.ID == entityID);
        }

        public Order Get(int entityID)
        {
            return DbContext.Set<Order>()
                .SingleOrDefault(predicate => predicate.ID == entityID)
                ?? throw new EntityNotFoundException(nameof(Order), entityID);
        }

        public IQueryable<Order> Get(Expression<Func<Order, bool>> predicate)
        {
            return DbContext.Set<Order>().Where(predicate);
        }

        public IQueryable<Order> GetAll()
        {
            return DbContext.Set<Order>();
        }

        public void Update(ref Order entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            DbContext.SaveChanges();
        }
    }
}
