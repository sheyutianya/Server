using Core.Managers;
using UnityEngine;
using System.Collections;
using System;

namespace Core.Net.Http
{
    //Http加载管理类
    public class HttpManager
    {
        const float TimeOutWait = 30f * 10000000f;//超时等待时间30秒

        //启动一个www加载
        static private IEnumerator DoLoad(string path, WWWForm form, Action<WWW> callback, Action<string> onError = null)
        {
            WWW www;
            if (form != null)
            {
                www = new WWW(GetRealPath(path), form);
            }
            else
            {
                www = new WWW(GetRealPath(path));
            }

            long startTime = DateTime.Now.Ticks;
            while (!www.isDone)
            {
                if (DateTime.Now.Ticks - startTime >= TimeOutWait)
                {
                    //弹出提示框通知玩家并且重新连接
                    Debug.LogError("网络超时");
                    break;
                }
                yield return new WaitForSeconds(0.5f);
            }
            yield return www;

            if (string.IsNullOrEmpty(www.error))
            {
                callback(www);
            }
            else
            {
                Debug.LogError("请求发生网络错误，url为：" + www.url + "\n错误信息为：" + www.error);
                if (onError != null)
                {
                    onError(www.error);
                }
            }
        }

        //加载path路径上的本文数据，path可以为相对路径（相对于StreamingAssets），也可以为绝对路径（如‘http://www.xxx.com’）
        static public void GetText(string path, Action<string> callback, Action<string> onError = null)
        {
            CoroutineManager.StartCoroutine(DoLoad(path, null, www => callback(www.text), onError));
        }

        static public void GetText(string path, Hashtable param, Action<string> callback, Action<string> onError = null)
        {
            GetText(GenerateGetPath(path, param), callback, onError);
        }

        static public void PostText(string path, Hashtable param, Action<string> callback, Action<string> onError = null)
        {
            CoroutineManager.StartCoroutine(DoLoad(path, GenerateWWWForm(param), www => callback(www.text), onError));
        }

        //加载path路径上的二进制数据，path可以为相对路径（相对于StreamingAssets），也可以为绝对路径（如‘http://www.xxx.com’）
        static public void GetBytes(string path, Action<byte[]> callback, Action<string> onError = null)
        {
            CoroutineManager.StartCoroutine(DoLoad(path, null, www => callback(www.bytes), onError));
        }

        //加载path路径上的AssetBundle资源包，path可以为相对路径（相对于StreamingAssets），也可以为绝对路径（如‘http://www.xxx.com’）
        static public void GetAssetBundle(string path, Action<AssetBundle> callback, Action<string> onError = null)
        {
            CoroutineManager.StartCoroutine(DoLoad(path, null, www => callback(www.assetBundle), onError));
        }

        //获取实际路径，当url为相对StreamingAssets的路径时，会返回加上StreamingAssets路径的完整路径
        static private string GetRealPath(string url)
        {
            //http路径
            if (url.IndexOf("://") >= 0)
            {
                return url;
            }
            string path = url;

			#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
				if(url.IndexOf(":/") < 0){
					path = Application.streamingAssetsPath + "/" + path;
				}
			#elif UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX || UNITY_IPHONE
				if(url[0] != '/'){
					path = Application.streamingAssetsPath + "/" + path;
				}
			#endif
			//经测试,windows,mac os,android,iphone,只有安卓平台不需要file:///
			#if UNITY_EDITOR || UNITY_IPHONE || UNITY_STANDALONE
            	path = "file:///" + path;
			#endif
            return path;
        }

        static public string GenerateGetPath(string url, Hashtable param)
        {
            if (null == param)
            {
                return url;
            }
            bool isFirst = true;
            foreach (DictionaryEntry entry in param)
            {
                if (isFirst)
                {
                    isFirst = false;
                    url += "?";
                }
                else
                {
                    url += "&";
                }
                url += entry.Key.ToString() + "=" + entry.Value.ToString();
            }
            return url;
        }

        static public WWWForm GenerateWWWForm(Hashtable param)
        {
            WWWForm form = new WWWForm();

            if (null == param)
            {
                return form;
            }
            foreach (DictionaryEntry entry in param)
            {
                form.AddField(entry.Key.ToString(), entry.Value.ToString());
            }
            return form;
        }
    }
}