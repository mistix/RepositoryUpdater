using RepoUpdater.Model.Abstraction;
using RepoUpdater.Model.Factories;
using System;
using System.Collections.Generic;
using System.IO;
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

        public void Save(IEnumerable<RepositoryBase> repositories, string path)
        {
            if (repositories == null || !repositories.Any())
                return;

            try
            {
                var document = new XmlDocument();

                if (File.Exists(path))
                {
                    document.Load(path);
                }
                else
                {
                    XmlDeclaration xmlDeclaration = document.CreateXmlDeclaration("1.0", "UTF-8", null);
                    XmlElement root = document.DocumentElement;
                    document.InsertBefore(xmlDeclaration, root);
                }

                XmlNode repositoriesNode = document.SelectSingleNode("repositories") ?? document.CreateElement("repositories");
                foreach (RepositoryBase item in repositories)
                {
                    var repositoryNode = document.CreateElement("repository");
                    var typeNode = document.CreateElement("type");
                    typeNode.InnerText = item.Name;

                    var pathNode = document.CreateElement("path");
                    pathNode.InnerText = item.RepositoryPath;

                    repositoryNode.AppendChild(typeNode);
                    repositoryNode.AppendChild(pathNode);
                    repositoriesNode.AppendChild(repositoryNode);
                }

                document.AppendChild(repositoriesNode);

                document.Save(path);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<RepositoryBase> Load(string path)
        {
            var list = new List<RepositoryBase>();
            if (!File.Exists(path))
                return Enumerable.Empty<RepositoryBase>();

            try
            {
                var document = new XmlDocument();
                document.Load(path);

                var repositories = document.SelectNodes("repositories/repository");
                if (repositories == null)
                    return Enumerable.Empty<RepositoryBase>();

                foreach (XmlNode node in repositories)
                {
                    string type = node.ChildNodes.Item(0).InnerText;
                    string repositoryPath = node.ChildNodes.Item(1).InnerText;

                    list.Add(_repositoryFactory.Create(type, repositoryPath));
                }
            }
            catch (Exception exception)
            {
                throw;
            }

            return list;
        }
    }
}