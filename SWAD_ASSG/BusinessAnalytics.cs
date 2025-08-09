using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_ASSG
{
    public class BusinessAnalytics : Configuration
    {
        public string ReportType { get; set; }
        public string DataSource { get; set; }
        public int RefreshInterval { get; set; }
        public int RetentionPeriod { get; set; }
        public string FilterCriteria { get; set; }

        public BusinessAnalytics(string configID, string reportType, string dataSource,
                               int refreshInterval, int retentionPeriod, string filterCriteria)
            : base(configID)
        {
            ReportType = reportType;
            DataSource = dataSource;
            RefreshInterval = refreshInterval;
            RetentionPeriod = retentionPeriod;
            FilterCriteria = filterCriteria;
        }

        public void GenerateReport(DateTime startDate, DateTime endDate)
        {
            Console.WriteLine($"Generating {ReportType} report from {startDate:yyyy-MM-dd} to {endDate:yyyy-MM-dd}");
            Console.WriteLine($"Data Source: {DataSource}");
            Console.WriteLine($"Filter Criteria: {FilterCriteria}");

            //simulate report generation
            Console.WriteLine("=== ANALYTICS REPORT ===");
            Console.WriteLine($"Report Type: {ReportType}");
            Console.WriteLine($"Generated on: {DateTime.Now}");
            Console.WriteLine("Sample metrics:");
            Console.WriteLine("- Total Orders: 1,234");
            Console.WriteLine("- Peak Time: 12:00-13:00");
            Console.WriteLine("- Popular Stall: Chicken Rice Stall");
            Console.WriteLine("========================");
        }

        public void UpdateRetentionPolicy(int newRetentionPeriod)
        {
            RetentionPeriod = newRetentionPeriod;
            UpdateConfiguration();
            Console.WriteLine($"Data retention period updated to {RetentionPeriod} days");
        }
    }
}
