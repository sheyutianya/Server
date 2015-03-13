
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

//using System;
//using KBEngine;

//namespace ChuMeng
//{
//    public class PlayerSync : KBEngine.MonoBehaviour
//    {
//        /*
//         * Write Message Send To Server
//         * PlayerManagerment  PhotonView Manager 
//         */ 
//        public void OnPhotonSerializeView (Packet packet)
//        {
//            if (photonView.IsMine) {
//                CGPlayerMove.Builder mv = CGPlayerMove.CreateBuilder ();
//                var vxz = Util.CoordToGrid(transform.position.x, transform.position.z);
//                //MapY Offset Height
//                mv.X = Convert.ToInt32( vxz.x);
//                mv.Y = Util.IntYOffset(transform.position.y);
//                mv.Z = Convert.ToInt32(vxz.y);

//                packet.protoBody = mv.BuildPartial ();

//            } else {
//                Debug.Log("Not Mine Push Move Command");
//                var ms = packet.protoBody as MotionSprite;
//                var vxz = Util.GridToCoord(ms.X, ms.Z);

//                var mvTarget = new Vector3(vxz.x, 0, vxz.y);

//                var cmd = new ObjectCommand();
//                cmd.targetPos = mvTarget;
//                cmd.commandID = ObjectCommand.ENUM_OBJECT_COMMAND.OC_MOVE;
//                GetComponent<LogicCommand>().PushCommand(cmd);

//            }

//        }

//        public void SetPosition(ViewPlayer ms) {
//            Debug.Log ("PlayerSync::SetPosition init other player "+ms);
//            Vector2 vxz = Util.GridToCoord (ms.X, ms.Z);
//            //float y = Util.FloatYOffset (ms.Y);
//            float y = ObjectManager.objectManager.GetSceneHeight (ms.X, ms.Z);
//            transform.position = new Vector3(vxz.x, y, vxz.y);
//            transform.rotation = Quaternion.Euler (new Vector3(0, ms.Dir, 0));
//        }
	
//    }

//}