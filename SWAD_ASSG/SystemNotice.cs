using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_ASSG
{
    public class SystemNotice : Configuration
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string TargetAudience { get; set; }
        public string PriorityLevel { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        public SystemNotice(string configID, string title, string content, string targetAudience,
                           string priorityLevel, DateTime publishDate, DateTime expiryDate)
            : base(configID)
        {
            Title = title;
            Content = content;
            TargetAudience = targetAudience;
            PriorityLevel = priorityLevel;
            PublishDate = publishDate;
            ExpiryDate = expiryDate;
        }

        public bool IsCurrentlyVisible()
        {
            DateTime now = DateTime.Now;
            return IsActive && now >= PublishDate && now <= ExpiryDate;
        }

        public void ScheduleNotice(DateTime newPublishDate, DateTime newExpiryDate)
        {
            PublishDate = newPublishDate;
            ExpiryDate = newExpiryDate;
            UpdateConfiguration();
        }
    }
}
