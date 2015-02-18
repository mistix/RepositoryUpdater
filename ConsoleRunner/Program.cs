using RepoUpdater.Model;
using RepoUpdater.Model.Abstraction;
using RepoUpdater.Model.Factories;
using System;
using TinyMessenger;

namespace ConsoleRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var messageBus = new TinyMessengerHub();
            var repositoryFactory = new RepositoryFactory(messageBus);
            Settings.GitPath = @"C:\Program Files\git\bin\git.exe";

            messageBus.Subscribe<GenericTinyMessage<Exception>>(m => Console.WriteLine("Wyjatek: {0}", m.Content.Message));
            messageBus.Subscribe<GenericTinyMessage<string>>(m => Console.WriteLine("Sukcess: {0}", m.Content));

            RepositoryUpdaterBase repository = repositoryFactory.Create(RepositoryType.Git, @"D:\programowanie\project\code_kats\LCD_Kat");

            repository.Update();

            Console.ReadLine();
        }
    }
}
