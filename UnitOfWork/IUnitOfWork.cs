
using Api.Models.EF;

namespace UnitOfWork
{
    public interface IUnitOfWork
    {
       IRepository<Role> Roles { get; }

        void Commit();
    }
}