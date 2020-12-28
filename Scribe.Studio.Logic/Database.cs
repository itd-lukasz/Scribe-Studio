using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scribe.Studio.Logic
{
    public class Database
    {
        private static string GetConnectionString(Connection connection)
        {
            SqlConnectionStringBuilder cnB = new SqlConnectionStringBuilder()
            {
                DataSource = connection.Server,
                InitialCatalog = connection.Database,
                IntegratedSecurity = connection.WindowsAuth
            };
            if (!cnB.IntegratedSecurity)
            {
                cnB.UserID = connection.User;
                cnB.Password = connection.Password;
            }
            return cnB.ConnectionString;
        }

        public static List<ExecutionLogRow> GetExecutionLogRows(DateTime start, DateTime end, Connection connection)
        {
            List<ExecutionLogRow> res = new List<ExecutionLogRow>();
            using (SqlConnection cn = new SqlConnection(GetConnectionString(connection)))
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"SELECT EXECID, STARTTIME, ENDTIME, JOBSPECNAME, SOURCENAME,
                                           TARGETNAME, SOURCEROWS, FATALERRORCODE, FATALERRORMESSAGE,
                                           LEGACYSOURCENAME, LEGACYTARGETNAME, LASTSOURCEKEY, LASTSOURCEKEYNAME, MESSAGELABEL
                                  FROM SCRIBE.EXECUTIONLOG WITH(NOLOCK)
                                 WHERE STARTTIME >= @start
                                   AND ENDTIME <= @end";
                cmd.Parameters.AddWithValue("@start", start);
                cmd.Parameters.AddWithValue("@end", end);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    res.Add(new ExecutionLogRow()
                    {
                        ID = Convert.ToString(dr.GetValue(0)),
                        StartTime = Convert.ToDateTime(dr.GetValue(1)),
                        EndTime = Convert.ToDateTime(dr.GetValue(2)),
                        JobSpecName = Convert.ToString(dr.GetValue(3)),
                        SourceName = Convert.ToString(dr.GetValue(4)),
                        TargetName = Convert.ToString(dr.GetValue(5)),
                        SourceRows = Convert.ToInt32(dr.GetValue(6)),
                        FatalErrorCode = Convert.ToInt32(dr.GetValue(7)),
                        FatalErrorMessage = Convert.ToString(dr.GetValue(8)),
                        LegacySourceName = Convert.ToString(dr.GetValue(9)),
                        LegacyTargetName = Convert.ToString(dr.GetValue(10)),
                        LastSourceKey = Convert.ToString(dr.GetValue(11)),
                        LastSourceKeyName = Convert.ToString(dr.GetValue(12)),
                        MessageLabel = Convert.ToString(dr.GetValue(13))
                    });
                }
                dr.Close();
                cn.Close();
            }
            return res;
        }

        public static string GetMessage(string guid, Connection connection)
        {
            string res = "";
            using (SqlConnection cn = new SqlConnection(GetConnectionString(connection)))
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"SELECT MESSAGE
                                  FROM SCRIBE.EXECUTIONLOG WITH(NOLOCK)
                                 WHERE EXECID = @execid";
                cmd.Parameters.AddWithValue("@execid", guid);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    res = Convert.ToString(dr.GetValue(0));
                }
                dr.Close();
                cn.Close();
            }
            return res;
        }
    }
}
