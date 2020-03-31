

namespace Api.Models.Repositories
{
    public interface IUnitOfWork
    {

        void Commit();
    }
}