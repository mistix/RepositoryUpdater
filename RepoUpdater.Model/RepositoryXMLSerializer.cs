using RepoUpdater.Model.Abstraction;
using RepoUpdater.Model.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace RepoUpdater.Model
{
    public class RepositoryXMLSerializer : IRepositoryListSerializer
    {
        #region Fields

        private readonly IRepositoryFactory _repositoryFactory;

        #endregion

        #region Constructors

        public RepositoryXMLSerializer(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        #endregion

        public void Save(IEnumerable<RepositoryUpdaterBase> repositories, string path)
        {
        }

        public IEnumerable<RepositoryUpdaterBase> Load(string path)
        {
            var list = new List<RepositoryUpdaterBase>();

            try
            {
                var document = new XmlDocument();
                document.Load(path);

                var repositories = document.SelectNodes("repositories/repository");
                if (repositories == null)
                    return Enumerable.Empty<RepositoryUpdaterBase>();

                foreach (XmlNode node in repositories)
                {
                    string type = node.ChildNodes.Item(0).InnerText;
                    string repositoryPath = node.ChildNodes.Item(1).InnerText;

                    list.Add(_repositoryFactory.Create(type, repositoryPath));
                }
            }
            catch (Exception exception)
            {
                // TODO logger in feature
            }

            return list;
        }
    }
}