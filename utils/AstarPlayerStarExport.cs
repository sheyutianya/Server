////using UnityEngine;
//using System.Collections;
//using System.IO;


//#if UNITY_EDITOR
//using UnityEditor;
//#endif
//using System;

//using SimpleJSON;

//namespace ChuMeng
//{
//    public class AstarPlayerStarExport : MonoBehaviour
//    {
//        public int mapId = 100;

//        [ButtonCallFunc()]
//        public bool export;

//        public Vector3 StartPos;

//        public void exportMethod ()
//        {
//#if UNITY_EDITOR
//            var astar = GetComponent<AstarPath> ();
//            string path = EditorUtility.SaveFilePanel("Save Graphs", "", "graph"+Convert.ToString(mapId)+".zip", "zip");
//            if(path != "") {
//                if (EditorUtility.DisplayDialog ("Scan before saving?","Do you want to scan the graphs before saving" +
//                                                 "\nNot scanning can cause node data to be omitted from the file if Save Node Data is enabled","Scan","Don't scan")) {
//                    AstarPath.MenuScan ();
//                }


//                uint checksum;
//                Pathfinding.Serialization.SerializeSettings settings = Pathfinding.Serialization.SerializeSettings.All;


//                byte[] bytes = null;
//                uint ch = 0;
//                AstarPath.active.AddWorkItem (new AstarPath.AstarWorkItem (delegate (bool force) {
//                    Pathfinding.Serialization.AstarSerializer sr = new Pathfinding.Serialization.AstarSerializer(astar.astarData, settings);
//                    sr.OpenSerialize();
//                    astar.astarData.SerializeGraphsPart (sr);
//                    //sr.SerializeEditorSettings (graphEditors);
//                    var start = GameObject.Find("PlayerStart").transform.position;
//                    var grid = Util.CoordToGrid(start.x, start.z);
//                    var yOff = Util.IntYOffset(start.y);

//                    SimpleJSON.JSONClass jc = new SimpleJSON.JSONClass();
//                    var arr = jc["playerStart"] = new SimpleJSON.JSONArray();

//                    arr[-1].AsInt = (int)(grid.x);
//                    arr[-1].AsInt = yOff;
//                    arr[-1].AsInt = (int)(grid.y);

//                    /*
//                    System.IO.MemoryStream stream = new System.IO.MemoryStream();
//                    BinaryWriter outfile = new BinaryWriter(stream);
//                    jc.Serialize(outfile);
//                    */
//                    Debug.Log("Export "+jc.ToString());

//                    sr.zip.AddEntry("playerStart"+Convert.ToString(mapId)+".json", System.Text.Encoding.UTF8.GetBytes(jc.ToString()));
//                    bytes = sr.CloseSerialize();
//                    ch = sr.GetChecksum ();
//                    return true;
//                }));

//                Pathfinding.Serialization.AstarSerializer.SaveToFile (path,bytes);
//                EditorUtility.DisplayDialog ("Done Saving","Done saving graph data.","Ok");

//            }
//#endif
//        }

//        [ButtonCallFunc()]
//        public bool pos;
//        public void posMethod() {
//            var start = GameObject.Find("PlayerStart").transform.position;
//            var grid = Util.CoordToGrid(start.x, start.z);
//            var yOff = Util.IntYOffset(start.y);
			
//            StartPos.x = (int)(grid.x);
//            StartPos.y = yOff;
//            StartPos.z = (int)(grid.y);
//        }

//        // Use this for initialization
//        void Start ()
//        {
	
//        }
	
//        // Update is called once per frame
//        void Update ()
//        {
	
//        }
//    }

//}