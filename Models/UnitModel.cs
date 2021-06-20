using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace erp.Models
{
    public class UnitModel
    {


        // OrgUnitID	OrgUnitNameAR	OrgUnitNameEN	SectionID	SectionAR	IsActive	strIsActive	B2MasterID	OrgType	strOrgType	MainMasterID
        public int OrgUnitID { get; set; }
        public String OrgUnitNameAR { get; set; }
        public String OrgUnitNameEN { get; set; }
        public int SectionID { get; set; }

        public String SectionAR { get; set; }

        public int IsActive { get; set; }

        public String strIsActive { get; set; }

        public String B2MasterID { get; set; }

        public int OrgType { get; set; }
        public String strOrgType { get; set; }

        public int MainMasterID { get; set; }
    }
}