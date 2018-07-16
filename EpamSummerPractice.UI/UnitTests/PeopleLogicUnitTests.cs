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
    }
}
