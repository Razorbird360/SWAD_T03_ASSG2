using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_ASSG
{
    public class SuspensionThreshold : Configuration
    {
        public string UserType { get; set; }
        public int NoShowLimit { get; set; }
        public int TimeFrame { get; set; }
        public int SuspensionDuration { get; set; }
        public bool GraceEnabled { get; set; }
        public string EscalationRules { get; set; }

        public SuspensionThreshold(string configID, string userType, int noShowLimit,
                                 int timeFrame, int suspensionDuration, bool graceEnabled,
                                 string escalationRules) : base(configID)
        {
            UserType = userType;
            NoShowLimit = noShowLimit;
            TimeFrame = timeFrame;
            SuspensionDuration = suspensionDuration;
            GraceEnabled = graceEnabled;
            EscalationRules = escalationRules;
        }

        public bool ShouldSuspendUser(int currentNoShows, bool isNewUser)
        {
            if (GraceEnabled && isNewUser)
            {
                Console.WriteLine($"Grace period applied for new {UserType} user");
                return false;
            }

            bool shouldSuspend = currentNoShows >= NoShowLimit;
            if (shouldSuspend)
            {
                Console.WriteLine($"Suspension triggered: {currentNoShows} no-shows >= {NoShowLimit} limit for {UserType}");
            }

            return shouldSuspend;
        }

        public void UpdateThreshold(int newNoShowLimit, int newTimeFrame, int newSuspensionDuration)
        {
            NoShowLimit = newNoShowLimit;
            TimeFrame = newTimeFrame;
            SuspensionDuration = newSuspensionDuration;
            UpdateConfiguration();
            Console.WriteLine($"Suspension threshold updated for {UserType}: {NoShowLimit} no-shows in {TimeFrame} days = {SuspensionDuration} day suspension");
        }
    }
}
