using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_ASSG
{
    internal class MenuItem
    {
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public float ItemPrice { get; set; }
        public bool ItemAvailabilityStatus
        {
            get { return ItemQuantity > 0; }
        }
        public int ItemQuantity { get; set; }

        public MenuItem(string name, string desc, float price, int quantity)
        {
            ItemName = name;
            ItemDescription = desc;
            ItemPrice = price;
            ItemQuantity = quantity;
        }

        public string GetAvailabilityStatus()
        {
            if (ItemAvailabilityStatus)
            {
                return "Available";
            }
            else
            {
                return "Out of Stock";
            }
        }
    }
}
