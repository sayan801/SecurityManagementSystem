using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SecurityManagementSystemEngine;

namespace SecurityManagementSystemStorage
{
    public class SecurityManagementSystemStorageInteraction
    {
        static string passwordCurrent = "technicise";
        static string dbmsCurrent = "securitydb";

        private static MySql.Data.MySqlClient.MySqlConnection OpenDbConnection()
        {
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = null;

            msqlConnection = new MySql.Data.MySqlClient.MySqlConnection("server=localhost;user id=root;Password=" + passwordCurrent + ";database=" + dbmsCurrent + ";persist security info=False");

            //open the connection
            if (msqlConnection.State != System.Data.ConnectionState.Open)
                msqlConnection.Open();

            return msqlConnection;
        }

        #region Visitor

        public static int DoEnterVisetor(VisitorInformation Newvisitor)
        {
            return DoRegisterNewVisetorindb(Newvisitor);
        }

        private static int DoRegisterNewVisetorindb(VisitorInformation NewVisitor)
        {
            int returnVal = 0;
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {
                //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();

                //define the connection used by the command object
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "INSERT INTO regvisitor(id,name,address,phone,idcardno,visitortype,purpose,visitwhom,signtime,remark,timewilltake) "
                                    + "VALUES(@id,@name,@address,@phone,@idcardno,@visitortype,@purpose,@visitwhom,@signtime,@remark,@timewilltake)";

                msqlCommand.Parameters.AddWithValue("@id", NewVisitor.id);
                msqlCommand.Parameters.AddWithValue("@name", NewVisitor.name);
                msqlCommand.Parameters.AddWithValue("@address", NewVisitor.addres);
                msqlCommand.Parameters.AddWithValue("@phone", NewVisitor.contact);
                msqlCommand.Parameters.AddWithValue("@idcardno", NewVisitor.idinfo);
                msqlCommand.Parameters.AddWithValue("@visitortype", NewVisitor.viitortype);
                msqlCommand.Parameters.AddWithValue("@purpose", NewVisitor.purpose);
                msqlCommand.Parameters.AddWithValue("@visitwhom", NewVisitor.empId);
                msqlCommand.Parameters.AddWithValue("@signtime", NewVisitor.signintime);
                msqlCommand.Parameters.AddWithValue("@remark", NewVisitor.remark);
                msqlCommand.Parameters.AddWithValue("@timewilltake", NewVisitor.expcttie);

                msqlCommand.ExecuteNonQuery();

                returnVal = 1;
            }
            catch (Exception er)
            {
                returnVal = 0;
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }
            return returnVal;
        }


        public static List<VisitorInformation> GetAllVisitorList()
        {
            return QueryAllVisitorList();
        }

        private static List<VisitorInformation> QueryAllVisitorList()
        {
            List<VisitorInformation> VisitorList = new List<VisitorInformation>();
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;



                msqlCommand.CommandText = "Select * From regvisitor;";
                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

                while (msqlReader.Read())
                {
                    VisitorInformation Visitor = new VisitorInformation();

                    Visitor.id = msqlReader.GetString("id");
                    Visitor.name = msqlReader.GetString("name");
                    Visitor.addres = msqlReader.GetString("address");
                    Visitor.contact = msqlReader.GetString("phone");
                    Visitor.idinfo = msqlReader.GetString("idcardno");
                    Visitor.viitortype = msqlReader.GetString("visitortype");
                    Visitor.purpose = msqlReader.GetString("purpose");
                    Visitor.empId = msqlReader.GetString("visitwhom");
                    Visitor.signintime = msqlReader.GetDateTime("signtime");
                    Visitor.remark = msqlReader.GetString("remark");
                    Visitor.expcttie = msqlReader.GetString("timewilltake");

                    Visitor.permisionBy = msqlReader.GetString("prmsnGrntdby");
                    Visitor.allowBy = msqlReader.GetString("allowvisitBy");
                    Visitor.empId = msqlReader.GetString("employId");

                    VisitorList.Add(Visitor);
                }
            }

            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }

