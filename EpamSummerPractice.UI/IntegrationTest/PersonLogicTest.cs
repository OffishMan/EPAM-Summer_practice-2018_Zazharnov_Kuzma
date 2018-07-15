using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EpamSummerPractice.DAL.Interface;
using EpamSummerPractice.BLL.Interface;
using NinjectContainer;
using Ninject;
using Entities;

namespace IntegrationTest
{
    [TestClass]
    public class PersonLogicTest
    {
        [TestMethod]
        public void TestAdding()
        {
            NinjectCommon.Registration();
            var personLogic = NinjectCommon.Kernel.Get<IPeopleLogic>();
            

            int id = personLogic.Add("Vyacheslav", "Soloviev", new DateTime(1995, 12, 27), 23, 
                "Samara", "Chapaeva", "22/24");
            var person = new Person
            {
                Name = "Vyacheslav",
                Surname = "Soloviev",
                DateOfBirth = new DateTime(1995, 12, 27),
                Age = 23,
                City = "Samara",
                Street = "Chapaeva",
                NumberOfHouse ="22/24"
            };

            Assert.AreEqual(personLogic.ToString(personLogic.ShowById(id)), personLogic.ToString(person),
                "Adding data about person incorrect");
        }
    }
}
