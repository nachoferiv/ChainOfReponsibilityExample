using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class VacationDAL : AbstractSQLDAL
    {
        EmployeeDAL empRepository;

        public VacationDAL(EmployeeDAL empRepository)
        {
            this.empRepository = empRepository;
        }

        public void Create(Vacation vacation)
        {
            try
            {
                string storeProcedureName = "vacations_create";
                List<SqlParameter> parameters = new List<SqlParameter>() {
                    new SqlParameter() { ParameterName = "@number_of_days", SqlDbType = SqlDbType.Int, Value = vacation.GetNumberOfDays()},
                    new SqlParameter() { ParameterName = "@reason", SqlDbType = SqlDbType.VarChar, Value = vacation.GetReason()},
                    new SqlParameter() { ParameterName = "@status", SqlDbType = SqlDbType.VarChar, Value = vacation.GetStatus().ToString()},
                    new SqlParameter() { ParameterName = "@requester", SqlDbType = SqlDbType.VarChar, Value = vacation.GetRequester()},
                    new SqlParameter() { ParameterName = "@current_approver", SqlDbType = SqlDbType.VarChar, Value = vacation.GetCurrentApprover().GetUsername()},
                };

                this.Execute(storeProcedureName, parameters);
                return;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void Update(Vacation vacation)
        {
            try
            {
                string storeProcedureName = "vacations_update";
                List<SqlParameter> parameters = new List<SqlParameter>() {
                    new SqlParameter() { ParameterName = "@id", SqlDbType = SqlDbType.Int, Value = vacation.GetID()},
                    new SqlParameter() { ParameterName = "@number_of_days", SqlDbType = SqlDbType.Int, Value = vacation.GetNumberOfDays()},
                    new SqlParameter() { ParameterName = "@reason", SqlDbType = SqlDbType.VarChar, Value = vacation.GetReason()},
                    new SqlParameter() { ParameterName = "@status", SqlDbType = SqlDbType.VarChar, Value = vacation.GetStatus().ToString()},
                    new SqlParameter() { ParameterName = "@requester", SqlDbType = SqlDbType.VarChar, Value = vacation.GetRequester()},
                    new SqlParameter() { ParameterName = "@current_approver", SqlDbType = SqlDbType.VarChar, Value = vacation.GetCurrentApprover().GetUsername()},
                };

                this.Execute(storeProcedureName, parameters);
                return;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public IList<Vacation> GetAll()
        {
            List<Vacation> vacationList = new List<Vacation>();
            try
            {
                DataSet dataset = new DataSet();
                string storeProcedureName = "vacations_get_all";

                dataset = this.Execute(storeProcedureName, null);
                if (dataset.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in dataset.Tables[0].Rows)
                    {
                        int id = Convert.ToInt32(row["id"]);
                        int numberOfDays = Convert.ToInt32(row["number_of_days"]);
                        string reason = row["reason"].ToString();
                        string requester = row["requester"].ToString();
                        string currentApproverUsername = row["current_approver"].ToString();
                        IEmployee currentApprover = this.empRepository.GetByUsername(currentApproverUsername);
                        EnumVacationStatus status = (EnumVacationStatus)Enum.Parse(typeof(EnumVacationStatus), row["status"].ToString(), true);

                        Vacation vacation = new Vacation(numberOfDays, reason, requester, currentApprover, status, id);
                        vacationList.Add(vacation);
                    }
                }

                return vacationList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Vacation GetByID(int id)
        {
            Vacation vacation = null;
            try
            {
                DataSet dataset = new DataSet();
                string storeProcedureName = "vacations_get_by_id";

                List<SqlParameter> parameters = new List<SqlParameter>() {
                    new SqlParameter() { ParameterName = "@id", SqlDbType = SqlDbType.Int, Value = id},
                };

                dataset = this.Execute(storeProcedureName, parameters);
                if (dataset.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in dataset.Tables[0].Rows)
                    {
                        id = Convert.ToInt32(row["id"]);
                        int numberOfDays = Convert.ToInt32(row["number_of_days"]);
                        string reason = row["reason"].ToString();
                        string requester = row["requester"].ToString();
                        string currentApproverUsername = row["current_approver"].ToString();
                        IEmployee currentApprover = this.empRepository.GetByUsername(currentApproverUsername);
                        EnumVacationStatus status = (EnumVacationStatus)Enum.Parse(typeof(EnumVacationStatus), row["status"].ToString(), true);

                        vacation = new Vacation(numberOfDays, reason, requester, currentApprover, status, id);
                        return vacation;
                    }
                }

                return vacation;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
