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
    public class employeeController : Controller
    {

        string connStr = ConfigurationManager.ConnectionStrings["ERPconnectionString"].ConnectionString;

        // GET: employee
        public ActionResult Index()

        {




            //       barList = List<BaranchModels>;
            List<AutoGenerateModel> AutoGenerateModelList = new List<AutoGenerateModel>();
            using (SqlConnection sqlconn = new SqlConnection(connStr))
            {
                SqlCommand sqlcmd = new SqlCommand("sp_GetLicenseDeg", sqlconn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlprmOFSp = new SqlParameter("@LicenseDegID", "0");
                sqlcmd.Parameters.Add(sqlprmOFSp);
                SqlParameter sqlprmOFSp2 = new SqlParameter("@IsActive", "1");
                sqlcmd.Parameters.Add(sqlprmOFSp2);

                sqlconn.Open();
                SqlDataReader sqlrdr = sqlcmd.ExecuteReader();
                while (sqlrdr.Read())
                {// BranchID  CanBeDeactivated
                    AutoGenerateModel AutoGenerateModels = new AutoGenerateModel();
                    AutoGenerateModels.Text = sqlrdr["LicenseDegDescAR"].ToString();
                    AutoGenerateModels.ID = Int16.Parse(sqlrdr["LicenseDegID"].ToString());
                    AutoGenerateModelList.Add(AutoGenerateModels);

                }

            }


            ViewBag.dataOfGetLicenseDegs = AutoGenerateModelList.ToArray();



            List<AutoGenerateModel> GetLicenseNamet = new List<AutoGenerateModel>();

            using (SqlConnection sqlconn = new SqlConnection(connStr))
            {
                SqlCommand sqlcmd = new SqlCommand("sp_GetLicenseName", sqlconn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlprmOFSp = new SqlParameter("@LicenseNameID", "0");
                sqlcmd.Parameters.Add(sqlprmOFSp);

                SqlParameter sqlprmOFSp2 = new SqlParameter("@IsActive", "1");
                sqlcmd.Parameters.Add(sqlprmOFSp2);

                sqlconn.Open();
                SqlDataReader sqlrdr = sqlcmd.ExecuteReader();
                while (sqlrdr.Read())
                {// BranchID  CanBeDeactivated
                    AutoGenerateModel baranchModels = new AutoGenerateModel();
                    baranchModels.Text = sqlrdr["LicenseNameAR"].ToString();
                    baranchModels.ID = Int16.Parse(sqlrdr["LicenseNameID"].ToString());

                    GetLicenseNamet.Add(baranchModels);

                }

            }



            AutoGenerateModel AutoGenerateModelser = new AutoGenerateModel();
            AutoGenerateModelser.Text = "يرجى الاختيار";
            AutoGenerateModelser.ID = 0;

            GetLicenseNamet.Add(AutoGenerateModelser);



            ViewBag.GetLicenseNamet = GetLicenseNamet.ToArray();

    






      


            List<AutoGenerateModel> GenderList = new List<AutoGenerateModel>();
            using (SqlConnection sqlconn = new SqlConnection(connStr))
            {
                SqlCommand sqlcmd = new SqlCommand("sp_GetGender", sqlconn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlprmOFSp = new SqlParameter("@GenderID", "0");
                sqlcmd.Parameters.Add(sqlprmOFSp);
                SqlParameter sqlprmOFSp2 = new SqlParameter("@IsActive", "1");
                sqlcmd.Parameters.Add(sqlprmOFSp2);

                sqlconn.Open();
                SqlDataReader sqlrdr = sqlcmd.ExecuteReader();
                while (sqlrdr.Read())
                {// BranchID  CanBeDeactivated
                    AutoGenerateModel AutoGenerateModels = new AutoGenerateModel();
                    AutoGenerateModels.Text = sqlrdr["GenderDescAR"].ToString();
                    AutoGenerateModels.ID = Int16.Parse(sqlrdr["GenderID"].ToString());
                    GenderList.Add(AutoGenerateModels);

                }

            }
         //    GenderList.Add(AutoGenerateModelser);




            ViewBag.GenderList = GenderList.ToArray();







            //       barList = List<BaranchModels>;
            List<AutoGenerateModel> MaritalStatusIDList = new List<AutoGenerateModel>();
            using (SqlConnection sqlconn = new SqlConnection(connStr))
            {
                SqlCommand sqlcmd = new SqlCommand("sp_GetMaritalStatus", sqlconn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlprmOFSp = new SqlParameter("@StatusID", "0");
                sqlcmd.Parameters.Add(sqlprmOFSp);
                SqlParameter sqlprmOFSp2 = new SqlParameter("@IsActive", "1");
                sqlcmd.Parameters.Add(sqlprmOFSp2);

                sqlconn.Open();
                SqlDataReader sqlrdr = sqlcmd.ExecuteReader();
                while (sqlrdr.Read())
                {// BranchID  CanBeDeactivated
                    AutoGenerateModel AutoGenerateModels = new AutoGenerateModel();
                    AutoGenerateModels.Text = sqlrdr["StatusDescMAR"].ToString();
                    AutoGenerateModels.ID = Int16.Parse(sqlrdr["StatusID"].ToString());
                    MaritalStatusIDList.Add(AutoGenerateModels);

                }

            }




            ViewBag.MaritalStatusIDList = MaritalStatusIDList.ToArray();








            return PartialView();
        }


        // POST: StoreEmployee
        public ActionResult StoreEmployee(EmployeeModel EmployeeModeller)
        {

            using (SqlConnection sqlconn = new SqlConnection(connStr))
            {
                SqlCommand sqlcmd = new SqlCommand("sp_SetEmployee", sqlconn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlprmOFSp = new SqlParameter("@Opr", "0");
                sqlcmd.Parameters.Add(sqlprmOFSp);
                sqlprmOFSp = new SqlParameter("@EmpID", "0");
                sqlcmd.Parameters.Add(sqlprmOFSp);
                sqlprmOFSp = new SqlParameter("@BranchID", "12");
                sqlcmd.Parameters.Add(sqlprmOFSp);
                sqlprmOFSp = new SqlParameter("@DepartmentID", "1");
                sqlcmd.Parameters.Add(sqlprmOFSp);
                sqlprmOFSp = new SqlParameter("@SectionID", "1");
                sqlcmd.Parameters.Add(sqlprmOFSp);
                sqlprmOFSp = new SqlParameter("@PhoneNo", "1");
                sqlcmd.Parameters.Add(sqlprmOFSp);
                sqlprmOFSp = new SqlParameter("@Address", EmployeeModeller.Address);
                sqlcmd.Parameters.Add(sqlprmOFSp);
                sqlprmOFSp = new SqlParameter("@FirstNameEN", EmployeeModeller.FirstNameEN);
                sqlcmd.Parameters.Add(sqlprmOFSp);
                sqlprmOFSp = new SqlParameter("@LastNameEN", EmployeeModeller.LastNameEN);
                sqlcmd.Parameters.Add(sqlprmOFSp);
                sqlprmOFSp = new SqlParameter("@MotherNameEN", EmployeeModeller.MotherNameEN);
                sqlcmd.Parameters.Add(sqlprmOFSp);
                sqlprmOFSp = new SqlParameter("@VicationBalance", "0");
                sqlcmd.Parameters.Add(sqlprmOFSp);
                sqlprmOFSp = new SqlParameter("@MidNameEN", EmployeeModeller.MidNameEN);
                sqlcmd.Parameters.Add(sqlprmOFSp);
                sqlprmOFSp = new SqlParameter("@MaritalStatusID", EmployeeModeller.MaritalStatusID);
                sqlcmd.Parameters.Add(sqlprmOFSp);
                sqlprmOFSp = new SqlParameter("@MotherNameAR", EmployeeModeller.MotherNameAR);
                sqlcmd.Parameters.Add(sqlprmOFSp);
                sqlprmOFSp = new SqlParameter("@FirstNameAR", EmployeeModeller.FirstNameAR);
                sqlcmd.Parameters.Add(sqlprmOFSp);
                sqlprmOFSp = new SqlParameter("@MidNameAR", EmployeeModeller.MidNameAR);
                sqlcmd.Parameters.Add(sqlprmOFSp);
                //sqlprmOFSp = new SqlParameter("@MaturityDate", "2021-4-4");
                //sqlcmd.Parameters.Add(sqlprmOFSp);
                sqlprmOFSp = new SqlParameter("@LastNameAR", EmployeeModeller.LastNameAR);
                sqlcmd.Parameters.Add(sqlprmOFSp);
                sqlprmOFSp = new SqlParameter("@Notes", EmployeeModeller.Notes);
                sqlcmd.Parameters.Add(sqlprmOFSp);
                sqlprmOFSp = new SqlParameter("@ChildrenCount", EmployeeModeller.ChildrenCount);
                sqlcmd.Parameters.Add(sqlprmOFSp);
                sqlprmOFSp = new SqlParameter("@LicenseDigreeID", EmployeeModeller.LicenseDigreeID);
                sqlcmd.Parameters.Add(sqlprmOFSp);
                sqlprmOFSp = new SqlParameter("@LicenseNameID", EmployeeModeller.LicenseNameID);
                sqlcmd.Parameters.Add(sqlprmOFSp);
                sqlprmOFSp = new SqlParameter("@LandLine", EmployeeModeller.PhoneNo);
                sqlcmd.Parameters.Add(sqlprmOFSp);
                sqlprmOFSp = new SqlParameter("@IsBlocked", "0");
                sqlcmd.Parameters.Add(sqlprmOFSp);
                sqlprmOFSp = new SqlParameter("@IsRetired", "0");
                sqlcmd.Parameters.Add(sqlprmOFSp);
                sqlprmOFSp = new SqlParameter("@JoinDate", EmployeeModeller.JoinDate);
                sqlcmd.Parameters.Add(sqlprmOFSp);
                sqlprmOFSp = new SqlParameter("@EmergencyComtactName", EmployeeModeller.EmergencyComtactName);
                sqlcmd.Parameters.Add(sqlprmOFSp);
                sqlprmOFSp = new SqlParameter("@GenderID", EmployeeModeller.GenderID);
                sqlcmd.Parameters.Add(sqlprmOFSp);
                sqlprmOFSp = new SqlParameter("@BloodID", "1");
                sqlcmd.Parameters.Add(sqlprmOFSp);
                sqlprmOFSp = new SqlParameter("@BirthDate", EmployeeModeller.BirthDate);
                sqlcmd.Parameters.Add(sqlprmOFSp);
                sqlprmOFSp = new SqlParameter("@EmergencyPhoneNo", EmployeeModeller.EmergencyPhoneNo);
                sqlcmd.Parameters.Add(sqlprmOFSp);
                sqlprmOFSp = new SqlParameter("@IsActive", 1);
                sqlcmd.Parameters.Add(sqlprmOFSp);
                sqlprmOFSp = new SqlParameter("@Result", System.Data.SqlDbType.Int);
                sqlprmOFSp.Direction = ParameterDirection.Output;
                sqlprmOFSp = new SqlParameter("@EmpID", System.Data.SqlDbType.Int);
                sqlprmOFSp.Direction = ParameterDirection.Output;
                sqlprmOFSp = new SqlParameter("@ID_No", System.Data.SqlDbType.Int);
                sqlprmOFSp.Direction = ParameterDirection.Output;
                sqlcmd.Parameters.Add(sqlprmOFSp);
                sqlconn.Open();
                sqlcmd.ExecuteNonQuery();
                var strResult = sqlcmd.Parameters["@EmpID"].Value.ToString();
                sqlconn.Close();

            }
            return Redirect("/employee");
        }
    }
}