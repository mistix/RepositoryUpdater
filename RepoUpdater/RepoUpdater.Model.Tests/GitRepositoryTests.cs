using NSubstitute;
using RepoUpdater.Model.Strategies;
using TinyMessenger;
using Xunit;

namespace RepoUpdater.Model.Tests
{
    public class GitRepositoryTests
    {
        [Fact]
        public void ExecuteGitTfs()
        {
            Settings.GitPath = @"C:\Program Files\Git\bin\git.exe";
            var path = @"D:\programowanie\project\code_kats\LCD_Kat";
            var command = Substitute.For<ICommandLine>();

            var eventBus = Substitute.For<ITinyMessengerHub>();
            eventBus.Publish(Arg.Any<ITinyMessage>());

            var target = new GitRepository(path, command, eventBus);

            target.Update();

            // Assert
            eventBus.Received().Publish(Arg.Any<ITinyMessage>());
        }
    }
}