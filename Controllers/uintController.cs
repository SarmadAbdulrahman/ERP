using erp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace erp.Controllers
{
    public class uintController : Controller
    {


        string connStr = ConfigurationManager.ConnectionStrings["ERPconnectionString"].ConnectionString;
       

        // GET: uint
        public ActionResult Index()
        {



            //       barList = List<BaranchModels>;
            List<DepartmentModel> DepartmentModelList = new List<DepartmentModel>();

            List<sectionModel> sectionModelList = new List<sectionModel>();


            //  List<BaranchByUperLevel> BaranchByUperLevelList = new List<BaranchByUperLevel>();


            /***
           * this is for get count of sp_GetOrgDepartment
           * 
           */

            using (SqlConnection sqlconn = new SqlConnection(connStr))
            {
                SqlCommand sqlcmd = new SqlCommand("sp_GetOrgDepartment", sqlconn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlprmOFSp = new SqlParameter("@DepartmentID", "0");
                sqlcmd.Parameters.Add(sqlprmOFSp);
                sqlconn.Open();
                SqlDataReader sqlrdr = sqlcmd.ExecuteReader();
                while (sqlrdr.Read())
                {// BranchID  CanBeDeactivated
                    DepartmentModel DepartmentModels = new DepartmentModel();
                    DepartmentModels.DepartmentDescAR = sqlrdr["DepartmentDescAR"].ToString();
                    DepartmentModels.DepartmentID = Int16.Parse(sqlrdr["DepartmentID"].ToString());
                    DepartmentModels.DepartmentDescEN = sqlrdr["DepartmentDescEN"].ToString();
                    //DepartmentModels.IsHO = Int16.Parse(sqlrdr["IsHO"].ToString());
                    //DepartmentModels.IsHO = Int16.Parse(sqlrdr["IsHO"].ToString());
                    //DepartmentModels.CEOAssetID = Int16.Parse(sqlrdr["CEOAssetID"].ToString());
                    //DepartmentModels.IsActive = Int16.Parse(sqlrdr["IsActive"].ToString());
                    //DepartmentModels.strIsActive = Int16.Parse(sqlrdr["strIsActive"].ToString());
                    // CanBeDeactivated
                    DepartmentModels.BranchDescEN = sqlrdr["BranchDescEN"].ToString();
                    DepartmentModels.BranchDescAR = sqlrdr["BranchDescAR"].ToString();
                    // DepartmentModels.CanBeDeactivated = sqlrdr["CanBeDeactivated"].ToString();
                    DepartmentModels.CanBeDeactivated = sqlrdr["CanBeDeactivated"].ToString();
                    //   var cc = sqlrdr["BranchDescAR"];
                    DepartmentModelList.Add(DepartmentModels);

                }

            }





            /***
         * this is for get count of [sp_GetOrgSections]
         * 
         */

            using (SqlConnection sqlconn = new SqlConnection(connStr))


            {
                SqlCommand sqlcmd = new SqlCommand("sp_GetOrgSections", sqlconn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlprmOFSp = new SqlParameter("@SectionID", "0");
                sqlcmd.Parameters.Add(sqlprmOFSp);
                sqlconn.Open();
                SqlDataReader sqlrdr = sqlcmd.ExecuteReader();
                while (sqlrdr.Read())
                {// BranchID  CanBeDeactivated


                    sectionModel sectionModelModels = new sectionModel();
                    sectionModelModels.SectionID = Int16.Parse(sqlrdr["SectionID"].ToString());
                    sectionModelModels.DepartmentDescAR = sqlrdr["DepartmentDescAR"].ToString();
                    sectionModelModels.SectionDescAR = sqlrdr["SectionDescAR"].ToString();
                    sectionModelModels.SectionDescEN = sqlrdr["SectionDescEN"].ToString();
                    sectionModelModels.strOrgType = sqlrdr["strOrgType"].ToString();
                    sectionModelModels.OrgType = Int16.Parse(sqlrdr["OrgType"].ToString());
                    sectionModelModels.DepartmentID = Int16.Parse(sqlrdr["DepartmentID"].ToString());
                    sectionModelModels.Bran_Dep_ID = sqlrdr["Bran_Dep_ID"].ToString();
                    sectionModelList.Add(sectionModelModels);


                }

            }






            //  List<BaranchByUperLevel> BaranchByUperLevelList = new List<BaranchByUperLevel>();



            /***
             * this is for get count of barnch
             * 
             */

            List<BaranchModels> barList = new List<BaranchModels>();

            using (SqlConnection sqlconn = new SqlConnection(connStr))
            {
                SqlCommand sqlcmd = new SqlCommand("sp_GetOrgBranchs", sqlconn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlprmOFSp = new SqlParameter("@Mstr", "1");
                sqlcmd.Parameters.Add(sqlprmOFSp);
                sqlconn.Open();
                SqlDataReader sqlrdr = sqlcmd.ExecuteReader();
                while (sqlrdr.Read())
                {// BranchID  CanBeDeactivated
                    BaranchModels baranchModels = new BaranchModels();
                    baranchModels.Name = sqlrdr["BranchDescAR"].ToString();
                    baranchModels.BelongTo = sqlrdr["MasterBranchAR"].ToString();
                    baranchModels.BranchNo = Int16.Parse(sqlrdr["BranchNo"].ToString());
                    baranchModels.BranchID = Int16.Parse(sqlrdr["BranchID"].ToString());
                    baranchModels.Address = sqlrdr["BranchDescEN"].ToString();
                    baranchModels.CanBeDeactivated = sqlrdr["CanBeDeactivated"].ToString();
                    baranchModels.BranchReadOnly = sqlrdr["BranchReadOnly"].ToString();
                    //   var cc = sqlrdr["BranchDescAR"];
                    barList.Add(baranchModels);

                }

            }








            /***
         * this is for get count of unit
         * 
         */

            List<UnitModel> unitList = new List<UnitModel>();

            using (SqlConnection sqlconn = new SqlConnection(connStr))
            {
                SqlCommand sqlcmd = new SqlCommand("sp_GetOrgUnits", sqlconn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlprmOFSp = new SqlParameter("@OrgUnitID", "0");
                sqlcmd.Parameters.Add(sqlprmOFSp);
                sqlconn.Open();
                SqlDataReader sqlrdr = sqlcmd.ExecuteReader();
                while (sqlrdr.Read())
                {// BranchID  CanBeDeactivated
                    UnitModel UnitModels = new UnitModel();
                    //baranchModels.Name = sqlrdr["BranchDescAR"].ToString();
                    //baranchModels.BelongTo = sqlrdr["MasterBranchAR"].ToString();
                    //baranchModels.BranchNo = Int16.Parse(sqlrdr["BranchNo"].ToString());
                    //baranchModels.BranchID = Int16.Parse(sqlrdr["BranchID"].ToString());
                    //baranchModels.Address = sqlrdr["BranchDescEN"].ToString();
                    //baranchModels.CanBeDeactivated = sqlrdr["CanBeDeactivated"].ToString();
                    //baranchModels.BranchReadOnly = sqlrdr["BranchReadOnly"].ToString();
                    //   var cc = sqlrdr["BranchDescAR"];
                    UnitModels.OrgUnitNameAR = sqlrdr["OrgUnitNameAR"].ToString();
                    UnitModels.OrgUnitNameEN = sqlrdr["OrgUnitNameEN"].ToString();
                    UnitModels.OrgUnitID = Int16.Parse(sqlrdr["OrgUnitID"].ToString());
                    UnitModels.strOrgType = sqlrdr["strOrgType"].ToString();
                    UnitModels.SectionAR = sqlrdr["SectionAR"].ToString();
                   // UnitModels. = sqlrdr["SectionAR"].ToString();

                    unitList.Add(UnitModels);

                }

            }













            ViewBag.baranchModels = barList.ToArray();
            ViewBag.sectionModelLists = sectionModelList.ToArray();
            ViewBag.UnitModels = unitList.ToArray();
            ViewBag.DepartmentModelList = DepartmentModelList.ToArray();
            ViewData["CountOfBaranchs"] = DepartmentModelList.LongCount();
            ViewData["CountOfBarancher"] = barList.LongCount();
            ViewData["CountOfSection"] = sectionModelList.LongCount();


            return PartialView();




        }



        // POST: StoreU
        public ActionResult StoreU(UnitModel Unit)
        {




            if (ModelState.IsValid)
            {
                using (SqlConnection sqlconn = new SqlConnection(connStr))
                {
                    SqlCommand sqlcmd = new SqlCommand("sp_SetOrgUnit", sqlconn);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter sqlprmOFSp = new SqlParameter("@Opr", "0");
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@OrgUnitID", 25);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
               
                    sqlprmOFSp = new SqlParameter("@OrgUnitNameAR", Unit.OrgUnitNameAR);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@OrgUnitNameEN", Unit.OrgUnitNameEN);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@BranhRp2Branch", Unit.B2MasterID);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@IsBranch", Unit.OrgType);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@IsActive", 1);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@Result", System.Data.SqlDbType.Int);
                    sqlprmOFSp.Direction = ParameterDirection.Output;

                    sqlcmd.Parameters.Add(sqlprmOFSp);

                    sqlconn.Open();
                    sqlcmd.ExecuteNonQuery();
                    var strResult = sqlcmd.Parameters["@Result"].Value.ToString();
                    sqlconn.Close();

                }








                return Redirect("/uint");
            }



            return Redirect("/uint");

        }




        // POST: EditU
        public ActionResult EditU(UnitModel Unit)
        {


           // List<UnitModel> UnitModelList = new List<UnitModel>();


            List<UnitModel> unitList = new List<UnitModel>();

            using (SqlConnection sqlconn = new SqlConnection(connStr))
            {
                SqlCommand sqlcmd = new SqlCommand("sp_GetOrgUnits", sqlconn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlprmOFSp = new SqlParameter("@OrgUnitID", Unit.OrgUnitID);
                sqlcmd.Parameters.Add(sqlprmOFSp);
                sqlconn.Open();
                SqlDataReader sqlrdr = sqlcmd.ExecuteReader();
                while (sqlrdr.Read())
                {// BranchID  CanBeDeactivated
                    UnitModel UnitModels = new UnitModel();
                    UnitModels.OrgUnitNameAR = sqlrdr["OrgUnitNameAR"].ToString();
                    UnitModels.OrgUnitNameEN = sqlrdr["OrgUnitNameEN"].ToString();
                    UnitModels.OrgUnitID = Int16.Parse(sqlrdr["OrgUnitID"].ToString());
                    UnitModels.strOrgType = sqlrdr["strOrgType"].ToString();
                    UnitModels.SectionAR = sqlrdr["SectionAR"].ToString();
                    // UnitModels. = sqlrdr["SectionAR"].ToString();

                    unitList.Add(UnitModels);

                }

            }




                using (SqlConnection sqlconn = new SqlConnection(connStr))
                {
                    SqlCommand sqlcmd = new SqlCommand("sp_SetOrgUnit", sqlconn);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter sqlprmOFSp = new SqlParameter("@Opr", "1");
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@OrgUnitID", Unit.OrgUnitID);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@OrgUnitNameAR", Unit.OrgUnitNameAR == null ? unitList[0].OrgUnitNameAR : Unit.OrgUnitNameAR);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@OrgUnitNameEN", Unit.OrgUnitNameEN == null ? unitList[0].OrgUnitNameEN : Unit.OrgUnitNameEN);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@BranhRp2Branch", Unit.B2MasterID == null ? unitList[0].B2MasterID : Unit.B2MasterID);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@IsBranch", Unit.OrgType == 0 ? unitList[0].OrgType : Unit.OrgType);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@IsActive", 1);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@Result", System.Data.SqlDbType.Int);
                    sqlprmOFSp.Direction = ParameterDirection.Output;

                    sqlcmd.Parameters.Add(sqlprmOFSp);

                    sqlconn.Open();
                    sqlcmd.ExecuteNonQuery();
                    var strResult = sqlcmd.Parameters["@Result"].Value.ToString();
                    sqlconn.Close();

                }








                return Redirect("/uint");
            }





 

    }
}