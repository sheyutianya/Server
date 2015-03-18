using System;
using System.Collections;
using System.Collections.Generic;
using Core.Managers;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Core.Asset
{
    //模型创建工厂，封装托管Prefab的创建过程
    public class AssetModelFactory
    {
        static private AssetModelFactory _Instance;
        static public AssetModelFactory GetInstance()
        {
            if (null == _Instance)
            {
                _Instance = new AssetModelFactory();
            }
            return _Instance;
        }

        private int _count;
        //防止外部创建，保证全局单例
        private AssetModelFactory()
        {
            EnterFrameManager.GetInstance().Register(Update);
        }

        private void Update()
        {
            _count++;
            if (_count < 3) return;
            _count = 0;
            if (callBackList.Count > 0)
            {
				var callback = callBackList[0];
				callBackList.RemoveAt(0);
				callback.Excute();
            }
        }

        //缓存实例化的GameObject，避免垃圾回收器频繁回收
        Dictionary<string, Stack<GameObject>> cache = new Dictionary<string, Stack<GameObject>>();
        //预制体的缓存容器
        Dictionary<string, Object> prefabCache = new Dictionary<string, Object>();

        List<AssetBackInfo> callBackList = new List<AssetBackInfo>(); 

        //通过资源名获取指定prefab的一个克隆
        public void GetAsset(string assetName, Action<AssetBackInfo> callback)
        {
            if (GetCache(assetName).Count > 0)
            {
                callback(new AssetBackInfo(assetName,GetCache(assetName).Pop(), callback));
                return;
            }

            //TODO 前期开发从resource目录下加载，后期改为ab包处理
            PreLoadAsset(assetName);
            
            if (prefabCache[assetName] != null)
            {
                callback(new AssetBackInfo(assetName,
                    (GameObject) GameObject.Instantiate(prefabCache[assetName] as GameObject), callback));
            }
            else
            {
                callback(new AssetBackInfo(assetName,
                    null, callback));
            }
        }

        //预加载预制缓存
        public void PreLoadAsset(string assetName, Action<AssetPrefabBackInfo> callback=null)
        {
            if (!prefabCache.ContainsKey(assetName))
            {
                prefabCache.Add(assetName, Resources.Load<GameObject>(assetName));
            }
            if (callback != null)
            {
                callback(new AssetPrefabBackInfo(assetName, prefabCache[assetName]));
            }
        }

        //通过资源名异步获取指定prefab的一个克隆
        public void GetAssetAsync(string assetName, Action<AssetBackInfo> callback)
        {
            if (GetCache(assetName).Count > 0)
            {
                callBackList.Add(new AssetBackInfo(assetName, GetCache(assetName).Pop(), callback));
                return;
            }

            //TODO 前期开发从resource目录下加载，后期改为ab包处理
            if (!prefabCache.ContainsKey(assetName))
            {
                CoroutineManager.StartCoroutine(PreLoadAssetAsync(assetName, callback));
                return;
            }

            if (prefabCache[assetName] != null)
            {
                callBackList.Add(new AssetBackInfo(assetName, (GameObject)GameObject.Instantiate(prefabCache[assetName] as GameObject), callback));
            }
            else
            {
                callBackList.Add(new AssetBackInfo(assetName, null, callback));
            }
        }

        //异步预加载预制缓存
        IEnumerator PreLoadAssetAsync(string assetName, System.Action<AssetBackInfo> callback) 
        {
            ResourceRequest resourceRequest = Resources.LoadAsync<GameObject>(assetName);
            yield return resourceRequest;
            if (!prefabCache.ContainsKey(assetName))
            {
                prefabCache.Add(assetName, resourceRequest.asset);
            }
            if (prefabCache[assetName] != null)
            {
                callBackList.Add(new AssetBackInfo(assetName, (GameObject)GameObject.Instantiate(prefabCache[assetName] as GameObject), callback));
            }
            else
            {
                callBackList.Add(new AssetBackInfo(assetName, null, callback));
            }
        }

        public void UnLoadPreAsset()
        {

        }

        //将用完之后的GameObject放回对象池，以供下次获取，这样可以减少虚拟机垃圾回收次数，提高性能
        public void SaveAsset(string assetName, GameObject asset)
        {
            GetCache(assetName).Push(asset);
        }

        //通过资源名获取对象池列表
        private Stack<GameObject> GetCache(string assetName)
        {
            if (!cache.ContainsKey(assetName))
            {
                cache.Add(assetName, new Stack<GameObject>());
            }
            return cache[assetName];
        }
    }
}