using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_ASSG
{
    public enum StallStatus
    {
        Inactive,
        Active
    }
    class FoodStall
    {
        public string  StallName { get; set; }
        public string StalllDescription { get; set; }
        public string StallContactDetails { get; set; }
        public string StallLocation { get; set; }
        public string ProfilePicture { get; set; }
        public StallStatus Status { get; set; }
        public List<MenuItem> Menu { get; set; }

        public List<Feedback> Feedbacks { get; set; }

        public FoodStall(string name, string desc, string contact, string location, string profilePicture, Enum status)
        {
            StallName = name;
            StalllDescription = desc;
            StallContactDetails = contact;
            StallLocation = location;
            ProfilePicture = profilePicture;
            Status = (StallStatus)status;
            Menu = new List<MenuItem>();
            Feedbacks = new List<Feedback>();
        }

        public void DisplayMenu()
        {
            Console.WriteLine($"=== {StallName} Menu ({Status}) ===");
            Console.WriteLine("{0,-25} {1,7}", "Item", "Price ($)");
            Console.WriteLine(new string('-', 34));

            foreach (var item in Menu)
            {
                Console.WriteLine("{0,-25} {1,7:F2}", item.ItemName, item.ItemPrice);
            }

            Console.WriteLine(new string('-', 34));
        }

        public void displayListOfFeedback()
        {
            if (Feedbacks.Count == 0)
            {
                Console.WriteLine("No feedback available for this stall.");
                return;
            }
            Console.WriteLine("=== Unreplied Feedback ===");
            foreach (var feedback in Feedbacks)
            {
                if (!feedback.replied)
                {
                    Console.WriteLine($"ID: {feedback.feedbackID}");
                    Console.WriteLine($"Customer: {feedback.customerName}");
                    Console.WriteLine($"Comment: {feedback.comment}");
                    Console.WriteLine($"Date: {feedback.timestamp}");
                    Console.WriteLine();
                }
            }

            Console.WriteLine("=== Replied Feedback ===");
            foreach (var feedback in Feedbacks)
            {
                if (feedback.replied)
                {
                    Console.WriteLine($"ID: {feedback.feedbackID}");
                    Console.WriteLine($"Customer: {feedback.customerName}");
                    Console.WriteLine($"Comment: {feedback.comment}");
                    Console.WriteLine($"Reply: {feedback.response}");
                    Console.WriteLine($"Date: {feedback.timestamp}");
                    Console.WriteLine();
                }
            }
        }
        public Feedback getFeedbackByID(int id)
        {
            foreach (var feedback in Feedbacks)
            {
                if (feedback.feedbackID == id)
                {
                    return feedback;
                }
            }
            return null;
        }
    }
}
