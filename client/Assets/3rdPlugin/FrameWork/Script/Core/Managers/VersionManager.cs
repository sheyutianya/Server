using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Hosting;
using Core.CSV;
using Core.Net.Http;
using UnityEngine;

namespace Core.Managers
{
    public class VersionManager
    {
        private const int MAX_ERROR_COUNT = 3;

        private static VersionManager _instance;

        public static VersionManager GetInstance()
        {
            if (null == _instance)
            {
                _instance = new VersionManager();
            }
            return _instance;
        }

        public static string REMOTE_VERSION_FILE_PATH;
        public static string VERSION_FILE_NAME;

        //本地文件信息
        Dictionary<object, VersionItem> fileInfoDict;
        //需要更新的文件数量
        int fileCountToUpdate = 0;
        int fileHasUpdate = 0;

        //总文件大小
        int totalFileSize = 0;
        //当前已下载文件大小
        int currentFileSize = 0;
        //更新完毕之后的回调函数
        public event Action OnComplete;
        public event Action<float> OnProgress;

        private VersionManager()
        {
        }

        public void Init(string remote, string version)
        {
            REMOTE_VERSION_FILE_PATH = remote;
            VERSION_FILE_NAME = version;

            //将streamingAssets目录复制到persistentDataPath
            WalkDir(Application.streamingAssetsPath, HandleFile);

            fileInfoDict = CSVParser<VersionItem>.Parse(File.ReadAllText(Path.Combine(Application.persistentDataPath, VERSION_FILE_NAME)));

            //加载服务器上的version.csv,然后对比更新
            HttpManager.GetText(Path.Combine(REMOTE_VERSION_FILE_PATH, VERSION_FILE_NAME), OnServerVersionFileLoaded);
        }

        private void OnServerVersionFileLoaded(string serverVersiontext)
        {
            Dictionary<object, VersionItem> serverFileInfoDict = CSVParser<VersionItem>.Parse(serverVersiontext);
            totalFileSize = 0;
            currentFileSize = 0;
            foreach (var item in serverFileInfoDict)
            {
                CheckVersionItem(item.Value, serverVersiontext);
            }
            if (fileCountToUpdate <= 0 && OnComplete != null)
            {
                OnComplete();
            }
        }

        private void CheckVersionItem(VersionItem item, string serverVersiontext)
        {
            var currentItem = GetVersionItemByPath(fileInfoDict, item.path);
            if (currentItem != null && item.md5.Equals(currentItem.md5))
            {
                return;
            }
            totalFileSize += item.size;
            ++fileCountToUpdate;

            int httpErrorCount = 0;
            var remoteFilePath = Path.Combine(REMOTE_VERSION_FILE_PATH, item.path);

            Action<byte[]> OnFileLoaded = null;
            OnFileLoaded = bytes =>
            {
                //文件尺寸不匹配,加载错误
                if (bytes.Length != item.size)
                {
                    ++httpErrorCount;
                    //重试次数超过上限
                    if (httpErrorCount >= MAX_ERROR_COUNT)
                    {
                        //跳过
                        CheckComplete(item, serverVersiontext);
                    }
                    else
                    {
                        //重新加载
                        HttpManager.GetBytes(remoteFilePath, OnFileLoaded);
                    }
                    return;
                }

                //将加载完成的文件写入本地储存
                var destPath = Path.Combine(Application.persistentDataPath, item.path);
                var destDir = Path.GetDirectoryName(destPath);
                if (!Directory.Exists(destDir))
                {
                    Directory.CreateDirectory(destDir);
                }
                File.WriteAllBytes(destPath, bytes);
                
                CheckComplete(item, serverVersiontext);
            };

            HttpManager.GetBytes(remoteFilePath, OnFileLoaded);
        }

        private void CheckComplete(VersionItem item, string serverVersiontext)
        {
            ++fileHasUpdate;
            currentFileSize += item.size;

            if (OnProgress != null)
            {
                OnProgress((float)currentFileSize / (float)totalFileSize);
            }
            if (fileHasUpdate >= fileCountToUpdate)
            {
                File.WriteAllText(Path.Combine(Application.persistentDataPath, VERSION_FILE_NAME), serverVersiontext);
                if (OnComplete != null)
                {
                    OnComplete();
                }
            }
        }

        private void HandleFile(string filePath)
        {
            var fileName = filePath.Substring(Application.streamingAssetsPath.Length + 1);
            //忽略.meta文件
            if (fileName.EndsWith(".meta"))
            {
                return;
            }
            var newFilePath = Path.Combine(Application.persistentDataPath, fileName);
            if (File.Exists(newFilePath))
            {
                return;
            }
            var newFileDir = Path.GetDirectoryName(newFilePath);
            if (!Directory.Exists(newFileDir))
            {
                Directory.CreateDirectory(newFileDir);
            }
            File.Copy(filePath, newFilePath);
        }

        static public void WalkDir(string dirPath, Action<string> action)
        {
            var fileList = Directory.GetFiles(dirPath);
            var dirList = Directory.GetDirectories(dirPath);

            foreach (var file in fileList)
            {
                action(file);
            }

            foreach (var dir in dirList)
            {
                WalkDir(dir, action);
            }
        }

        static private VersionItem GetVersionItemByPath(Dictionary<object, VersionItem> target, string path)
        {
            foreach (var item in target)
            {
                if (path.Equals(item.Value.path))
                {
                    return item.Value;
                }
            }
            return null;
        }
    }
}

public class VersionItem : BaseTemplate
{
    public int id;
    public string path;
    public string md5;
    public int size;
}