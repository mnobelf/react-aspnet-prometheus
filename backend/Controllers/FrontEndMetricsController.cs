using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using backend.FrontEndMetrics;
using System.Text.Json;
using Microsoft.AspNetCore.Cors;

namespace backend.Controllers
{
    public class TempMetrics
    {
        public string? Name { get; set; }
        public string? Value { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class FrontEndMetricsController : ControllerBase
    {
        public class metric
        {
            public string? Name { get; set; }
            public string? Value { get; set; }
        }

        [HttpPost]
        public ContentResult PushMetrics(metric m)
        {
            try
            {
                if (m.Name == "ReactApp_FCP")
                {
                    FrontEndMetrics.FrontEndMetrics.FCP.Observe(float.Parse(m.Value));
                    return Content("Metric name : ReactApp_FCP");
                }
                else if (m.Name == "ReactApp_TTFB")
                {
                    FrontEndMetrics.FrontEndMetrics.TTFB.Observe(float.Parse(m.Value));
                    return Content("Metric name : ReactApp_TTFB");
                }
                else if (m.Name == "ReactApp_TTI")
                {
                    FrontEndMetrics.FrontEndMetrics.TTI.Observe(float.Parse(m.Value));
                    return Content("Metric name : ReactApp_TTI");
                }
                else if (m.Name == "ReactApp_Load_Time")
                {
                    FrontEndMetrics.FrontEndMetrics.LoadTime.Observe(float.Parse(m.Value));
                    return Content("Metric name : ReactApp_Load_Time");
                }
                else if (m.Name == "ReactApp_DNSLookup")
                {
                    FrontEndMetrics.FrontEndMetrics.DNSLookup.Observe(float.Parse(m.Value));
                    return Content("Metric name : ReactApp_DNSLookup");
                }
                else if (m.Name == "ReactApp_Fetch_Time")
                {
                    FrontEndMetrics.FrontEndMetrics.FetchTime.Observe(float.Parse(m.Value));
                    return Content("Metric name : ReactApp_Fetch_Time");
                }
                else if (m.Name == "ReactApp_Memory_Usage")
                {
                    FrontEndMetrics.FrontEndMetrics.MemoryUsage.Observe(float.Parse(m.Value));
                    return Content("Metric name : ReactApp_Memory_Usage");
                }
                else
                {
                    throw new InvalidOperationException("Invalid Metric name");
                }
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
    }
}