            return VisitorList;

        }

        #region Delete Visitor

        public static void DeleteVisitor(string visitorToDelete)
        {
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "DELETE FROM regvisitor WHERE id=@visitorToDelete";
                msqlCommand.Parameters.AddWithValue("@visitorToDelete", visitorToDelete);

                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }
        }

        #endregion


        #endregion

        #region Residence

        public static int DoEnterResidence(ResidenceInformation Newresidence)
        {
            return DoRegisterNewResidenceindb(Newresidence);
        }

        private static int DoRegisterNewResidenceindb(ResidenceInformation NewResidence)
        {
            int returnVal = 0;
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {
                //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();

                //define the connection used by the command object
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "INSERT INTO residence(id,fmlyhadsname,houseno,roomno,contact,emailaddrs,fmlymebrs,visitinghrs,remark) "
                                    + "VALUES(@id,@fmlyhadsname,@houseno,@roomno,@contact,@emailaddrs,@fmlymebrs,@visitinghrs,@remark)";

                msqlCommand.Parameters.AddWithValue("@id", NewResidence.id);
                msqlCommand.Parameters.AddWithValue("@fmlyhadsname", NewResidence.name);
                msqlCommand.Parameters.AddWithValue("@houseno", NewResidence.houseNo);
                msqlCommand.Parameters.AddWithValue("@roomno", NewResidence.roomNo);
                msqlCommand.Parameters.AddWithValue("@contact", NewResidence.contact);
                msqlCommand.Parameters.AddWithValue("@emailaddrs", NewResidence.email);
                msqlCommand.Parameters.AddWithValue("@fmlymebrs", NewResidence.fmlyMbrs);
                msqlCommand.Parameters.AddWithValue("@visitinghrs", NewResidence.visitingHour);
                msqlCommand.Parameters.AddWithValue("@remark", NewResidence.remark);

                msqlCommand.ExecuteNonQuery();

                returnVal = 1;
            }
            catch (Exception er)
            {
                returnVal = 0;
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }
            return returnVal;
        }

        public static List<ResidenceInformation> GetAllResidenceList()
        {
            return QueryAllResidenceList();
        }
        private static List<ResidenceInformation> QueryAllResidenceList()
        {
            List<ResidenceInformation> ResidenceList = new List<ResidenceInformation>();

            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "Select * From residence ;";
                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

                while (msqlReader.Read())
                {
                    ResidenceInformation Residence = new ResidenceInformation();

                    Residence.id = msqlReader.GetString("id");
                    Residence.name = msqlReader.GetString("fmlyhadsname");
                    Residence.houseNo = msqlReader.GetString("houseno");
                    Residence.roomNo = msqlReader.GetString("roomno");
                    Residence.contact = msqlReader.GetString("contact");
                    Residence.email = msqlReader.GetString("emailaddrs");
                    Residence.fmlyMbrs = msqlReader.GetString("fmlymebrs");
                    Residence.visitingHour = msqlReader.GetString("visitinghrs");
                    Residence.remark = msqlReader.GetString("remark");
                    
                    ResidenceList.Add(Residence);
                }

            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }

            return ResidenceList;
        }

        #region Delete Residence

        public static void DeleteResidence(string residenceToDelete)
        {
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "DELETE FROM residence WHERE id=@residenceToDelete";
                msqlCommand.Parameters.AddWithValue("@residenceToDelete", residenceToDelete);

                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }
        }

        #endregion

        #endregion

        #region Employee

        public static int DoEnterEmployee(EmployeeInformation NewEmployee)
        {
            return DoRegisterNewEmployeeindb(NewEmployee);
        }

        private static int DoRegisterNewEmployeeindb(EmployeeInformation Newemployee)
        {
            int returnVal = 0;
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {
                //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();

                //define the connection used by the command object
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "INSERT INTO employee(id,name,address,contact,joiningdate,email,homenumber,employeeType,remark) "
                                    + "VALUES(@id,@name,@address,@contact,@joiningdate,@email,@homenumber,@employeeType,@remark)";

                msqlCommand.Parameters.AddWithValue("@id", Newemployee.id);
                msqlCommand.Parameters.AddWithValue("@name", Newemployee.name);
                msqlCommand.Parameters.AddWithValue("@address", Newemployee.addres);
                msqlCommand.Parameters.AddWithValue("@contact", Newemployee.contact);
                msqlCommand.Parameters.AddWithValue("@joiningdate", Newemployee.joiningdate);
                msqlCommand.Parameters.AddWithValue("@email", Newemployee.email);
                msqlCommand.Parameters.AddWithValue("@homenumber", Newemployee.homeNumber);
                msqlCommand.Parameters.AddWithValue("@employeeType", Newemployee.employeeType);
                msqlCommand.Parameters.AddWithValue("@remark", Newemployee.remark);

                msqlCommand.ExecuteNonQuery();

                returnVal = 1;
            }
            catch (Exception er)
            {
                returnVal = 0;
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }
            return returnVal;
        }


        public static List<EmployeeInformation> GetAllEmployeeList()
        {
            return QueryAllEmployeeList();
        }
        private static List<EmployeeInformation> QueryAllEmployeeList()
        {
            List<EmployeeInformation> EmployeeList = new List<EmployeeInformation>();

            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "Select * From employee ;";
                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

                while (msqlReader.Read())
                {
                    EmployeeInformation Employee = new EmployeeInformation();

                    Employee.id = msqlReader.GetString("id");
                    Employee.name = msqlReader.GetString("name");
                    Employee.addres = msqlReader.GetString("address");
                    Employee.contact = msqlReader.GetString("contact");
                    Employee.joiningdate = msqlReader.GetDateTime("joiningdate");
                    Employee.email = msqlReader.GetString("email");
                    Employee.homeNumber = msqlReader.GetString("homenumber");
                    Employee.employeeType = msqlReader.GetString("employeeType");
                    Employee.remark = msqlReader.GetString("remark");

                    EmployeeList.Add(Employee);
                }

            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }

            return EmployeeList;
        }

        #region Delete Employee

        public static void DeleteEmployee(string employeeToDelete)
        {
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "DELETE FROM employee WHERE id=@employeeToDelete";
                msqlCommand.Parameters.AddWithValue("@employeeToDelete", employeeToDelete);

                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }
        }

        #endregion
        #endregion

        #region Security

        public static int DoEnterSecurity(SecurityInformation NewSecurity)
        {
            return DoRegisterNewSecurityindb(NewSecurity);
        }

        private static int DoRegisterNewSecurityindb(SecurityInformation Newsecurity)
        {
            int returnVal = 0;
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {
                //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();

                //define the connection used by the command object
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "INSERT INTO security(id,name,address,contact,joiningdate,email,homenumber,remark) "
                                    + "VALUES(@id,@name,@address,@contact,@joiningdate,@email,@homenumber,@remark)";

                msqlCommand.Parameters.AddWithValue("@id", Newsecurity.id);
                msqlCommand.Parameters.AddWithValue("@name", Newsecurity.name);
                msqlCommand.Parameters.AddWithValue("@address", Newsecurity.addres);
                msqlCommand.Parameters.AddWithValue("@contact", Newsecurity.contact);
                msqlCommand.Parameters.AddWithValue("@joiningdate", Newsecurity.joiningdate);
                msqlCommand.Parameters.AddWithValue("@email", Newsecurity.email);
                msqlCommand.Parameters.AddWithValue("@homenumber", Newsecurity.homeNumber);
                msqlCommand.Parameters.AddWithValue("@remark", Newsecurity.remark);

                msqlCommand.ExecuteNonQuery();

                returnVal = 1;
            }
            catch (Exception er)
            {
                returnVal = 0;
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }
            return returnVal;
        }


        public static List<SecurityInformation> GetAllSecurityList()
        {
            return QueryAllSecurityList();
        }
        private static List<SecurityInformation> QueryAllSecurityList()
        {
            List<SecurityInformation> SecurityList = new List<SecurityInformation>();

            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "Select * From security ;";
                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

                while (msqlReader.Read())
                {
                    SecurityInformation Security = new SecurityInformation();

                    Security.id = msqlReader.GetString("id");
                    Security.name = msqlReader.GetString("name");
                    Security.addres = msqlReader.GetString("address");
                    Security.contact = msqlReader.GetString("contact");
                    Security.joiningdate = msqlReader.GetDateTime("joiningdate");
                    Security.email = msqlReader.GetString("email");
                    Security.homeNumber = msqlReader.GetString("homenumber");
                    Security.remark = msqlReader.GetString("remark");

                    SecurityList.Add(Security);
                }

            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }

            return SecurityList;
        }

        #region Delete Security

        public static void DeleteSecurity(string securityToDelete)
        {
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "DELETE FROM security WHERE id=@securityToDelete";
                msqlCommand.Parameters.AddWithValue("@securityToDelete", securityToDelete);

                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }
        }

        #endregion
        #endregion
    }
}
