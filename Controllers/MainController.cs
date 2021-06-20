using erp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace erp.Controllers
{

  

    public class MainController : Controller
    {
        string connStr = ConfigurationManager.ConnectionStrings["ERPconnectionString"].ConnectionString;
        // GET: Main
        public ActionResult Index()
        {





            List<DepartmentModel> DepartmentModelList = new List<DepartmentModel>();


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















            //       barList = List<BaranchModels>;
            List<BaranchModels> barList = new List<BaranchModels>();




            List<BaranchByUperLevel> BaranchByUperLevelList = new List<BaranchByUperLevel>();




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

            using (SqlConnection sqlconn2 = new SqlConnection(connStr))
            {
                SqlCommand sqlcmd = new SqlCommand("sp_OrgLevels", sqlconn2);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlprmOFSp = new SqlParameter("@OrgLvlID", "0");
                sqlcmd.Parameters.Add(sqlprmOFSp);
                sqlconn2.Open();
                SqlDataReader sqlrdr = sqlcmd.ExecuteReader();
                while (sqlrdr.Read())
                {// BranchID  CanBeDeactivated
                    BaranchByUperLevel BaranchByUperLevelModels = new BaranchByUperLevel();
                    BaranchByUperLevelModels.text = sqlrdr["OrgLvlAR"].ToString();

                    BaranchByUperLevelModels.id = Int16.Parse(sqlrdr["OrgLvlID"].ToString());

                    //   var cc = sqlrdr["BranchDescAR"];
                    BaranchByUperLevelList.Add(BaranchByUperLevelModels);

                }

            }




            List<BaranchByUperLevel> GetLicenseNamet = new List<BaranchByUperLevel>();

            using (SqlConnection sqlconn = new SqlConnection(connStr))
            {
                SqlCommand sqlcmd = new SqlCommand("sp_GetLicenseName", sqlconn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlprmOFSp = new SqlParameter("@LicenseNameID", "0");
                sqlcmd.Parameters.Add(sqlprmOFSp);
                sqlconn.Open();
                SqlDataReader sqlrdr = sqlcmd.ExecuteReader();
                while (sqlrdr.Read())
                {// BranchID  CanBeDeactivated
                    BaranchByUperLevel baranchModels = new BaranchByUperLevel();
                    baranchModels.text = sqlrdr["LicenseNameAR"].ToString();
                    baranchModels.id = Int16.Parse(sqlrdr["LicenseNameID"].ToString());

                    GetLicenseNamet.Add(baranchModels);

                }

            }







                // var json = JsonConvert.SerializeObject(barList);
                // GetLicenseNamet



                    ViewBag.baranchModels = barList.ToArray();
                   ViewBag.GetLicenseNamet = GetLicenseNamet.ToArray();
                  ViewBag.BaranchByUperLevel = BaranchByUperLevelList.ToArray();
                  ViewData["CountOfBaranchs"] = barList.LongCount();
                ViewData["CountOfBarancher"] = DepartmentModelList.LongCount();
            return PartialView();

         //   }



 }


        // POST: StoreB
        public ActionResult StoreB(BaranchModels baranch)
        {




            if (ModelState.IsValid)
            {
                using (SqlConnection sqlconn = new SqlConnection(connStr))
                {
                    SqlCommand sqlcmd = new SqlCommand("sp_SetBranchs1", sqlconn);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter sqlprmOFSp = new SqlParameter("@Opr","0");
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@BranchID", 25);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@BranchNo", 25);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@BranchNameAR", baranch.Name);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@BranchNameEN", baranch.Name);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@BranhRp2Branch", baranch.BelongTo);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@BLvl", baranch.Level);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@IsActive", 1);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@Result", System.Data.SqlDbType.Int);
                    sqlprmOFSp.Direction = ParameterDirection.Output;

                    sqlcmd.Parameters.Add(sqlprmOFSp);

                    sqlconn.Open();
                    sqlcmd.ExecuteNonQuery();
                  var  strResult = sqlcmd.Parameters["@Result"].Value.ToString();
                    sqlconn.Close();

                }








                return Redirect("/main");
            }



                return Redirect("/main");

        }




        // POST: EditB
        public ActionResult EditB(BaranchModels baranch)
        {


            List<BaranchModels> barList = new List<BaranchModels>();

            using (SqlConnection sqlconn = new SqlConnection(connStr))
            {
                SqlCommand sqlcmd = new SqlCommand("sp_GetOrgBranchs", sqlconn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlprmOFSp = new SqlParameter("@Mstr", baranch.BranchID);
                sqlcmd.Parameters.Add(sqlprmOFSp);
                sqlconn.Open();
                SqlDataReader sqlrdr = sqlcmd.ExecuteReader();
                while (sqlrdr.Read())
                {// BranchID  CanBeDeactivated
                    BaranchModels baranchModels = new BaranchModels();
                    baranchModels.Name = sqlrdr["BranchDescAR"].ToString();
                    baranchModels.BelongTo = sqlrdr["BranchMasterID"].ToString();
                    baranchModels.BranchNo = Int16.Parse(sqlrdr["BranchNo"].ToString());
                    baranchModels.BranchID = Int16.Parse(sqlrdr["BranchID"].ToString());
                    baranchModels.Address = sqlrdr["BranchDescEN"].ToString();
                    baranchModels.CanBeDeactivated = sqlrdr["CanBeDeactivated"].ToString();
                    baranchModels.BranchReadOnly = sqlrdr["BranchReadOnly"].ToString();
                    //   var cc = sqlrdr["BranchDescAR"];
                    barList.Add(baranchModels);

                }

            }



            if (ModelState.IsValid)
            {
                using (SqlConnection sqlconn = new SqlConnection(connStr))
                {
                    SqlCommand sqlcmd = new SqlCommand("sp_SetBranchs1", sqlconn);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter sqlprmOFSp = new SqlParameter("@Opr", "1");
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@BranchID", baranch.BranchID);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@BranchNo", baranch.BranchID);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@BranchNameAR", baranch.Name == null ? barList[0].Name : baranch.Name);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@BranchNameEN", baranch.Address == null? barList[0].Address : baranch.Address);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@BranhRp2Branch", baranch.BelongTo==null? barList[0].BelongTo:baranch.BelongTo);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@BLvl", baranch.Level==0?barList[0].Level:baranch.Level);
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








                return Redirect("/main");
            }



            return Redirect("/main");

        }






        // POST: Stoper
        public ActionResult Stoper(BaranchModels baranch)
        {


            List<BaranchModels> barList = new List<BaranchModels>();

            using (SqlConnection sqlconn = new SqlConnection(connStr))
            {
                SqlCommand sqlcmd = new SqlCommand("sp_GetOrgBranchs", sqlconn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlprmOFSp = new SqlParameter("@Mstr", baranch.BranchID);
                sqlcmd.Parameters.Add(sqlprmOFSp);
                sqlconn.Open();
                SqlDataReader sqlrdr = sqlcmd.ExecuteReader();
                while (sqlrdr.Read())
                {// BranchID  CanBeDeactivated
                    BaranchModels baranchModels = new BaranchModels();
                    baranchModels.Name = sqlrdr["BranchDescAR"].ToString();
                    baranchModels.BelongTo = sqlrdr["BranchMasterID"].ToString();
                    baranchModels.BranchNo = Int16.Parse(sqlrdr["BranchNo"].ToString());
                    baranchModels.BranchID = Int16.Parse(sqlrdr["BranchID"].ToString());
                    baranchModels.Address = sqlrdr["BranchDescEN"].ToString();
                    baranchModels.CanBeDeactivated = sqlrdr["CanBeDeactivated"].ToString();
                    baranchModels.BranchReadOnly = sqlrdr["BranchReadOnly"].ToString();
                    //   var cc = sqlrdr["BranchDescAR"];
                    barList.Add(baranchModels);

                }

            }





                if (ModelState.IsValid)
            {
                using (SqlConnection sqlconn = new SqlConnection(connStr))
                {
                    SqlCommand sqlcmd = new SqlCommand("sp_SetBranchs1", sqlconn);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter sqlprmOFSp = new SqlParameter("@Opr", "1");
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@BranchID", baranch.BranchID);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@BranchNo", baranch.BranchID);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@BranchNameAR", barList[0].Name);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@BranchNameEN", barList[0].Address);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@BranhRp2Branch", barList[0].BelongTo);
                    sqlcmd.Parameters.Add(sqlprmOFSp);
                    sqlprmOFSp = new SqlParameter("@BLvl", barList[0].Level);
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








                return Redirect("/main");
            }



            return Redirect("/main");

        }




        // 
        // GET: GetDataBaranchByUperLevel
        public ActionResult GetDataBaranchByUperLevel(int type)
        {


            //       barList = List<BaranchModels>;

         //  list<String>  Body=new Lis;
            List<BaranchByUperLevel> BaranchByUperLevelist = new List<BaranchByUperLevel>();

            using (SqlConnection sqlconn = new SqlConnection(connStr))
            {
                SqlCommand sqlcmd = new SqlCommand("sp_BranchUpperLvl", sqlconn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlprmOFSp = new SqlParameter("@Blvl", type);
                sqlcmd.Parameters.Add(sqlprmOFSp);
                sqlconn.Open();
                SqlDataReader sqlrdr = sqlcmd.ExecuteReader();
                while (sqlrdr.Read())
                {// BranchID  CanBeDeactivated
                    BaranchByUperLevel baranchModels = new BaranchByUperLevel();
                    baranchModels.text = sqlrdr["VALUE"].ToString();
                    baranchModels.id = Int16.Parse(sqlrdr["ID"].ToString());

                    BaranchByUperLevelist.Add(baranchModels);

                }

                //  Body.Add();

                string json = JsonConvert.SerializeObject(new
                {
                    results = BaranchByUperLevelist
                });

                //   var json = JsonConvert.SerializeObject(""BaranchByUperLevelist);

                //   var resultsz = JsonConvert.DeserializeObject(json);


                return Content(json);

            }

        }





        // 
        // GET: GetDataBaranchAll
        public ActionResult GetDataBaranchAll(int type)
        {


            //       barList = List<BaranchModels>;

            //  list<String>  Body=new Lis;
            List<BaranchByUperLevel> BaranchByUperLevelist = new List<BaranchByUperLevel>();

            using (SqlConnection sqlconn = new SqlConnection(connStr))
            {
                SqlCommand sqlcmd = new SqlCommand("sp_GetOrgBranchs", sqlconn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlprmOFSp = new SqlParameter("@Mstr", type);
                sqlcmd.Parameters.Add(sqlprmOFSp);
                sqlconn.Open();
                SqlDataReader sqlrdr = sqlcmd.ExecuteReader();
                while (sqlrdr.Read())
                {// BranchID  CanBeDeactivated
                    BaranchByUperLevel baranchModels = new BaranchByUperLevel();
                     baranchModels.text = sqlrdr["BranchDescAR"].ToString();
                    baranchModels.id = Int16.Parse(sqlrdr["BranchID"].ToString());

                    BaranchByUperLevelist.Add(baranchModels);

                }

                //  Body.Add();

                string json = JsonConvert.SerializeObject(new
                {
                    results = BaranchByUperLevelist
                });

                //   var json = JsonConvert.SerializeObject(""BaranchByUperLevelist);

                //   var resultsz = JsonConvert.DeserializeObject(json);


                return Content(json);

            }

        }





        // 
        // GET: GetDataSectionsAll
        public ActionResult GetDataSectionsAll(int type)
        {


            //       barList = List<BaranchModels>;

            //  list<String>  Body=new Lis;
            List<BaranchByUperLevel> BaranchByUperLevelist = new List<BaranchByUperLevel>();

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
                    BaranchByUperLevel baranchModels = new BaranchByUperLevel();
                    baranchModels.text = sqlrdr["SectionDescAR"].ToString();
                    baranchModels.id = Int16.Parse(sqlrdr["SectionID"].ToString());
                    BaranchByUperLevelist.Add(baranchModels);

                }

                //  Body.Add();

                string json = JsonConvert.SerializeObject(new
                {
                    results = BaranchByUperLevelist
                });

                //   var json = JsonConvert.SerializeObject(""BaranchByUperLevelist);

                //   var resultsz = JsonConvert.DeserializeObject(json);


                return Content(json);

            }

        }

       

        // 
        // GET: GetDataBaranchAll
        public ActionResult GetDataDepartmentAll(int type)
        {


            //       barList = List<BaranchModels>;

            //  list<String>  Body=new Lis;
            List<BaranchByUperLevel> BaranchByUperLevelist = new List<BaranchByUperLevel>();

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
                    BaranchByUperLevel baranchModels = new BaranchByUperLevel();
                    baranchModels.text = sqlrdr["DepartmentDescAR"].ToString();
                    baranchModels.id = Int16.Parse(sqlrdr["DepartmentID"].ToString());

                    BaranchByUperLevelist.Add(baranchModels);

                }

                //  Body.Add();

                string json = JsonConvert.SerializeObject(new
                {
                    results = BaranchByUperLevelist
                });

                //   var json = JsonConvert.SerializeObject(""BaranchByUperLevelist);

                //   var resultsz = JsonConvert.DeserializeObject(json);


                return Content(json);

            }

        }






        // GET: GetLincenceNamesAll
        public ActionResult GetLincenceNamesAll(int type)
        {


            //       barList = List<BaranchModels>;

            //  list<String>  Body=new Lis;
            List<BaranchByUperLevel> BaranchByUperLevelist = new List<BaranchByUperLevel>();

            using (SqlConnection sqlconn = new SqlConnection(connStr))
            {
                SqlCommand sqlcmd = new SqlCommand("sp_GetLicenseName", sqlconn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlprmOFSp = new SqlParameter("@LicenseNameID", "0");
                sqlcmd.Parameters.Add(sqlprmOFSp);
                sqlconn.Open();
                SqlDataReader sqlrdr = sqlcmd.ExecuteReader();
                while (sqlrdr.Read())
                {// BranchID  CanBeDeactivated
                    BaranchByUperLevel baranchModels = new BaranchByUperLevel();
                    baranchModels.text = sqlrdr["LicenseNameAR"].ToString();
                    baranchModels.id = Int16.Parse(sqlrdr["LicenseNameID"].ToString());

                    BaranchByUperLevelist.Add(baranchModels);

                }

                //  Body.Add();

                string json = JsonConvert.SerializeObject(new
                {
                    results = BaranchByUperLevelist
                });


                return Content(json);

            }

        }


    }
}