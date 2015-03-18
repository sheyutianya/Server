using System.Collections.Generic;
using Core.CSV;
using Core.Managers;
using UnityEngine;
using System;
using System.Collections;
using Core.Net.Http;
using System.Text;

namespace Core.Asset
{
    //资源管理器接口
    interface IAssetManager
    {
        /** 获取资源
         * assetName 资源名
         * callback 资源准备好之后的回调函数
         * */
        void GetAsset(string assetName, Action<UnityEngine.Object> callback);

        /**
         * 将用完之后的资源放回池中，以供下一次获取使用，避免垃圾回收器频繁回收
         */
        void SaveAsset(string assetName, UnityEngine.Object asset);

        /**
         * 检查资源配置文件中是否有assetName的资源记录
         */
        bool HasAsset(string assetName);
    }

    //资源管理器
    public class AssetManager : IAssetManager
    {
        //资源定义信息，key为资源name，value为资源信息（name, bundlePath, maxCount等）
        private readonly Dictionary<string, AssetConfigItem> configItemDict;

        public AssetManager()
        {
            configItemDict = new Dictionary<string, AssetConfigItem>();
        }

        /**读取配置文件信息*/
        public void LoadConfig(Dictionary<object, AssetConfigItem> configData)
        {
            foreach (var assetDef in configData)
            {
                var item = assetDef.Value;
                configItemDict.Add(item.name, item);
            }
        }

        /**
         * 通过assetName获取资源
         * 资源准备好之后的回调函数
         */
        public void GetAsset(string assetName, Action<UnityEngine.Object> callback)
		{
			GetAsset (assetName, callback, typeof(GameObject));
		}

		public void GetAsset(string assetName, Action<UnityEngine.Object> callback, Type type)
        {
            //如果资源名在资源定义表中没有定义，返回空
            if (!HasAsset(assetName))
            {
                callback(null);
                return;
            }
            AssetConfigItem configItem = configItemDict[assetName];
            //如果资源的prefab已经准备好
            if (configItem.IsPrefabLoaded())
            {
                callback(configItem.GetItem(type));
                return;
            }
            //如果资源的prefab正在加载中
            if (configItem.IsPrefabLoading())
            {
                configItem.OnPrefabLoaded += () => callback(configItem.GetItem(type));
                return;
            }
            //如果资源所在的assetBundle已经加载好，但是prefab还没初始化过
            if (configItem.IsBundleLoaded())
            {
                configItem.OnPrefabLoaded += () => callback(configItem.GetItem(type));
                configItem.LoadPrefab(type);
                return;
            }
            //如果资源所在的assetBundle还没加载或正在加载，添加assetBundle加载完成后的回调
            configItem.OnBundleLoaded += () => GetAsset(assetName, callback, type);
            //如果资源所在的assetBundle还没启动加载则启动加载
            if (!configItem.IsBundleLoading())
            {
                configItem.LoadBundle();
            }
        }

        //将用完之后的资源放回资源池中，减少垃圾回收
        public void SaveAsset(string assetName, UnityEngine.Object asset)
        {
            if (HasAsset(assetName))
            {
                configItemDict[assetName].SaveItem(asset);
            }
        }

        //检查资源名在资源定义表中是否有定义
        public bool HasAsset(string assetName)
        {
            return configItemDict.ContainsKey(assetName);
        }
    }

    //资源配置项
    public class AssetConfigItem : BaseTemplate
    {
        //资源名
        public string name;

        //资源所在的assetBundle路径
        public string bundlePath;

        //资源缓存的最大数量,小于0表示缓存所有,等于0表示不做缓存,大于0表示只缓存指定的数目,多余的会被垃圾回收掉
        public int maxCount;

        //资源所在的assetBundle
        UnityEngine.AssetBundle bundle;
        //bundle是否正在加载中
        bool _IsBundleLoading;

        //bundle加载完毕之后的事件
        public event Action OnBundleLoaded;

        //资源prefab,所有对象都会从prefab克隆
        UnityEngine.Object prefab;
        //prefab是否正在加载中
        bool _IsPrefabLoading;
        //prefab加载完毕之后的事件
        public event Action OnPrefabLoaded;

        //通过prefab生成出来的对象的缓存对象池
        ObjectPool<UnityEngine.Object> cache;

        //assetBundle是否加载完毕
        public bool IsBundleLoaded()
        {
            return bundle != null;
        }

        //assetBundle是否正在加载中
        public bool IsBundleLoading()
        {
            return _IsBundleLoading;
        }

        //加载资源所在的assetBundle
        public void LoadBundle()
        {
            _IsBundleLoading = true;
            HttpManager.GetAssetBundle(bundlePath, result =>
            {
                _IsBundleLoading = false;
                bundle = result;
                if (OnBundleLoaded != null)
                {
                    OnBundleLoaded();
                    OnBundleLoaded = null;
                }
            });
        }

        //prefab是否已经加载完毕
        public bool IsPrefabLoaded()
        {
            return prefab != null;
        }

        //prefab是否正在加载中
        public bool IsPrefabLoading()
        {
            return _IsPrefabLoading;
        }

        //加载资源的prefab
		public void LoadPrefab(Type type)
        {
			if(!bundle.Contains(name)){
				Debug.LogError(name + "don't exist in " + bundlePath);
				return;
			}
            _IsPrefabLoading = true;
			CoroutineManager.StartCoroutine(LoadPrefabImpl(type));
        }

        //加载资源的prefab
        private IEnumerator LoadPrefabImpl(Type type)
        {
            AssetBundleRequest request = bundle.LoadAsync(name, type);
            yield return request;
            _IsPrefabLoading = false;
            prefab = request.asset;
            cache = new ObjectPool<UnityEngine.Object>(prefab, maxCount);
            if (OnPrefabLoaded != null)
            {
                OnPrefabLoaded();
                OnPrefabLoaded = null;
            }
        }

        //获取资源所对应的对象(prefab的一个副本)
        public UnityEngine.Object GetItem(Type type)
        {
			if(type.Equals(typeof(GameObject))){
            	return cache.Pop();
			}
			return prefab;
        }

        //将资源放回缓存对象池,减少垃圾回收
        public void SaveItem(UnityEngine.Object item)
        {
            cache.Push(item);
        }
    }

    //对象池
    public class ObjectPool<T> where T : UnityEngine.Object
    {
        //对象prefab,生成新对象时会克隆prefab
        readonly UnityEngine.Object prefab;
        //由prefab克隆出来的闲置对象的列表
        readonly Stack<T> cache;
        readonly int maxCount;//小于0表示数量无限制, 等于0表示不缓存,大于0表示最多只缓存指定的数目,多余的会被垃圾回收掉

        public ObjectPool(UnityEngine.Object prefab, int maxCount)
        {
            this.prefab = prefab;
            this.cache = new Stack<T>();
            this.maxCount = maxCount;
        }

        //将闲置对象放回池中
        public void Push(T item)
        {
            if (maxCount < 0 || cache.Count < maxCount)
            {
                cache.Push(item);
            }
        }

        //从池中获取闲置对象
        public T Pop()
        {
            if (cache.Count > 0)
            {
                return cache.Pop();
            }
            return (T)GameObject.Instantiate(prefab);
        }
    }
}

static public class AssetBundleUtil
{
	static public string LoadText(this AssetBundle ab, string name)
	{
		TextAsset ta = (TextAsset)ab.Load (name, typeof(TextAsset));
		return Encoding.Default.GetString (ta.bytes);
	}
}