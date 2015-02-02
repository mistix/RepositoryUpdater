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
        private readonly IList<IRepositoryUpdaterStrategy> _repositories;

        public RepositoryListTests()
        {
            _target = new RepositoryList();
            _repositories = new List<IRepositoryUpdaterStrategy>()
            {
                Substitute.For<IRepositoryUpdaterStrategy>(),
                Substitute.For<IRepositoryUpdaterStrategy>(),
                Substitute.For<IRepositoryUpdaterStrategy>(),
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

            _target.Clean();

            Assert.Equal(0, _target.Repositories.Count());
        }
    }
}