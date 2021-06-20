using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace erp.Models
{
    public class DepartmentModel
    {

        // DepartmentID	DepartmentDescAR	DepartmentDescEN	Branch_ID	BranchDescAR	BranchDescEN	
        //IsHO	CEOAssetID	IsActive	strIsActive

        public int DepartmentID { get; set; }
        public int Branch_ID { get; set; }
        public String DepartmentDescAR { get; set; }
        public String DepartmentDescEN { get; set; }
        public String BranchDescAR { get; set; }
        public String BranchDescEN { get; set; }
  
        public int IsHO { get; set; }
        public int CEOAssetID { get; set; }
        public int IsActive { get; set; }
        public int strIsActive { get; set; }

        public String CanBeDeactivated { get; set; }


    }
}