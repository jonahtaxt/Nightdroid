using System;
using System.Collections.Concurrent;
using Effisoft.Nightdroid.Common.Interfaces;
using Effisoft.Nightdroid.Common.Models;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Effisoft.Nightdroid.Common.Interfaces.DataAccess;
using Effisoft.Nightdroid.DataAccess.MongoDB.Proxy;
using MongoDB.Driver;

namespace Effisoft.Nightdroid.DataAccess.MongoDB
{
    public class NSDataAccess : INSDataAccess
    {
        public string Entity { get; set; }
        private readonly MongoDataAccess _mongoDataAccess;
        private ConcurrentBag<BG> _concurrentBag; 

        public NSDataAccess(string connection, string databaseName)
        {
            _mongoDataAccess = new MongoDataAccess(connection, databaseName);
        }

        public async Task<List<BG>> GetNSDataAsync(int noDays)
        {
            _mongoDataAccess.EntityName = Entity;
            var filter = "{ date : { $gte : " + ConvertToUnixTimestamp(DateTime.Now.AddDays(noDays * -1)) + "000 }}";
            var entries = await _mongoDataAccess.GetEntities<Entries>(filter);
            _concurrentBag = new ConcurrentBag<BG>();
            Parallel.ForEach(entries, AddEntry);
            return _concurrentBag.OrderByDescending(e => e.Date).ToList();
        }

        private static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            var timestampString = (timestamp.ToString(CultureInfo.InvariantCulture));
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return origin.AddSeconds(Convert.ToDouble(timestampString.Remove(timestampString.Length - 3)));
        }

        private static double ConvertToUnixTimestamp(DateTime date)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var diff = date.ToUniversalTime() - origin;
            return Math.Floor(diff.TotalSeconds);
        }

        private void AddEntry(object o)
        {
            var entry = (Entries) o;
            var bg = new BG()
            {
                Date = ConvertFromUnixTimestamp(entry.Date),
                Direction = entry.Direction,
                Sgv = entry.Sgv,
                Trend = entry.Trend
            };
            _concurrentBag.Add(bg);
        }
    }
}