using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Timer
{
    public class Timer
    {
        private float timeElapsed = 0;

        public float delay;
        public int repeatCount;

        private int currentCount;

        public event Action OnTimer;
        public event Action OnTimerComplete;

        public Timer(float delay, int repeatCount)
        {
            this.delay = delay;
            this.repeatCount = repeatCount;
        }

        public bool Running
        {
            get { return TimerManager.GetInstance().HasTimer(this); }
        }

        public int CurrnetCount
        {
            get { return currentCount; }
        }

        public void Start()
        {
            TimerManager.GetInstance().AddTimer(this);
        }

        public void Stop()
        {
            TimerManager.GetInstance().RemoveTimer(this);
        }

        public void Reset()
        {
            Stop();
            timeElapsed = 0;
            currentCount = 0;
        }

        public void Update(float deltaTime)
        {
            timeElapsed += deltaTime;
            while (timeElapsed >= delay)
            {
                timeElapsed -= delay;
                ++currentCount;

                if (OnTimer != null)
                {
                    OnTimer();
                }

                if (repeatCount > 0 && currentCount >= repeatCount)
                {
                    Stop();
                    if (OnTimerComplete != null)
                    {
                        OnTimerComplete();
                    }
                    break;
                }
            }
        }
    }

    public class TimerManager
    {
        private static TimerManager _instarnce;

        public static TimerManager GetInstance()
        {
            if (_instarnce == null)
            {
                _instarnce = new TimerManager();
            }
            return _instarnce;
        }

        private float _currentTime;

        private TimerManager()
        {
        }

        public void Init()
        {
            _currentTime = Time.realtimeSinceStartup;
        }

        private List<Timer> timerList = new List<Timer>();

        /// <summary>
        /// 添加计时器事件
        /// </summary>
        /// <param name="name"></param>
        /// <param name="o"></param>
        public void AddTimer(Timer timer)
        {
            if (!timerList.Contains(timer))
            {
                timerList.Add(timer);
            }
        }

        /// <summary>
        /// 删除计时器事件
        /// </summary>
        /// <param name="name"></param>
        public void RemoveTimer(Timer timer)
        {
            timerList.Remove(timer);
        }

        public bool HasTimer(Timer timer)
        {
            return timerList.Contains(timer);
        }

        /// <summary>
        /// 计时器运行
        /// </summary>
        public void Run()
        {
            float now = Time.realtimeSinceStartup;
            float deltaTime = now - _currentTime;
            _currentTime = now;
            for (int i=timerList.Count-1; i>= 0; i--)
            {
                var timer = timerList[i];
                timer.Update(deltaTime);
            }
        }
    }
}