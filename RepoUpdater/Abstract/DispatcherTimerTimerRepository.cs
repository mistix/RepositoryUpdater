using System;
using System.Windows.Threading;

namespace RepoUpdater.Abstract
{
    public class DispatcherTimerTimerRepository : IDispatcherTimer
    {
        #region Fields

        private readonly DispatcherTimer _dispatcherTimer;

        #endregion

        #region Events

        public event EventHandler OnTime
        {
            add { _dispatcherTimer.Tick += value; }

            remove { _dispatcherTimer.Tick -= value; }
        }

        #endregion

        #region Properties

        public TimeSpan Interval { get; set; }

        #endregion


        #region Constructors

        public DispatcherTimerTimerRepository()
        {
            _dispatcherTimer = new DispatcherTimer();
            Interval = new TimeSpan(0, 0, 10, 0);
        }

        #endregion

        #region Methods

        public void Start()
        {
            _dispatcherTimer.Start();
        }

        public void Stop()
        {
            _dispatcherTimer.Stop();
        }

        #endregion
    }
}