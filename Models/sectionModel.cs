using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace erp.Models
{
    public class sectionModel
    {



        // SectionID	SectionDescEN	SectionDescAR	DepartmentID	DepartmentDescAR	IsActive	strIsActive	 Bran_Dep_ID 	OrgType	 strOrgType
        public int SectionID { get; set; }
        public String SectionDescAR { get; set; }
        public String SectionDescEN { get; set; }
        public int DepartmentID { get; set; }

        public String DepartmentDescAR { get; set; }

        public int IsActive { get; set; }

        public String strIsActive { get; set; }

        public String Bran_Dep_ID { get; set; }

        public int OrgType { get; set; }
        public String strOrgType { get; set; }

    }


}