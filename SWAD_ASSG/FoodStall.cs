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

        public FoodStall(string name, string desc, string contact, string location, string profilePicture, Enum status)
        {
            StallName = name;
            StalllDescription = desc;
            StallContactDetails = contact;
            StallLocation = location;
            ProfilePicture = profilePicture;
            Status = (StallStatus)status;
            Menu = new List<MenuItem>();
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
    }
}
