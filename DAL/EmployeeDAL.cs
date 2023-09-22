using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class EmployeeDAL : AbstractSQLDAL
    {
        public IEmployee Create(IEmployee user)
        {
            try
            {
                string storeProcedureName = "employees_create";
                List<SqlParameter> parameters = new List<SqlParameter>() {
                    new SqlParameter() { ParameterName = "@username", SqlDbType = SqlDbType.VarChar, Value = user.GetUsername()},
                    new SqlParameter() { ParameterName = "@name", SqlDbType = SqlDbType.VarChar, Value = user.GetName()},
                    new SqlParameter() { ParameterName = "@surname", SqlDbType = SqlDbType.VarChar, Value = user.GetSurname()},
                    new SqlParameter() { ParameterName = "@position", SqlDbType = SqlDbType.VarChar, Value = user.GetPosition()},
                };

                this.Execute(storeProcedureName, parameters);
                return this.GetByUsername(user.GetUsername());
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public IEmployee GetByUsername(string username)
        {
            IEmployee user = null;
            try
            {
                DataSet dataset = new DataSet();
                string storeProcedure = "employees_get_by_username";

                List<SqlParameter> parameters = new List<SqlParameter>() {
                    new SqlParameter() { ParameterName = "@username", SqlDbType = SqlDbType.VarChar, Value = username},
                };

                dataset = this.Execute(storeProcedure, parameters);
                if (dataset.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in dataset.Tables[0].Rows)
                    {
                        user = MapEmployeeFromDataRow(row);
                    }
                }

                if (user is null)
                    throw new Exception($"Employee with username {username} was not found.");
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private IEmployee MapEmployeeFromDataRow(DataRow row)
        {
            IEmployee employee;
            string position = row["position"].ToString();
            switch (position)
            {
                case "employee":
                    employee = new Employee();
                    break;
                case "leader":
                    employee = new Leader();
                    break;
                case "manager":
                    employee = new Manager();
                    break;
                case "sr_manager":
                    employee = new SrManager();
                    break;
                default:
                    employee = null;
                    break;
            }

            employee.SetUsername(row["username"].ToString());
            employee.SetName(row["name"].ToString());
            employee.SetSurname(row["surname"].ToString());

            return employee;
        }

        public IEmployee GetSuperior(string username)
        {
            IEmployee employee = null;
            try
            {
                DataSet dataset = new DataSet();
                string storeProcedure = "employees_get_superior";

                List<SqlParameter> parameters = new List<SqlParameter>() {
                    new SqlParameter() { ParameterName = "@username", SqlDbType = SqlDbType.VarChar, Value = username},
                };

                dataset = this.Execute(storeProcedure, parameters);
                if (dataset.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in dataset.Tables[0].Rows)
                    {
                        employee = MapEmployeeFromDataRow(row);
                    }
                }

                return employee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
