
///*
//Author: liyonghelpme
//Email: 233242872@qq.com
//*/

///*
//Author: liyonghelpme
//Email: 233242872@qq.com
//*/
////using UnityEngine;
//using System.Collections;

//namespace ChuMeng
//{
//    /// <summary>
//    /// 控制主镜头跟随玩家一起移动
//    /// </summary>
//    public class CameraController : KBEngine.MonoBehaviour
//    {
//        public GameObject player;
//        public float offsetX = -6;
//        public float offsetZ = 6;
//        public float maxinumDistance = 2;
//        public float playerVelocity = 10;
//        public float offsetY = 10;
//        public float XRot = 45;
//        public float YRot = 180;
//        public float RotSmooth = 5;
//        private float movementX;
//        private float movementZ;
//        float movementY = 0;
//        Quaternion targetRotation;
//        float scrollDegree = 0;
//        public float ScrollCoff = 1;
//        // Use this for initialization
//        public static CameraController cameraController;
//        void Awake() {
//            cameraController = this;
//            DontDestroyOnLoad (gameObject);
			
//            regEvt = new System.Collections.Generic.List<MyEvent.EventType> () {
//                MyEvent.EventType.PlayerEnterWorld,
//                MyEvent.EventType.PlayerLeaveWorld,
//            };
//            RegEvent ();
//        }

//        protected override void OnEvent (MyEvent evt)
//        {
//            if (evt.type == MyEvent.EventType.PlayerEnterWorld) {
//                player = evt.player;
//            } else if (evt.type == MyEvent.EventType.PlayerLeaveWorld) {
//                player = null;
//            }
//        }
	
//        // Update is called once per frame
//        void Update ()
//        {
//            if (player != null) {
//                scrollDegree += Input.GetAxis ("Mouse ScrollWheel") * ScrollCoff;

//                scrollDegree = Mathf.Max (0, Mathf.Min (45, scrollDegree));
//                Vector3 npos = new Vector3 (0, 0, 1);
//                npos = Quaternion.Euler (new Vector3 (scrollDegree, 0, 0)) * npos;
//                Vector3 newCameraPos = offsetZ * npos + (new Vector3 (0, offsetY, 0));

//                //Vector3 viewDir = (new Vector3 (0, -offsetY, 0))-npos;

//                //targetRotation = Quaternion.Euler (new Vector3(XRot, YRot, 0));
//                float xDir = 90 - (180 - (90 - scrollDegree)) / 2;
//                //var qua = Quaternion.LookRotation (viewDir);
//                targetRotation = Quaternion.Euler (new Vector3 (xDir, YRot, 0));


//                movementX = (player.transform.position.x + offsetX - this.transform.position.x) / maxinumDistance;
//                movementZ = (player.transform.position.z + newCameraPos.z - this.transform.position.z) / maxinumDistance;
//                movementY = (player.transform.position.y + newCameraPos.y - this.transform.position.y) / maxinumDistance;

//                transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, Time.deltaTime * RotSmooth);
//                this.transform.position += new Vector3 (movementX * playerVelocity * Time.deltaTime, movementY * playerVelocity * Time.deltaTime, movementZ * playerVelocity * Time.deltaTime);
//            }
//        }
//    }

//}
