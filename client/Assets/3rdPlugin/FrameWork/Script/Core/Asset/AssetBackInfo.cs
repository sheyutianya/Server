using System;
using UnityEngine;

namespace Core.Asset
{
    /// <summary>
    /// 资源加载完后返回的信息
    /// </summary>
    public class AssetBackInfo
    {
        /// <summary>
        /// 资源名称
        /// </summary>
        public string assetName { get; set; }

        /// <summary>
        /// 资源实例化的对象
        /// </summary>
        public GameObject gameObject { get; set; }

        /// <summary>
        /// 回调函数
        /// </summary>
        public Action<AssetBackInfo> callBack { get; set; }

        public AssetBackInfo(string assetName, GameObject gameObject, Action<AssetBackInfo> callBack)
        {
            this.assetName = assetName;
            this.gameObject = gameObject;
            this.callBack = callBack;
        }

        public void Excute()
        {
            callBack(this);
        }
    }
}
