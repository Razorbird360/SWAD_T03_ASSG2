using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_ASSG
{
    class Feedback
    {
        public string feedbackID { get; set; }
        public string customerName { get; set; }
        public DateTime timestamp { get; set; }
        public int stallID { get; set; }
        public string title { get; set; }
        public string comment { get; set; }
        public bool replied { get; set; }

        public string response { get; set; }

        public Feedback(int stallID, string title, string comment, string feedbackID, string customerName, DateTime timeStamp)
        {
            this.stallID = stallID;
            this.title = title;
            this.comment = comment;
            this.replied = false;
            this.response = "";
            this.feedbackID = feedbackID;
            this.customerName = customerName;
            this.timestamp = timeStamp;
        }

        public void updateResponse(string response)
        {
            this.response = response;
            this.replied = true;
        }
    }
}
