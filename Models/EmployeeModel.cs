using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace erp.Models
{
    public class EmployeeModel
    {

        public String EmpID { get; set; }
        public String ID_No { get; set; }
        public String DepartmentID { get; set; }
        public String BranchID { get; set; }
        public String SectionID { get; set; }
        public String FirstNameEN { get; set; }
        public String MidNameEN { get; set; }
        public String LastNameEN { get; set; }
        public String MotherNameEN { get; set; }
        public String FirstNameAR { get; set; }
        public String MidNameAR { get; set; }
        public String LastNameAR { get; set; }
        public String MotherNameAR { get; set; }
        public String Address { get; set; }
        public String PhoneNo { get; set; }
        public String LicenseDigreeID { get; set; }
        public String LicenseNameID { get; set; }
        public String GenderID { get; set; }
        public String BirthDate { get; set; }
        public String JoinDate { get; set; }
        public String CurrentLocation { get; set; }
        public String VicationBalance { get; set; }
        public String IsActive { get; set; }
        public String IsBlocked { get; set; }
        public String IsRetired { get; set; }
        public String EmergencyComtactName { get; set; }
        public String EmergencyPhoneNo { get; set; }
        public String LandLine { get; set; }
        public String MaritalStatusID { get; set; }
        public String ChildrenCount { get; set; }
        public String Notes { get; set; }
        public String MaturityDate { get; set; }
    
    }
}