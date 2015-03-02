using NSubstitute;
using RepoUpdater.Model.Abstraction;
using RepoUpdater.Model.Strategies;
using System;
using TinyMessenger;
using Xunit;

namespace RepoUpdater.Model.Tests
{
    public class GitTfsRepositoryTests
    {
        private const string RepositoryPath = @"D:\programowanie\project\code_kats\LCD_Kat";

        public GitTfsRepositoryTests()
        {
            Settings.GitPath = @"C:\Program Files\Git\bin\git.exe";
        }

        [Fact]
        public void ExecuteGitTfs()
        {
            var command = Substitute.For<ICommandLine>();

            var eventBus = Substitute.For<ITinyMessengerHub>();
            eventBus.Publish(Arg.Any<ITinyMessage>());

            var target = new GitTfsRepository(RepositoryPath, command, eventBus);

            target.Update();

            // Assert
            eventBus.Received().Publish(Arg.Any<ITinyMessage>());
        }

        [Fact]
        public void ExecuteGitRepository_RealRepository()
        {
            var command = new CommandLine();
            var eventBus = Substitute.For<ITinyMessengerHub>();
            eventBus.Publish(Arg.Any<ITinyMessage>());

            var target = new GitTfsRepository(RepositoryPath, command, eventBus);
            target.Update();

            eventBus.DidNotReceive().Publish(Arg.Any<GenericTinyMessage<Exception>>());
            eventBus.Received().Publish(Arg.Any<GenericTinyMessage<string>>());
        }
    }
}