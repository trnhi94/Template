using UnityEngine;

namespace _MAINGAME.Scripts.AppScripts.Utilities.Behaviours
{
    public class Singleton<T> : MonoBehaviour where T: MonoBehaviour
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
            instance = this as T;

            if(instance == null)
            {
                Destroy(gameObject);
            }
        }
    }
}