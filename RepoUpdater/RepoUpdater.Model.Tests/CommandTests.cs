using Xunit;

namespace RepoUpdater.Model.Tests
{
    public class CommandTests
    {
        private const string GitPath = @"C:\Program Files\Git\bin\git.exe";

        [Fact]
        public void ExecutionOfGitVersionCommand()
        {
            var command = new CommandLine();
            var output = command.Execute(GitPath, "--version", true);

            Assert.Contains("git version", output);
        }
    }
}