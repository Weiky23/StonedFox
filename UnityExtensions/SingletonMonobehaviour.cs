using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StonedFox
{
    public class SingletonMonobehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance;

        protected void Awake()
        {
            SingletonMonobehaviour<T>[] t = FindObjectsOfType<SingletonMonobehaviour<T>>();
            if (t != null && t.Length > 1)
            {
                Debug.LogError("Already created singleton type of " + typeof(T).ToString());
                Debug.LogError("Now Destroying this");
                Destroy(this);
                return;
            }
            Instance = GetComponent<T>();
            AwakeNext();
        }

        protected virtual void AwakeNext()
        {

        }
    }
}
