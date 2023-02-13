using System;

namespace _MAINGAME.Scripts.AppScripts.Utilities.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class InjectAttribute : Attribute
    {
        public string Hook { get; }

        public InjectAttribute() { }

        public InjectAttribute(string hook) 
        {
            this .Hook = hook;
        }
    }
}
