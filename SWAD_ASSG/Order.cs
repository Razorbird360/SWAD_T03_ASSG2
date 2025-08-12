using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_ASSG
{

    public enum  OrderStatus
    {
        Pending,
        Preparing,
        ReadyForPickup,
        Completed,
        Cancelled
    }

    public enum PaymentStatus
    {
        Unpaid,
        Paid,
        Refunded
    }

    class Order
    {
        public int OrderID { get; set; }
        public int StudentID { get; set; }
        public int StallID { get; set; }
        public int TimeSlotID { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderTime { get; set; }
        public DateTime PickupTime { get; set; }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending; // Default status is Pending

        public string CancellationReason { get; set; }  
        public string StudentNotes { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public string PaymentTransactionID { get; set; }

        public FoodStall FoodStall { get; set; }  // navigation property

        // Navigation properties
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public QRCode QRCode { get; set; }
        public TimeSlot TimeSlot { get; set; }

        // Default constructor
        public Order() { }

        // Parameterized constructor
        public Order(int orderID, int studentID, FoodStall stall, decimal totalAmount, DateTime orderTime, int timeSlotID, DateTime pickupTime)
        {
            OrderID = orderID;
            StudentID = studentID;
            StallID = stall.StallID;
            FoodStall = stall;
            TotalAmount = totalAmount;
            OrderTime = orderTime;
            TimeSlotID = timeSlotID;
            PickupTime = pickupTime;

            // Initialize fields with defaults
            CancellationReason = "";        // empty string
            StudentNotes = "";              // empty string
            PaymentTransactionID = "";      // empty string

            OrderStatus = OrderStatus.Pending;      // enum default
            PaymentStatus = PaymentStatus.Unpaid;   // enum default

            Items = new List<OrderItem>();  // just in case
        }

        // Add order items
        public void AddOrderItem(OrderItem item)
        {
            if (item != null)
            {
                Items.Add(item);
            }
            else
            {
                throw new ArgumentNullException(nameof(item), "Order item cannot be null");
            }
        }

        public void DisplayOrderSummary()
        {
            Console.WriteLine($"\n=== Order Summary ===");
            Console.WriteLine($"Order ID: {OrderID}");
            Console.WriteLine($"Total Price: ${TotalAmount:F2}");
            Console.WriteLine($"Order Time: {OrderTime}");
            Console.WriteLine();
        }

        public float CalculateItemPrices()
        {
            float total = 0;
            foreach (var item in Items)
            {
                var menuItem = FoodStall.GetMenuItemById(item.MenuItemID);
                if (menuItem != null)
                {
                    total += menuItem.ItemPrice * item.Quantity;
                }
            }
            return total;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"OrderID: {OrderID}");
            sb.AppendLine($"StudentID: {StudentID}");
            sb.AppendLine($"StallID: {StallID}");
            sb.AppendLine($"TimeSlotID: {TimeSlotID}");
            sb.AppendLine($"TotalAmount: {TotalAmount:C}");
            sb.AppendLine($"OrderTime: {OrderTime}");
            sb.AppendLine($"PickupTime: {PickupTime}");
            sb.AppendLine($"OrderStatus: {OrderStatus}");
            sb.AppendLine($"CancellationReason: {CancellationReason}");
            sb.AppendLine($"StudentNotes: {StudentNotes}");
            sb.AppendLine($"PaymentStatus: {PaymentStatus}");
            sb.AppendLine($"PaymentTransactionID: {PaymentTransactionID}");

            if (QRCode != null)
            {
                sb.AppendLine("QRCode:");
                sb.AppendLine($"  QRCodeID: {QRCode.QRCodeID}");
                sb.AppendLine($"  GeneratedTime: {QRCode.GeneratedTime}");
                sb.AppendLine($"  ExpiryTime: {QRCode.ExpiryTime}");
                sb.AppendLine($"  CollectionStatus: {QRCode.CollectionStatus}");
            }
            else
            {
                sb.AppendLine("QRCode: None");
            }

            if (TimeSlot != null)
            {
                sb.AppendLine("TimeSlot:");
                sb.AppendLine($"  TimeSlotID: {TimeSlot.TimeSlotID}");
                sb.AppendLine($"  StartTime: {TimeSlot.StartTime}");
                sb.AppendLine($"  EndTime: {TimeSlot.EndTime}");
                sb.AppendLine($"  IsAvailable: {TimeSlot.IsAvailable}");
                sb.AppendLine($"  IsExclusive: {TimeSlot.IsExclusive}");
                sb.AppendLine($"  MaxOrders: {TimeSlot.MaxOrders}");
            }
            else
            {
                sb.AppendLine("TimeSlot: None");
            }

            if (Items != null && Items.Count > 0)
            {
                sb.AppendLine("Order Items:");
                foreach (var item in Items)
                {
                    sb.AppendLine($"  OrderItemID: {item.OrderItemID}, MenuItemID: {item.MenuItemID}, Quantity: {item.Quantity}");
                }
            }
            else
            {
                sb.AppendLine("Order Items: None");
            }

            return sb.ToString();
        }
        public void UpdateOrderStatus(OrderStatus newStatus, string? cancellationReason = null)
        {
            // Basic validation: don't allow setting to the same status
            if (OrderStatus == newStatus)
            {
                throw new InvalidOperationException("Order is already in the specified status.");
            }

            // If cancelling, store cancellation reason if provided
            if (newStatus == OrderStatus.Cancelled)
            {
                if (string.IsNullOrWhiteSpace(cancellationReason))
                {
                    throw new ArgumentException("Cancellation reason must be provided when cancelling an order.");
                }
                CancellationReason = cancellationReason.Trim();
            }
            else
            {
                // Clear cancellation reason if status moves away from Cancelled
                CancellationReason = string.Empty;
            }

            // Update the order status
            OrderStatus = newStatus;
        }


    }

}
