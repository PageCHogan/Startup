using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Protocols;
using Startup.Models;

namespace Startup.Services
{
    public class DatabaseService
    {
        private const string CONNECTION_STRING = "Data Source=HOGAN-PC\\SQLEXPRESS;Initial Catalog=StartupDB;Integrated Security=True";
        
        public DatabaseService()
        {
            //Empty Constructor...for now
        }

        public List<TestDataModel> GetTestData(int? userID = null)
        {
            List<TestDataModel> testData = new List<TestDataModel>();
            string SqlQuery = "SELECT * FROM Users";

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand command;

                if (userID.HasValue)
                {
                    SqlQuery += " Where ID = @0";
                    command = new SqlCommand(SqlQuery, conn);
                    command.Parameters.Add(new SqlParameter("0", userID));
                }
                else
                {
                    command = new SqlCommand(SqlQuery, conn);
                }

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (Int32.TryParse(reader[0].ToString(), out int id)) {
                            testData.Add(new TestDataModel()
                            {
                                ID = id,
                                Name = reader[1].ToString(),
                                Email = reader[2].ToString()
                            });
                        }
                    }
                }
            }

            return testData;
        }
    }
}
