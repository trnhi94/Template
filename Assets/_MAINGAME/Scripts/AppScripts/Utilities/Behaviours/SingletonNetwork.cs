using UnityEngine;
using Fusion;
using _MAINGAME.Scripts.AppScripts.Utilities.Repository;

namespace _MAINGAME.Scripts.AppScripts.Utilities.Behaviours
{
    public class SingletonNetwork<T> : NetworkApplicationBehaviour where T: NetworkApplicationBehaviour
    {
        private static T instance;
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = (T)FindObjectOfType(typeof(T));
                }
                return instance;
            }
        }

        protected virtual void Awake()
        {
            InjectComponent();
            instance = this as T;
            if (instance == null)
            {
                Destroy(gameObject);
            }
        }
    }
}