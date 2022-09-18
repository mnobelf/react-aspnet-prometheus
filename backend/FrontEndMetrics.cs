using Prometheus;

namespace backend.FrontEndMetrics
{
    public class FrontEndMetrics
    {
        public static readonly Histogram FCP =
            Metrics.CreateHistogram("ReactApp_FCP", "React SPA FCP",
                new HistogramConfiguration
                {
                    Buckets = Histogram.LinearBuckets(start: 200, width: 200, count: 10)
                });
        public static readonly Histogram TTFB =
            Metrics.CreateHistogram("ReactApp_TTFB", "React SPA TTFB",
                new HistogramConfiguration
                {
                    Buckets = Histogram.LinearBuckets(start: 200, width: 200, count: 10)
                });
        public static readonly Histogram TTI =
            Metrics.CreateHistogram("ReactApp_TTI", "React SPA TTI",
                new HistogramConfiguration
                {
                    Buckets = Histogram.LinearBuckets(start: 200, width: 200, count: 10)
                });
        public static readonly Histogram DNSLookup =
            Metrics.CreateHistogram("ReactApp_DNSLookup", "React SPA DNSLookup",
                new HistogramConfiguration
                {
                    Buckets = Histogram.LinearBuckets(start: 200, width: 200, count: 10)
                });
        public static readonly Histogram LoadTime =
            Metrics.CreateHistogram("ReactApp_Load_Time", "React SPA Load Time",
                new HistogramConfiguration
                {
                    Buckets = Histogram.LinearBuckets(start: 200, width: 200, count: 10)
                });
        public static readonly Histogram FetchTime =
            Metrics.CreateHistogram("ReactApp_Fetch_Time", "React SPA Fetch Time",
                new HistogramConfiguration
                {
                    Buckets = Histogram.LinearBuckets(start: 200, width: 200, count: 10)
                });
        public static readonly Histogram MemoryUsage =
            Metrics.CreateHistogram("ReactApp_Memmory_Usage", "Total allocated heap size, in bytes",
                new HistogramConfiguration
                {
                    Buckets = Histogram.LinearBuckets(start: 200, width: 200, count: 10)
                });
    }
}
