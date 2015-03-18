using UnityEngine;
using System.Collections;

namespace Core.Managers
{
    //Coroutine管理器，提供全局的StartCoroutine方法
    //如果使用此类的方法,需要自己在必要时调用StopCoroutine,否则可能引起内存泄露
    //一版情况下可使用自己MonoBehavior的StartCoroutine方法
    public class CoroutineManager
    {
        static public void Init(MonoBehaviour component)
        {
            gameEntry = component;
        }

        static private MonoBehaviour gameEntry;

        static public Coroutine StartCoroutine(IEnumerator routine)
        {
            return gameEntry.StartCoroutine(routine);
        }

        static public void StopCoroutine(IEnumerator routine)
        {
            gameEntry.StopCoroutine(routine);
        }
    }
}