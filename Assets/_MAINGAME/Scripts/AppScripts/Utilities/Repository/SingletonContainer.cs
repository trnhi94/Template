using System;
using System.Collections.Generic;
using _MAINGAME.Scripts.AppScripts.Utilities.Behaviours;
using UnityEngine;

namespace _MAINGAME.Scripts.AppScripts.Utilities.Repository
{
    public class SingletonContainer : Singleton<SingletonContainer>
    {
        private readonly Dictionary<Type, object> _singleton = new();
        private readonly Dictionary<Type, List<Action<object>>> _keepForReplace = new();

        public void RegistrySingleton(object content, params Type[] types)
        {
            foreach (var type in types)
            {
                if(_singleton.ContainsKey(type))
                {
                    _singleton.Remove(type);
                }
                _singleton.Add(type, content);

                if(!_keepForReplace.TryGetValue(type, out var callback))
                {
                    continue;
                }
                Debug.LogWarning($"{type} has been created and will be sent to the waiters");
                _keepForReplace.Remove(type);

                foreach (var c in callback)
                {
                    c?.Invoke(content);
                }

            }
        }

        public void GetSingleton(Type type, Action<object> replaceCallback)
        {
            if (_singleton.TryGetValue(type, out var res))
            {
                replaceCallback?.Invoke(res);
                return;
            }

            Debug.LogWarning($"{type} could not be injected. It will be replaced when having the intance");
            if(_keepForReplace.TryGetValue(type, out var cbList))
            {
                cbList.Add(replaceCallback);
            }
            else
            {
                _keepForReplace.Add(type, new List<Action<object>> 
                { 
                    replaceCallback 
                });
            }
        }
    }
}
