using NSubstitute;
using RepoUpdater.Model.Factories;
using RepoUpdater.Model.Strategies;
using System;
using TinyMessenger;
using Xunit;
using Xunit.Extensions;

namespace RepoUpdater.Model.Tests
{
    public class RepositoryFactoryTests
    {
        private readonly RepositoryFactory _repositoryFactory;

        public RepositoryFactoryTests()
        {
            var eventBus = Substitute.For<ITinyMessengerHub>();
            _repositoryFactory = new RepositoryFactory(eventBus);
        }

        [Theory]
        [InlineData(RepositoryType.Git, typeof(GitRepository), "C:/Git/repo")]
        [InlineData(RepositoryType.Tfs, typeof(TfsRepository), "C:/Tfs/repo")]
        public void ShouldCreateRepositoriesBasedOnParameter(RepositoryType repositoryType, Type expectedType, string path)
        {
            var target = _repositoryFactory.Create(repositoryType, path);

            Assert.NotNull(target);
            Assert.IsType(expectedType, target);
        }

        [Fact]
        public void ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _repositoryFactory.Create(RepositoryType.Unknown, string.Empty));
        }
    }
}