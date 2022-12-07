using BackendAPI.Service;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITests.Service

{
    public class PathProviderTests
    {
        PathProvider _pathProvider;
        [SetUp]
        public void Setup()
        {
           _pathProvider = new PathProvider();
        }

        [Test]
        public void PathProviderTests_Should_Return_A_Players_json_Path()
        {
            //Act
            string path = PathProvider.GetPlayersJsonPath();
            string pathExpected = @"data\players.json";
            //Assert
            Assert.AreEqual(path, pathExpected);
        }

        [Test]
        public void PathProviderTests_Should_Return_A_Category_json_Path()
        {
            //Act
            string path = PathProvider.GetCategoryJsonPath();
            string pathExpected = @"data\categorys.json";
            //Assert
            Assert.AreEqual(path, pathExpected);
        }

        [Test]
        public void PathProviderTests_Should_Return_A_Letter_json_Path()
        {
            //Act
            string path = PathProvider.GetLetterJsonPath();
            string pathExpected = @"data\letters.json";
            //Assert
            Assert.AreEqual(path, pathExpected);
        }

        [Test]
        public void PathProviderTests_Should_Return_A_GameSession_json_Path()
        {
            //Act
            string path = PathProvider.GetGameSessionJsonPath();
            string pathExpected = @"data\gameSessions.json";
            //Assert
            Assert.AreEqual(path, pathExpected);
        }
    }
}