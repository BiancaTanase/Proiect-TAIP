using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server;
using NUnit.Framework;
using Moq;

namespace TaipTestProject
{
    [TestClass]
    public class DatabaseTest
    {
        [TestCase("userName2", "userPassword2", "true")]
        [TestCase("", "userPassword2", "empty name or password")]
        [TestCase("userName", "", "empty name or password")]
        [TestCase("userName1", "userPassword1", "name already there")]
        [TestCase("userName1", "1234", "password to short")]
        public void TestAddUser(string inputName, string inputPassword, string expectedResult)
        {
            TAIPDatabase db = TAIPDatabase.Instance;
            string result = db.AddUser(inputName, inputPassword);
            NUnit.Framework.Assert.AreEqual(expectedResult, result);
        }

        [TestCase(null, null)]
        [NUnit.Framework.ExpectedException(typeof(ArgumentException))]
        public void TestAddUser_Invalid(string inputName, string inputPassword)
        {
            TAIPDatabase db = TAIPDatabase.Instance;
            string result = db.AddUser(inputName, inputPassword);
            NUnit.Framework.Assert.AreEqual("true", result);
        }

        [TestCase("name1", "pass1")]
        public void TestAddUser_Mock(string inputName, string inputPassword)
        {
            Mock<IStore> mockstore = new Mock<IStore>();
            TAIPDatabase db = TAIPDatabase.Instance;
            db.mockstore = mockstore.Object;
            string result = db.AddUser(inputName, inputPassword);
            mockstore.Verify(m => m.SaveChanges(), Times.Once);
        }
    }
}
