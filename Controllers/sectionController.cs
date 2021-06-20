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
    public class sectionController : Controller
    {

        string connStr = ConfigurationManager.ConnectionStrings["ERPconnectionString"].ConnectionString;
        // GET: section


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
                    sectionModelModels.Bran_Dep_ID =sqlrdr["Bran_Dep_ID"].ToString();
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
            // var json = JsonConvert.SerializeObject(barList);  sectionModelList

            ViewBag.baranchModels = barList.ToArray();
            ViewBag.sectionModelLists = sectionModelList.ToArray();
            ViewBag.DepartmentModelList = DepartmentModelList.ToArray();
            ViewData["CountOfBaranchs"] = DepartmentModelList.LongCount();
            ViewData["CountOfBarancher"] = barList.LongCount();
            ViewData["CountOfSection"] = sectionModelList.LongCount();


            return PartialView();




        }

        // EditD

        // POST: StoreSection
        public ActionResult StoreSection(sectionModel baranch)
        {




            if (ModelState.IsValid)
            {
                using (SqlConnection sqlconn = new SqlConnection(connStr))
                {
                    SqlCommand sqlcmd = new SqlCommand("sp_SetSection", sqlconn);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter sqlprmOFSp = new SqlParameter("@Opr", "0");
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@SectionID", 25);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    //sqlprmOFSp = new SqlParameter("@BranchNo", 25);
                    //sqlcmd.Parameters.Add(sqlprmOFSp);

                    sqlprmOFSp = new SqlParameter("@SectionAR", baranch.SectionDescAR);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@SectionEN", baranch.SectionDescEN);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@BranhRp2Branch", baranch.Bran_Dep_ID);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@IsBranch", baranch.OrgType);
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








                return Redirect("/section");
            }



            return Redirect("/section");

        }


        // POST: EditS
        public ActionResult EditS(sectionModel baranch)
        {


            List<sectionModel> secList = new List<sectionModel>();


            using (SqlConnection sqlconn = new SqlConnection(connStr))


            {
                SqlCommand sqlcmd = new SqlCommand("sp_GetOrgSections", sqlconn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlprmOFSp = new SqlParameter("@SectionID", baranch.SectionID);
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
                    secList.Add(sectionModelModels);


                }

            }



            if (ModelState.IsValid)
            {


                using (SqlConnection sqlconn = new SqlConnection(connStr))
                {
                    SqlCommand sqlcmd = new SqlCommand("sp_SetSection", sqlconn);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter sqlprmOFSp = new SqlParameter("@Opr", "1");
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@SectionID", baranch.SectionID);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    //sqlprmOFSp = new SqlParameter("@BranchNo", 25);
                    //sqlcmd.Parameters.Add(sqlprmOFSp);

                    sqlprmOFSp = new SqlParameter("@SectionAR", baranch.SectionDescAR==null? secList[0].SectionDescAR:baranch.SectionDescAR);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@SectionEN", baranch.SectionDescEN == null ? secList[0].SectionDescEN : baranch.SectionDescEN);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@BranhRp2Branch", baranch.Bran_Dep_ID == null ? secList[0].Bran_Dep_ID : baranch.Bran_Dep_ID);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@IsBranch", baranch.OrgType == 0 ? secList[0].OrgType : baranch.OrgType);
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








                return Redirect("/section");
            }



            return Redirect("/section");

        }




    }
}