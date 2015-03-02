using NSubstitute;
using RepoUpdater.Model.Abstraction;
using RepoUpdater.Model.Factories;
using RepoUpdater.Model.Strategies;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TinyMessenger;
using Xunit;

namespace RepoUpdater.Model.Tests
{
    public class RepositoryXMLSerializerTests
    {
        #region Fields

        private readonly RepositoryXMLSerializer _target;

        #endregion

        #region Constructors

        public RepositoryXMLSerializerTests()
        {
            var fakeBus = Substitute.For<ITinyMessengerHub>();
            var repositoryFactory = new RepositoryFactory(fakeBus);

            _target = new RepositoryXMLSerializer(repositoryFactory);
        }

        #endregion

        #region Test Methods

        [Fact]
        public void LoadData_FileContainsMultipleData()
        {
            IEnumerable<RepositoryUpdaterBase> repositories = _target.Load("TestData\\TestData.xml");

            Assert.Equal(2, repositories.Count());

            RepositoryUpdaterBase firstElement = repositories.ElementAt(0);
            Assert.True(firstElement is GitRepository);
            Assert.Equal(@"c:\git\git", firstElement.RepositoryPath);

            RepositoryUpdaterBase secondElement = repositories.ElementAt(1);
            Assert.True(secondElement is TfsRepository);
            Assert.Equal(@"c:\git\tfs", secondElement.RepositoryPath);
        }

        [Fact]
        public void LoadData_FileContainsSingleEntry()
        {
        }

        [Fact]
        public void LoadData_PathToFileIsInvalid()
        {
        }

        [Fact]
        public void LoadData_FileNotExists()
        {
        }

        [Fact]
        public void SaveData_FileNotExists()
        {
        }

        [Fact]
        public void SaveData_PathToFileIsInvalid()
        {
        }

        [Fact]
        public void SaveData_FileContainsData()
        {
        }

        #endregion
    }
}