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

        // Association: One FoodStall has many Orders
        private List<Order> Orders = new List<Order>();

        // Association: One FoodStall has many Staff
        public List<FoodStallStaff> StaffMembers { get; private set; } = new List<FoodStallStaff>();

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

        public List<MenuItem> GetMenuItems()
        {
            return Menu;
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
        public MenuItem AddMenuItem(string name, string desc, float price, int quantity)
        {
            var newItem = new MenuItem(name, desc, price, quantity, this)
            {
                ItemID = nextItemId++
            };
            Menu.Add(newItem);
            return newItem;
        }
        public void UpdateField(MenuItem item, string fieldName, object newValue)
        {
            item.updateField(fieldName, newValue);
        }
        public void RemoveMenuItemById(int itemId)
        {
            var item = GetMenuItemById(itemId);
            if (item != null)
            {
                Menu.Remove(item);
                item.clearFoodStallReference();
            }
        }

        public (List<Feedback> unreplied, List<Feedback> replied) getListOfFeedback()
        {
            var unreplied = new List<Feedback>();
            var replied = new List<Feedback>();

            foreach (var feedback in Feedbacks)
            {
                if (feedback.replied)
                    replied.Add(feedback);
                else
                    unreplied.Add(feedback);
            }

            return (unreplied, replied);
        }
        public Feedback getFeedbackByID(string id)
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
        public void AddOrder(Order order)
        {
            if (order != null && order.FoodStall == this)
            {
                Orders.Add(order);
            }
        }

        public List<Order> GetIncomingOrders()
        {
            return Orders.ToList();
        }


        public void AddStaffMember(FoodStallStaff staff)
        {
            if (staff != null && !StaffMembers.Contains(staff))
            {
                StaffMembers.Add(staff);
                staff.StallAffiliation = this;  // maintain two-way link
            }
        }


    }
}
