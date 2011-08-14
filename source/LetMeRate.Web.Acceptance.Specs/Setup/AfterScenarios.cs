using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TechTalk.SpecFlow;

namespace LetMeRate.Web.Acceptance.Specs.Setup
{
    [Binding]
    public class AfterScenarios
    {
        [AfterScenario]
        public void ClearDatabase()
        {
            // TODO why can't i do this with simple.data?
            var connString = ConfigurationManager.ConnectionStrings["Simple.Data.Properties.Settings.DefaultConnectionString"].ConnectionString;
            using (var cn = new SqlConnection(connString))
            {
                cn.Open();
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"DELETE Authorisation;
                                        DELETE Rating;
                                        DELETE UserAccount;";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
