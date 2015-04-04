using System;

namespace RepoUpdater.Abstract
{
    public interface IRepositoryUpdater
    {
        #region Methods

        void Run();
        void Stop();

        void SetTimeSpan(TimeSpan timeSpan);

        #endregion
    }
}