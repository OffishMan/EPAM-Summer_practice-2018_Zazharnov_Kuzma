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
    public class PeopleDao : IPeopleDao
    {
        private readonly string _connectionString;

        public PeopleDao()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        }
        public int Add(Person person)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "CreatePerson";           

                var name = new SqlParameter("@Name", SqlDbType.NVarChar)
                {
                    Value = person.Name
                };
                command.Parameters.Add(name);

                var surname = new SqlParameter("@Surname", SqlDbType.NVarChar)
                {
                    Value = person.Surname
                };
                command.Parameters.Add(surname);
                
                var dateOfBirth = new SqlParameter("@Date_of_birth", SqlDbType.DateTime)
                {
                    Value = person.DateOfBirth
                };
                command.Parameters.Add(dateOfBirth);
                
                var age = new SqlParameter("@Age", SqlDbType.Int)
                {
                    Value = person.Age
                };
                command.Parameters.Add(age);
                
                var city = new SqlParameter("@City", SqlDbType.NVarChar)
                {
                    Value = person.City
                };
                command.Parameters.Add(city);
                
                var street = new SqlParameter("@Street", SqlDbType.NVarChar)
                {
                    Value = person.Street
                };
                command.Parameters.Add(street);

                var houseNumber = new SqlParameter("@House_number", SqlDbType.NVarChar)
                {
                    Value = person.NumberOfHouse
                };
                command.Parameters.Add(houseNumber);

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
                command.CommandText = "RemovePerson";

                var identificator = new SqlParameter("@ID", SqlDbType.Int)
                {
                    Value = id
                };
                command.Parameters.Add(identificator);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Person> GetAll()
        {
            using (var connetion = new SqlConnection(_connectionString))
            {
                var command = connetion.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ShowAllPeople";
                connetion.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Person()
                    {
                        Id = (int)reader["ID"],
                        Name = (string)reader["Name"],
                        Surname = (string)reader["Surname"],
                        DateOfBirth = (DateTime)reader["Date_of_birth"],
                        Age = (int)reader["Age"],
                        City = (string)reader["City"],
                        Street = (string)reader["Street"],
                        NumberOfHouse = (string)reader["House_number"]
                    };
                }
            }
            //return null;
        }

        public Person ShowById(int id)
        {
            using (var connetion = new SqlConnection(_connectionString))
            {
                var command = connetion.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ReturnPersonByID";

                var identificator = new SqlParameter("@ID", SqlDbType.Int)
                {
                    Value = id
                };
                command.Parameters.Add(identificator);

                connetion.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    return new Person()
                    {
                        Id = (int)reader["ID"],
                        Name = (string)reader["Name"],
                        Surname = (string)reader["Surname"],
                        DateOfBirth = (DateTime)reader["Date_of_birth"],
                        Age = (int)reader["Age"],
                        City = (string)reader["City"],
                        Street = (string)reader["Street"],
                        NumberOfHouse = (string)reader["House_number"]
                    };
                }
            }
            return null;
        }

        public void Update(Person person)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UpdatePerson";

                var identificator = new SqlParameter("@ID", SqlDbType.Int)
                {
                    Value = person.Id
                };
                command.Parameters.Add(identificator);

                var name = new SqlParameter("@Name", SqlDbType.NVarChar)
                {
                    Value = person.Name
                };
                command.Parameters.Add(name);

                var surname = new SqlParameter("@Surname", SqlDbType.NVarChar)
                {
                    Value = person.Surname
                };
                command.Parameters.Add(surname);

                var dateOfBirth = new SqlParameter("@Date_of_birth", SqlDbType.DateTime)
                {
                    Value = person.DateOfBirth
                };
                command.Parameters.Add(dateOfBirth);

                var age = new SqlParameter("@Age", SqlDbType.Int)
                {
                    Value = person.Age
                };
                command.Parameters.Add(age);

                var city = new SqlParameter("@City", SqlDbType.NVarChar)
                {
                    Value = person.City
                };
                command.Parameters.Add(city);

                var street = new SqlParameter("@Street", SqlDbType.NVarChar)
                {
                    Value = person.Street
                };
                command.Parameters.Add(street);

                var houseNumber = new SqlParameter("@House_number", SqlDbType.NVarChar)
                {
                    Value = person.NumberOfHouse
                };
                command.Parameters.Add(houseNumber);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        #region Reward
        public void AddReward(int idP, int idM)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "CreateReward";

                var personID = new SqlParameter("@IdP", SqlDbType.NVarChar)
                {
                    Value = idP
                };
                command.Parameters.Add(personID);


                var medalID = new SqlParameter("@IdM", SqlDbType.NVarChar)
                {
                    Value = idM
                };
                command.Parameters.Add(medalID);
                connection.Open();
                command.ExecuteNonQuery();

            }
        }

        public void DeleteReward(int idP, int idM)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "RemoveReward";

                var personID = new SqlParameter("@idP", SqlDbType.NVarChar)
                {
                    Value = idP
                };
                command.Parameters.Add(personID);


                var medalID = new SqlParameter("@idM", SqlDbType.NVarChar)
                {
                    Value = idM
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

        public IEnumerable<string> GetAllRewards()
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
        #endregion
    }
}
