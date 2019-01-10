using Microsoft.VisualStudio.TestTools.UnitTesting;
using PointRobertsSoftware.StarTrek.Api.Controllers;
using PointRobertsSoftware.StarTrek.Api.Data;
using System.Collections.Generic;
using PointRobertsSoftware.StarTrek.Domain.Models;
using PointRobertsSoftware.StarTrek.Api.Models;
using PointRobertsSoftware.StarTrek.Api.Tests.TestMocks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace StarTrekApi.Tests
{
    [TestClass]
    public class UserTests
    {

        [TestMethod]
        public void GetAllUsersTest()
        {
            List<User> allUsers = new List<User> {
                new User { Id = 1, FirstName="Drew", LastName="Johnson", UserId="drjohnson" },
                new User { Id = 2, FirstName="Janey", LastName="Johnson", UserId="jajohnson" }
            };

            var testContext = new TestUserRepository
            {
                Users = allUsers
            };

            //var services = new ServiceCollection();
            //services.AddTransient<TestStartrekContext, DbContext>();

            var usersController = new UsersController(testContext);
            List<User> result = (List<User>)usersController.Get();

            Assert.AreEqual(allUsers.Count, result.Count);
            foreach (User user in allUsers)
            {
                result.Contains(user);
            }
        }

        [TestMethod]
        public void GetUserTest()
        {
            List<User> allUsers = new List<User> {
                new User { Id = 1, FirstName="Drew", LastName="Johnson", UserId="drjohnson" },
                new User { Id = 2, FirstName="Janey", LastName="Johnson", UserId="jajohnson" }
            };

            var testRepo = new TestUserRepository
            {
                Users = allUsers
            };

            var usersController = new UsersController(testRepo);
            ActionResult<User> result0 = usersController.Get(0).Result;
            ActionResult<User> result1 = usersController.Get(1).Result;
            ActionResult<User> result2 = usersController.Get(2).Result;
            ActionResult<User> result3 = usersController.Get(3).Result;

            Assert.IsInstanceOfType(result0.Result, typeof(BadRequestResult));


            Assert.AreEqual(result1.Value, allUsers[0]);
            Assert.IsNull(result1.Result);

            Assert.AreEqual(result2.Value, allUsers[1]);
            Assert.IsNull(result2.Result);

            Assert.IsInstanceOfType(result3.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void PostUserSuccessfulTest()
        {
            var userToAdd = new User { FirstName = "Drew", LastName = "Johnson", UserId = "drjohnson" };

            var testRepo = new TestUserRepository();

            var usersController = new UsersController(testRepo);

            ActionResult<User> actionResult = usersController.PostAsync(userToAdd).Result;

            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult));

            User actionResultValue = (User)((CreatedAtActionResult)actionResult.Result).Value;

            Assert.AreEqual(userToAdd.FirstName, actionResultValue.FirstName);
            Assert.AreEqual(userToAdd.LastName, actionResultValue.LastName);
            Assert.AreEqual(userToAdd.UserId, actionResultValue.UserId);
        }

        [TestMethod]
        public void PostUserIncorrectlyIncludesIdTest()
        {
            var userToAdd = new User { Id = 1, FirstName = "Drew", LastName = "Johnson", UserId = "drjohnson" };

            var testRepo = new TestUserRepository();

            var usersController = new UsersController(testRepo);

            ActionResult<User> actionResult = usersController.PostAsync(userToAdd).Result;

            Assert.IsInstanceOfType(actionResult.Result, typeof(BadRequestObjectResult));

            string actionResultValue = (string)((BadRequestObjectResult)actionResult.Result).Value;

            Assert.IsFalse(string.IsNullOrWhiteSpace(actionResultValue));

        }

        [TestMethod]
        public void PostUserWithoutFirstNameFailsTest()
        {
            var userToAdd = new User { LastName = "Johnson", UserId = "drjohnson" };

            var testRepo = new TestUserRepository();    

            var usersController = new UsersController(testRepo);

            ActionResult<User> actionResult = usersController.PostAsync(userToAdd).Result;

            Assert.IsInstanceOfType(actionResult.Result, typeof(BadRequestObjectResult));

            string actionResultValue = (string)((BadRequestObjectResult)actionResult.Result).Value;

            Assert.IsFalse(string.IsNullOrWhiteSpace(actionResultValue));
        }

        [TestMethod]
        public void PostUserWithoutUserIdTest()
        {
            var userToAdd = new User { FirstName = "Drew", LastName = "Johnson" };

            var testRepo = new TestUserRepository();

            var usersController = new UsersController(testRepo);

            ActionResult<User> actionResult = usersController.PostAsync(userToAdd).Result;

            Assert.IsInstanceOfType(actionResult.Result, typeof(BadRequestObjectResult));

            string actionResultValue = (string)((BadRequestObjectResult)actionResult.Result).Value;

            Assert.IsFalse(string.IsNullOrWhiteSpace(actionResultValue));
        }
    }
}

//[TestClass]
//public class MatchRepositoryTests
//{
//    private readonly IMatchRepository matchRepository;

//    public MatchRepositoryTests()
//    {
//        var services = new ServiceCollection();
//        services.AddTransient<IMatchRepository, MatchRepository>();

//        var serviceProvider = services.BuildServiceProvider();

//        matchRepository = serviceProvider.GetService<IMatchRepository>();
//    }
//}



