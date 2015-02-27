using System;

namespace RepoUpdater.Model.ModelView
{
    public class RepositoryItem
    {
        public string Path { get; set; }

        public string RepositoryType { get; set; }

        public string Status { get; set; }

        public DateTime? CheckedDate { get; set; }
    }
}