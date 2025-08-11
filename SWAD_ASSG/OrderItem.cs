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

        public MenuItem MenuItem { get; set; }  

        public OrderItem(int orderItemID, Order order, MenuItem menuItem, int quantity)
        {
            OrderItemID = orderItemID;
            Order = order ?? throw new ArgumentNullException(nameof(order));
            OrderID = order.OrderID;
            MenuItem = menuItem ?? throw new ArgumentNullException(nameof(menuItem));
            MenuItemID = menuItem.ItemID;  // or whatever the ID property is named
            Quantity = quantity;
        }


    }
}
