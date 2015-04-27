using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DOWTank.Core.Service
{
    public class UtilityService : IUtilityService
    {
        private readonly DOWTankEntities _context;

        public UtilityService(DOWTankEntities context)
        {
            _context = context;
        }

        public void ExecStoredProcedureWithoutResults(string name, Dictionary<string, object> parameters = null)
        {
            var addedParams = new StringBuilder();

            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    if (param.Value != null)
                    {
                        addedParams.Append(string.Format("{0}=N'{1}',", param.Key, param.Value));
                    }
                    else
                    {
                        addedParams.Append(string.Format("{0}=null,", param.Key));
                    }
                }
            }

            if (addedParams.Length > 0)
            {
                addedParams = addedParams.Remove(addedParams.Length - 1, 1);
            }

            _context.Database.ExecuteSqlCommand(string.Format("EXEC [dbo].{0} {1}", name, addedParams));
        }
        public void ExecStoredProcedureWithoutResults(string name, object parameterWrapper)
        {
            var addedParams = new StringBuilder();

            if (parameterWrapper != null)
            {
                foreach (var prop in parameterWrapper.GetType().GetProperties())
                {
                    var propValue = prop.GetValue(parameterWrapper, null);

                    if (propValue != null)
                    {
                        addedParams.Append(string.Format("@{0}=N'{1}',", prop.Name, propValue));
                    }
                    else
                    {
                        addedParams.Append(string.Format("@{0}=null,", prop.Name, propValue));
                    }
                }
            }

            if (addedParams.Length > 0)
            {
                addedParams = addedParams.Remove(addedParams.Length - 1, 1);
            }
            _context.Database.ExecuteSqlCommand(string.Format("EXEC [dbo].{0} {1}", name, addedParams));

        }

        public IEnumerable<T> ExecStoredProcedureWithResults<T>(string name, Dictionary<string, object> parameters = null)
        {
            var addedParams = new StringBuilder();

            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    if (param.Value != null)
                    {
                        addedParams.Append(string.Format("{0}=N'{1}',", param.Key, param.Value));
                    }
                    else
                    {
                        addedParams.Append(string.Format("{0}=null,", param.Key));
                    }
                }
            }

            if (addedParams.Length > 0)
            {
                addedParams = addedParams.Remove(addedParams.Length - 1, 1);
            }

            return _context.Database.SqlQuery<T>(string.Format("EXEC [dbo].{0} {1}", name, addedParams));
        }
   
        public IEnumerable<T> ExecStoredProcedureWithResults<T>(string name, object parameterWrapper)
        {
            var addedParams = new StringBuilder();

            if (parameterWrapper != null)
            {
                foreach (var prop in parameterWrapper.GetType().GetProperties())
                {
                    var propValue = prop.GetValue(parameterWrapper, null);

                    if (propValue != null)
                    {
                        addedParams.Append(string.Format("@{0}=N'{1}',", prop.Name, propValue));
                    }
                    else
                    {
                        addedParams.Append(string.Format("@{0}=null,", prop.Name, propValue));
                    }
                }
            }

            if (addedParams.Length > 0)
            {
                addedParams = addedParams.Remove(addedParams.Length - 1, 1);
            }

            return _context.Database.SqlQuery<T>(string.Format("EXEC [dbo].{0} {1}", name, addedParams));
        }

        public DataTable ExecStoredProcedureForDataTable(string name, object parameterWrapper)
        {

            DataTable retVal = new DataTable();
            var conn = (SqlConnection)_context.Database.Connection;
            using (SqlCommand cmd = new SqlCommand(name, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                SqlDataAdapter adpter = new SqlDataAdapter(cmd);
                if (parameterWrapper != null)
                {
                    foreach (var prop in parameterWrapper.GetType().GetProperties())
                    {
                        var propValue = prop.GetValue(parameterWrapper, null);
                        SqlParameter param = new SqlParameter(prop.Name, null);
                        if (propValue != null) param.Value = propValue;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);
                    }
                }
                adpter.Fill(retVal);
                return retVal;
            }
        }
    }

    public interface IUtilityService
    {
        void ExecStoredProcedureWithoutResults(string name, Dictionary<string, object> parameters);
        void ExecStoredProcedureWithoutResults(string name, object parameterWrapper = null);
        IEnumerable<T> ExecStoredProcedureWithResults<T>(string name, Dictionary<string, object> parameters = null);
        IEnumerable<T> ExecStoredProcedureWithResults<T>(string name, object parameterWrapper = null);
        DataTable ExecStoredProcedureForDataTable(string name, object parameterWrapper);
    }
}
