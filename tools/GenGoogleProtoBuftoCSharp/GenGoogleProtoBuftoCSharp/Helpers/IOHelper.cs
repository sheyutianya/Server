using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace GenGoogleProtoBuftoAS3.Helpers
{
    public static class IOHelper
    {
        // Methods
        public static bool CreateFolder(string pPath)
        {
            try
            {
                if (!Directory.Exists(pPath))
                {
                    Directory.CreateDirectory(pPath);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static bool CreateTxT(string pPath)
        {
            try
            {
                if (File.Exists(pPath))
                {
                    File.Delete(pPath);
                }
                File.CreateText(pPath).Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static bool DeleteFolder(string pPath)
        {
            try
            {
                foreach (string str in Directory.GetFileSystemEntries(pPath))
                {
                    if (File.Exists(str))
                    {
                        FileInfo info = new FileInfo(str);
                        if (info.Attributes.ToString().IndexOf("Readonly") != 1)
                        {
                            info.Attributes = FileAttributes.Normal;
                        }
                        File.Delete(str);
                    }
                    else
                    {
                        DeleteFolder(str);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string GetConfiguration(string pKey)
        {
            XmlDocument document = new XmlDocument();
            document.Load(Application.ExecutablePath + ".config");
            XmlElement element = (XmlElement)document.SelectSingleNode("//appSettings").SelectSingleNode("//add[@key='" + pKey + "']");
            return element.GetAttribute("value");
        }

        public static void UpdateConfiguration(string pKey, string pValue)
        {
            XmlDocument document = new XmlDocument();
            document.Load(Application.ExecutablePath + ".config");
            XmlNode node = document.SelectSingleNode("//appSettings");
            XmlElement element = (XmlElement)node.SelectSingleNode("//add[@key='" + pKey + "']");
            if (element != null)
            {
                element.SetAttribute("value", pValue);
            }
            else
            {
                XmlElement newChild = document.CreateElement("add");
                newChild.SetAttribute("key", pKey);
                newChild.SetAttribute("value", pValue);
                node.AppendChild(newChild);
            }
            document.Save(Application.ExecutablePath + ".config");
        }
    }
}
