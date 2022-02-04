using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace YankeesChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {
        private static readonly List<Team> Teams = new List<Team>
        {
            new Team { Name = "New York Yankees", Abbreviation = "NYY", PlayerIds = null, Players = null },
            new Team { Name = "Boston Red Sox", Abbreviation = "BOS", PlayerIds = null, Players = null },
            new Team { Name = "Baltimore Orioles", Abbreviation = "BAL", PlayerIds = null, Players = null },
        };

        private readonly ILogger<TeamController> _logger;

        public TeamController(ILogger<TeamController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("{abbreviation}")]
        public IActionResult Get(string abbreviation)
        {
            string connectionString = "Server=tcp:fxzjoebulw.database.windows.net,1433;Database=nya_example;User ID=nyyapplicant@fxzjoebulw;Password=12345!abc;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
            using (SqlConnection connection = new SqlConnection(connectionString))  
            {
                connection.Open();
                // DataTable table = connection.GetSchema("Tables");
                // DisplayData(table);
                DataTable columns = connection.GetSchema("Columns", new[] { "nya_example", "dbo", "teams" });
                DisplayColumns(columns);;
                // string queryString = "SELECT * FROM nya_example.dbo.teams";
                // SqlCommand command = new SqlCommand(queryString, connection);
                // using(SqlDataReader reader = command.ExecuteReader())
                // {
                //     while (reader.Read())
                //     {
                //         Console.WriteLine(String.Format("{0}, {1}, {2}, {3}, {4}", reader[0], reader[1], reader[2], reader[3], reader[4]));
                //     }
                // }
                // string queryString = "SELECT * FROM nya_example.dbo.players";
                // SqlCommand command = new SqlCommand(queryString, connection);
                // using(SqlDataReader reader = command.ExecuteReader())
                // {
                //     while (reader.Read())
                //     {
                //         Console.WriteLine(String.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}", reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6], reader[7], reader[8], reader[9]));
                //     }
                // }
            } 

            Team t = Teams.FirstOrDefault(t => t.Abbreviation == abbreviation);
            return t is null ? NotFound() : Ok(t);
        }

        private static void DisplayData(System.Data.DataTable table)  
        {  
            foreach (System.Data.DataRow row in table.Rows)  
            {  
                foreach (System.Data.DataColumn col in table.Columns)  
                {  
                Console.WriteLine("{0} = {1}", col.ColumnName, row[col]);  
                }  
            Console.WriteLine("============================");  
            }  
        }

        private static void DisplayColumns(System.Data.DataTable table)  
        {  
            foreach (System.Data.DataRow row in table.Rows)  
            {  
                foreach (System.Data.DataColumn col in table.Columns)  
                {  
                    if (col.ColumnName == "COLUMN_NAME") {
                        Console.WriteLine("{0} = {1}", col.ColumnName, row[col]);  
                    }
                }  
            Console.WriteLine("============================");  
            }  
        }   
    }
}
