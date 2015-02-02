using RepoUpdater.Model.Factories;
using RepoUpdater.Model.Strategies;
using System;
using Xunit;
using Xunit.Extensions;

namespace RepoUpdater.Model.Tests
{
    public class RepositoryFactoryTests
    {
        [Theory]
        [InlineData(RepositoryType.Git, typeof(GitRepository), "C:/Git/repo")]
        [InlineData(RepositoryType.Tfs, typeof(TfsRepository), "C:/Tfs/repo")]
        public void ShouldCreateRepositoriesBasedOnParameter(RepositoryType repositoryType, Type expectedType, string path)
        {
            var target = RepositoryFactory.Create(repositoryType, path);

            Assert.NotNull(target);
            Assert.IsType(expectedType, target);
        }

        [Fact]
        public void ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => RepositoryFactory.Create(RepositoryType.Unknown, string.Empty));
        }
    }
}