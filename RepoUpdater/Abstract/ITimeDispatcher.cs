﻿using System;

namespace RepoUpdater.Abstract
{
    public interface IDispatcherTimer
    {

        #region Events

        event EventHandler OnTime;

        #endregion

        #region Properties

        TimeSpan Interval { get; set; }

        #endregion

        #region Methods

        void Start();
        void Stop();

        #endregion
    }
}