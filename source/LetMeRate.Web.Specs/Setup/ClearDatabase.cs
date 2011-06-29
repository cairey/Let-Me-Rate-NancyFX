using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Simple.Data;
using TechTalk.SpecFlow;

namespace LetMeRate.Web.Specs.Setup
{
    [Binding]
    public class ClearDatabase
    {
        [AfterScenario]
        public void Clear()
        {
            // TODO why can't i do this with simple.data?

            var connString = ConfigurationManager.ConnectionStrings["Simple.Data.Properties.Settings.DefaultConnectionString"].ConnectionString;
            using (var cn = new SqlConnection(connString))
            {
                cn.Open();
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "TRUNCATE Table UserAccount";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
