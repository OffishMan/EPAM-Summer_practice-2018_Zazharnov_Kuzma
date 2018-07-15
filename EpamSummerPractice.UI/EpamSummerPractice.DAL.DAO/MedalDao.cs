using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamSummerPractice.DAL.Interface;
using System.Configuration;
using Entities;
using System.Data.SqlClient;
using System.Data;

namespace EpamSummerPractice.DAL.DAO
{
    public class MedalDao : IMedalDao
    {
        private readonly string _connectionString;

        public MedalDao()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        }

        public int Add(Medal medal)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "CreateMedal";            //Имя хранимой процедуры

                var title = new SqlParameter("@Title", SqlDbType.NVarChar)
                {
                    Value = medal.Title
                };
                command.Parameters.Add(title);


                var material = new SqlParameter("@Material", SqlDbType.NVarChar)
                {
                    Value = medal.Material
                };
                command.Parameters.Add(material);
                connection.Open();
                //command.ExecuteNonQuery();
                return (int)(decimal)command.ExecuteScalar();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "RemoveMedal";            //Имя хранимой процедуры

                var identificator = new SqlParameter("@ID", SqlDbType.Int)
                {
                    Value = id
                };
                command.Parameters.Add(identificator);
                                              
                connection.Open();
                command.ExecuteNonQuery();                
            }
        }

        public IEnumerable<Medal> GetAll()
        {
            using (var connetion = new SqlConnection(_connectionString))
            {
                var command = connetion.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ShowAllMedals";
                //command.CommandText = @"SELECT * FROM Medals"; //Возможный, но нежелательный вариант
                connetion.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Medal()
                    {
                        Id = (int)reader["ID"],
                        Title = (string)reader["Title"],
                        Material = (string)reader["Material"]
                    };
                }            
            }
            //return null;
        }

        public Medal ShowById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ReturnMedalByID";            //Имя хранимой процедуры

                var identificator = new SqlParameter("@ID", SqlDbType.Int)
                {
                    Value = id
                };
                command.Parameters.Add(identificator);

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    return new Medal()
                    {
                        Id = (int)reader["ID"],
                        Title = (string)reader["Title"],
                        Material = (string)reader["Material"]
                    };
                }
            }
            return null;
        }

        public bool UsedInReward(int medalId)
        {
            using (var connetion = new SqlConnection(_connectionString))
            {
                var command = connetion.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "FindRewardByMedalID";

                var medalID = new SqlParameter("@id", SqlDbType.Int)
                {
                    Value = medalId
                };

                command.Parameters.Add(medalID);
                connetion.Open();
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return true;
                }
            }
            return false;
        }

        public void Update(int medalId, Medal medal)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UpdateMedal";            //Имя хранимой процедуры

                var identificator = new SqlParameter("@id", SqlDbType.Int)
                {
                    Value = medalId
                };
                command.Parameters.Add(identificator);

                var title = new SqlParameter("@Title", SqlDbType.NVarChar)
                {
                    Value = medal.Title
                };
                command.Parameters.Add(title);

                var material = new SqlParameter("@Material", SqlDbType.NVarChar)
                {
                    Value = medal.Material
                };
                command.Parameters.Add(material);



                connection.Open();
                command.ExecuteNonQuery();               
            }
        }        
    }
}
