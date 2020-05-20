using ContactManager.Api.Controllers;
using ContactManager.Data;
using ContactManager.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;

namespace ContactManager.Api.Tests
{
    public class ContactsTests
    {
        [Fact]
        public void TestGetContacts()
        {
            // Arrange
            var dbContext = DbContextMocker.GetContactsDbContext("TestDb");
            var controller = new ContactsController(dbContext);

            // Act
            var response = controller.Get() as ObjectResult;
            dbContext.Dispose();
            var resultList = (List<ContactViewModel>)response.Value;

            // Assert
            Assert.True(resultList.Count > 0);
        }
    }
}
