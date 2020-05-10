using System.Threading.Tasks;

namespace GS.Core.BLL.Interfaces.Services
{
    public interface IDeleteAsyncRepository
    {
         Task Delete(string entityId);
    }
}