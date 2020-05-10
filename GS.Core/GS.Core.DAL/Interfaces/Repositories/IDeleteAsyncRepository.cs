using System.Threading.Tasks;

namespace GS.Core.DAL.Interfaces.Repositories
{
    public interface IDeleteAsyncRepository
    {
         Task Delete(string entityId);
    }
}