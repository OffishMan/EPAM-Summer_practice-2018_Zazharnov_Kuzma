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
        public void Add(Person person)
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
                command.ExecuteNonQuery();
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

        public void Update(int id, Person person)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UpdatePerson";

                var identificator = new SqlParameter("@ID", SqlDbType.Int)
                {
                    Value = id
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
    }
}
