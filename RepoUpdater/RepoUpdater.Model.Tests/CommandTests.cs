using Xunit;

namespace RepoUpdater.Model.Tests
{
    public class CommandTests
    {
        private const string GitPath = @"C:\Program Files\Git\bin\git.exe";
        private const string TestRepositoryPath = @"D:\programowanie\project\code_kats\LCD_Kat";

        [Fact]
        public void ExecutionOfGitVersionCommand()
        {
            var command = new CommandLine();
            var output = command.Execute(GitPath, "--version", TestRepositoryPath, true);

            Assert.Contains("git version", output);
        }
    }
}