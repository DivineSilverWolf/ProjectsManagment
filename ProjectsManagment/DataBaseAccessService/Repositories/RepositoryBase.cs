using DataBaseAccessService.Data;
using Microsoft.EntityFrameworkCore;

namespace DataBaseAccessService.Repositories
{
    public abstract class RepositoryBase<T>(DataContext context) where T : class
    {
        private protected DataContext _context = context;

        private protected abstract T? SearchEntity(T entity);
        public virtual void Add(T entity)
        {
            _context.ChangeTracker.TrackGraph(entity, e =>
            {
                if (e.Entry.IsKeySet)
                {
                    e.Entry.State = EntityState.Unchanged;
                }
                else
                {
                    e.Entry.State = EntityState.Added;
                }
            });
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }
        public async virtual void AddAsync(T entity)
        {
            _context.ChangeTracker.TrackGraph(entity, e =>
            {
                if (e.Entry.IsKeySet)
                {
                    e.Entry.State = EntityState.Unchanged;
                }
                else
                {
                    e.Entry.State = EntityState.Added;
                }
            });
            await _context.SaveChangesAsync();
        }

        public virtual bool Update(T entity)
        {
            T? foundEntity = SearchEntity(entity);
            if (foundEntity != null)
            {
                _context.ChangeTracker.TrackGraph(entity, e =>
                {
                    if (e.Entry.IsKeySet)
                    {
                        e.Entry.State = EntityState.Unchanged;
                    }
                    else
                    {
                        e.Entry.State = EntityState.Modified;
                    }
                });
                _context.SaveChanges();
            }
            return foundEntity != null;
        }

        public async virtual Task<bool> UpdateAsync(T entity)
        {
            T? foundEntity = SearchEntity(entity);
            if (foundEntity != null)
            {
                _context.ChangeTracker.TrackGraph(entity, e =>
                {
                    if (e.Entry.IsKeySet)
                    {
                        e.Entry.State = EntityState.Unchanged;
                    }
                    else
                    {
                        e.Entry.State = EntityState.Modified;
                    }
                });
                await _context.SaveChangesAsync();
            }
            return foundEntity != null;
        }

        public virtual bool Delete(T entity)
        {
            T? foundEntity = SearchEntity(entity);
            if (foundEntity != null)
            {
                _context.Set<T>().Remove(foundEntity);
                _context.SaveChanges();
            }
            return foundEntity != null;
        }

        public async virtual Task<bool> DeleteAsync(T entity)
        {
            T? foundEntity = SearchEntity(entity);
            if (foundEntity != null) {
                _context.Set<T>().Remove(foundEntity);
                await _context.SaveChangesAsync();
            }
            return foundEntity != null;
        }

        public virtual IReadOnlyCollection<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public IEnumerable<T> GetItems(int offset, int count)
        {
            return _context.Set<T>().Skip(offset).Take(count).ToList();
        }        
    }
}
