using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_ASSG
{
    class Administrator : User
    {
        public string contactDetails { get; set; }
        public string permissionLevel { get; set; }
        public string department { get; set; }

        public List<FeedbackReport> reportedFeedbacks { get; set; } = new List<FeedbackReport>();

        public Administrator(string contactDetails, string permissionLevel, string department, string userID, string name, string email, string password)
        {
            this.userID = userID;
            this.name = name;
            this.email = email;
            this.password = password;
            this.contactDetails = contactDetails;
            this.permissionLevel = permissionLevel;
            this.department = department;
        }

        public void ReportFeedback(FeedbackReport feedbackReport)
        {
            reportedFeedbacks.Add(feedbackReport);
        }
    }
}
