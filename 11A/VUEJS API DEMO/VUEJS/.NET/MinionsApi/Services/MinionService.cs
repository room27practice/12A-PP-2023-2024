using Microsoft.Data.SqlClient;
using System.Net;

namespace MinionsApi.Services
{
    public class MinionService : IMinionService
    {

        private readonly string connectionString = "Server=DESKTOP-H86OA8E\\SQLEXPRESS;Database=MinionsDB;Trusted_Connection=True;TrustServerCertificate=true";
        private readonly SqlConnection connection;
        public MinionService()
        {
            connection = new SqlConnection(connectionString);
        }

        public ICollection<Minion> GetAllMinions()
        {
            List<Minion> result = new List<Minion>();
            string sqlText = "SELECT m.Id,m.[Name] AS 'MinionName',m.Age,v.[Name] AS 'VillainName',t.Name AS 'City' FROM Minions as m\r\nLEFT OUTER JOIN MinionsVillians AS mv\r\nON m.Id=mv.MinionId\r\nLEFT OUTER JOIN Villians AS v\r\nON v.Id=mv.VillianId\r\nLEFT OUTER JOIN Towns AS t\r\nON t.Id=m.TownId";

            using (connection)
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlText, connection);
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        int id = (int)reader["Id"];
                        string villainName = reader["VillainName"].ToString();
                        var alreadyRecordedMinionFound = result.FirstOrDefault(m => m.Id == id); //null

                        if (alreadyRecordedMinionFound == null)
                        {
                            var minionCurrent = new Minion();
                            minionCurrent.Id = id;
                            minionCurrent.MinionName = reader["MinionName"].ToString();
                            minionCurrent.Age = (int)reader["Age"];
                            minionCurrent.City = reader["City"].ToString();
                            minionCurrent.VillainNames.Add(villainName);
                            result.Add(minionCurrent);
                        }
                        else
                        {
                            alreadyRecordedMinionFound.VillainNames.Add(villainName);
                        }
                    }
                }
            }
            return result;

        }
    }

    public interface IMinionService
    {
        ICollection<Minion> GetAllMinions();
    }

    public class Minion
    {
        public Minion()
        {
            VillainNames = new HashSet<string>();
        }
        public int Id { get; set; }
        public string MinionName { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public ICollection<string> VillainNames { get; set; }
    }


}
