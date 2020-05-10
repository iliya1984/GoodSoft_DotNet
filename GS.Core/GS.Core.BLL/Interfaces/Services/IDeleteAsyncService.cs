using System.Threading.Tasks;

namespace GS.Core.BLL.Interfaces.Services
{
    public interface IDeleteAsyncService
    {
         Task Delete(string entityId);
    }
}