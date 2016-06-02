using Effisoft.Nightdroid.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Effisoft.Nightdroid.Common.Interfaces.DataAccess;

namespace Effisoft.Nightdroid.Common.Interfaces.Repository
{
    public interface INSRepository
    {
        Task<List<BG>> GetNSDataAsync(int noDays);

        Task<List<BG>> GetNSDataAsync(string entityName, int noDays);
    }
}