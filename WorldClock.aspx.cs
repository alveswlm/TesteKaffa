using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;
using System.Web.UI.HtmlControls;

namespace KaffaTestApplication
{
    public partial class WorldClock : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        static async Task ConsumirServico()
        {
            try
            {
                HttpClient client = new HttpClient();

                if (client == null)
                {
                    client.BaseAddress = new Uri("http://worldclockapi.com/api/json/utc/now");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    Time time = new Time();

                    time = await GetTime("http://worldclockapi.com/api/json/utc/now", client);
                }
            }
            catch
            {
                throw;
            }
        }
        static async Task<Time> GetTime(string path, HttpClient client)
        {
            Time time = null;
            HttpResponseMessage response = await client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                time = await response.Content.ReadAsAsync<Time>();
            }
            return time;
        }

        public class Time
        {
            public string currentDateTime { get; set; }
        }

        protected void btnShowTime_Click(object sender, EventArgs e)
        {
            ConsumeService();
        }

        static async Task ConsumeService()
        {
            try
            {
                var currentTimeClient = RestService.For<ICurrentTimeApiService>("http://worldclockapi.com");

                var clock = await currentTimeClient.GetCurrentTime();

                string current = "Current Date/Time Hour: " + clock.CurrentDateTime;
                HtmlGenericControl spanCurrentDateTime = new HtmlGenericControl();
                spanCurrentDateTime.InnerText = "Current Date/Time Hour: " + clock.CurrentDateTime;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}