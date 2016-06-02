using System;
using System.Globalization;
using System.Web.Http;

namespace Effisoft.Nightdroid.Api.Controllers
{
    public class NSDataController : ApiController
    {
        //private MongoHelper _mongoHelper;

        //[HttpPost]
        //public async Task<IHttpActionResult> GetNSDataAsync(GetNSDataRequest getNsDataRequest)
        //{
        //    _mongoHelper = new MongoHelper(getNsDataRequest.DBConnection, getNsDataRequest.DatabaseName)
        //    {
        //        EntityName = "entries"
        //    };
        //    var filter = "{ date : { $gte : " + ConvertToUnixTimestamp(DateTime.Now.AddDays(-3)) + "000 }}";
        //    var entries = await _mongoHelper.GetEntities<Entries>(filter);
        //    var result = new List<BG>();
        //    entries.ForEach(svg =>
        //    {
        //        result.Add(new BG()
        //        {
        //            Sgv = svg.Sgv,
        //            Date = ConvertFromUnixTimestamp(svg.Date),
        //            Direction = svg.Direction,
        //            Trend = svg.Trend
        //        });
        //    });
        //    result = result.OrderByDescending(a => a.Date).ToList();
        //    return Ok(result);
        //}
    }
}