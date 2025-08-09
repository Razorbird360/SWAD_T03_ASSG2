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
        public int StallID { get; set; }
        public string StallName { get; set; }
        public string StalllDescription { get; set; }
        public string StallContactDetails { get; set; }
        public string StallLocation { get; set; }
        public string ProfilePicture { get; set; }
        public StallStatus Status { get; set; }
        public List<MenuItem> Menu { get; set; }

        private int nextItemId = 1;

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

        public void DisplayMenuItems()
        {
            Console.WriteLine();
            Console.WriteLine($"===== {StallName} Menu =====");
            Console.WriteLine("{0,-8} {1,-25} {2,8}", "Item ID", "Item Name", "Price ($)");
            foreach (var item in Menu)
            {
                Console.WriteLine("{0,-8} {1,-25} {2,8:F2}", item.ItemID, item.ItemName, item.ItemPrice);
            }
            Console.WriteLine();
        }

        public MenuItem GetMenuItemById(int itemId)
        {
            foreach (var item in Menu)
            {
                if (item.ItemID == itemId)
                {
                    return item;
                }
            }
            return null;
        }
        public void AddMenuItem(MenuItem newItem)
        {
            if (newItem != null)
            {
                if (newItem.ItemID == 0)
                {
                    newItem.ItemID = nextItemId++;
                }
                Menu.Add(newItem);
            }
        }
        public void UpdateField(MenuItem item, string field, object newValue)
        {
            if (field.ToLower() == "name")
            {
                item.ItemName = Convert.ToString(newValue);
            }
            else if (field.ToLower() == "description")
            {
                item.ItemDescription = Convert.ToString(newValue);
            }
            else if (field.ToLower() == "price")
            {
                item.ItemPrice = float.Parse(newValue.ToString());
            }
            else if (field.ToLower() == "quantity")
            {
                item.ItemQuantity = Convert.ToInt32(newValue);
            }
        }
        public void RemoveMenuItemById(int itemId)
        {
            var item = GetMenuItemById(itemId);
            if (item != null)
            {
                Menu.Remove(item);
            }
        }
        public bool validateFieldValue(string field, object value, MenuItem currentItem = null)
        {
            if (field.ToLower() == "name")
            {
                string name = Convert.ToString(value).Trim().ToLower();
                foreach (var item in Menu)
                {
                    if (item.ItemName.Trim().ToLower() == name)
                    {
                        if (currentItem == null || item.ItemID != currentItem.ItemID)
                        {
                            return false; // Name already exists and is not the current item
                        }
                        else
                        {
                            return true; // Name exists but is the current item, so it's valid
                        }
                    }
                }
            }
            if (field.ToLower() == "description")
            {
                string description = Convert.ToString(value).Trim();
                if (string.IsNullOrEmpty(description))
                {
                    return false; // Description cannot be empty
                }
            }
            if (field.ToLower() == "price")
            {
                if (float.TryParse(value.ToString(), out float price))
                {
                    if (price < 0)
                    {
                        return false; // Price cannot be negative
                    }
                }
                else
                {
                    return false; // Invalid price format
                }
            }
            if (field.ToLower() == "quantity")
            {
                if (int.TryParse(value.ToString(), out int quantity))
                {
                    if (quantity < 0)
                    {
                        return false; // Quantity cannot be negative
                    }
                }
                else
                {
                    return false; // Invalid quantity format
                }
            }
            return true;
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
