using System.Threading.Tasks;
using Datory;

namespace SSCMS
{
    public partial interface IContentTagRepository : IRepository
    {
        Task InsertAsync(int siteId, string tagName);

        Task DeleteAsync(int siteId, string tagName);

        Task DeleteAsync(int siteId);
    }
}