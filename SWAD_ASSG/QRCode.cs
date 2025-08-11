using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_ASSG
{
    public enum CollectionStatus
    {
        NotCollected,
        Collected,
        Expired
    }
    class QRCode
    {
        public int QRCodeID { get; set; }
        public int OrderID { get; set; }
        public DateTime GeneratedTime { get; set; }
        public DateTime ExpiryTime { get; set; }
        public CollectionStatus CollectionStatus { get; set; }

        public Order Order { get; set; }

        public QRCode() { }

        public QRCode(int qrCodeID, int orderID, DateTime generatedTime, DateTime expiryTime, CollectionStatus collectionStatus)
        {
            QRCodeID = qrCodeID;
            OrderID = orderID;
            GeneratedTime = generatedTime;
            ExpiryTime = expiryTime;
            CollectionStatus = collectionStatus;
        }
    }
}
