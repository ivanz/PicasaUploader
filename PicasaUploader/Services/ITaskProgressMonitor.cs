using System;
using System.Collections.Generic;
using System.Linq;

namespace PicasaUploader.Services
{
    public interface ITaskProgressMonitor
    {
        void StartTask(int stepsCount, string description);
        void Step(string description);
        void CompleteTask();

        bool IsTaskRunning { get; }

        event EventHandler<EventArgs> TaskCompleted;
        event EventHandler<EventArgs> TaskStarted;
    }
}
