using Microsoft.EntityFrameworkCore;
using TestSwaggerData.DataModel;
using TestSwaggerData.Interfaces;


namespace TestSwaggerData.Repositories
{
    public abstract class BaseRepository<DbModel> : IBaseRepository<DbModel> where DbModel : BaseModel
    {
        protected Context _dbContext;
        protected DbSet<DbModel> _dbSet;

        public BaseRepository(Context dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<DbModel>();
        }

        public virtual bool Any()
            => _dbSet.Any();

        public virtual List<DbModel> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual DbModel? Get(int id)
        {
            return _dbSet.FirstOrDefault(dbModel => dbModel.Id == id);
        }

        public virtual DbModel Create(DbModel model)
        {
            _dbSet.Add(model);

            _dbContext.SaveChanges();

            return model;
        }

        public virtual void Delete(int id)
        {
            var model = Get(id);

            if (model is null)
            {
                throw new KeyNotFoundException();
            }

            Delete(model);
        }

        public virtual void Delete(DbModel model)
        {
            _dbSet.Remove(model);
            _dbContext.SaveChanges();
        }
    }
}
