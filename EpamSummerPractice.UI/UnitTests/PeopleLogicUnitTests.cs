using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Entities;
using EpamSummerPractice.BLL.Logic;
using EpamSummerPractice.DAL.Interface;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class PeopleLogicUnitTests
    {
        int id;

        #region Add

        [TestMethod]
        public void CorrectDataAdding()
        {
            var mock = new Mock<IPeopleDao>();
            mock.Setup(item => item.Add(It.IsAny<Person>())).Returns(7);
            var logic = new PeopleLogic(mock.Object);


            id = logic.Add("Eldar", "Petrov", new DateTime(1993, 12, 27), 25,
                "Omsk", "50 years of October", "51b");

            Assert.AreEqual(id, 7, "Method Add doesn't work");
        }

        [ExpectedException(typeof(ArgumentNullException), "Name not null. Method Add")]
        [TestMethod]
        public void AddNullName()
        {
            var mock = new Mock<IPeopleDao>();
            mock.Setup(item => item.Add(It.IsAny<Person>())).Returns(7);
            var logic = new PeopleLogic(mock.Object);
            id = logic.Add(null, "Petrov", new DateTime(1993, 12, 27), 25,
                "Omsk", "50 years of October", "51b");
        }

        [ExpectedException(typeof(ArgumentNullException), "Surname not null. Method Add")]
        [TestMethod]
        public void AddNullSurname()
        {
            var mock = new Mock<IPeopleDao>();
            mock.Setup(item => item.Add(It.IsAny<Person>())).Returns(7);
            var logic = new PeopleLogic(mock.Object);
            logic.Add("Eldar", null, new DateTime(1993, 12, 27), 25,
                "Omsk", "50 years of October", "51b");
        }

        [ExpectedException(typeof(Exception), "Correct date. Method Add")]
        [TestMethod]
        public void AddWrongDate()
        {
            var mock = new Mock<IPeopleDao>();
            mock.Setup(item => item.Add(It.IsAny<Person>())).Returns(7);
            var logic = new PeopleLogic(mock.Object);
            logic.Add("Eldar", "Petrov", new DateTime(2020, 12, 27), 25,
                "Omsk", "50 years of October", "51b");
        }

        [ExpectedException(typeof(Exception), "Correct age. Method Add")]
        [TestMethod]
        public void AddWrongAge()
        {
            var mock = new Mock<IPeopleDao>();
            mock.Setup(item => item.Add(It.IsAny<Person>())).Returns(7);
            var logic = new PeopleLogic(mock.Object);
            logic.Add("Eldar", "Petrov", new DateTime(1993, 12, 27), 27,
                "Omsk", "50 years of October", "51b");
        }

        [ExpectedException(typeof(Exception), "City name is correct. Method Add")]
        [TestMethod]
        public void AddIncorrectCity()
        {
            var mock = new Mock<IPeopleDao>();
            mock.Setup(item => item.Add(It.IsAny<Person>())).Returns(7);
            var logic = new PeopleLogic(mock.Object);
            logic.Add("Eldar", "Petrov", new DateTime(1993, 12, 27), 25,
                "Om5sk", "50 years of October", "51b");
        }

        [ExpectedException(typeof(ArgumentNullException), "City not null. Method Add")]
        [TestMethod]
        public void AddNullCity()
        {
            var mock = new Mock<IPeopleDao>();
            mock.Setup(item => item.Add(It.IsAny<Person>())).Returns(7);
            var logic = new PeopleLogic(mock.Object);
            logic.Add("Eldar", "Petrov", new DateTime(1993, 12, 27), 25,
                null, "50 years of October", "51b");
        }

        [ExpectedException(typeof(ArgumentNullException), "Street not null. Method Add")]
        [TestMethod]
        public void AddNullStreet()
        {
            var mock = new Mock<IPeopleDao>();
            mock.Setup(item => item.Add(It.IsAny<Person>())).Returns(7);
            var logic = new PeopleLogic(mock.Object);
            logic.Add("Eldar", "Petrov", new DateTime(1993, 12, 27), 25,
                "Omsk", null, "51b");
        }

        [ExpectedException(typeof(Exception), "Name not null. Method Add")]
        [TestMethod]
        public void AddIncorrectHouseNumber()
        {
            var mock = new Mock<IPeopleDao>();
            mock.Setup(item => item.Add(It.IsAny<Person>())).Returns(7);
            var logic = new PeopleLogic(mock.Object);
            logic.Add("Eldar", "Petrov", new DateTime(1993, 12, 27), 25,
                 "Omsk", "50 years of October", "b");
        }

        [ExpectedException(typeof(ArgumentNullException), "Name not null. Method Add")]
        [TestMethod]
        public void AddNullHouseNumber()
        {
            var mock = new Mock<IPeopleDao>();
            mock.Setup(item => item.Add(It.IsAny<Person>())).Returns(7);
            var logic = new PeopleLogic(mock.Object);
            logic.Add("Eldar", "Petrov", new DateTime(1993, 12, 27), 25,
                 "Omsk", "50 years of October", null);
        }
        #endregion

        #region Update
        [TestMethod]
        public void CorrectDataUpdating()
        {
            var mock = new Mock<IPeopleDao>();
            mock.Setup(item => item.ShowById(It.Is<int>(v => v == 5))).Returns(
                new Person
                {
                    Id = 5,
                    Name = "Victor",
                    Surname = "Petrov",
                    DateOfBirth = new DateTime(1993, 12, 27),
                    Age = 25,
                    City = "Omsk",
                    Street = "50 years of October",
                    NumberOfHouse = "51b"
                });
            var logic = new PeopleLogic(mock.Object);

            mock.Setup(item => item.Update(It.IsAny<Person>()));            

            Assert.AreEqual(true, logic.Update(5, "Eldar", "Petrov", new DateTime(1993, 12, 27), 25,
                                    "Omsk", "50 years of October", "51b"), "Method Update doesn't work");
        }

        [ExpectedException(typeof(ArgumentNullException), "Name not null. Method Update")]
        [TestMethod]
        public void UpdateNullName()
        {
            var mock = new Mock<IPeopleDao>();
            mock.Setup(item => item.ShowById(It.IsAny<int>())).Returns(
                new Person
                {
                    Name = "Victor",
                    Surname = "Petrov",
                    DateOfBirth = new DateTime(1993, 12, 27),
                    Age = 25,
                    City = "Omsk",
                    Street = "50 years of October",
                    NumberOfHouse = "51b"
                });
            var logic = new PeopleLogic(mock.Object);

            mock.Setup(item => item.Update(It.IsAny<Person>()));

            logic.Update(0, null, "Petrov", new DateTime(1993, 12, 27), 25,
                "Omsk", "50 years of October", "51b");
        }

        [ExpectedException(typeof(ArgumentNullException), "Surname not null. Method Update")]
        [TestMethod]
        public void UpdateNullSurname()
        {
            var mock = new Mock<IPeopleDao>();
            mock.Setup(item => item.ShowById(It.IsAny<int>())).Returns(
                new Person
                {
                    Name = "Victor",
                    Surname = "Petrov",
                    DateOfBirth = new DateTime(1993, 12, 27),
                    Age = 25,
                    City = "Omsk",
                    Street = "50 years of October",
                    NumberOfHouse = "51b"
                });
            var logic = new PeopleLogic(mock.Object);

            mock.Setup(item => item.Update(It.IsAny<Person>()));

            logic.Update(0, "Eldar", null, new DateTime(1993, 12, 27), 25,
                "Omsk", "50 years of October", "51b");
        }

        [ExpectedException(typeof(Exception), "Correct date. Method Update")]
        [TestMethod]
        public void UpdateWrongDate()
        {
            var mock = new Mock<IPeopleDao>();
            mock.Setup(item => item.ShowById(It.IsAny<int>())).Returns(
                new Person
                {
                    Name = "Victor",
                    Surname = "Petrov",
                    DateOfBirth = new DateTime(1993, 12, 27),
                    Age = 25,
                    City = "Omsk",
                    Street = "50 years of October",
                    NumberOfHouse = "51b"
                });
            var logic = new PeopleLogic(mock.Object);

            mock.Setup(item => item.Update(It.IsAny<Person>()));

            logic.Update(0, "Eldar", "Petrov", new DateTime(2020, 12, 27), 25,
                "Omsk", "50 years of October", "51b");
        }

        [ExpectedException(typeof(Exception), "Correct age. Method Update")]
        [TestMethod]
        public void UpdateWrongAge()
        {
            var mock = new Mock<IPeopleDao>();
            mock.Setup(item => item.ShowById(It.IsAny<int>())).Returns(
                new Person
                {
                    Name = "Victor",
                    Surname = "Petrov",
                    DateOfBirth = new DateTime(1993, 12, 27),
                    Age = 25,
                    City = "Omsk",
                    Street = "50 years of October",
                    NumberOfHouse = "51b"
                });
            var logic = new PeopleLogic(mock.Object);

            mock.Setup(item => item.Update(It.IsAny<Person>()));

            logic.Update(0, "Eldar", "Petrov", new DateTime(1993, 12, 27), 27,
                "Omsk", "50 years of October", "51b");
        }

        [ExpectedException(typeof(Exception), "City name is correct. Method Update")]
        [TestMethod]
        public void UpdateIncorrectCity()
        {
            var mock = new Mock<IPeopleDao>();
            mock.Setup(item => item.ShowById(It.IsAny<int>())).Returns(
                new Person
                {
                    Name = "Victor",
                    Surname = "Petrov",
                    DateOfBirth = new DateTime(1993, 12, 27),
                    Age = 25,
                    City = "Omsk",
                    Street = "50 years of October",
                    NumberOfHouse = "51b"
                });
            var logic = new PeopleLogic(mock.Object);

            mock.Setup(item => item.Update(It.IsAny<Person>()));

            logic.Update(0, "Eldar", "Petrov", new DateTime(1993, 12, 27), 25,
                "Om5sk", "50 years of October", "51b");
        }

        [ExpectedException(typeof(ArgumentNullException), "City not null. Method Update")]
        [TestMethod]
        public void UpdateNullCity()
        {
            var mock = new Mock<IPeopleDao>();
            mock.Setup(item => item.ShowById(It.IsAny<int>())).Returns(
                new Person
                {
                    Name = "Victor",
                    Surname = "Petrov",
                    DateOfBirth = new DateTime(1993, 12, 27),
                    Age = 25,
                    City = "Omsk",
                    Street = "50 years of October",
                    NumberOfHouse = "51b"
                });
            var logic = new PeopleLogic(mock.Object);

            mock.Setup(item => item.Update(It.IsAny<Person>()));

            logic.Update(0, "Eldar", "Petrov", new DateTime(1993, 12, 27), 25,
                null, "50 years of October", "51b");
        }

        [ExpectedException(typeof(ArgumentNullException), "Street not null. Method Update")]
        [TestMethod]
        public void UpdateNullStreet()
        {
            var mock = new Mock<IPeopleDao>();
            mock.Setup(item => item.ShowById(It.IsAny<int>())).Returns(
                new Person
                {
                    Name = "Victor",
                    Surname = "Petrov",
                    DateOfBirth = new DateTime(1993, 12, 27),
                    Age = 25,
                    City = "Omsk",
                    Street = "50 years of October",
                    NumberOfHouse = "51b"
                });
            var logic = new PeopleLogic(mock.Object);

            mock.Setup(item => item.Update(It.IsAny<Person>()));

            logic.Update(0, "Eldar", "Petrov", new DateTime(1993, 12, 27), 25,
                "Omsk", null, "51b");
        }

        [ExpectedException(typeof(Exception), "Name not null. Method Update")]
        [TestMethod]
        public void UpdateIncorrectHouseNumber()
        {
            var mock = new Mock<IPeopleDao>();
            mock.Setup(item => item.ShowById(It.IsAny<int>())).Returns(
                new Person
                {
                    Name = "Victor",
                    Surname = "Petrov",
                    DateOfBirth = new DateTime(1993, 12, 27),
                    Age = 25,
                    City = "Omsk",
                    Street = "50 years of October",
                    NumberOfHouse = "51b"
                });
            var logic = new PeopleLogic(mock.Object);

            mock.Setup(item => item.Update(It.IsAny<Person>()));

            logic.Update(0, "Eldar", "Petrov", new DateTime(1993, 12, 27), 25,
                             "Omsk", "50 years of October", "b");
        }

        [ExpectedException(typeof(ArgumentNullException), "Name not null. Method Update")]
        [TestMethod]
        public void UpdateNullHouseNumber()
        {
            var mock = new Mock<IPeopleDao>();
            mock.Setup(item => item.ShowById(It.IsAny<int>())).Returns(
                new Person
                {
                    Name = "Victor",
                    Surname = "Petrov",
                    DateOfBirth = new DateTime(1993, 12, 27),
                    Age = 25,
                    City = "Omsk",
                    Street = "50 years of October",
                    NumberOfHouse = "51b"
                });
            var logic = new PeopleLogic(mock.Object);

            mock.Setup(item => item.Update(It.IsAny<Person>()));           

            logic.Update(0, "Eldar", "Petrov", new DateTime(1993, 12, 27), 25,
                 "Omsk", "50 years of October", null);
        }

        #endregion

        [TestMethod]
        public void GetByIDPerson()
        {
            var mock = new Mock<IPeopleDao>();
            mock.Setup(item => item.ShowById(It.Is<int>(v => v == 7))).Returns(
                new Person
                {
                    Id = 7,
                    Name = "Victor",
                    Surname = "Petrov",
                    DateOfBirth = new DateTime(1993, 12, 27),
                    Age = 25,
                    City = "Omsk",
                    Street = "50 years of October",
                    NumberOfHouse = "51b"
                });
            
            var logic = new PeopleLogic(mock.Object);

            Person person = new Person
            {
                Id = 7,
                Name = "Victor",
                Surname = "Petrov",
                DateOfBirth = new DateTime(1993, 12, 27),
                Age = 25,
                City = "Omsk",
                Street = "50 years of October",
                NumberOfHouse = "51b"
            };            

            Assert.AreEqual(Person.ToString(logic.ShowById(7)), Person.ToString(person), "Method ShowByID doesn't work");
        }

        [TestMethod]
        public void DeletePersonWithoutException()
        {
            var mock = new Mock<IPeopleDao>();
            mock.Setup(item => item.ShowById(It.Is<int>(v => v == 7))).Returns(
                new Person
                {
                    Id = 7,
                    Name = "Victor",
                    Surname = "Petrov",
                    DateOfBirth = new DateTime(1993, 12, 27),
                    Age = 25,
                    City = "Omsk",
                    Street = "50 years of October",
                    NumberOfHouse = "51b"
                });
            mock.Setup(item => item.ShowById(It.Is<int>(v => v == 9))).Returns(
                new Person
                {
                    Id = 9,
                    Name = "Alexander",
                    Surname = "Indropov",
                    DateOfBirth = new DateTime(1993, 11, 23),
                    Age = 25,
                    City = "Omsk",
                    Street = "50 years of October",
                    NumberOfHouse = "22/24"
                });

            mock.Setup(item => item.Delete(It.IsAny<int>()));

            var logic = new PeopleLogic(mock.Object);



            Assert.AreEqual(true, logic.Delete(9), "Expected exception by delete");
        }

        [ExpectedException(typeof(Exception), "Person with this ID is exist. Method Delete")]
        [TestMethod]
        public void DeletePersonWithException()
        {
            var mock = new Mock<IPeopleDao>();
            mock.Setup(item => item.ShowById(It.Is<int>(v => v == 7))).Returns(
                new Person
                {
                    Id = 7,
                    Name = "Victor",
                    Surname = "Petrov",
                    DateOfBirth = new DateTime(1993, 12, 27),
                    Age = 25,
                    City = "Omsk",
                    Street = "50 years of October",
                    NumberOfHouse = "51b"
                });
            mock.Setup(item => item.ShowById(It.Is<int>(v => v == 9))).Returns(
                new Person
                {
                    Id = 9,
                    Name = "Alexander",
                    Surname = "Indropov",
                    DateOfBirth = new DateTime(1993, 11, 23),
                    Age = 25,
                    City = "Omsk",
                    Street = "50 years of October",
                    NumberOfHouse = "22/24"
                });            

            mock.Setup(item => item.Delete(It.IsAny<int>()));

            var logic = new PeopleLogic(mock.Object);

            

            Assert.AreEqual(true, logic.Delete(5), "Expected exception by delete" );
        }

        [TestMethod]
        public void TryGetAll()
        {
            var mock = new Mock<IPeopleDao>();
            mock.Setup(item => item.GetAll()).Returns(new List<Person>()
            {
                new Person
                 {
                     Name = "Eldar",
                     Surname = "Petrov",
                     DateOfBirth = new DateTime(1993, 12, 27),
                     Age = 25,
                     City = "Omsk",
                     Street = "50 years of October",
                     NumberOfHouse = "51b"
                 }
            });
            var logic = new PeopleLogic(mock.Object);
            var list = logic.GetAll().ToList();
            Assert.AreEqual(list.Count, 1);
        }



        [TestMethod]
        public void TryGetAllReward()
        {
            var mock = new Mock<IPeopleDao>();
            mock.Setup(item => item.GetAllRewards()).Returns(new List<string>()
            {
                "Ivanov Petr: Gold For Moqing Update",
                "Petrov Ivan: Silver For Moqing Delete",
                "Bad fantasy: Bronze For nothing"
            });

            var logic = new PeopleLogic(mock.Object);
            var list = logic.GetAllRewards().ToList();
            Assert.AreEqual(list.Count, 3);
        }
    }
}
