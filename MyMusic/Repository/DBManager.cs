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
            string sql = @"SELECT * 
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

        public int ModificaBrano(BraniViewModel brano)
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

        public List<BandViewModel> GetAllBand()
        {
            List<BandViewModel> bandList = new List<BandViewModel>();
            string sql = @"SELECT * 
                        FROM Band";

            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var band = new BandViewModel
                {
                    IDBand = Convert.ToInt32(reader["IDBand"]),
                    NomeBand = reader["NomeBand"].ToString(),
                    Immagine = reader["Immagine"].ToString(),
                    Genere = reader["Genere"].ToString(),
                    AnnoUscitaAlbum = Convert.ToDateTime(reader["AnnoUscitaAlbum"])
                };
                bandList.Add(band);
            }
            return bandList;
        }

        public int ModificaBand(BandViewModel band)
        {
            string sql = @"UPDATE Band
                       SET [NomeBand] = @NomeBand
                          ,[Immagine] = @Immagine
                          ,[Genere] = @Genere
                          ,[AnnoUscitaAlbum] = @AnnoUscitaAlbum
     
                       WHERE IDBand =@IDBand";

            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@NomeBand", band.NomeBand);
            command.Parameters.AddWithValue("@Immagine", band.Immagine);
            command.Parameters.AddWithValue("@Genere", band.Genere);
            command.Parameters.AddWithValue("@AnnoUscitaAlbum", band.AnnoUscitaAlbum);
            command.Parameters.AddWithValue("@IDBand", band.IDBand);

            return command.ExecuteNonQuery();
        }
        public int AggiungiBand(BandViewModel band)
        {
            string sql = @"INSERT INTO Band
            ([NomeBand]
           ,[Immagine]
           ,[Genere]
           ,[AnnoUscitaAlbum] )
                       VALUES (@NomeBand,@Immagine,@Genere,@AnnoUscitaAlbum ) ";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@NomeBand", band.NomeBand);
            command.Parameters.AddWithValue("@Immagine", band.Immagine);
            command.Parameters.AddWithValue("@Genere", band.Genere);
            command.Parameters.AddWithValue("@AnnoUscitaAlbum", band.AnnoUscitaAlbum);

            return command.ExecuteNonQuery();
        }

        public List<ArtistaViewModel> GetAllArtista()
        {
            List<ArtistaViewModel> artistaList = new List<ArtistaViewModel>();
            string sql = @"SELECT * 
                        FROM Artisti";

            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var artista = new ArtistaViewModel
                {
                    IDArtista = Convert.ToInt32(reader["IDArtista"]),
                    Nome = reader["Nome"].ToString(),
                    Cognome = reader["Cognome"].ToString(),
                    Alias = reader["Alias"].ToString(),
                    BandMusicale = reader["Alias"].ToString(),
                    Tipo = reader["Alias"].ToString()

                };
                artistaList.Add(artista);
            }
            return artistaList;
        }


        public int ModificaArtista(ArtistaViewModel artista)
        {
            string sql = @"UPDATE Artisti
                       SET [Nome] = @Nome
                          ,[Cognome] = @Cognome
                          ,[Alias] = @Alias
                          ,[BandMusicale] = @BandMusicale
                          ,[Tipo] = @Tipo
                          
                     WHERE IDArtista =@IDArtista";

            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@NomeBand", artista.Nome);
            command.Parameters.AddWithValue("@Immagine", artista.Cognome);
            command.Parameters.AddWithValue("@Genere", artista.Alias);
            command.Parameters.AddWithValue("@AnnoUscitaAlbum", artista.BandMusicale);
            command.Parameters.AddWithValue("@AnnoUscitaAlbum", artista.Tipo);

            return command.ExecuteNonQuery();
        }
        public int AggiungiArtista(ArtistaViewModel artista)
        {
            string sql = @"INSERT INTO Artisti
            ([Nome]
           ,[Cognome]
           ,[Alias]
           ,[BandMusicale]
           ,[Tipo] )
                       VALUES (@Nome,@Cognome,@Alias,@BandMusicale,@Tipo ) ";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Nome", artista.Nome);
            command.Parameters.AddWithValue("@Cognome", artista.Cognome);
            command.Parameters.AddWithValue("@Alias", artista.Alias);
            command.Parameters.AddWithValue("@BandMusicale", artista.BandMusicale);
            command.Parameters.AddWithValue("@Tipo", artista.Tipo);

            return command.ExecuteNonQuery();
        }

        public List<AlbumViewModel> GetAllAlbum()
        {
            List<AlbumViewModel> albumList = new List<AlbumViewModel>();
            string sql = @"SELECT * 
                        FROM Album";

            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var album = new AlbumViewModel
                {
                    IDAlbum = Convert.ToInt32(reader["IDArtista"]),
                    TitoloAlbum = reader["TitoloAlbum"].ToString(),
                    BandAlbum = reader["BandAlbum"].ToString(),
                    BraniAlbum = reader["BraniAlbum"].ToString(),
                    AnnoUscitaAlbum = Convert.ToDateTime(reader["AnnoUscitaAlbum"])


                };
                albumList.Add(album);
            }
            return albumList;
        }

        public int ModificaAlbum(AlbumViewModel album)
        {
            string sql = @"UPDATE Album
                       SET [TitoloAlbum] = @TitoloAlbum
                          ,[BandAlbum] = @BandAlbum
                          ,[BraniAlbum] = @BraniAlbum
                          ,[AnnoUscitaAlbum] = @AnnoUscitaAlbum
                          
                     WHERE IDAlbum =@IDAlbum";

            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@TitoloAlbum", album.TitoloAlbum);
            command.Parameters.AddWithValue("@BandAlbum", album.BandAlbum);
            command.Parameters.AddWithValue("@BraniAlbum", album.BraniAlbum);
            command.Parameters.AddWithValue("@AnnoUscitaAlbum", album.AnnoUscitaAlbum);

            return command.ExecuteNonQuery();
        }
        public int AggiungiAlbum(AlbumViewModel album)
        {
            string sql = @"INSERT INTO Album
            ([TitoloAlbum]
           ,[BandAlbum]
           ,[BraniAlbum]
           ,[AnnoUscitaAlbum] )
                       VALUES (@TitoloAlbum,@BandAlbum,@BraniAlbum,@AnnoUscitaAlbum ) ";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@TitoloAlbum", album.TitoloAlbum);
            command.Parameters.AddWithValue("@BandAlbum", album.BandAlbum);
            command.Parameters.AddWithValue("@BraniAlbum", album.BraniAlbum);
            command.Parameters.AddWithValue("@AnnoUscitaAlbum", album.AnnoUscitaAlbum);

            return command.ExecuteNonQuery();
        }

    }
}
