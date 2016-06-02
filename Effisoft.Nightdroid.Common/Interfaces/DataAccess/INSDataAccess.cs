using System.Collections.Generic;
using System.Threading.Tasks;
using Effisoft.Nightdroid.Common.Models;

namespace Effisoft.Nightdroid.Common.Interfaces.DataAccess
{
    public interface INSDataAccess
    {
        string Entity { get; set; }
        Task<List<BG>> GetNSDataAsync(int noDays);
    }
}