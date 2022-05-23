using MyMusic.Models;
using System.Data.SqlClient;

namespace MyMusic.Repository
{
    public class DBManager
    {
        private static string connectionString = @"Server = ACADEMYNETPD04\SQLEXPRESS; Database = MUSIC; Trusted_Connection = True;";

        public List<BraniViewModel> GetAllBrani()
        {
            List<BraniViewModel> braniList = new List<BraniViewModel>();
            string sql = @"SELECT Titolo, Band, Album, AnnoUscita, Durata, Genere 
                        FROM Brani";

            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var brano = new BraniViewModel
                {
                    IDBrano = Convert.ToInt32(reader["IDBrano"]),
                    Titolo = reader["Titolo"].ToString(),
                    Band = reader["Band"].ToString(),
                    Album = reader["Album"].ToString(),
                    AnnoUscita = Convert.ToDateTime(reader["AnnoUscita"]),
                    Durata = Convert.ToInt32(reader["Durata"]),
                    Genere = reader["Genere"].ToString()
                };
                braniList.Add(brano);
            }
            return braniList;
        }

        public int EditBrano(BraniViewModel brano)
        {
            string sql = @"UPDATE Brani
                       SET [Titolo] = @Titolo
                          ,[Band] = @Band
                          ,[Album] = @Album
                          ,[AnnoUscita] = @AnnoUscita
                          ,[Durata] = @Durata
                          ,[Genere] = @Genere
                     WHERE IDBrano =@IDBrano";

            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Titolo", brano.Titolo);
            command.Parameters.AddWithValue("@Band", brano.Band);
            command.Parameters.AddWithValue("@Album", brano.Album);
            command.Parameters.AddWithValue("@AnnoUscita", brano.AnnoUscita);
            command.Parameters.AddWithValue("@Durata", brano.Durata);
            command.Parameters.AddWithValue("@Genere", brano.Genere);
            command.Parameters.AddWithValue("@IDBrano", brano.IDBrano);

            return command.ExecuteNonQuery();
        }
        public int AggiungiBrano(BraniViewModel brano)
        {
            string sql = @"INSERT INTO Brani
            ([Titolo]
           ,[Band]
           ,[Album]
           ,[AnnoUscita]
           ,[Durata]
           ,[Genere])
                       VALUES (@Titolo,@Band,@Album,@AnnoUscita,@Durata,@Genere) ";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Titolo", brano.Titolo);
            command.Parameters.AddWithValue("@Band", brano.Band);
            command.Parameters.AddWithValue("@Album", brano.Album);
            command.Parameters.AddWithValue("@AnnoUscita", brano.AnnoUscita);
            command.Parameters.AddWithValue("@Durata", brano.Durata);
            command.Parameters.AddWithValue("@Genere", brano.Genere);

            return command.ExecuteNonQuery();
        }


    }
}
