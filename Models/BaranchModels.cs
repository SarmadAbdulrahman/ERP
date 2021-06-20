using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace erp.Models
{
    public class BaranchModels
    {


        //  [StringLength(60, MinimumLength = 3)]   BranchNo  BranchID
        public string Name { get; set; }

       // [StringLength(60, MinimumLength = 3)]  
        public string Address { get; set; }

        public string BelongTo { get; set; }


        public int BranchNo { get; set; }

        public int BranchID { get; set; }


        public int Level { get; set; }
        public int BranchMasterID { get; set; }

        // BranchMasterID

        public string CanBeDeactivated { get; set; }

        public string BranchReadOnly { get; set; }



    }
}