using System;
using System.Windows.Forms;

namespace SpotDifferenceGames.Services
{
    public class GameTimer
    {
        private Timer timer;
        private int seconds;
        private int timeLimitSeconds;

        public event EventHandler Tick;

        public Action<int, int> OnTimerTick { get; set; }
        public Action OnTimeUp { get; set; }

        public GameTimer(int gameLevel)
        {
            timer = new Timer();
            timer.Interval = 1000;

            // فرضية: كل مستوى له وقت معين (مثلاً: 60 + 30 * المستوى)
            //+ gameLevel * 30
            timeLimitSeconds = 30 ;

            timer.Tick += (s, e) =>
            {
                seconds++;
                Tick?.Invoke(this, EventArgs.Empty);

                // استدعاء الحدث الخاص بعرض الوقت
                OnTimerTick?.Invoke(seconds / 60, seconds % 60);

                if (seconds >= timeLimitSeconds)
                {
                    Stop();
                    OnTimeUp?.Invoke();
                }
            };
        }

        public void Start() => timer.Start();
        public void Stop() => timer.Stop();
        public void Reset()
        {
            seconds = 0;
        }

        public int ElapsedSeconds => seconds;
    }
}
