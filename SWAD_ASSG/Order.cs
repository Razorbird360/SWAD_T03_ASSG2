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
        public DateTime? PickupTime { get; set; }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending; // Default status is Pending

        public string CancellationReason { get; set; }  
        public string StudentNotes { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentTransactionID { get; set; }

        public FoodStall FoodStall { get; set; }  // navigation property

        // Navigation properties
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public QRCode QRCode { get; set; }
        public TimeSlot TimeSlot { get; set; }

        // Default constructor
        public Order() { }

        // Parameterized constructor
        public Order(int orderID, int studentID, int stallID, int timeSlotID, decimal totalAmount,
                     DateTime orderTime, DateTime? pickupTime, OrderStatus orderStatus, string cancellationReason,
                     string studentNotes, PaymentStatus paymentStatus, string paymentTransactionID)
        {
            OrderID = orderID;
            StudentID = studentID;
            StallID = stallID;
            TimeSlotID = timeSlotID;
            TotalAmount = totalAmount;
            OrderTime = orderTime;
            PickupTime = pickupTime;
            OrderStatus = orderStatus;
            CancellationReason = cancellationReason;
            StudentNotes = studentNotes;
            PaymentStatus = paymentStatus.ToString();
            PaymentTransactionID = paymentTransactionID;
        }




    }
}
