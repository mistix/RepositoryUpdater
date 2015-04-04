using System;
using System.Threading.Tasks;
using RepoUpdater.Abstract;
using RepoUpdater.Model.Abstraction;

namespace RepoUpdater
{
    public class RepositoryUpdater : IRepositoryUpdater
    {
        #region Fields

        private readonly IDispatcherTimer _dispatcherTimer;
        private readonly IRepositoryList _repositoryList;

        #endregion

        #region Constructors

        public RepositoryUpdater(IDispatcherTimer dispatcherTimer, IRepositoryList repositoryList)
        {
            _dispatcherTimer = dispatcherTimer;
            _repositoryList = repositoryList;
        }

        #endregion

        #region Methods

        public void Run()
        {
            _dispatcherTimer.OnTime += DispatcherTimerOnOnTime;
            _dispatcherTimer.Start();
        }

        public void Stop()
        {
            _dispatcherTimer.Stop();
        }

        public void SetTimeSpan(TimeSpan timeSpan)
        {
            if (timeSpan == null)
                throw new ArgumentNullException();

            _dispatcherTimer.Interval = timeSpan;
        }

        #endregion

        #region Private Methods

        private void DispatcherTimerOnOnTime(object sender, EventArgs eventArgs)
        {
            Task.Run(() =>
            {
                foreach (RepositoryBase repository in _repositoryList.Repositories)
                    repository.Update();
            });
        }

        #endregion

    }
}