
using Api.Models.EF;

namespace UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ProjectNCTEntities _dbContext;

        private BaseRepository<Role> _role;



        public UnitOfWork(ProjectNCTEntities dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<Role> Roles
        {
            get
            {
                return _role ??
                       (_role = new BaseRepository<Role>(_dbContext));
            }
        }

       

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}