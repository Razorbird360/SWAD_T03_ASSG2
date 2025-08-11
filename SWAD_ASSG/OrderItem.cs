using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_ASSG
{
    class OrderItem
    {
        public int OrderItemID { get; set; }
        public int OrderID { get; set; }
        public int MenuItemID { get; set; }
        public int Quantity { get; set; }

        public Order Order { get; set; }

        public OrderItem() { }

        public OrderItem(int orderItemID, int orderID, int menuItemID, int quantity)
        {
            OrderItemID = orderItemID;
            OrderID = orderID;
            MenuItemID = menuItemID;
            Quantity = quantity;
        }
    }
}
