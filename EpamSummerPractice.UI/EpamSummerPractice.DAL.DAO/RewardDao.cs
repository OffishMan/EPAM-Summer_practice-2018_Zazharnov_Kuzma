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
    public class RewardDao : IRewardDao
    {
        private readonly string _connectionString;

        public RewardDao()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        }
        public void Add(Reward reward)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "CreateReward";

                var personID = new SqlParameter("@IdP", SqlDbType.NVarChar)
                {
                    Value = reward.PersonID
                };
                command.Parameters.Add(personID);


                var medalID = new SqlParameter("@IdM", SqlDbType.NVarChar)
                {
                    Value = reward.MedalID
                };
                command.Parameters.Add(medalID);
                connection.Open();
                command.ExecuteNonQuery();

            }
        }

        public void Delete(Reward reward)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "RemoveReward";

                var personID = new SqlParameter("@Person_ID", SqlDbType.NVarChar)
                {
                    Value = reward.PersonID
                };
                command.Parameters.Add(personID);


                var medalID = new SqlParameter("@Medal_ID", SqlDbType.NVarChar)
                {
                    Value = reward.MedalID
                };

                command.Parameters.Add(medalID);
                connection.Open();
                command.ExecuteNonQuery();

            }
        }

        public bool IsPersonCreated(int personId)
        {
            using (var connetion = new SqlConnection(_connectionString))
            {
                var command = connetion.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ReturnPersonByID";

                var personID = new SqlParameter("@id", SqlDbType.Int)
                {
                    Value = personId
                };

                command.Parameters.Add(personID);
                connetion.Open();
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsMedalCreated(int medalId)
        {
            using (var connetion = new SqlConnection(_connectionString))
            {
                var command = connetion.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ReturnMedalByID";

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

        public IEnumerable<string> GetAll()
        {
            using (var connetion = new SqlConnection(_connectionString))
            {
                List<string> list = new List<string>();
                var command = connetion.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ShowAllRewards";                
                connetion.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(($"{(string)reader["Name"]} {(string)reader["Surname"]}: {(string)reader["Material"]} {(string)reader["Title"]}"));
                }
                return list;
            }
        }

        //public Reward GetFirstByMedalId(int id)
        //{
        //    using (var connetion = new SqlConnection(_connectionString))
        //    {
        //        var command = connetion.CreateCommand();
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.CommandText = "ShowRewardsByMedalID";

        //        var medalID = new SqlParameter("@Medal_ID", SqlDbType.Int)
        //        {
        //            Value = id
        //        };

        //        command.Parameters.Add(medalID);
        //        connetion.Open();
        //        var reader = command.ExecuteReader();

        //        if (reader.Read())
        //        {
        //            return new Reward()
        //            {
        //                PersonID = (int)reader["Person_ID"],
        //                MedalID = (int)reader["Medal_ID"]
        //            };
        //        }
        //    }
        //    return null;
        //}

        //public Reward GetFirstByPersonId(int id)
        //{
        //    using (var connetion = new SqlConnection(_connectionString))
        //    {
        //        var command = connetion.CreateCommand();
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.CommandText = "ShowRewardsByMedalID";

        //        var personID = new SqlParameter("@Person_ID", SqlDbType.Int)
        //        {
        //            Value = id
        //        };

        //        command.Parameters.Add(personID);
        //        connetion.Open();
        //        var reader = command.ExecuteReader();

        //        if (reader.Read())
        //        {
        //            return new Reward()
        //            {
        //                PersonID = (int)reader["Person_ID"],
        //                MedalID = (int)reader["Medal_ID"]
        //            };
        //        }
        //    }
        //    return null;
        //}
    }
}
