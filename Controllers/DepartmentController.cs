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
    public class DepartmentController : Controller
    {
        string connStr = ConfigurationManager.ConnectionStrings["ERPconnectionString"].ConnectionString;

        // GET: Department
        public ActionResult Index()
        {



            //       barList = List<BaranchModels>;
            List<DepartmentModel> DepartmentModelList = new List<DepartmentModel>();




          //  List<BaranchByUperLevel> BaranchByUperLevelList = new List<BaranchByUperLevel>();




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
                    DepartmentModels.CanBeDeactivated =sqlrdr["CanBeDeactivated"].ToString();
                    //   var cc = sqlrdr["BranchDescAR"];
                    DepartmentModelList.Add(DepartmentModels);

                }

            }



            List<BaranchModels> barList = new List<BaranchModels>();




          //  List<BaranchByUperLevel> BaranchByUperLevelList = new List<BaranchByUperLevel>();




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



            // var json = JsonConvert.SerializeObject(barList);

            ViewBag.baranchModels = barList.ToArray();

            ViewBag.DepartmentModelList = DepartmentModelList.ToArray();
            ViewData["CountOfBaranchs"] = DepartmentModelList.LongCount();
            ViewData["CountOfBarancher"] = barList.LongCount();
            return PartialView();




        }



        // POST: StoreDepartment
        public ActionResult StoreDepartment(DepartmentModel DepartmentModel)
        {


            if (ModelState.IsValid)
            {
                using (SqlConnection sqlconn = new SqlConnection(connStr))
                {
                    SqlCommand sqlcmd = new SqlCommand("sp_SetDepartment", sqlconn);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter sqlprmOFSp = new SqlParameter("@Opr", "0");
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@BranhRp2Branch", DepartmentModel.Branch_ID);
                    sqlcmd.Parameters.Add(sqlprmOFSp);


    
                    sqlprmOFSp = new SqlParameter("@DeparmentID", "0");
                    sqlcmd.Parameters.Add(sqlprmOFSp);


                    sqlprmOFSp = new SqlParameter("@DepartemntAR", DepartmentModel.DepartmentDescAR);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@DepartemntEN", DepartmentModel.DepartmentDescEN);
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

            }


            return Redirect("/department");
        }





        // POST: StoperD
        public ActionResult StoperD(DepartmentModel baranch)
        {


            List<DepartmentModel> DepartmentModelList = new List<DepartmentModel>();




            //  List<BaranchByUperLevel> BaranchByUperLevelList = new List<BaranchByUperLevel>();




            using (SqlConnection sqlconn = new SqlConnection(connStr))
            {
                SqlCommand sqlcmd = new SqlCommand("sp_GetOrgDepartment", sqlconn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlprmOFSp = new SqlParameter("@DepartmentID", baranch.DepartmentID);
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

                    DepartmentModels.Branch_ID = Int16.Parse(sqlrdr["Branch_ID"].ToString());
                    DepartmentModels.BranchDescAR = sqlrdr["BranchDescAR"].ToString();
                    // DepartmentModels.CanBeDeactivated = sqlrdr["CanBeDeactivated"].ToString();
                    DepartmentModels.CanBeDeactivated = sqlrdr["CanBeDeactivated"].ToString();
                    //   var cc = sqlrdr["BranchDescAR"];
                    DepartmentModelList.Add(DepartmentModels);

                }

            }





            if (ModelState.IsValid)
            {


                using (SqlConnection sqlconn = new SqlConnection(connStr))
                {
                    SqlCommand sqlcmd = new SqlCommand("sp_SetDepartment", sqlconn);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter sqlprmOFSp = new SqlParameter("@Opr", "1");
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@BranhRp2Branch", DepartmentModelList[0].Branch_ID);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@DeparmentID", DepartmentModelList[0].DepartmentID);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@DepartemntAR", DepartmentModelList[0].DepartmentDescAR);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@DepartemntEN", DepartmentModelList[0].DepartmentDescEN);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@IsActive", "0");
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@Result", System.Data.SqlDbType.Int);
                    sqlprmOFSp.Direction = ParameterDirection.Output;

                    sqlcmd.Parameters.Add(sqlprmOFSp);

                    sqlconn.Open();
                    sqlcmd.ExecuteNonQuery();
                    var strResult = sqlcmd.Parameters["@Result"].Value.ToString();
                    sqlconn.Close();

                }


                return Redirect("/department");
            }



            return Redirect("/department");

        }




        // POST: EditD
        public ActionResult EditD(DepartmentModel baranch)
        {


            List<DepartmentModel> DepartmentModelList = new List<DepartmentModel>();




            //  List<BaranchByUperLevel> BaranchByUperLevelList = new List<BaranchByUperLevel>();




            using (SqlConnection sqlconn = new SqlConnection(connStr))
            {
                SqlCommand sqlcmd = new SqlCommand("sp_GetOrgDepartment", sqlconn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlprmOFSp = new SqlParameter("@DepartmentID", baranch.DepartmentID);
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

                    DepartmentModels.Branch_ID = Int16.Parse(sqlrdr["Branch_ID"].ToString());
                    DepartmentModels.BranchDescAR = sqlrdr["BranchDescAR"].ToString();
                    // DepartmentModels.CanBeDeactivated = sqlrdr["CanBeDeactivated"].ToString();
                    DepartmentModels.CanBeDeactivated = sqlrdr["CanBeDeactivated"].ToString();
                    //   var cc = sqlrdr["BranchDescAR"];
                    DepartmentModelList.Add(DepartmentModels);

                }

            }







                using (SqlConnection sqlconn = new SqlConnection(connStr))
                {
                    SqlCommand sqlcmd = new SqlCommand("sp_SetDepartment", sqlconn);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter sqlprmOFSp = new SqlParameter("@Opr", "1");
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@BranhRp2Branch", baranch.Branch_ID==0?DepartmentModelList[0].Branch_ID:baranch.Branch_ID);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@DeparmentID", DepartmentModelList[0].DepartmentID);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@DepartemntAR", baranch.DepartmentDescAR==null?DepartmentModelList[0].DepartmentDescAR: baranch.DepartmentDescAR);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@DepartemntEN", baranch.DepartmentDescEN == null ? DepartmentModelList[0].DepartmentDescEN : baranch.DepartmentDescEN);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@IsActive", "1");
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@Result", System.Data.SqlDbType.Int);
                    sqlprmOFSp.Direction = ParameterDirection.Output;

                    sqlcmd.Parameters.Add(sqlprmOFSp);

                    sqlconn.Open();
                    sqlcmd.ExecuteNonQuery();
                    var strResult = sqlcmd.Parameters["@Result"].Value.ToString();
                    sqlconn.Close();

                }


                return Redirect("/department");
     ;



        }





    }
}