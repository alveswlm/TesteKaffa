using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace KaffaTestApplication
{
    public interface ICurrentTimeApiService
    {
        [Get("/api/json/utc/now")]
        Task<Clock> GetCurrentTime();
    }
}