using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DietaApp.Database
{ 
        public abstract class BaseRepository<Entity> : IRepository<Entity> where Entity : BaseEntity // Aby mieć Id w Entities i moc wykorzystac w dziedziczeniu
        {
        protected DietaAppDbContext mDbContext;
        protected abstract DbSet<Entity> DbSet { get; }
        public BaseRepository(DietaAppDbContext dbContext)
        {
            mDbContext = dbContext;
        }

        public List<Entity> GetAll()
        {
            var list = new List<Entity>();

            var entities = DbSet;

            foreach (var entity in entities)
                list.Add(entity);

            return list;
        }

        public bool AddNew(Entity entity)
        {
            DbSet.Add(entity);
            return SaveChanges();
        }

        public bool Delete(Entity entity)
        {
            var foundEntity = DbSet.FirstOrDefault(x => x.Id == entity.Id);

            if (foundEntity != null)
            {
                DbSet.Remove(foundEntity);
                return SaveChanges();
            }

            return false;
        }



        public bool SaveChanges()
        {
          return  mDbContext.SaveChanges() > 0;
        }


        }
    
}
