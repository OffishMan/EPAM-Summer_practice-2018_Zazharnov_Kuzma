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

        public IEnumerable<Reward> GetAll()
        {
            using (var connetion = new SqlConnection(_connectionString))
            {
                var command = connetion.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ShowAllRewards";                
                connetion.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Reward()
                    {
                        PersonID = (int)reader["Person_ID"],  //Потом заменить на соответсвующие выводу поля, наверное на уровне логики
                        MedalID = (int)reader["Medal_ID"]
                    };
                }
            }
        }

        public Reward GetFirstByMedalId(int id)
        {
            using (var connetion = new SqlConnection(_connectionString))
            {
                var command = connetion.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ShowRewardsByMedalID";

                var medalID = new SqlParameter("@Medal_ID", SqlDbType.Int)
                {
                    Value = id
                };

                command.Parameters.Add(medalID);
                connetion.Open();
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Reward()
                    {
                        PersonID = (int)reader["Person_ID"],
                        MedalID = (int)reader["Medal_ID"]
                    };
                }
            }
            return null;
        }

        public Reward GetFirstByPersonId(int id)
        {
            using (var connetion = new SqlConnection(_connectionString))
            {
                var command = connetion.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ShowRewardsByMedalID";

                var personID = new SqlParameter("@Person_ID", SqlDbType.Int)
                {
                    Value = id
                };

                command.Parameters.Add(personID);
                connetion.Open();
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Reward()
                    {
                        PersonID = (int)reader["Person_ID"],
                        MedalID = (int)reader["Medal_ID"]
                    };
                }
            }
            return null;
        }
    }
}
