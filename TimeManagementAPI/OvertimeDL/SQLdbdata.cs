using Microsoft.Data.SqlClient;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace OvertimeDL
{
    public class SQLdbdata:Inc
    {
        private string connectionString
        = "Data Source =localhost\\SQLEXPRESS; Initial Catalog = ProjectRepo; Integrated Security = True; TrustServerCertificate=True;";

        private SqlConnection sqlConnection;
        public SQLdbdata()
        {
            sqlConnection = new SqlConnection(connectionString);
            
        }
       

        public void Add(OvetimeClass3 c33)
        {
            var existing = GetTime();

            if (existing.Any(x => x.Id == c33.Id))
            {
                Console.WriteLine("Duplicate ID detected. Skipping insert.");
                return;
            }

            var insertStatement = "INSERT INTO Employee_tbl VALUES (@ID, @Name, @TimeIn, @Timeout)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@ID", c33.Id);
            insertCommand.Parameters.AddWithValue("@Name", c33.Name);
            insertCommand.Parameters.AddWithValue("@TimeIn", c33.TimeIn);
            insertCommand.Parameters.AddWithValue("@Timeout", c33.Timeout);

            sqlConnection.Open();
            insertCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public List<OvetimeClass3> GetTime()
        {
            string selectStatement = "SELECT ID, Name, TimeIn, Timeout FROM Employee_tbl";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();

            SqlDataReader reader = selectCommand.ExecuteReader();

            var c33 = new List<OvetimeClass3>();
           

            while (reader.Read())
            {
                //deserialize

                OvetimeClass3 newc3 = new OvetimeClass3();
                newc3.Id = Convert.ToInt32(reader ["ID"].ToString());
                newc3.Name = reader["Name"].ToString();
                newc3.TimeIn = (TimeSpan)reader["TimeIn"];
                newc3.Timeout = (TimeSpan)reader["TimeOut"];

                c33.Add(newc3);
            }

            sqlConnection.Close();
            return c33;
        }
    }
}
