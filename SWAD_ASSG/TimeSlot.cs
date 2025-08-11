using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_ASSG
{
    class TimeSlot
    {
        public int TimeSlotID { get; set; }
        public int StallID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsExclusive { get; set; }
        public int MaxOrders { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();

        public TimeSlot() { }

        public TimeSlot(int timeSlotID, int stallID, DateTime startTime, DateTime endTime,
                        bool isAvailable, bool isExclusive, int maxOrders)
        {
            TimeSlotID = timeSlotID;
            StallID = stallID;
            StartTime = startTime;
            EndTime = endTime;
            IsAvailable = isAvailable;
            IsExclusive = isExclusive;
            MaxOrders = maxOrders;
        }
    }
}
