using System;
using UnityEngine;

namespace Core.Asset
{
    /// <summary>
    /// 资源预加载完后返回的信息
    /// </summary>
    public class AssetPrefabBackInfo
    {
        /// <summary>
        /// 资源名称
        /// </summary>
        public string assetName { get; set; }

        /// <summary>
        /// 资源实例化的对象
        /// </summary>
        public UnityEngine.Object prefabObject { get; set; }


        public AssetPrefabBackInfo(string assetName, UnityEngine.Object prefabObject)
        {
            this.assetName = assetName;
            this.prefabObject = prefabObject;
        }
    }
}
