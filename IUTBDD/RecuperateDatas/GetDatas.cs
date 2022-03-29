using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Data.Sqlite;
using Persistance.Models;

namespace RecuperateDatas
{
    public static class GetDatas
    {
        private static string sqlitePath = Path.Combine(
       Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
       @"StarWars.db");

        /// <summary>
        /// On attend ici d'avoir le nom d'un personnage. 
        /// La méthode actuellement utlisée ne serait-elle pas un peu trop brutale ?
        /// </summary>
        /// <returns></returns>  
        public static List<string> GetName()
        {
            

            List<string> names = new List<string>();

            using (var connection = new SqliteConnection("Data Source=" + sqlitePath))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText ="SELECT * FROM Characters";


                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        names.Add(reader.GetString(1));                        
                    }
                }
                connection.Close();

            }

            return names;

        }


        public static List<string> GetNameCorrected()
        {
            List<string> names = new List<string>();

            using (var connection = new SqliteConnection("Data Source=" + sqlitePath))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Characters";


                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        names.Add(reader.GetString(1));
                    }
                }
                connection.Close();

            }

            return names;

        }

        /// <summary>
        /// On cherche à avoir la planete d'origine d'un habitant. On est sur une optimisation de requête.
        /// Peut-être voir avec une jointure ? Attention on doit toujours obtenir le même résultat.
        /// </summary>
        /// <returns></returns>
        public static List<HomePlanetCharacter>  GetHomePlanet()
        {
            List<HomePlanetCharacter> homePlanetsCharacters = new List<HomePlanetCharacter>();

            using (var connection = new SqliteConnection("Data Source=" + sqlitePath))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                SELECT c.Name,(SELECT Name FROM Planets WHERE ID = c.HomeplanetId) AS HomePlanetName 
                FROM Characters c";


                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string home = reader.IsDBNull(reader.GetOrdinal("HomePlanetName")) ? "null" : reader.GetString(1);

                        homePlanetsCharacters.Add(new HomePlanetCharacter(reader.GetString(0),home));
                    }
                }
                connection.Close();

            }

            return homePlanetsCharacters;
        }

        

        public static List<HomePlanetCharacter> GetHomePlanetCorrected()
        {
            List<HomePlanetCharacter> homePlanetsCharacters = new List<HomePlanetCharacter>();

            using (var connection = new SqliteConnection("Data Source=" + sqlitePath))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                SELECT c.Name,(SELECT Name FROM Planets WHERE ID = c.HomeplanetId) AS HomePlanetName 
                FROM Characters c";


                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string home = reader.IsDBNull(reader.GetOrdinal("HomePlanetName")) ? "null" : reader.GetString(1);

                        homePlanetsCharacters.Add(new HomePlanetCharacter(reader.GetString(0), home));
                    }
                }

                connection.Close();

            }

            return homePlanetsCharacters;
        }


        public static List<CharacterFromEpisode> GetCharacterEpisodes()
        {
            List<CharacterFromEpisode> characterEpisodes = new List<CharacterFromEpisode>();

            using (var connection = new SqliteConnection("Data Source=" + sqlitePath))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                SELECT
                c.Name,
                ce.EpisodeId
                FROM Characters c
                INNER JOIN CharacterEpisodes ce
                ON c.Id = ce.CharacterId
                Inner JOIN Episodes e
                ON ce.EpisodeId = e.Id
                Group by c.Name,
                e.ID
                HAVING ce.EpisodeId = 5";


                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        characterEpisodes.Add(new CharacterFromEpisode(reader.GetString(0), int.Parse(reader.GetString(1))));
                    }
                }
                connection.Close();
            }



            return characterEpisodes;
        }



        public static List<CharacterFromEpisode> GetCharacterEpisodesCorrected()
        {
            List<CharacterFromEpisode> characterEpisodes = new List<CharacterFromEpisode>();

            using (var connection = new SqliteConnection("Data Source=" + sqlitePath))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                SELECT
                c.Name,
                ce.EpisodeId
                FROM Characters c
                INNER JOIN CharacterEpisodes ce
                ON c.Id = ce.CharacterId
                Inner JOIN Episodes e
                ON ce.EpisodeId = e.Id
                Group by c.Name,
                e.ID
                HAVING ce.EpisodeId = 5";


                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        characterEpisodes.Add(new CharacterFromEpisode(reader.GetString(0), int.Parse(reader.GetString(1))));
                    }
                }
                connection.Close();
            }            

            return characterEpisodes;
        }

        /// <summary>
        /// Ici on a déjà une requête fonctionnelle. Seulement elle ne renvoie pas le bon nom.
        /// On cherche l'ami de Luke Skywalker vivant sur la planète Alderaan.
        /// Vous pouvez directement modifier la requête.
        /// </summary>
        /// <returns></returns>

        public static List<string> GetCharacterFriendLuke()
        {
            List<string> characterFriend = new List<string>();

            using (var connection = new SqliteConnection("Data Source=StarWars.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                SELECT
                c.Name
                FROM Characters c
                INNER JOIN CharacterFriends cf
                ON c.Id = cf.CharacterId";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        characterFriend.Add(reader.GetString(0));
                    }
                }
                connection.Close();
            }



            return characterFriend;
        }



    }
}
