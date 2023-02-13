using System;
using UnityEngine;

namespace _MAINGAME.Scripts.AppScripts.Utilities.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SingletonAttribute : Attribute
    {
        public Type[] Types { get; }
        public SingletonAttribute()
        {
            Types = null;
        }

        public SingletonAttribute(params Type[] types)
        {
            this.Types = types;
        }
    }
}
