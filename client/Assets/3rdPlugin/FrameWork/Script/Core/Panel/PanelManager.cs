using Core.Asset;
using UnityEngine;

namespace Core.Panel
{
    public class PanelManager
    {
        /// ������壬������Դ������
        public void CreatePanel<T>(string name) where T : Component
        {
            AssetModelFactory.GetInstance().GetAsset(name, go =>
            {
                go.gameObject.name = name + "Panel";
                go.gameObject.layer = LayerMask.NameToLayer("Default");
                go.gameObject.transform.localScale = Vector3.one;
                go.gameObject.transform.localPosition = Vector3.zero;

                go.gameObject.AddComponent<T>();

                Debug.Log("StartCreatePanel------>>>>" + name);
            });
        }
    }
}