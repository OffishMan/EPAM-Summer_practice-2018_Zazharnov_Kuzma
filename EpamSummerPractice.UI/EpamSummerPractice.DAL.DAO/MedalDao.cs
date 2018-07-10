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

        public void Add(Medal medal)
        {
            using (var connetion = new SqlConnection(_connectionString))
            {
                SqlCommand command = connetion.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "CreateMedal";            //Имя хранимой процедуры

                var parameter = new SqlParameter("@", SqlDbType.NVarChar) { Value = medal.Title};
                command.Parameters.Add("@", SqlDbType.NVarChar);

                //return (int)(decimal)command.ExecuteScalar();
            }
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Medal> GetAll()
        {
            using (var connetion = new SqlConnection(_connectionString))
            {
                var command = connetion.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;

                command.CommandText = @"SELECT * FROM Medals";
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

                //return (int)(decimal)command.ExecuteScalar();
            }
        }

        public Medal ShowById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Medal medal)
        {
            throw new NotImplementedException();
        }
    }
}
