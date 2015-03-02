using RepoUpdater.Model.Abstraction;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using RepoUpdater.Model.Factories;

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

            var document = new XmlDocument();
            document.Load(path);

            var repositories = document.SelectNodes("repositories");
            if (repositories == null)
                return Enumerable.Empty<RepositoryUpdaterBase>();

            foreach (var node in repositories)
            {
            }

            return list;
        }
    }
}