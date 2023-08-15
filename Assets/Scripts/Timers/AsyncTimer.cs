using System;
using Cysharp.Threading.Tasks;

namespace Timers
{
    public class AsyncTimer
    {
        private readonly Action _action;
        private readonly int _tickDelayInMilliseconds;
        private readonly bool _autoRepeat;
        private bool _isTimerWorking;

        public AsyncTimer(Action action, int tickDelayInMilliseconds, bool autoRepeat)
        {
            _action = action;
            _tickDelayInMilliseconds = tickDelayInMilliseconds;
            _autoRepeat = autoRepeat;
            _isTimerWorking = false;
            TimerTick();
        }

        public void StartTimer()
        {
            _isTimerWorking = true;
        }

        private async void TimerTick()
        {
            await UniTask.Delay(_tickDelayInMilliseconds);
            if (_isTimerWorking == false)
            {
                return;
            }

            _action?.Invoke();
            if (_autoRepeat == false)
            {
                return;
            }

            TimerTick();
        }

        public void StopTimer()
        {
            _isTimerWorking = false;
        }
    }
}