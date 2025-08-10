using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_ASSG
{
    class ReportFeedback
    {
        public string Subject { get; set; }
        public string Reason { get; set; }
        public int ReportedByUserID { get; set; }
        public DateTime ReportedAt { get; set; }
        public Feedback feedback { get; set; }

        public ReportFeedback(string subject, string reason, int reportedByUserID, Feedback feedback)
        {
            Subject = subject;
            Reason = reason;
            ReportedByUserID = reportedByUserID;
            ReportedAt = DateTime.Now;
            this.feedback = feedback;
        }
    }
}
