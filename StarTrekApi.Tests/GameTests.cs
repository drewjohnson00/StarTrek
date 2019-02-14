using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using PointRobertsSoftware.StarTrek.Domain.Models;
using PointRobertsSoftware.StarTrek.Api.Tests.TestMocks;
using PointRobertsSoftware.StarTrek.Api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace PointRobertsSoftware.StarTrek.Api.Tests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void GetAllGamesTest()
        {
            var allGames = new List<Game>();

            var game1 = new Game
            {
                Id = 1,
                PlayerIds = new int[] { 1 },
                GameState = new GameState
                {
                    Enterprise = new EnterpriseState { FuelLevel = 5000, ShieldLevel = 5000, Torpedoes = 20, QuadrantX = 1, QuadrantY = 1, SectorX = 2, SectorY = 2, Alive = true },
                    Bases = new BaseState[]
                    {
                        new BaseState { Energy = 2000, Shields = 2000, QuadrantX = 1, QuadrantY = 1, SectorX = 3, SectorY = 3, Alive = true },
                        new BaseState { Energy = 1500, Shields = 1999, QuadrantX = 1, QuadrantY = 1, SectorX = 4, SectorY = 4, Alive = true }
                    }
                }
            };

            allGames.Add(game1);

            var testContext = new TestGameRepository
            {
                Games = allGames
            };

            var gamesController = new GamesController(testContext);
            ActionResult<IEnumerable<Game>> actionResult = gamesController.Get();

            Assert.IsInstanceOfType(actionResult.Result, typeof(OkResult));

            var result = (List<Game>)actionResult.Value;

            Assert.AreEqual(allGames.Count, result.Count);
            foreach (Game game in allGames)
            {
                Assert.IsTrue(result.Contains(game));
            }
        }

        [TestMethod]
        public void GetGameTest()
        {
            var allGames = new List<Game>();

            var game1 = new Game
            {
                Id = 1,
                PlayerIds = new int[] { 1 },
                GameState = new GameState
                {
                    Enterprise = new EnterpriseState { FuelLevel = 5000, ShieldLevel = 5000, Torpedoes = 20, QuadrantX = 1, QuadrantY = 1, SectorX = 2, SectorY = 2, Alive = true },
                    Bases = new BaseState[]
                    {
                        new BaseState { Energy = 2000, Shields = 2000, QuadrantX = 1, QuadrantY = 1, SectorX = 3, SectorY = 3, Alive = true },
                        new BaseState { Energy = 1500, Shields = 1999, QuadrantX = 1, QuadrantY = 1, SectorX = 4, SectorY = 4, Alive = true }
                    }
                }
            };

            var game2 = new Game
            {
                Id = 2,
                PlayerIds = new int[] { 2 },
                GameState = new GameState
                {
                    Enterprise = new EnterpriseState { FuelLevel = 5000, ShieldLevel = 5000, Torpedoes = 20, QuadrantX = 1, QuadrantY = 1, SectorX = 2, SectorY = 2, Alive = true },
                    Bases = new BaseState[]
                    {
                        new BaseState { Energy = 2000, Shields = 2000, QuadrantX = 1, QuadrantY = 1, SectorX = 3, SectorY = 3, Alive = true },
                        new BaseState { Energy = 1500, Shields = 1999, QuadrantX = 1, QuadrantY = 1, SectorX = 4, SectorY = 4, Alive = true }
                    },
                    Klingons = new KlingonState[]
                    {
                        new KlingonState { Alive=true, Energy=500, EntityType=Domain.SectorContent.KlingonShip, QuadrantX=5, QuadrantY=5, SectorX=5, SectorY=5 },
                        new KlingonState { Alive=true, Energy=480, EntityType=Domain.SectorContent.KlingonShip, QuadrantX=5, QuadrantY=5, SectorX=6, SectorY=6 }
                    }
                }
            };

            allGames.Add(game1);
            allGames.Add(game2);


            var testRepo = new TestGameRepository
            {
                Games = allGames
            };

            var gamesController = new GamesController(testRepo);
            ActionResult<Game> result0 = gamesController.Get(0).Result;
            ActionResult<Game> result1 = gamesController.Get(1).Result;
            ActionResult<Game> result2 = gamesController.Get(2).Result;
            ActionResult<Game> result3 = gamesController.Get(3).Result;

            Assert.IsInstanceOfType(result0.Result, typeof(BadRequestResult));

            Assert.IsInstanceOfType(result1.Result, typeof(OkResult));
            Assert.AreEqual(result1.Value, allGames[0]);
            Assert.IsNull(result1.Result);

            Assert.IsInstanceOfType(result2.Result, typeof(OkResult));
            Assert.AreEqual(result2.Value, allGames[1]);
            Assert.IsNull(result2.Result);

            Assert.IsInstanceOfType(result3.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void DeleteTest()
        {
            var allGames = new List<Game>();

            var game1 = new Game
            {
                Id = 1,
                PlayerIds = new int[] { 1 },
                GameState = new GameState
                {
                    Enterprise = new EnterpriseState { FuelLevel = 5000, ShieldLevel = 5000, Torpedoes = 20, QuadrantX = 1, QuadrantY = 1, SectorX = 2, SectorY = 2, Alive = true },
                    Bases = new BaseState[]
                    {
                        new BaseState { Energy = 2000, Shields = 2000, QuadrantX = 1, QuadrantY = 1, SectorX = 3, SectorY = 3, Alive = true },
                        new BaseState { Energy = 1500, Shields = 1999, QuadrantX = 1, QuadrantY = 1, SectorX = 4, SectorY = 4, Alive = true }
                    }
                }
            };

            allGames.Add(game1);

            var testRepo = new TestGameRepository
            {
                Games = allGames
            };

            var gamesController = new GamesController(testRepo);
            ActionResult result0 = gamesController.Delete(0).Result;
            ActionResult result1 = gamesController.Delete(1).Result;

            Assert.IsInstanceOfType(result0, typeof(BadRequestResult));
            Assert.IsInstanceOfType(result1, typeof(OkResult));
        }
    }
}
