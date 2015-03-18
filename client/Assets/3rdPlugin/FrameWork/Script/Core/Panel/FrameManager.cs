using UnityEngine;
using System.Collections;

namespace Core.Panel
{
	public enum FrameType
	{
		//全屏面板,打开时其它面板和场景都会隐藏
		FULLSCREEN,
		//附加到场景上的面板,打开时只会隐藏其它面板,场景继续显示
		OVERLAY
	}

	public interface IFrame
	{
		void Show();
	}

	public abstract class AbstractFrame : MonoBehaviour, IFrame
	{
		abstract public void Show();
		abstract protected void Close();
	}

	public interface IFrameManager
	{
		void ShowFrame (string frameName, FrameType type);
	}

	public class FrameManager : IFrameManager
	{
		public const string LAYER_FULLSCREEN_PANEL = "panel_fullscreen";
		public const string LAYER_OVERLAY_PANEL = "panel_overlay";

		static private FrameManager _instance;
		
		static public FrameManager GetInstance()
		{
			if(null == _instance){
				_instance = new FrameManager();
			}
			return _instance;
		}

		private FrameManager(){}

		public void ShowFrame(string frameName, FrameType frameType)
		{
			GameObject prefab = Resources.Load<GameObject> (frameName);
			GameObject go = (GameObject)Object.Instantiate (prefab);
			AbstractFrame frame = go.GetComponent<AbstractFrame> ();
			frame.Show ();

			switch(frameType)
			{
			case FrameType.FULLSCREEN:
				Camera.main.enabled = false;
				UICamera.mainCamera.cullingMask = LayerMask.NameToLayer(LAYER_FULLSCREEN_PANEL);
				break;
			case FrameType.OVERLAY:
				Camera.main.enabled = true;
				UICamera.mainCamera.cullingMask = ~LayerMask.NameToLayer(LAYER_FULLSCREEN_PANEL);
				break;
			}
		}
	}
}