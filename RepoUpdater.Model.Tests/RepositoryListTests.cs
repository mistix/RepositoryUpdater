using NSubstitute;
using RepoUpdater.Model.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using TinyMessenger;
using Xunit;
using Xunit.Extensions;

namespace RepoUpdater.Model.Tests
{
    public class RepositoryListTests
    {
        private readonly RepositoryList _target;
        private readonly IList<RepositoryUpdaterBase> _repositories;
        private const string Path = "path";

        public RepositoryListTests()
        {
            var command = Substitute.For<ICommandLine>();
            var eventBus = Substitute.For<ITinyMessengerHub>();
            var serializer = Substitute.For<IRepositoryListSerializer>();
            var applicationSettings = Substitute.For<IApplicationSettings>();

            _target = new RepositoryList(serializer, applicationSettings);

            _repositories = new List<RepositoryUpdaterBase>()
            {
                Substitute.For<RepositoryUpdaterBase>(Path, "GIT", command, eventBus),
                Substitute.For<RepositoryUpdaterBase>(Path, "Tfs", command, eventBus),
                Substitute.For<RepositoryUpdaterBase>(Path, "GitTfs", command, eventBus)
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

            Assert.Equal(2, _target.Repositories.Count);

            _target.Clear();

            Assert.Equal(0, _target.Repositories.Count);
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

        [Fact]
        public void Remove_ShouldRemoveItemAtIndex()
        {

            _target.Add(_repositories[0]);
            _target.Add(_repositories[1]);
            _target.Add(_repositories[2]);

            Assert.Equal(3, _target.Repositories.Count);

            _target.Remove(2);

            Assert.Equal(2, _target.Repositories.Count);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(-10)]
        public void Remove_ShouldThrowArgumentOfOfRangeException(int index)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _target.Remove(index));
        }
    }
}