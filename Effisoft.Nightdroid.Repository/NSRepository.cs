using Effisoft.Nightdroid.Common.Interfaces.Repository;
using Effisoft.Nightdroid.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Effisoft.Nightdroid.Common.Interfaces.DataAccess;

namespace Effisoft.Nightdroid.Repository
{
    public class NSRepository : INSRepository
    {
        private readonly INSDataAccess _nsDataAccess;

        public NSRepository(INSDataAccess nsDataAccess)
        {
            _nsDataAccess = nsDataAccess;
        }

        public async Task<List<BG>> GetNSDataAsync(int noDays)
        {
            var result = await _nsDataAccess.GetNSDataAsync(noDays);
            return result;
        }

        public async Task<List<BG>> GetNSDataAsync(string entityName, int noDays)
        {
            _nsDataAccess.Entity = entityName;
            var result = await GetNSDataAsync(noDays);
            return result;
        }
    }
}