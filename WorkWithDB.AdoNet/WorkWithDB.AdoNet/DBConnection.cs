using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ADO.NET.WorkWithDB;
using Microsoft.Extensions.Configuration;

namespace WorkWithDB.AdoNet
{
    class DBConnection
    {
        private readonly string connectionString;
        public DBConnection(string path)
        {
            this.connectionString = path;
        }

        public bool GetInfoFromDB(out List<GithubProfileModel> profiles)
        {
            profiles = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "select * from GithubProfile";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            profiles = new List<GithubProfileModel>();
                            while (reader.Read())
                            {
                                int row = reader.GetOrdinal("id");
                                profiles.Add(
                                    new GithubProfileModel
                                    {
                                        Id = reader.GetSqlInt32(row).Value,
                                        UserName = (string)GetValue(reader, "UserName"),
                                        Url = (string)GetValue(reader, "Url"),
                                        Company = (string)GetValue(reader, "Company"),
                                        Name = (string)GetValue(reader, "Name"),
                                        Bio = (string)GetValue(reader, "Bio"),
                                        Location = (string)GetValue(reader, "Location"),
                                        Email = (string)GetValue(reader, "Email"),
                                        BlogOrWebsite = (string)GetValue(reader, "BlogOrWebsite"),
                                        StarsCount = reader.GetInt32(reader.GetOrdinal("StarsCount")),
                                        ImageUrl = (string)GetValue(reader, "ImageUrl"),
                                        LastUpdate = (DateTime?)GetValue(reader, "LastUpdate"),
                                    }
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception e) when (e is InvalidOperationException || e is SqlException)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }

        public static object GetValue(SqlDataReader reader, string index)
        {
            if (reader[index] is DBNull)
                return null;
            return reader[index];
        }
    }
}
