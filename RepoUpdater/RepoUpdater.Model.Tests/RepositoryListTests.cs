using NSubstitute;
using RepoUpdater.Model.Abstraction;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RepoUpdater.Model.Tests
{
    public class RepositoryListTests
    {
        private readonly RepositoryList _target;
        private readonly IList<RepositoryUpdaterBase> _repositories;
        private const string Path = "path";

        public RepositoryListTests()
        {
            _target = new RepositoryList();
            _repositories = new List<RepositoryUpdaterBase>()
            {
                Substitute.For<RepositoryUpdaterBase>(Path),
                Substitute.For<RepositoryUpdaterBase>(Path),
                Substitute.For<RepositoryUpdaterBase>(Path),
            };
        }

        [Fact]
        public void Should_AddRepository()
        {
            _target.Add(_repositories[0]);
            _target.Add(_repositories[1]);

            Assert.Equal(2, _target.Repositories.Count());
        }

        [Fact]
        public void Should_NotAddDuplicateRepository()
        {
            _target.Add(_repositories[0]);
            _target.Add(_repositories[0]);

            Assert.Equal(1, _target.Repositories.Count());
        }

        [Fact]
        public void Should_RemoveRepository()
        {
            _target.Add(_repositories[0]);
            _target.Add(_repositories[1]);

            Assert.Equal(2, _target.Repositories.Count());

            _target.Remove(_repositories[0]);

            Assert.Equal(1, _target.Repositories.Count());
        }

        [Fact]
        public void Should_ReturnAllRepositories()
        {
            _target.Add(_repositories[0]);
            _target.Add(_repositories[1]);

            Assert.Equal(2, _target.Repositories.Count());

            _target.Clear();

            Assert.Equal(0, _target.Repositories.Count());
        }

        [Fact]
        public void Should_Update_All_Element_In_List()
        {
            _target.Add(_repositories[0]);
            _target.Add(_repositories[1]);
            _target.Add(_repositories[2]);

            _target.UpdateAll();

            _repositories[0].Received().Update();
            _repositories[1].Received().Update();
            _repositories[2].Received().Update();
        }
    }
}