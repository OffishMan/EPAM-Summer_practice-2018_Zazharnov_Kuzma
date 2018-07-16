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
        private static int id;
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            NinjectCommon.Registration();            
        }

        [TestMethod]
        public void TestAdding()
        {            
            var personLogic = NinjectCommon.Kernel.Get<IPeopleLogic>();
            id = personLogic.Add("Vyacheslav", "Soloviev", new DateTime(1995, 12, 27), 23,
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

        [TestMethod]
        public void TestUpdating()
        {
            //NinjectCommon.Registration();
            var personLogic = NinjectCommon.Kernel.Get<IPeopleLogic>();

            Person person = personLogic.ShowById(id);
            person.Name = "Igor";

            personLogic.Update(id, "Igor", "Soloviev", new DateTime(1995, 12, 27), 23,
                "Samara", "Chapaeva", "22/24");

            Assert.AreEqual(personLogic.ToString(personLogic.ShowById(id)), personLogic.ToString(person),
                "Adding data about person incorrect");
        }

        [ExpectedException(typeof(NullReferenceException), "This item must be null")]
        [TestMethod]
        public void TestDeleting()
        {
            //NinjectCommon.Registration();
            var personLogic = NinjectCommon.Kernel.Get<IPeopleLogic>();

            Person person = personLogic.ShowById(id);

            personLogic.Delete(id);

            Assert.AreEqual(personLogic.ToString(personLogic.ShowById(id)), personLogic.ToString(person),
                "Adding data about person incorrect");
        }

    }
}
