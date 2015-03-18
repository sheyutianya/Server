using UnityEditor;
using UnityEngine;
using System.Collections;

public class ExportAssetBundle
{
    [MenuItem("Export/AssetBundle/Win32")]
    static public void ExportResourceWin32()
    {
        ExportResourceImpl(BuildTarget.StandaloneWindows);
    }

    [MenuItem("Export/AssetBundle/Win64")]
    static public void ExportResourceWin64()
    {
        ExportResourceImpl(BuildTarget.StandaloneWindows64);
    }

    [MenuItem("Export/AssetBundle/Android")]
    static public void ExportResourceAndroid()
    {
        ExportResourceImpl(BuildTarget.Android);
    }

    [MenuItem("Export/AssetBundle/IPHONE")]
    static public void ExportResourceIPhone()
    {
        ExportResourceImpl(BuildTarget.iPhone);
    }

    static private void ExportResourceImpl(BuildTarget buildTarget)
    {
        string path = EditorUtility.SaveFilePanel("Save Resource", "", "New Resource", "unity3d");
        if (path.Length <= 0)
        {
            return;
        }
        Debug.Log(path);
        Object[] selection = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
        //BuildPipeline.BuildAssetBundle(null, selection, path, BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets, buildTarget);
        BuildPipeline.BuildAssetBundle(null, selection, path, BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.DeterministicAssetBundle, buildTarget);
        Selection.objects = selection;
    }
}
