
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

//public class AnimateTexture : MonoBehaviour {
//    public string TextureName = "sharedtextures/watertown/water_{0}";
//    public int TextureNum = 80;
//    public float Duration = 5;

//    float passTime = 0;
//    float delta;
//    void Awake() {
//        var tname = string.Format(TextureName, 0);
//        renderer.material.SetTexture ("_AnimTex", Resources.Load<Texture>(tname));
//        delta = Duration / TextureNum;
//    }
//    // Use this for initialization
//    void Start () {
	
//    }
	
//    // Update is called once per frame
//    void Update () {
//        passTime += Time.deltaTime;
//        int fn = Mathf.FloorToInt(passTime / delta);
//        fn = fn % TextureNum;
//        var tname = string.Format (TextureName, fn);
//        renderer.material.SetTexture ("_AnimTex", Resources.Load<Texture> (tname));
//    }
//}
