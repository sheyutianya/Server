using Core.Managers;
using Core.Timer;
using UnityEngine;
using Core.Music;

namespace Core
{
	//游戏主入口脚本
	public class GameEntry : MonoBehaviour
	{
		protected virtual void Awake()
		{
			DontDestroyOnLoad(this);

            //注册协程
			CoroutineManager.Init(this);

            //启动timer
            TimerManager.GetInstance().Init();
            InvokeRepeating("OnTimer", 0, 0.1f);
		}

		protected virtual void Start()
		{
		}

		protected virtual void Update()
		{
            //更新帧频事件
			EnterFrameManager.GetInstance().Do();
		}

	    protected virtual void FixedUpdate()
	    {
	        EnterFrameManager.GetInstance().DoFixUpdate();
	    }

	    protected virtual void LateUpdate()
	    {
            EnterFrameManager.GetInstance().DoLateUpdate();
	    }

	    void OnTimer()
	    {
	        TimerManager.GetInstance().Run();
	    }
	}
}