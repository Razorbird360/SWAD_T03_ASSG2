using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_ASSG
{
    internal class MenuItem
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public float ItemPrice { get; set; }
        public int ItemQuantity { get; set; }
        // This property indicates whether the item is available based on its quantity
        public bool ItemAvailabilityStatus
        {
            get { return ItemQuantity > 0; }
        }
        // Composition: Each MenuItem is associated with one FoodStall
        public FoodStall FoodStall { get; set; }

        internal MenuItem(string name, string desc, float price, int quantity, FoodStall foodStall)
        {
            ItemName = name;
            ItemDescription = desc;
            ItemPrice = price;
            ItemQuantity = quantity;
            FoodStall = foodStall;
        }
        // function to update the food stall reference to null when the item is removed from the menu
        public void clearFoodStallReference()
        {
            FoodStall = null;
        }

        public void updateField(string fieldName, object newValue)
        {
            if (fieldName.ToLower() == "name")
            {
                ItemName = Convert.ToString(newValue);
            }
            else if (fieldName.ToLower() == "description")
            {
                ItemDescription = Convert.ToString(newValue);
            }
            else if (fieldName.ToLower() == "price")
            {
                ItemPrice = float.Parse(newValue.ToString());
            }
            else if (fieldName.ToLower() == "quantity")
            {
                ItemQuantity = Convert.ToInt32(newValue);
            }
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

        public bool CheckItemQuantity(int requestedQuantity)
        {
            return ItemQuantity >= requestedQuantity;
        }
    }
}





