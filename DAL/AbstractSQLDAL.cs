using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public abstract class AbstractSQLDAL
    {
        protected SqlConnection conn = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=chain_of_responsibility;Integrated Security=True;");
        protected SqlTransaction transaction;
        protected SqlCommand command;

        protected DataSet Execute(string storeProcedureName, List<SqlParameter> parameters = null)
        {
            try
            {
                conn.Open();
                transaction = conn.BeginTransaction();
                command = new SqlCommand(storeProcedureName, conn, transaction);
                command.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                    command.Parameters.AddRange(parameters.ToArray());

                DataSet dataset = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(command);

                da.Fill(dataset);

                transaction.Commit();
                conn.Close();

                return dataset;
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                conn.Close();
                throw ex;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                conn.Close();
                throw ex;
            }
        }
    }
}
