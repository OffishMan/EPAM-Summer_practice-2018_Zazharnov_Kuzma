using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Entities;
using EpamSummerPractice.BLL.Logic;
using EpamSummerPractice.DAL.Interface;
using System.Linq;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class MedalsLogicUnitTests
    {
        int id;       

        [TestMethod]
        public void CorrectDataAdding()
        {
            var mock = new Mock<IMedalDao>();
            mock.Setup(item => item.Add(It.IsAny<Medal>())).Returns(7);
            var logic = new MedalsLogic(mock.Object);


            id = logic.Add("GG", "Ice");

            Assert.AreEqual(id, 7, "Method Add doesn't work");
        }

        [ExpectedException(typeof(ArgumentNullException), "Title not null. Method Add")]
        [TestMethod]
        public void AddNullName()
        {
            var mock = new Mock<IMedalDao>();
            mock.Setup(item => item.Add(It.IsAny<Medal>())).Returns(7);
            var logic = new MedalsLogic(mock.Object);


            logic.Add(null, "Ice");
        }

        [ExpectedException(typeof(ArgumentNullException), "Material not null. Method Add")]
        [TestMethod]
        public void AddNullSurname()
        {
            var mock = new Mock<IMedalDao>();
            mock.Setup(item => item.Add(It.IsAny<Medal>())).Returns(7);
            var logic = new MedalsLogic(mock.Object);


            logic.Add("GG", null);
        }

        [TestMethod]
        public void CorrectDataUpdating()
        {
            var mock = new Mock<IMedalDao>();
            mock.Setup(item => item.ShowById(It.Is<int>(v => v == 7))).Returns(
                new Medal
                {
                    Id = 7,
                    Title = "GG",
                    Material = "Gold"
                });
            var logic = new MedalsLogic(mock.Object);

            mock.Setup(item => item.Update(It.IsAny<Medal>()));           

           

            Assert.AreEqual(true, logic.Update(7, "GG", "Silver"), "Method Update doesn't work");
        }

        [ExpectedException(typeof(ArgumentNullException), "Title not null. Method Update")]
        [TestMethod]
        public void UpdateNullTitle()
        {
            var mock = new Mock<IMedalDao>();
            mock.Setup(item => item.ShowById(It.IsAny<int>())).Returns(
                new Medal
                {
                    Title = "GG",
                    Material = "Gold"
                });
            var logic = new MedalsLogic(mock.Object);

            mock.Setup(item => item.Update(It.IsAny<Medal>()));
            
            logic.Update(0, null, "Silver");
        }

        [ExpectedException(typeof(ArgumentNullException), "Material not null. Method Update")]
        [TestMethod]
        public void UpdateNullMaterial()
        {
            var mock = new Mock<IMedalDao>();
            mock.Setup(item => item.ShowById(It.IsAny<int>())).Returns(
                new Medal
                {
                    Title = "GG",
                    Material = "Gold"
                });
            var logic = new MedalsLogic(mock.Object);

            mock.Setup(item => item.Update(It.IsAny<Medal>()));

            logic.Update(0, "GG", null);
        }

        [TestMethod]
        public void CorrectDataDeleting()
        {
            var mock = new Mock<IMedalDao>();
            mock.Setup(item => item.ShowById(It.Is<int>(v => v == 7))).Returns(
                new Medal
                {
                    Id = 7,
                    Title = "GG",
                    Material = "Gold"
                });
            var logic = new MedalsLogic(mock.Object);

            mock.Setup(item => item.Delete(It.IsAny<int>()));



            Assert.AreEqual(true, logic.Delete(7), "Method Delete doesn't work");
        }

        [ExpectedException(typeof(Exception), "Medal with this ID is exist. Method Delete")]
        [TestMethod]
        public void DeleteMedalWithException()
        {
            var mock = new Mock<IMedalDao>();
            mock.Setup(item => item.ShowById(It.Is<int>(v => v == 7))).Returns(
                new Medal
                {
                    Id = 7,
                    Title = "GG",
                    Material = "Gold"
                });
            var logic = new MedalsLogic(mock.Object);

            mock.Setup(item => item.Delete(It.IsAny<int>()));

            Assert.AreEqual(true, logic.Delete(5), "Method Delete doesn't work");
        }

        [TestMethod]
        public void TryGetAll()
        {
            var mock = new Mock<IMedalDao>();
            mock.Setup(item => item.GetAll()).Returns(new List<Medal>()
            {
                new Medal
                 {
                     Title = "G",
                     Material = "Gold"
                 }
            });
            var logic = new MedalsLogic(mock.Object);
            var list = logic.GetAll().ToList();
            Assert.AreEqual(list.Count, 1);
        }
    }
}
