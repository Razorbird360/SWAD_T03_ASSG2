using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_ASSG
{
    public abstract class Configuration
    {
        public string ConfigID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsActive { get; set; }

        protected Configuration(string configID)
        {
            ConfigID = configID;
            CreatedDate = DateTime.Now;
            LastModified = DateTime.Now;
            IsActive = true;
        }

        public virtual void UpdateConfiguration()
        {
            LastModified = DateTime.Now;
        }
    }
}
