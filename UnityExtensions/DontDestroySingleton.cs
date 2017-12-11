using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace StonedFox
{
    public class DontDestroySingleton<T> : DontDestroySingleton where T : MonoBehaviour
    {
        public static T Instance;

        protected void Awake()
        {
            DontDestroySingleton<T>[] t = FindObjectsOfType<DontDestroySingleton<T>>();
            if (t != null && t.Length > 1)
            {
                Debug.LogError("Already created singleton type of " + typeof(T).ToString() + " destroying this new GameObject");
                Destroy(gameObject);
                return;
            }
            Instance = GetComponent<T>();
            DontDestroyOnLoad(this);
            AwakeNext();
            NewDontDestroy(this);
        }

        protected virtual void AwakeNext()
        {

        }
    }

    public abstract class DontDestroySingleton : MonoBehaviour
    {
        public static event Action<DontDestroySingleton> OnNewDontDestroy;

        // место где точно не задестроят
        protected Transform home;

        protected void NewDontDestroy(DontDestroySingleton dontDestroy)
        {
            if (OnNewDontDestroy != null)
            {
                OnNewDontDestroy(dontDestroy);
            }
        }

        public void SetHome(Transform t)
        {
            home = t;
        }

        public void GetBackHome()
        {
            if (home != null)
            {
                transform.parent = home;
            }
            else
            {
                transform.parent = null;
            }
        }
    }
}
