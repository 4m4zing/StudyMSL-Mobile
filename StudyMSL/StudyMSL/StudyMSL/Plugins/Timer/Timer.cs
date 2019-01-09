using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xamarin.Forms;

namespace StudyMSL.Plugins.Timer
{
    public class Timer
    {
        private readonly TimeSpan _timeSpan;
        private readonly Action _callback;

        private double _time;
        public double time
        {
            get { return _time; }
            set { _time = value; }
        }

        private static CancellationTokenSource _cancellationTokenSource;

        public Timer(TimeSpan timeSpan, Action callback)
        {
            _timeSpan = timeSpan;
            _callback = callback;
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public void Start()
        {
            CancellationTokenSource cts = _cancellationTokenSource; // safe copy
            Device.StartTimer(_timeSpan, () =>
            {
                if (cts.IsCancellationRequested)
                {
                    return false;
                }
                _callback.Invoke();
                return true; //true to continuous, false to single use
            });
        }

        //public void Start(double duration)
        //{
        //    Device.StartTimer(_timeSpan, () =>
        //    {
        //        duration -= 1;
        //        time = duration;
        //        if (duration == 0.00)
        //        {
        //            return false;
        //        }
        //        _callback.Invoke();
        //        return true; //true to continuous, false to single use
        //    });
        //}

        public void Stop()
        {
            Interlocked.Exchange(ref _cancellationTokenSource, new CancellationTokenSource()).Cancel();
        }

        public double getTime()
        {
            return time;
        }
    }
}

