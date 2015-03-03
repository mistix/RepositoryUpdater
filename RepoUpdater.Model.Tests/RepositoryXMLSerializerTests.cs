using NSubstitute;
using RepoUpdater.Model.Abstraction;
using RepoUpdater.Model.Factories;
using RepoUpdater.Model.Strategies;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TinyMessenger;
using Xunit;

namespace RepoUpdater.Model.Tests
{
    public class RepositoryXMLSerializerTests
    {
        #region Fields

        private readonly RepositoryXMLSerializer _target;
        private IList<RepositoryUpdaterBase> _repositories;

        #endregion

        #region Constructors

        public RepositoryXMLSerializerTests()
        {
            var fakeBus = Substitute.For<ITinyMessengerHub>();
            var repositoryFactory = new RepositoryFactory(fakeBus);
            _repositories = new List<RepositoryUpdaterBase>()
            {
                repositoryFactory.Create(RepositoryType.Git, "C:\\fake"),
                repositoryFactory.Create(RepositoryType.Tfs, "C:\\fake"),
                repositoryFactory.Create(RepositoryType.GitTfs, "C:\\fake")
            };

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
            IEnumerable<RepositoryUpdaterBase> repositories = _target.Load("TestData\\TestData-singleElement.xml");

            Assert.Equal(1, repositories.Count());

            RepositoryUpdaterBase firstElement = repositories.ElementAt(0);
            Assert.True(firstElement is GitRepository);
            Assert.Equal(@"c:\git\git", firstElement.RepositoryPath);
        }

        [Fact]
        public void LoadData_PathToFileIsInvalid()
        {
            Assert.Throws<ArgumentException>(() => _target.Load("TestData\\TestData-singleElementkkk.xml"));
        }

        [Fact]
        public void SaveData_FileNotExists()
        {
            const string filePath = "TestData\\TestData-saved.xml";
            if (File.Exists(filePath))
                File.Delete(filePath);

            _target.Save(_repositories, filePath);

            Assert.True(File.Exists(filePath));

            IEnumerable<RepositoryUpdaterBase> repositories = _target.Load(filePath);

            Assert.Equal(3, repositories.Count());
            Assert.True(RepositoriesEquals(repositories.ElementAt(0), _repositories[0]));
            Assert.True(RepositoriesEquals(repositories.ElementAt(1), _repositories[1]));
            Assert.True(RepositoriesEquals(repositories.ElementAt(2), _repositories[2]));
        }

        [Fact]
        public void SaveData_FileContainsData()
        {
            const string filePath = "TestData\\TestDataExistingDataTarget.xml";
            const string sourcePath = "TestData\\TestDataExistingData.xml";

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                File.Copy(sourcePath, filePath);
            }
            else
            {
                File.Copy(sourcePath, filePath);
            }

            _target.Save(_repositories, filePath);

            Assert.True(File.Exists(filePath));

            IEnumerable<RepositoryUpdaterBase> repositories = _target.Load(filePath);

            Assert.Equal(5, repositories.Count());
        }

        #endregion

        #region Test Helpers

        private static bool RepositoriesEquals(RepositoryUpdaterBase left, RepositoryUpdaterBase right)
        {
            return left.RepositoryPath == right.RepositoryPath
                   && left.Name == right.Name;
        }

        #endregion

    }
}