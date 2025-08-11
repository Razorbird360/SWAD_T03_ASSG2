using SWAD_ASSG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SWAD_ASSG
{
    class FoodStallStaff : User
    {
        public string StaffContact { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public string EmergencyContactNumber { get; set; }

        // Association: reference to the FoodStall this staff is affiliated with
        public FoodStall StallAffiliation { get; set; }

        public FoodStallStaff(string userID, string name, string email, string password,
                              string staffContact, DateTime dateOfEmployment,
                              string emergencyContactNumber, FoodStall stallAffiliation)
        {
            this.userID = userID;
            this.name = name;
            this.email = email;
            this.password = password;
            this.StaffContact = staffContact;
            this.DateOfEmployment = dateOfEmployment;
            this.EmergencyContactNumber = emergencyContactNumber;
            this.StallAffiliation = stallAffiliation;
        }
    }
}